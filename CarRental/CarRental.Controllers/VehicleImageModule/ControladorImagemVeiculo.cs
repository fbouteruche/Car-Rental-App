using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleImageModule;

namespace CarRental.Controllers.ImagemVeiculoModule
{
    public class ControladorImagemVeiculo : Controller<VehicleImage>
    {

        private Bitmap bmp;
        #region Queries
        private const string comandoInserir = @"INSERT INTO [DBO].[TBIMAGEMVEICULO] 
                                                (
                                                 [ID_VEICULO],
                                                 [IMAGEM]
                                                )VALUES
                                                (
                                                @ID_VEICULO,
                                                @IMAGEM
                                                );";
        private const string comandoExcluir = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string comandoExcluirTodosPorIdDoVeiculo = "DELETE FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string comandoSelecionarTodosDoVeiculo = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO;";
        private const string comandoSelecionarPorId = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID] = @ID";
        private const string comandoSelecionarPorIdDoVeiculo = "SELECT * FROM [DBO].[TBIMAGEMVEICULO] WHERE [ID_VEICULO] = @ID_VEICULO";
        private const string comandoSelecioarTodos = "SELECT * FROM DBO].[TBIMAGEMVEICULO]";
        #endregion
        public override string Edit(int id, VehicleImage registro)
        {
            registro.Id = Db.Insert(comandoInserir,ObtemParametrosImagem(registro));
            return "";
        }

        public void EditarLista(List<VehicleImage> registros)
        {
            if (registros != null)
            {
                if (registros.Count != 0)
                    ExcluirPorIdDoVeiculo(registros[0].VehicleId);
                foreach (VehicleImage imagem in registros)
                {
                    InsertNew(imagem);
                }
            }
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(comandoExcluir, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public bool ExcluirPorIdDoVeiculo(int idVeiculo)
        {
            try
            {
                Db.Delete(comandoExcluirTodosPorIdDoVeiculo, AddParameter("ID_Veiculo", idVeiculo));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public override string InsertNew(VehicleImage registro)
        {
            string resultadoValidacao = "VALIDO";

            registro.Id = Db.Insert(comandoInserir, ObtemParametrosImagem(registro));

            return resultadoValidacao;
        }

        public override VehicleImage SelectById(int id)
        {
            return Db.Get(comandoSelecionarPorId,ConverteEmImagemVeiculo,AddParameter("ID",id));
        }
        public List<VehicleImage> SelecionarPorIdDoVeiculo(int id)
        {
            return Db.GetAll(comandoSelecionarPorIdDoVeiculo, ConverteEmImagemVeiculo, AddParameter("ID_VEICULO", id));
        }

        public override List<VehicleImage> SelectAll()
        {
            return Db.GetAll(comandoSelecioarTodos,ConverteEmImagemVeiculo);
        }

        public List<VehicleImage> SelecioanrTodasImagensDeUmVeiculo(int id)
        {
            return Db.GetAll(comandoSelecionarTodosDoVeiculo, ConverteEmImagemVeiculo,AddParameter("ID_VEICULO",id));
        }

        private Dictionary<string, object> ObtemParametrosImagem(VehicleImage imagemVeiculo)
        {
            bmp = imagemVeiculo.Image;
            MemoryStream memoria = new MemoryStream();
            bmp.Save(memoria,ImageFormat.Bmp);
            byte[] imagemByte = memoria.ToArray();

            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", imagemVeiculo.Id);
            parametros.Add("ID_VEICULO", imagemVeiculo.VehicleId);
            parametros.Add("IMAGEM", imagemByte);

            return parametros;
        }

        private Bitmap ConverteEmImagem(IDataReader reader)
        {

            byte[] a = (byte[])(reader["IMAGEM"]);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            bmp = (Bitmap)tc.ConvertFrom(a);

            return bmp;
        }

        private VehicleImage ConverteEmImagemVeiculo(IDataReader reader)
        {
            byte[] byteArray= (byte[])(reader["IMAGEM"]);
            var id = Convert.ToInt32(reader["ID"]);
            var idVeiculo = Convert.ToInt32(reader["ID_VEICULO"]);

            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            bmp = (Bitmap)tc.ConvertFrom(byteArray);
            Bitmap imagem = new Bitmap(bmp);

            return new VehicleImage(id,idVeiculo, imagem);

        }
    }
}

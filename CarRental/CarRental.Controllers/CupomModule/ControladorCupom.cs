using CarRental.Controllers.Shared;
using CarRental.Domain.CouponModule;
using CarRental.Domain.PartnerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.CupomModule
{
    public class ControladorCupom : Controller<Coupon>
    {
        #region queries
        private const string sqlInserirCupom =
           @"INSERT INTO [TBCUPOM_DESCONTO]
                (
                    [NOMECUPOM],
                    [CODIGO],      
                    [VALORMINIMO],
                    [VALOR], 
                    [EHDESCONTOFIXO],
                    [VALIDADE],                    
                    [ID_PARCEIRO] 
                )
            VALUES
                (
                    @NOMECUPOM,
                    @CODIGO,
                    @VALORMINIMO,
                    @VALOR,
                    @EHDESCONTOFIXO,
                    @VALIDADE,
                    @ID_PARCEIRO
                )";

        private const string sqlEditarCupom =
            @" UPDATE [TBCUPOM_DESCONTO]
                SET 
                    [NOMECUPOM] = @NOMECUPOM, 
                    [CODIGO] = @CODIGO, 
                    [VALORMINIMO] = @VALORMINIMO,
                    [VALOR] = @VALOR, 
                    [EHDESCONTOFIXO] = @EHDESCONTOFIXO,
                    [VALIDADE] = @VALIDADE,
                    [ID_PARCEIRO] = @ID_PARCEIRO
                WHERE [ID] = @ID";

        private const string sqlDeletarCupom =
            @"DELETE FROM [TBCUPOM_DESCONTO] 
                WHERE [ID] = @ID";

        private const string sqlSelecionarTodosCupons =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID";
        private const string sqlSelecionarCupomPorId =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[ID] = @ID";

        private const string sqlSelecionarCupomPorCodigo =
            @"SELECT 
                    D.[ID],       
                    D.[NOMECUPOM],       
                    D.[CODIGO], 
                    D.[VALORMINIMO],
                    D.[VALOR],                    
                    D.[EHDESCONTOFIXO],                                                           
                    D.[VALIDADE],
                    D.[ID_PARCEIRO],
                    P.[ID],
                    P.[NOMEPARCEIRO]
            FROM
                [TBCUPOM_DESCONTO] AS D INNER JOIN
                [TBPARCEIRO] AS P
            ON
                D.ID_PARCEIRO = P.ID
            WHERE 
                D.[CODIGO] = @CODIGO";

        private const string sqlExisteCupom =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCUPOM_DESCONTO]
            WHERE 
                [ID] = @ID";

        private const string sqlExisteCodigo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCUPOM_DESCONTO]
            WHERE 
                [CODIGO] = @CODIGO";
        #endregion
        public override string InsertNew(Coupon registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(sqlInserirCupom, ObtemParametrosCupom(registro));

            return resultadoValidacao;
        }

        public override List<Coupon> SelectAll()
        {
            return Db.GetAll(sqlSelecionarTodosCupons, ConverterEmCupom);
        }

        public override Coupon SelectById(int id)
        {
            return Db.Get(sqlSelecionarCupomPorId, ConverterEmCupom, AddParameter("ID", id));
        }

        public Coupon SelecionarPorCodigo(string codigo)
        {
            return Db.Get(sqlSelecionarCupomPorCodigo, ConverterEmCupom, AddParameter("CODIGO", codigo));
        }

        public override string Edit(int id, Coupon registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarCupom, ObtemParametrosCupom(registro));
            }

            return resultadoValidacao;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeletarCupom, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlExisteCupom, AddParameter("ID", id));
        }

        public bool ExisteCodigo(string codigo)
        {
            return Db.Exists(sqlExisteCodigo, AddParameter("CODIGO", codigo));
        }

        private Dictionary<string, object> ObtemParametrosCupom(Coupon registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOMECUPOM", registro.Name);
            parametros.Add("CODIGO", registro.Code);
            parametros.Add("VALORMINIMO", registro.MinimumValue);
            parametros.Add("VALOR", registro.Value);
            parametros.Add("EHDESCONTOFIXO", registro.IsFixedDiscount);
            parametros.Add("VALIDADE", registro.ExpirationDate);
            parametros.Add("ID_PARCEIRO", registro.Partner.Id);

            return parametros;
        }

        private Coupon ConverterEmCupom(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOMECUPOM"]);
            string codigo = Convert.ToString(reader["CODIGO"]);
            double valorMinimo = Convert.ToDouble(reader["VALORMINIMO"]);
            double valor = Convert.ToDouble(reader["VALOR"]);            
            bool ehDescontoFixo = Convert.ToBoolean(reader["EHDESCONTOFIXO"]);
            DateTime validade = Convert.ToDateTime(reader["VALIDADE"]);

            int idParceiro = Convert.ToInt32(reader["ID_PARCEIRO"]);
            string nomeParceiro = Convert.ToString(reader["NOMEPARCEIRO"]);
            Partner parceiro = new Partner(idParceiro, nomeParceiro);


            Coupon cupom = new Coupon(id, nome, codigo, valor, valorMinimo, ehDescontoFixo, validade, parceiro);

            cupom.Id = id;

            return cupom;
        }
    }
}

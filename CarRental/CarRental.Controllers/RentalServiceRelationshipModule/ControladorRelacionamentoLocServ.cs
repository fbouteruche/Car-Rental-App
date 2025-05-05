using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.FuncionarioModule;
using CarRental.Controllers.RentalModule;
using CarRental.Controllers.ServicoModule;
using CarRental.Controllers.Shared;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.RelacionamentoLocServModule
{
    public class ControladorRelacionamentoLocServ : Controller<RentalServiceRelationship>
    {
        private int id = 0;
        ControladorServico controladorServico = new ControladorServico();
        RentalController controladorLocacao = new RentalController(new VehicleController(), new ControladorFuncionario(), new CustomerController(), new ControladorServico(), new CouponController());
        #region queries Relacionamento
        private const string sqlInserirRelacao =
                @"INSERT INTO[DBO].[TBSERVICO_LOCACAO]
                (
                    [ID_LOCACAO],
                    [ID_SERVICO]
                )
                VALUES
                (
                    @ID_LOCACAO,
                    @ID_SERVICO
                );";

        private const string sqlEditarRelacao =
        @"UPDATE [DBO].[TBSERVICO_LOCACAO] 
                SET
                    [ID_LOCACAO] = @ID_LOCACAO,
                    [ID_SERVICO] = @ID_SERVICO
                WHERE 
                    [ID] = @ID;";

        private const string sqlSelecionarTodasRelacoes =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO];";

        private const string sqlSelecionarRelacaoPorId =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID] = @ID;";

        private const string sqlSelecionarRelacaoPorLocacao =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID_LOCACAO] = @ID_LOCACAO;";

        private const string sqlDeletarRelacao =
            @"DELETE FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID] = @ID;";

        #endregion
        public override string Edit(int id, RentalServiceRelationship registro)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeletarRelacao, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlSelecionarRelacaoPorId, AddParameter("ID", id));
        }

        public override string InsertNew(RentalServiceRelationship registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
                foreach (Service servico in registro.Services)
                {
                    id = servico.Id;
                    registro.Id = Db.Insert(sqlInserirRelacao, ObtemParametrosRelacao(registro));
                }

            return resultadoValidacao;
        }

        public override RentalServiceRelationship SelectById(int id)
        {
            return Db.Get(sqlSelecionarRelacaoPorId, ConverterEmRelacionamento, AddParameter("ID", id));
        }

        public object SelecionarPorLocacao(int id)
        {
            return Db.GetAll(sqlSelecionarRelacaoPorLocacao, ConverterEmRelacionamento, AddParameter("ID_LOCACAO", id));
        }

        public override List<RentalServiceRelationship> SelectAll()
        {
            return Db.GetAll(sqlSelecionarTodasRelacoes, ConverterEmRelacionamento);
        }
        private RentalServiceRelationship ConverterEmRelacionamento(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var id_locacao = Convert.ToInt32(reader["ID_LOCACAO"]);
            var id_servico = Convert.ToInt32(reader["ID_SERVICO"]);

            List<Service> filtrado = new List<Service>();
            foreach (Service item in controladorServico.SelectAll())
                if (item.Id == id_servico)
                    filtrado.Add(item);
            Rental locacao = controladorLocacao.SelectById(id_locacao);

            return new RentalServiceRelationship(id, locacao, filtrado);
        }
        private Dictionary<string, object> ObtemParametrosRelacao(RentalServiceRelationship relacionamento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("ID", relacionamento.Id);
            parametros.Add("ID_LOCACAO", relacionamento.Rental.Id);
            parametros.Add("ID_SERVICO", id);

            return parametros;
        }
    }
}

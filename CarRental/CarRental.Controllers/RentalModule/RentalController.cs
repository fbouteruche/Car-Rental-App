using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.FuncionarioModule;
using CarRental.Controllers.ServicoModule;
using CarRental.Controllers.Shared;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.CouponModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.VehicleModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.RentalModule
{
    public class RentalController : Controller<Rental>
    {
        private VehiculeController controladorVeiculo = null;
        private ControladorFuncionario controladorFuncionario = null;
        private CustomerController controladorCliente = null;
        private ControladorServico controladorServico = null;
        private CouponController controladorCupom = new CouponController();

        public RentalController(VehiculeController controladorVeiculo, ControladorFuncionario controladorFuncionario, CustomerController controladorCliente, ControladorServico controladorServico, CouponController controladorCupom)
        {
            this.controladorVeiculo = controladorVeiculo;
            this.controladorFuncionario = controladorFuncionario;
            this.controladorCliente = controladorCliente;
            this.controladorServico = controladorServico;
            //this.controladorCupom = controladorCupom;
        }

        #region queries
        private const string sqlInserirLocacao =
                @"INSERT INTO[DBO].[TBLOCACAO]
                (
                    [ID_VEICULO],
                    [ID_FUNCIONARIO],
                    [ID_CLIENTECONTRATANTE],
                    [ID_CLIENTECONDUTOR],
                    [ID_CUPOM],
                    [DATADESAIDA],
                    [DATAPREVISTADECHEGADA],
                    [DATADECHEGADA],
                    [TIPODOPLANO],
                    [TIPODESEGURO],
                    [PRECOLOCACAO],
                    [PRECODEVOLUCAO],
                    [ESTAABERTA]
                )
                VALUES
                (
                    @ID_VEICULO,
                    @ID_FUNCIONARIO,
                    @ID_CLIENTECONTRATANTE,
                    @ID_CLIENTECONDUTOR,
                    @ID_CUPOM,
                    @DATADESAIDA,
                    @DATAPREVISTADECHEGADA,
                    @DATADECHEGADA,
                    @TIPODOPLANO,
                    @TIPODESEGURO,
                    @PRECOLOCACAO,
                    @PRECODEVOLUCAO,
                    @ESTAABERTA
                );";

        private const string sqlEditarLocacao =
        @"UPDATE [DBO].[TBLOCACAO] 
                SET
                    [ID_VEICULO] = @ID_VEICULO,
                    [ID_FUNCIONARIO] = @ID_FUNCIONARIO,
                    [ID_CLIENTECONTRATANTE] = @ID_CLIENTECONTRATANTE,
                    [ID_CLIENTECONDUTOR] = @ID_CLIENTECONDUTOR,
                    [ID_CUPOM] = @ID_CUPOM,
                    [DATADESAIDA] = @DATADESAIDA,
                    [DATAPREVISTADECHEGADA] = @DATAPREVISTADECHEGADA,
                    [DATADECHEGADA] = @DATADECHEGADA,
                    [TIPODOPLANO] = @TIPODOPLANO,
                    [TIPODESEGURO] = @TIPODESEGURO,
                    [PRECOLOCACAO] = @PRECOLOCACAO,
                    [PRECODEVOLUCAO] = @PRECODEVOLUCAO,
                    [ESTAABERTA] = @ESTAABERTA
                WHERE 
                    [ID] = @ID;";

        private const string sqlSelecionarTodosLocacaos =
            @"SELECT * FROM [DBO].[TBLOCACAO];";

        private const string sqlSelecionarLocacaoPorId =
            @"SELECT * FROM [DBO].[TBLOCACAO] WHERE [ID] = @ID;";


        private const string sqlDeletarLocacao =
                @"DELETE FROM [DBO].[TBLOCACAO] WHERE [ID] = @ID;";

        string sqlSelecionarIdServicoPorIdLocacao =
            @"SELECT [ID_SERVICO] FROM [TBSERVICO_LOCACAO]
               WHERE [ID_LOCACAO] = @ID_LOCACAO";


        #endregion
        public override string InsertNew(Rental registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(sqlInserirLocacao, ObtemParametrosLocacao(registro));

            return resultadoValidacao;
        }
        public override List<Rental> SelectAll()
        {
            return Db.GetAll(sqlSelecionarTodosLocacaos, ConverterEmLocacao);
        }
        public override Rental SelectById(int id)
        {
            return Db.Get(sqlSelecionarLocacaoPorId, ConverterEmLocacao, AddParameter("ID", id));
        }

        private List<Service> SelecionarServicosComIdLocacao(int idLocacao)
        {
            List<Service> servicosDaLocacao = new List<Service>();
            List<int> idsDeServicos = Db.GetAll(sqlSelecionarIdServicoPorIdLocacao, ConverterEmInteiro, AddParameter("ID_LOCACAO", idLocacao));
            foreach (int idServico in idsDeServicos)
            {
                servicosDaLocacao.Add(controladorServico.SelectById(idServico));
            }
            return servicosDaLocacao;
        }

        public override string Edit(int id, Rental registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarLocacao, ObtemParametrosLocacao(registro));
            }

            return resultadoValidacao;
        }
        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeletarLocacao, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlSelecionarLocacaoPorId, AddParameter("ID", id));
        }

        private Dictionary<string, object> ObtemParametrosLocacao(Rental locacao)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", locacao.Id);
            parametros.Add("ID_VEICULO",locacao.Vehicle.Id);
            parametros.Add("ID_FUNCIONARIO", locacao.RentingEmployee.Id);
            parametros.Add("ID_CLIENTECONTRATANTE", locacao.ContractingCustomer.Id);
            parametros.Add("ID_CLIENTECONDUTOR", locacao.DriverCustomer.Id);
            if(locacao.Coupon != null)
                parametros.Add("ID_CUPOM", locacao.Coupon.Id);
            else
                parametros.Add("ID_CUPOM", null);
            parametros.Add("DATADESAIDA", locacao.DepartureDate);
            parametros.Add("DATAPREVISTADECHEGADA", locacao.ExpectedReturnDate);
            parametros.Add("DATADECHEGADA", locacao.ReturnDate);
            parametros.Add("TIPODOPLANO", locacao.PlanType);
            parametros.Add("TIPODESEGURO", locacao.InsuranceType);
            parametros.Add("PRECOLOCACAO", locacao.RentalPrice);
            parametros.Add("PRECODEVOLUCAO", locacao.ReturnPrice);
            parametros.Add("ESTAABERTA", locacao.IsOpen);
            return parametros;
        }

        private int ConverterEmInteiro(IDataReader reader)
        {
            return Convert.ToInt32(reader["ID_SERVICO"]);
        }

        private Rental ConverterEmLocacao(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var id_veiculo = Convert.ToInt32(reader["ID_VEICULO"]);
            var id_funcionario = Convert.ToInt32(reader["ID_FUNCIONARIO"]);
            var id_clienteContratante = Convert.ToInt32(reader["ID_CLIENTECONTRATANTE"]);
            var id_clienteCondutor = Convert.ToInt32(reader["ID_CLIENTECONDUTOR"]);
            var id_cupom = 0;
            if (reader["ID_CUPOM"] != DBNull.Value)
                id_cupom = Convert.ToInt32(reader["ID_CUPOM"]);
            //pode haver problemas com retorno null. caso ocorrer, fazer algo como:
            //if (!int.TryParse(reader["ID_CLIENTECONDUTOR"].ToString(), out int id_clienteCondutor))
            //    id_clienteCondutor = -1;
            var dataDeSaida = Convert.ToDateTime(reader["DATADESAIDA"]);
            var dataPrevistaDeChegada = Convert.ToDateTime(reader["DATAPREVISTADECHEGADA"]);
            var dataDeChegada = Convert.ToDateTime(reader["DATADECHEGADA"]);
            var tipoDoPlano = Convert.ToString(reader["TIPODOPLANO"]);
            var tipoDeSeguro = Convert.ToString(reader["TIPODESEGURO"]);
            var precoLocacao = Convert.ToDouble(reader["PRECOLOCACAO"]);
            var precoDevolucao = Convert.ToDouble(reader["PRECODEVOLUCAO"]);
            var estaAberta = Convert.ToBoolean(reader["ESTAABERTA"]);

            List <Service>  servicosDaLocacao = SelecionarServicosComIdLocacao(id);
            //foreach (Service servico in controladorServico.SelectAll())
            //{
            //    List<int> idsDeServicos = SelecionarServicosComIdLocacao(id);
            //    if (idsDeServicos.Contains(servico.Id))
            //        servicosDaLocacao.Add(servico);
            //}

            Vehicle veiculo = controladorVeiculo.SelectById(id_veiculo);
            Employee funcionarioLocador = controladorFuncionario.SelectById(id_funcionario);
            Customer clienteContratante = controladorCliente.SelectById(id_clienteContratante);
            Customer clienteCondutor = controladorCliente.SelectById(id_clienteCondutor);
            Coupon cupom;
            if (id_cupom != 0)
                cupom = controladorCupom.SelectById(id_cupom);
            else
                cupom = null;

            return new Rental(id, veiculo, funcionarioLocador, clienteContratante, clienteCondutor, cupom, dataDeSaida, dataPrevistaDeChegada, dataDeChegada, tipoDoPlano, tipoDeSeguro, precoLocacao, precoDevolucao, estaAberta, servicosDaLocacao);
        }
    }
}

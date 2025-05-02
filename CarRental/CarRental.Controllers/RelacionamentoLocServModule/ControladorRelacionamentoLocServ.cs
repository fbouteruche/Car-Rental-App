using CarRental.Controladores.ClientesModule;
using CarRental.Controladores.CupomModule;
using CarRental.Controladores.FuncionarioModule;
using CarRental.Controladores.LocacaoModule;
using CarRental.Controladores.ServicoModule;
using CarRental.Controladores.Shared;
using CarRental.Controladores.VeiculoModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controladores.RelacionamentoLocServModule
{
    public class ControladorRelacionamentoLocServ : Controlador<RentalServiceRelationship>
    {
        private int id = 0;
        ControladorServico controladorServico = new ControladorServico();
        ControladorLocacao controladorLocacao = new ControladorLocacao(new ControladorVeiculo(), new ControladorFuncionario(), new ControladorCliente(), new ControladorServico(), new ControladorCupom());
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
        public override string Editar(int id, RentalServiceRelationship registro)
        {
            throw new NotImplementedException();
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlDeletarRelacao, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlSelecionarRelacaoPorId, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(RentalServiceRelationship registro)
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

        public override RentalServiceRelationship SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarRelacaoPorId, ConverterEmRelacionamento, AdicionarParametro("ID", id));
        }

        public object SelecionarPorLocacao(int id)
        {
            return Db.GetAll(sqlSelecionarRelacaoPorLocacao, ConverterEmRelacionamento, AdicionarParametro("ID_LOCACAO", id));
        }

        public override List<RentalServiceRelationship> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodasRelacoes, ConverterEmRelacionamento);
        }
        private RentalServiceRelationship ConverterEmRelacionamento(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var id_locacao = Convert.ToInt32(reader["ID_LOCACAO"]);
            var id_servico = Convert.ToInt32(reader["ID_SERVICO"]);

            List<Service> filtrado = new List<Service>();
            foreach (Service item in controladorServico.SelecionarTodos())
                if (item.Id == id_servico)
                    filtrado.Add(item);
            Rental locacao = controladorLocacao.SelecionarPorId(id_locacao);

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

using CarRental.Controllers.Shared;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRental.Controllers.ServicoModule
{
    public class ControladorServico : Controller<Service>
    {
        #region queries
        private const string sqlInserirServico =
            @"INSERT INTO TBSERVICO
            (
                [NOME],
                [EHTAXADODIARIO],
                [VALOR]
            )
            VALUES
            (
                @NOME,
                @EHTAXADODIARIO,
                @VALOR
            )";
        private const string sqlSelecionarTodosServicos =
            @"SELECT 
                [ID],
                [NOME],
                [EHTAXADODIARIO],
                [VALOR]
            FROM 
                TBSERVICO ORDER BY ID;";

        private const string sqlSelecionarServicoPorId =
            @"SELECT  
                [ID],
                [NOME],
                [EHTAXADODIARIO],
                [VALOR]
            FROM
                TBSERVICO 
            WHERE 
                [ID] = @ID";

        private const string sqlEditarServico =
            @"UPDATE TBSERVICO SET
                [NOME] = @NOME,
                [EHTAXADODIARIO] = @EHTAXADODIARIO,
                [VALOR] = @VALOR
            WHERE
                [ID] = @ID
            ";
        private const string sqlDeletarServico =
            @"DELETE 
                FROM 
                TBSERVICO 
            WHERE 
                [ID] = @ID";

        private const string sqlExisteServico =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBSERVICO]
            WHERE 
                [ID] = @ID";
        #endregion
        public override string InsertNew(Service registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(sqlInserirServico, ObtemParametrosServico(registro));

            return resultadoValidacao;
        }
        public override List<Service> SelectAll()
        {
            return Db.GetAll(sqlSelecionarTodosServicos, ConverterEmServico);
        }
        public override Service SelectById(int id)
        {
            return Db.Get(sqlSelecionarServicoPorId, ConverterEmServico, AddParameter("ID", id));
        }
        public override string Edit(int id, Service registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarServico, ObtemParametrosServico(registro));
            }

            return resultadoValidacao;
        }
        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeletarServico, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlExisteServico, AddParameter("ID", id));
        }

        private Dictionary<string, object> ObtemParametrosServico(Service servico)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", servico.Id);
            parametros.Add("NOME", servico.Name);
            parametros.Add("EHTAXADODIARIO", servico.IsChargedDaily);
            parametros.Add("VALOR", servico.Value);

            return parametros;
        }
        
        private Service ConverterEmServico(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            bool ehTaxadoDiario = Convert.ToBoolean(reader["EHTAXADODIARIO"]);
            double valor = Convert.ToDouble(reader["VALOR"]);

            Service servico = new Service(id, nome, ehTaxadoDiario, valor);

            servico.Id = id;

            return servico;
        }
    }
}

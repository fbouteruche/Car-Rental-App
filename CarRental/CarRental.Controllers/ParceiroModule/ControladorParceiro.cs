using CarRental.Controllers.Shared;
using CarRental.Domain.PartnerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.ParceiroModule
{
    public class ControladorParceiro : Controlador<Partner>
    {
        #region queries
        private const string sqlInserirParceiro =
            @"INSERT INTO TBPARCEIRO
	                (
		                [NOMEPARCEIRO]
	                ) 
	                VALUES
	                (
                        @NOMEPARCEIRO
	                )";

        private const string sqlEditarParceiro =
            @"UPDATE TBPARCEIRO
                    SET
                        [NOMEPARCEIRO] = @NOMEPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlDeletarParceiro =
            @"DELETE 
	                FROM
                        TBPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarParceiroPorId =
            @"SELECT
                        [ID],
		                [NOMEPARCEIRO]
	                FROM
                        TBPARCEIRO
                    WHERE 
                        ID = @ID";

        private const string sqlSelecionarTodosParceiros =
            @"SELECT
                        [ID],
		                [NOMEPARCEIRO]
	                FROM
                        TBPARCEIRO";

        private const string sqlExisteParceiro =
            @"SELECT 
                    COUNT(*) 
                FROM 
                    [TBPARCEIRO]
                WHERE 
                    [ID] = @ID";
        #endregion
        public override string InserirNovo(Partner registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(sqlInserirParceiro, ObtemParametrosParceiro(registro));

            return resultadoValidacao;
        }

        public override List<Partner> SelecionarTodos()
        {
            return Db.GetAll(sqlSelecionarTodosParceiros, ConverterEmParceiro);
        }       

        public override Partner SelecionarPorId(int id)
        {
            return Db.Get(sqlSelecionarParceiroPorId, ConverterEmParceiro, AdicionarParametro("ID", id));
        }        
        public override string Editar(int id, Partner registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarParceiro, ObtemParametrosParceiro(registro));
            }

            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlDeletarParceiro, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteParceiro, AdicionarParametro("ID", id));
        }

        private Dictionary<string, object> ObtemParametrosParceiro(Partner registro)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", registro.Id);
            parametros.Add("NOMEPARCEIRO", registro.Nome);

            return parametros;
        }
        private Partner ConverterEmParceiro(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOMEPARCEIRO"]);

            Partner parceiro = new Partner(id, nome);

            parceiro.Id = id;

            return parceiro;
        }
    }
}

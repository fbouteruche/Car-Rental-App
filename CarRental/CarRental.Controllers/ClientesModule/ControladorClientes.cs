using CarRental.Controllers.Shared;
using CarRental.Domain.CustomerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.ClientesModule
{
    public class ControladorCliente : Controlador<Customer>
    {
        #region Queries
            private const string sqlInserirClientes =
            @"
               INSERT INTO [TBCLIENTE]
            (
	            [NOME],
	            [REGISTROUNICO],
	            [ENDERECO],
	            [EMAIL],
	            [TELEFONE],
	            [EHPESSOAFISICA],
	            [CNH],
	            [VALIDADECNH]
            )
            VALUES
            (
	            @NOME,
	            @REGISTROUNICO,
	            @ENDERECO,
	            @EMAIL,
	            @TELEFONE,
	            @EHPESSOAFISICA,
	            @CNH,
	            @VALIDADECNH
            )";

		private const string sqlEditarClientes =
		@"
				UPDATE [TBCLIENTE] 
				 SET
					[NOME] = @NOME,
					[REGISTROUNICO] = @REGISTROUNICO,
					[ENDERECO] = @ENDERECO,
					[TELEFONE] = @TELEFONE,
					[EMAIL] = @EMAIL,
					[EHPESSOAFISICA] = @EHPESSOAFISICA,
					[CNH] = @CNH,
					[VALIDADECNH] = @VALIDADECNH
				WHERE [ID] = @ID;
            ";

		private const string sqlExcluirClientes =
		@"
				DELETE FROM [TBCLIENTE] WHERE [ID] = @ID
			";

		private const string sqlSelecionarTodosClientes =
		@"
			SELECT * FROM [TBCLIENTE]
			";

		private const string sqlSelecionarClientesPorId =
		@"
			SELECT * FROM [TBCLIENTE] WHERE [ID] = @ID;
			";

			private const string sqlExisteCliente =
			@"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";

		#endregion

		public override string Editar(int id, Customer registro)
		{
			string resultadoValidacao = registro.Validate();

			if (resultadoValidacao == "VALIDO")
			{
				registro.Id = id;
				Db.Update(sqlEditarClientes, ObtemParametrosClientes(registro));
			}

			return resultadoValidacao;
		}

		public override bool Excluir(int id)
		{
			try
			{
				Db.Delete(sqlExcluirClientes, AdicionarParametro("ID", id));
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public override bool Existe(int id)
		{
			return Db.Exists(sqlExisteCliente, AdicionarParametro("ID", id));
		}

		public override string InserirNovo(Customer registro)
		{
			string resultadoValidacao = registro.Validate();

			if (resultadoValidacao == "VALIDO")
			{
				registro.Id = Db.Insert(sqlInserirClientes, ObtemParametrosClientes(registro));
			}
			return resultadoValidacao;
		}

       

        public override Customer SelecionarPorId(int id)
		{
			return Db.Get(sqlSelecionarClientesPorId, ConverterEmClientes, AdicionarParametro("ID", id));
		}

		public override List<Customer> SelecionarTodos()
		{
			return Db.GetAll(sqlSelecionarTodosClientes, ConverterEmClientes);
		}

        private Customer ConverterEmClientes(IDataReader reader)
        {
			DateTime? validadeCnh = null;
			int id = Convert.ToInt32(reader["ID"]);
			string nome = Convert.ToString((reader["NOME"]));
			string registroUnico = Convert.ToString((reader["REGISTROUNICO"]));
			string endereco = Convert.ToString(reader["ENDERECO"]);
			string telefone = Convert.ToString(reader["TELEFONE"]);
			string email = Convert.ToString(reader["EMAIL"]);
			string cnh = Convert.ToString(reader["CNH"]);
			if(reader["VALIDADECNH"] != DBNull.Value)
				validadeCnh = Convert.ToDateTime(reader["VALIDADECNH"]);
			bool ehPessoaFisica = Convert.ToBoolean(reader["EHPESSOAFISiCA"]);

			Customer cliente = new Customer(id, nome, registroUnico, endereco, telefone, email, cnh, validadeCnh, ehPessoaFisica);
			cliente.Id = id;
			return cliente;
		}

        private Dictionary<string, object> ObtemParametrosClientes(Customer cliente)
		{
			var parametros = new Dictionary<string, object>();

			parametros.Add("ID", cliente.Id);
			parametros.Add("NOME", cliente.Name);
			parametros.Add("REGISTROUNICO", cliente.UniqueId);
			parametros.Add("ENDERECO", cliente.Address);
			parametros.Add("TELEFONE", cliente.Phone);
			parametros.Add("EMAIL", cliente.Email);
			parametros.Add("CNH", cliente.DriverLicense);
			parametros.Add("VALIDADECNH", cliente.LicenseExpiryDate);
			parametros.Add("EHPESSOAFISICA", cliente.IsPhysicalPerson);

			return parametros;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Data;
using CarRental.Controladores.Shared;
using CarRental.Domain.FuncionarioModule;

namespace CarRental.Controladores.FuncionarioModule
{
    public class ControladorFuncionario : Controlador<Employee>
    {

        #region Queries
        private const string comandoInserir = @"INSERT INTO TBFUNCIONARIO
										(
											[NOME],
											[REGISTROUNICO],
											[ENDERECO],
											[TELEFONE],
											[EMAIL],
											[EHPESSOAFISICA],
											[MATRICULAINTERNA],
											[USUARIOACESSO],
                                            [SENHA],
											[CARGO],
											[SALARIO],
                                            [DATAADMISSAO]
										)
										VALUES
										(
											@NOME,
											@REGISTROUNICO,
											@ENDERECO,
											@TELEFONE,
											@EMAIL,
											@EHPESSOAFISICA,
											@MATRICULAINTERNA,
											@USUARIOACESSO,
                                            @SENHA,
											@CARGO,
											@SALARIO,
                                            @DATAADMISSAO
										);";
        private const string comandoEditar = @"UPDATE TBFUNCIONARIO 
									    SET
									    	[NOME] = @NOME,
									    	[REGISTROUNICO] = @REGISTROUNICO,
									    	[ENDERECO] = @ENDERECO,
									    	[TELEFONE] = @TELEFONE,
									    	[EMAIL] = @EMAIL,
									    	[EHPESSOAFISICA] = @EHPESSOAFISICA,
									    	[MATRICULAINTERNA] = @MATRICULAINTERNA,
									    	[USUARIOACESSO] = @USUARIOACESSO,
                                            [SENHA] = @SENHA,
									    	[CARGO] = @CARGO,
									    	[SALARIO] = @SALARIO,
                                            [DATAADMISSAO] = @DATAADMISSAO
									    WHERE [ID] = @ID;";
        private const string comandoExcluir = @"DELETE FROM TBFUNCIONARIO WHERE [ID] = @ID;";
        private const string comandoSelecionarTodos = "SELECT * FROM TBFUNCIONARIO;";
        private const string comandoSelecionarPorId = "SELECT * FROM TBFUNCIONARIO WHERE [ID] = @ID;";
        #endregion

        public override string Editar(int id, Employee registro)
        {
            string resultadoValidacao = registro.Validate();
            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(comandoEditar, ObtemParametrosFuncionario(registro));
            }
            return resultadoValidacao;
        }

        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(comandoExcluir, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Existe(int id)
        {
            return Db.Exists(comandoSelecionarPorId, AdicionarParametro("ID", id));
        }

        public override string InserirNovo(Employee registro)
        {
            string resultadoValidacao = registro.Validate();
            if (resultadoValidacao == "VALIDO")
                registro.Id = Db.Insert(comandoInserir, ObtemParametrosFuncionario(registro));

            return resultadoValidacao;
        }

        public override Employee SelecionarPorId(int id)
        {
            return Db.Get(comandoSelecionarPorId, ConverterEmFuncionario, AdicionarParametro("ID", id));
        }

        public override List<Employee> SelecionarTodos()
        {
            return Db.GetAll(comandoSelecionarTodos, ConverterEmFuncionario);
        }

        private Dictionary<string, object> ObtemParametrosFuncionario(Employee funcionario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", funcionario.Id);
            parametros.Add("NOME", funcionario.Name);
            parametros.Add("REGISTROUNICO", funcionario.UniqueId);
            parametros.Add("ENDERECO", funcionario.Address);
            parametros.Add("TELEFONE", funcionario.Phone);
            parametros.Add("EMAIL", funcionario.Email);
            parametros.Add("MATRICULAINTERNA", funcionario.InternalRegistration);
            parametros.Add("USUARIOACESSO", funcionario.LoginUsername);
            parametros.Add("SENHA", funcionario.UserPassword);
            parametros.Add("DATAADMISSAO", funcionario.HiringDate);
            parametros.Add("CARGO", funcionario.JobTitle);
            parametros.Add("SALARIO", float.Parse(Convert.ToString(funcionario.Salary)));
            parametros.Add("EHPESSOAFISICA", Convert.ToBoolean(funcionario.IsPhysicalPerson));

            return parametros;
        }

        private Employee ConverterEmFuncionario(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string nome = Convert.ToString(reader["NOME"]);
            string registroUnico = Convert.ToString(reader["REGISTROUNICO"]);
            string endereco = Convert.ToString(reader["ENDERECO"]);
            string telefone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);
            int matriculaInterna = Convert.ToInt32(reader["MATRICULAINTERNA"]);
            string usuarioAcesso = Convert.ToString(reader["USUARIOACESSO"]);
            string senha = Convert.ToString(reader["SENHA"]);
            DateTime dataAdmissao = Convert.ToDateTime(reader["DATAADMISSAO"]);
            string cargo = Convert.ToString(reader["CARGO"]);
            double salario = Convert.ToDouble(Convert.ToString(reader["SALARIO"]));
            bool ehPessoaFisica = Convert.ToBoolean(reader["EHPESSOAFISICA"]);

            Employee funcionario = new Employee(id, nome, registroUnico, endereco, telefone, email, matriculaInterna, usuarioAcesso,senha, dataAdmissao, cargo, salario, ehPessoaFisica);

            funcionario.Id = id;

            return funcionario;
        }
    }
}

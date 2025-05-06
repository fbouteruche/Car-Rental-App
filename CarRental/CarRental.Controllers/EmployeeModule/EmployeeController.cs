using System;
using System.Collections.Generic;
using System.Data;
using CarRental.Controllers.Shared;
using CarRental.Domain.EmployeeModule;

namespace CarRental.Controllers.EmployeeModule
{
    public class EmployeeController : Controller<Employee>
    {

        #region Queries
        private const string insertCommand = @"INSERT INTO TBFUNCIONARIO
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
        private const string updateCommand = @"UPDATE TBFUNCIONARIO 
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
        private const string deleteCommand = @"DELETE FROM TBFUNCIONARIO WHERE [ID] = @ID;";
        private const string selectAllCommand = "SELECT * FROM TBFUNCIONARIO;";
        private const string selectByIdCommand = "SELECT * FROM TBFUNCIONARIO WHERE [ID] = @ID;";
        #endregion

        public override string Edit(int id, Employee record)
        {
            string resultadoValidacao = record.Validate();
            if (resultadoValidacao == "VALID")
            {
                record.Id = id;
                Db.Update(updateCommand, GetEmployeeParameters(record));
            }
            return resultadoValidacao;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(deleteCommand, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(selectByIdCommand, AddParameter("ID", id));
        }

        public override string InsertNew(Employee record)
        {
            string resultadoValidacao = record.Validate();
            if (resultadoValidacao == "VALID")
                record.Id = Db.Insert(insertCommand, GetEmployeeParameters(record));

            return resultadoValidacao;
        }

        public override Employee SelectById(int id)
        {
            return Db.Get(selectByIdCommand, ConvertToEmployee, AddParameter("ID", id));
        }

        public override List<Employee> SelectAll()
        {
            return Db.GetAll(selectAllCommand, ConvertToEmployee);
        }

        private Dictionary<string, object> GetEmployeeParameters(Employee funcionario)
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

        private Employee ConvertToEmployee(IDataReader reader)
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

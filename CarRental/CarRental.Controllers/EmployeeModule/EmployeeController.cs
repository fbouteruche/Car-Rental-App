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

        public override string Edit(int id, Employee employee)
        {
            string validationResult = employee.Validate();
            if (validationResult == "VALID")
            {
                employee.Id = id;
                Db.Update(updateCommand, GetEmployeeParameters(employee));
            }
            return validationResult;
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

        public override string InsertNew(Employee employee)
        {
            string validationResult = employee.Validate();
            if (validationResult == "VALID")
                employee.Id = Db.Insert(insertCommand, GetEmployeeParameters(employee));

            return validationResult;
        }

        public override Employee SelectById(int id)
        {
            return Db.Get(selectByIdCommand, ConvertToEmployee, AddParameter("ID", id));
        }

        public override List<Employee> SelectAll()
        {
            return Db.GetAll(selectAllCommand, ConvertToEmployee);
        }

        private Dictionary<string, object> GetEmployeeParameters(Employee employee)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", employee.Id);
            parameters.Add("NOME", employee.Name);
            parameters.Add("REGISTROUNICO", employee.UniqueId);
            parameters.Add("ENDERECO", employee.Address);
            parameters.Add("TELEFONE", employee.Phone);
            parameters.Add("EMAIL", employee.Email);
            parameters.Add("MATRICULAINTERNA", employee.InternalRegistration);
            parameters.Add("USUARIOACESSO", employee.LoginUsername);
            parameters.Add("SENHA", employee.UserPassword);
            parameters.Add("DATAADMISSAO", employee.HiringDate);
            parameters.Add("CARGO", employee.JobTitle);
            parameters.Add("SALARIO", float.Parse(Convert.ToString(employee.Salary)));
            parameters.Add("EHPESSOAFISICA", Convert.ToBoolean(employee.IsPhysicalPerson));

            return parameters;
        }

        private Employee ConvertToEmployee(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["NOME"]);
            string uniqueId = Convert.ToString(reader["REGISTROUNICO"]);
            string address = Convert.ToString(reader["ENDERECO"]);
            string phone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);
            int internalRegistration = Convert.ToInt32(reader["MATRICULAINTERNA"]);
            string loginUsername = Convert.ToString(reader["USUARIOACESSO"]);
            string userPassword = Convert.ToString(reader["SENHA"]);
            DateTime hiringDate = Convert.ToDateTime(reader["DATAADMISSAO"]);
            string jobTitle = Convert.ToString(reader["CARGO"]);
            double salary = Convert.ToDouble(Convert.ToString(reader["SALARIO"]));
            bool isPhysicalPerson = Convert.ToBoolean(reader["EHPESSOAFISICA"]);

            Employee employee = new Employee(id, name, uniqueId, address, phone, email, internalRegistration, loginUsername, userPassword, hiringDate, jobTitle, salary, isPhysicalPerson);

            employee.Id = id;

            return employee;
        }
    }
}

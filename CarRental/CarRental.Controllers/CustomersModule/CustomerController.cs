using CarRental.Controllers.Shared;
using CarRental.Domain.CustomerModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.CustomersModule
{
    public class CustomerController : Controller<Customer>
    {
        #region Queries
        private const string sqlInsertCustomers =
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

        private const string sqlEditCustomers =
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

        private const string sqlDeleteCustomers =
        @"
                DELETE FROM [TBCLIENTE] WHERE [ID] = @ID
            ";

        private const string sqlSelectAllCustomers =
        @"
            SELECT * FROM [TBCLIENTE]
            ";

        private const string sqlSelectCustomerById =
        @"
            SELECT * FROM [TBCLIENTE] WHERE [ID] = @ID;
            ";

        private const string sqlCustomerExists =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBCLIENTE]
            WHERE 
                [ID] = @ID";

        #endregion

        public override string Edit(int id, Customer record)
        {
            string validationResult = record.Validate();

            if (validationResult == "VALID")
            {
                record.Id = id;
                Db.Update(sqlEditCustomers, GetCustomerParameters(record));
            }

            return validationResult;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteCustomers, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlCustomerExists, AddParameter("ID", id));
        }

        public override string InsertNew(Customer record)
        {
            string validationResult = record.Validate();

            if (validationResult == "VALID")
            {
                record.Id = Db.Insert(sqlInsertCustomers, GetCustomerParameters(record));
            }
            return validationResult;
        }

        public override Customer SelectById(int id)
        {
            return Db.Get(sqlSelectCustomerById, ConvertToCustomer, AddParameter("ID", id));
        }

        public override List<Customer> SelectAll()
        {
            return Db.GetAll(sqlSelectAllCustomers, ConvertToCustomer);
        }

        private Customer ConvertToCustomer(IDataReader reader)
        {
            DateTime? licenseExpiryDate = null;
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["NOME"]);
            string uniqueId = Convert.ToString(reader["REGISTROUNICO"]);
            string address = Convert.ToString(reader["ENDERECO"]);
            string phone = Convert.ToString(reader["TELEFONE"]);
            string email = Convert.ToString(reader["EMAIL"]);
            string driverLicense = Convert.ToString(reader["CNH"]);
            if(reader["VALIDADECNH"] != DBNull.Value)
                licenseExpiryDate = Convert.ToDateTime(reader["VALIDADECNH"]);
            bool isPhysicalPerson = Convert.ToBoolean(reader["EHPESSOAFISiCA"]);

            Customer customer = new Customer(id, name, uniqueId, address, phone, email, driverLicense, licenseExpiryDate, isPhysicalPerson);
            customer.Id = id;
            return customer;
        }

        private Dictionary<string, object> GetCustomerParameters(Customer customer)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", customer.Id);
            parameters.Add("NOME", customer.Name);
            parameters.Add("REGISTROUNICO", customer.UniqueId);
            parameters.Add("ENDERECO", customer.Address);
            parameters.Add("TELEFONE", customer.Phone);
            parameters.Add("EMAIL", customer.Email);
            parameters.Add("CNH", customer.DriverLicense);
            parameters.Add("VALIDADECNH", customer.LicenseExpiryDate);
            parameters.Add("EHPESSOAFISICA", customer.IsPhysicalPerson);

            return parameters;
        }
    }
}

using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.Controllers.ServiceModule;
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
        private VehicleController vehicleController = null;
        private EmployeeController employeeController = null;
        private CustomerController customerController = null;
        private ServiceController serviceController = null;
        private CouponController couponController = new CouponController();

        public RentalController(VehicleController vehicleController, EmployeeController employeeController, CustomerController customerController, ServiceController serviceController, CouponController couponController)
        {
            this.vehicleController = vehicleController;
            this.employeeController = employeeController;
            this.customerController = customerController;
            this.serviceController = serviceController;
            //this.couponController = couponController; // If you want to use a different couponController instance, uncomment this line.
        }

        #region queries
        private const string sqlInsertRental =
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

        private const string sqlUpdateRental =
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

        private const string sqlSelectAllRentals =
            @"SELECT * FROM [DBO].[TBLOCACAO];";

        private const string sqlSelectRentalById =
            @"SELECT * FROM [DBO].[TBLOCACAO] WHERE [ID] = @ID;";

        private const string sqlDeleteRental =
                @"DELETE FROM [DBO].[TBLOCACAO] WHERE [ID] = @ID;";

        private string sqlSelectServiceIdByRentalId =
            @"SELECT [ID_SERVICO] FROM [TBSERVICO_LOCACAO]
               WHERE [ID_LOCACAO] = @ID_LOCACAO";
        #endregion

        public override string InsertNew(Rental record)
        {
            string validationResult = record.Validate();

            if (validationResult == "VALID")
                record.Id = Db.Insert(sqlInsertRental, GetRentalParameters(record));

            return validationResult;
        }
        public override List<Rental> SelectAll()
        {
            return Db.GetAll(sqlSelectAllRentals, ConvertToRental);
        }
        public override Rental SelectById(int id)
        {
            return Db.Get(sqlSelectRentalById, ConvertToRental, AddParameter("ID", id));
        }

        private List<Service> SelectServicesByRentalId(int rentalId)
        {
            List<Service> rentalServices = new List<Service>();
            List<int> serviceIds = Db.GetAll(sqlSelectServiceIdByRentalId, ConvertToInt, AddParameter("ID_LOCACAO", rentalId));
            foreach (int serviceId in serviceIds)
            {
                rentalServices.Add(serviceController.SelectById(serviceId));
            }
            return rentalServices;
        }

        public override string Edit(int id, Rental record)
        {
            string validationResult = record.Validate();

            if (validationResult == "VALID")
            {
                record.Id = id;
                Db.Update(sqlUpdateRental, GetRentalParameters(record));
            }

            return validationResult;
        }
        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteRental, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlSelectRentalById, AddParameter("ID", id));
        }

        private Dictionary<string, object> GetRentalParameters(Rental rental)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", rental.Id);
            parameters.Add("ID_VEICULO", rental.Vehicle.Id);
            parameters.Add("ID_FUNCIONARIO", rental.RentingEmployee.Id);
            parameters.Add("ID_CLIENTECONTRATANTE", rental.ContractingCustomer.Id);
            parameters.Add("ID_CLIENTECONDUTOR", rental.DriverCustomer.Id);
            if (rental.Coupon != null)
                parameters.Add("ID_CUPOM", rental.Coupon.Id);
            else
                parameters.Add("ID_CUPOM", null);
            parameters.Add("DATADESAIDA", rental.DepartureDate);
            parameters.Add("DATAPREVISTADECHEGADA", rental.ExpectedReturnDate);
            parameters.Add("DATADECHEGADA", rental.ReturnDate);
            parameters.Add("TIPODOPLANO", rental.PlanType);
            parameters.Add("TIPODESEGURO", rental.InsuranceType);
            parameters.Add("PRECOLOCACAO", rental.RentalPrice);
            parameters.Add("PRECODEVOLUCAO", rental.ReturnPrice);
            parameters.Add("ESTAABERTA", rental.IsOpen);
            return parameters;
        }

        private int ConvertToInt(IDataReader reader)
        {
            return Convert.ToInt32(reader["ID_SERVICO"]);
        }

        private Rental ConvertToRental(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var vehicleId = Convert.ToInt32(reader["ID_VEICULO"]);
            var employeeId = Convert.ToInt32(reader["ID_FUNCIONARIO"]);
            var contractingCustomerId = Convert.ToInt32(reader["ID_CLIENTECONTRATANTE"]);
            var driverCustomerId = Convert.ToInt32(reader["ID_CLIENTECONDUTOR"]);
            var couponId = 0;
            if (reader["ID_CUPOM"] != DBNull.Value)
                couponId = Convert.ToInt32(reader["ID_CUPOM"]);
            // There may be problems with null return. If it happens, do something like:
            // if (!int.TryParse(reader["ID_CLIENTECONDUTOR"].ToString(), out int driverCustomerId))
            //     driverCustomerId = -1;
            var departureDate = Convert.ToDateTime(reader["DATADESAIDA"]);
            var expectedReturnDate = Convert.ToDateTime(reader["DATAPREVISTADECHEGADA"]);
            var returnDate = Convert.ToDateTime(reader["DATADECHEGADA"]);
            var planType = Convert.ToString(reader["TIPODOPLANO"]);
            var insuranceType = Convert.ToString(reader["TIPODESEGURO"]);
            var rentalPrice = Convert.ToDouble(reader["PRECOLOCACAO"]);
            var returnPrice = Convert.ToDouble(reader["PRECODEVOLUCAO"]);
            var isOpen = Convert.ToBoolean(reader["ESTAABERTA"]);

            List<Service> rentalServices = SelectServicesByRentalId(id);
            //foreach (Service service in serviceController.SelectAll())
            //{
            //    List<int> serviceIds = SelectServicesByRentalId(id);
            //    if (serviceIds.Contains(service.Id))
            //        rentalServices.Add(service);
            //}

            Vehicle vehicle = vehicleController.SelectById(vehicleId);
            Employee rentingEmployee = employeeController.SelectById(employeeId);
            Customer contractingCustomer = customerController.SelectById(contractingCustomerId);
            Customer driverCustomer = customerController.SelectById(driverCustomerId);
            Coupon coupon;
            if (couponId != 0)
                coupon = couponController.SelectById(couponId);
            else
                coupon = null;

            return new Rental(id, vehicle, rentingEmployee, contractingCustomer, driverCustomer, coupon, departureDate, expectedReturnDate, returnDate, planType, insuranceType, rentalPrice, returnPrice, isOpen, rentalServices);
        }
    }
}

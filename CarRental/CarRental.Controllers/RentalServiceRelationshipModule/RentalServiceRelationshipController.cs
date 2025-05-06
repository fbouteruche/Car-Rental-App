using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.FuncionarioModule;
using CarRental.Controllers.RentalModule;
using CarRental.Controllers.ServiceModule;
using CarRental.Controllers.Shared;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Controllers.RentalServiceRelationshipModule
{
    public class RentalServiceRelationshipController : Controller<RentalServiceRelationship>
    {
        private int id = 0;
        ServiceController serviceController = new ServiceController();
        RentalController rentalController = new RentalController(new VehicleController(), new ControladorFuncionario(), new CustomerController(), new ServiceController(), new CouponController());
        #region relationship queries
        private const string sqlInsertRelationship =
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

        private const string sqlEditRelationship =
        @"UPDATE [DBO].[TBSERVICO_LOCACAO] 
                SET
                    [ID_LOCACAO] = @ID_LOCACAO,
                    [ID_SERVICO] = @ID_SERVICO
                WHERE 
                    [ID] = @ID;";

        private const string sqlSelectAllRelationships =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO];";

        private const string sqlSelectRelationshipById =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID] = @ID;";

        private const string sqlSelectRelationshipByRental =
            @"SELECT * FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID_LOCACAO] = @ID_LOCACAO;";

        private const string sqlDeleteRelationship =
            @"DELETE FROM [DBO].[TBSERVICO_LOCACAO] WHERE [ID] = @ID;";

        #endregion
        public override string Edit(int id, RentalServiceRelationship record)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteRelationship, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlSelectRelationshipById, AddParameter("ID", id));
        }

        public override string InsertNew(RentalServiceRelationship record)
        {
            string validationResult = record.Validate();

            if (validationResult == "VALID")
                foreach (Service service in record.Services)
                {
                    id = service.Id;
                    record.Id = Db.Insert(sqlInsertRelationship, GetRelationshipParameters(record));
                }

            return validationResult;
        }

        public override RentalServiceRelationship SelectById(int id)
        {
            return Db.Get(sqlSelectRelationshipById, ConvertToRelationship, AddParameter("ID", id));
        }

        public object SelectByRental(int rentalId)
        {
            return Db.GetAll(sqlSelectRelationshipByRental, ConvertToRelationship, AddParameter("ID_LOCACAO", rentalId));
        }

        public override List<RentalServiceRelationship> SelectAll()
        {
            return Db.GetAll(sqlSelectAllRelationships, ConvertToRelationship);
        }
        private RentalServiceRelationship ConvertToRelationship(IDataReader reader)
        {
            var relationshipId = Convert.ToInt32(reader["ID"]);
            var rentalId = Convert.ToInt32(reader["ID_LOCACAO"]);
            var serviceId = Convert.ToInt32(reader["ID_SERVICO"]);

            List<Service> filteredServices = new List<Service>();
            foreach (Service item in serviceController.SelectAll())
                if (item.Id == serviceId)
                    filteredServices.Add(item);
            Rental rental = rentalController.SelectById(rentalId);

            return new RentalServiceRelationship(relationshipId, rental, filteredServices);
        }
        private Dictionary<string, object> GetRelationshipParameters(RentalServiceRelationship relationship)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("ID", relationship.Id);
            parameters.Add("ID_LOCACAO", relationship.Rental.Id);
            parameters.Add("ID_SERVICO", id);

            return parameters;
        }
    }
}

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
        #region queries Relacionamento
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
        public override string Edit(int id, RentalServiceRelationship registro)
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

        public override string InsertNew(RentalServiceRelationship registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALID")
                foreach (Service servico in registro.Services)
                {
                    id = servico.Id;
                    registro.Id = Db.Insert(sqlInsertRelationship, GetRelationshipParameters(registro));
                }

            return resultadoValidacao;
        }

        public override RentalServiceRelationship SelectById(int id)
        {
            return Db.Get(sqlSelectRelationshipById, ConvertToRelationship, AddParameter("ID", id));
        }

        public object SelectByRental(int id)
        {
            return Db.GetAll(sqlSelectRelationshipByRental, ConvertToRelationship, AddParameter("ID_LOCACAO", id));
        }

        public override List<RentalServiceRelationship> SelectAll()
        {
            return Db.GetAll(sqlSelectAllRelationships, ConvertToRelationship);
        }
        private RentalServiceRelationship ConvertToRelationship(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var id_locacao = Convert.ToInt32(reader["ID_LOCACAO"]);
            var id_servico = Convert.ToInt32(reader["ID_SERVICO"]);

            List<Service> filtrado = new List<Service>();
            foreach (Service item in serviceController.SelectAll())
                if (item.Id == id_servico)
                    filtrado.Add(item);
            Rental locacao = rentalController.SelectById(id_locacao);

            return new RentalServiceRelationship(id, locacao, filtrado);
        }
        private Dictionary<string, object> GetRelationshipParameters(RentalServiceRelationship relacionamento)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("ID", relacionamento.Id);
            parametros.Add("ID_LOCACAO", relacionamento.Rental.Id);
            parametros.Add("ID_SERVICO", id);

            return parametros;
        }
    }
}

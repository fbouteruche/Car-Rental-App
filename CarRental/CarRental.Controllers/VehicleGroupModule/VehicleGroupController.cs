using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleGroupModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRental.Controllers.VehicleGroupModule
{
    public class VehicleGroupController : Controller<VehicleGroup>
    {
        private const string sqlInsertVehicleGroup =
                @"INSERT INTO TBGRUPOVEICULO
                (
                    [NOME],
                    [TAXAPLANODIARIO],
                    [TAXAPORKMDIARIO],
                    [TAXAPLANOCONTROLADO],
                    [LIMITEKMCONTROLADO],
                    [TAXAKMEXCEDIDOCONTROLADO],
                    [TAXAPLANOLIVRE]
                )
                VALUES
                (
                    @NOME,
                    @TAXAPLANODIARIO,
                    @TAXAPORKMDIARIO,
                    @TAXAPLANOCONTROLADO,
                    @LIMITEKMCONTROLADO,
                    @TAXAKMEXCEDIDOCONTROLADO,
                    @TAXAPLANOLIVRE
                );";

        private const string sqlUpdateVehicleGroup =
                @"UPDATE TBGRUPOVEICULO 
                SET
                    [NOME] = @NOME,
                    [TAXAPLANODIARIO] = @TAXAPLANODIARIO,
                    [TAXAPORKMDIARIO] = @TAXAPORKMDIARIO,
                    [TAXAPLANOCONTROLADO] = @TAXAPLANOCONTROLADO,
                    [LIMITEKMCONTROLADO] = @LIMITEKMCONTROLADO,
                    [TAXAKMEXCEDIDOCONTROLADO] = @TAXAKMEXCEDIDOCONTROLADO,
                    [TAXAPLANOLIVRE] = @TAXAPLANOLIVRE
                WHERE [ID] = @ID;";

        private const string sqlDeleteVehicleGroup =
                @"DELETE FROM TBGRUPOVEICULO  WHERE [ID] = @ID;";

        private const string sqlSelectVehicleGroupById =
                @"SELECT * FROM TBGRUPOVEICULO WHERE [ID] = @ID;";

        private const string sqlSelectAllVehicleGroups =
                @"SELECT * FROM TBGRUPOVEICULO;";

        private const string sqlVehicleGroupExists =
                @"SELECT 
                    COUNT(*) 
                FROM 
                    [TBGRUPOVEICULO]
                WHERE 
                    [ID] = @ID";

        public override string InsertNew(VehicleGroup record)
        {
            string validationResult = record.Validate();

            List<VehicleGroup> registeredVehicleGroups = SelectAll();
            foreach (VehicleGroup group in registeredVehicleGroups)
            {
                if (record.Name == group.Name)
                    validationResult = "The vehicle group name must be unique\n";
            }

            if (validationResult == "VALID")
            {
                record.Id = Db.Insert(sqlInsertVehicleGroup, GetVehicleGroupParameters(record));
            }

            return validationResult;
        }

        public override string Edit(int id, VehicleGroup record)
        {
            string validationResult = record.Validate();

            List<VehicleGroup> registeredVehicleGroups = SelectAll();
            foreach (VehicleGroup group in registeredVehicleGroups)
            {
                if (id != group.Id && record.Name == group.Name)
                    validationResult = "The vehicle group name must be unique\n";
            }

            if (validationResult == "VALID")
            {
                record.Id = id;
                Db.Update(sqlUpdateVehicleGroup, GetVehicleGroupParameters(record));
            }

            return validationResult;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteVehicleGroup, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlVehicleGroupExists, AddParameter("ID", id));
        }

        public override VehicleGroup SelectById(int id)
        {
            return Db.Get(sqlSelectVehicleGroupById, ConvertToVehicleGroup, AddParameter("ID", id));
        }

        public override List<VehicleGroup> SelectAll()
        {
            return Db.GetAll(sqlSelectAllVehicleGroups, ConvertToVehicleGroup);
        }

        private Dictionary<string, object> GetVehicleGroupParameters(VehicleGroup vehicleGroup)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", vehicleGroup.Id);
            parameters.Add("NOME", vehicleGroup.Name);
            parameters.Add("TAXAPLANODIARIO", vehicleGroup.DailyPlanRate);
            parameters.Add("TAXAPORKMDIARIO", vehicleGroup.DailyPerKmRate);
            parameters.Add("TAXAPLANOCONTROLADO", vehicleGroup.ControlledPlanRate);
            parameters.Add("LIMITEKMCONTROLADO", vehicleGroup.ControlledKmLimit);
            parameters.Add("TAXAKMEXCEDIDOCONTROLADO", vehicleGroup.ControlledExceededKmRate);
            parameters.Add("TAXAPLANOLIVRE", vehicleGroup.UnlimitedPlanRate);

            return parameters;
        }

        private VehicleGroup ConvertToVehicleGroup(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]);
            string name = Convert.ToString(reader["NOME"]);
            double dailyPlanRate = Convert.ToDouble(reader["TAXAPLANODIARIO"]);
            double dailyPerKmRate = Convert.ToDouble(reader["TAXAPORKMDIARIO"]);
            double controlledPlanRate = Convert.ToDouble(reader["TAXAPLANOCONTROLADO"]);
            int controlledKmLimit = Convert.ToInt32(reader["LIMITEKMCONTROLADO"]);
            double controlledExceededKmRate = Convert.ToDouble(reader["TAXAKMEXCEDIDOCONTROLADO"]);
            double unlimitedPlanRate = Convert.ToDouble(reader["TAXAPLANOLIVRE"]);

            VehicleGroup vehicleGroup = new VehicleGroup(id, name, dailyPlanRate, dailyPerKmRate, controlledPlanRate,
                controlledKmLimit, controlledExceededKmRate, unlimitedPlanRate);

            return vehicleGroup;
        }
    }
}

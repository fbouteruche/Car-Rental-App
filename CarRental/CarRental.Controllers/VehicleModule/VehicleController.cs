using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.VehicleImageModule;
using CarRental.Controllers.VehicleImageModule;
using CarRental.Domain.VehicleModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace CarRental.Controllers.VehicleModule
{
    public class VehicleController : Controller<Vehicle>
    {
        private VehicleImageController imageController = new VehicleImageController();
        #region queries
        private const string sqlInsertVehicle =
            @"INSERT INTO TBVEICULO
            (
                [MODELO],
                [ID_GRUPOVEICULO],
                [PLACA],
                [CHASSI],      
                [MARCA], 
                [COR],
                [TIPOCOMBUSTIVEL],
                [CAPACIDADETANQUE],
                [ANO],
                [KILOMETRAGEM],
                [NUMEROPORTAS],
                [CAPACIDADEPESSOAS],
                [TAMANHOPORTAMALA],
                [TEMARCONDICIONADO],
                [TEMDIRECAOHIDRAULICA],
                [TEMFREIOSABS],
                [ESTAALUGADO]
            )
            VALUES
            (
                @MODELO,
                @ID_GRUPOVEICULO,
                @PLACA,
                @CHASSI,      
                @MARCA,
                @COR,
                @TIPOCOMBUSTIVEL,
                @CAPACIDADETANQUE,
                @ANO,
                @KILOMETRAGEM,
                @NUMEROPORTAS,
                @CAPACIDADEPESSOAS,
                @TAMANHOPORTAMALA,
                @TEMARCONDICIONADO,
                @TEMDIRECAOHIDRAULICA,
                @TEMFREIOSABS,
                @ESTAALUGADO
            )";
        private const string sqlSelectAllVehicles =
            @"SELECT
                CV.[ID],
                CV.[MODELO],
                CV.[ID_GRUPOVEICULO],
                CV.[PLACA],
                CV.[CHASSI],      
                CV.[MARCA], 
                CV.[COR],
                CV.[TIPOCOMBUSTIVEL],
                CV.[CAPACIDADETANQUE],
                CV.[ANO],
                CV.[KILOMETRAGEM],
                CV.[NUMEROPORTAS],
                CV.[CAPACIDADEPESSOAS],
                CV.[TAMANHOPORTAMALA],
                CV.[TEMARCONDICIONADO],
                CV.[TEMDIRECAOHIDRAULICA],
                CV.[TEMFREIOSABS],
                CV.[ESTAALUGADO],
                CG.[NOME],
                CG.[TAXAPLANODIARIO],
                CG.[TAXAPORKMDIARIO],
                CG.[TAXAPLANOCONTROLADO],
                CG.[LIMITEKMCONTROLADO],
                CG.[TAXAKMEXCEDIDOCONTROLADO],
                CG.[TAXAPLANOLIVRE]
            FROM 
                [TBVEICULO] AS CV LEFT JOIN 
                [TBGRUPOVEICULO] AS CG
            ON
                CG.ID = CV.ID_GRUPOVEICULO";
        private const string sqlSelectVehicleById =
            @"SELECT  
                CV.[ID],
                CV.[MODELO],
                CV.[ID_GRUPOVEICULO],
                CV.[PLACA],
                CV.[CHASSI],      
                CV.[MARCA], 
                CV.[COR],
                CV.[TIPOCOMBUSTIVEL],
                CV.[CAPACIDADETANQUE],
                CV.[ANO],
                CV.[KILOMETRAGEM],
                CV.[NUMEROPORTAS],
                CV.[CAPACIDADEPESSOAS],
                CV.[TAMANHOPORTAMALA],
                CV.[TEMARCONDICIONADO],
                CV.[TEMDIRECAOHIDRAULICA],
                CV.[TEMFREIOSABS],
                CV.[ESTAALUGADO],
                CG.[NOME],
                CG.[TAXAPLANODIARIO],
                CG.[TAXAPORKMDIARIO],
                CG.[TAXAPLANOCONTROLADO],
                CG.[LIMITEKMCONTROLADO],
                CG.[TAXAKMEXCEDIDOCONTROLADO],
                CG.[TAXAPLANOLIVRE]
            FROM 
                [TBVEICULO] AS CV LEFT JOIN 
                [TBGRUPOVEICULO] AS CG
            ON
                CG.ID = CV.ID_GRUPOVEICULO
            WHERE 
                CV.[ID] = @ID";
        private const string sqlEditVehicle =
            @"UPDATE TBVEICULO SET
                [MODELO] = @MODELO,
                [ID_GRUPOVEICULO] = @ID_GRUPOVEICULO,
                [PLACA] = @PLACA,
                [CHASSI] = @CHASSI,
                [MARCA] = @MARCA,
                [COR] = @COR,
                [TIPOCOMBUSTIVEL] = @TIPOCOMBUSTIVEL,
                [CAPACIDADETANQUE] = @CAPACIDADETANQUE,
                [ANO] = @ANO,
                [KILOMETRAGEM] = @KILOMETRAGEM,
                [NUMEROPORTAS] = @NUMEROPORTAS,
                [CAPACIDADEPESSOAS] = @CAPACIDADEPESSOAS,
                [TAMANHOPORTAMALA] = @TAMANHOPORTAMALA,
                [TEMARCONDICIONADO] = @TEMARCONDICIONADO,
                [TEMDIRECAOHIDRAULICA] = @TEMDIRECAOHIDRAULICA,
                [TEMFREIOSABS] = @TEMFREIOSABS,
                [ESTAALUGADO] = @ESTAALUGADO
            WHERE
                [ID] = @ID
            ";
        private const string sqlDeleteVehicle =
            @"DELETE 
                FROM 
                TBVEICULO 
            WHERE 
                [ID] = @ID";
        private const string sqlVehicleExists =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULO]
            WHERE 
                [ID] = @ID";

        private const string sqlVehicleTotal =
            @"SELECT COUNT(*) AS QTD FROM[TBVEICULO]";
        #endregion
        public override string InsertNew(Vehicle vehicle)
        {
            string validationResult = vehicle.Validate();

            if (validationResult == "VALIDO")
            {
                vehicle.Id = Db.Insert(sqlInsertVehicle, GetVehicleParameters(vehicle));
                if (vehicle.images != null)
                {
                    foreach (VehicleImage vehicleImage in vehicle.images)
                    {
                        vehicleImage.VehicleId = vehicle.Id;
                        imageController.InsertNew(vehicleImage);
                    }
                }
            }
            return validationResult;
        }
        public override List<Vehicle> SelectAll()
        {
            List<Vehicle> vehicles = Db.GetAll(sqlSelectAllVehicles, ConvertToVehicle);

            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.images = imageController.SelectAllImagesOfVehicle(vehicle.Id);
            }

            return vehicles;
        }
        public override Vehicle SelectById(int id)
        {
            Vehicle vehicle = Db.Get(sqlSelectVehicleById, ConvertToVehicle, AddParameter("ID", id));
            vehicle.images = imageController.SelectAllImagesOfVehicle(id);
            return vehicle;
        }
        public override string Edit(int id, Vehicle vehicle)
        {
            string validationResult = vehicle.Validate();

            if (validationResult == "VALIDO")
            {
                vehicle.Id = id;
                Db.Update(sqlEditVehicle, GetVehicleParameters(vehicle));
                foreach (VehicleImage image in vehicle.images)
                    image.VehicleId = vehicle.Id;
                imageController.EditList(vehicle.images);
            }

            return validationResult;
        }
        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlDeleteVehicle, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
     
        public override bool Exists(int id)
        {
            return Db.Exists(sqlVehicleExists, AddParameter("ID", id));
        }

        private Dictionary<string, object> GetVehicleParameters(Vehicle vehicle)
        {
            var parameters = new Dictionary<string, object>();

            parameters.Add("ID", vehicle.Id);
            parameters.Add("MODELO", vehicle.model);
            parameters.Add("ID_GRUPOVEICULO", vehicle.vehicleGroup.Id);
            parameters.Add("PLATE", vehicle.licensePlate);
            parameters.Add("CHASSIS", vehicle.chassis);
            parameters.Add("BRAND", vehicle.brand);
            parameters.Add("COLOR", vehicle.color);
            parameters.Add("FUELTYPE", vehicle.fuelType);
            parameters.Add("TANKCAPACITY", vehicle.tankCapacity);
            parameters.Add("YEAR", vehicle.year);
            parameters.Add("MILEAGE", vehicle.mileage);
            parameters.Add("NUMBEROFDOORS", vehicle.numberOfDoors);
            parameters.Add("PASSENGERCAPACITY", vehicle.passengerCapacity);
            parameters.Add("TRUNKSIZE", vehicle.trunkSize);
            parameters.Add("HASAIRCONDITIONING", vehicle.hasAirConditioning);
            parameters.Add("HASPOWERSTEERING", vehicle.hasPowerSteering);
            parameters.Add("HASABS", vehicle.hasAbsBrakes);
            parameters.Add("ISRENTED", vehicle.isRented);

            return parameters;
        }

        private Vehicle ConvertToVehicle(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var model = Convert.ToString(reader["MODELO"]);
            var vehicleGroupId = Convert.ToInt32(reader["ID_GRUPOVEICULO"]);
            var licensePlate = Convert.ToString(reader["PLACA"]);
            var chassis = Convert.ToString(reader["CHASSI"]);
            var brand = Convert.ToString(reader["MARCA"]);
            var color = Convert.ToString(reader["COR"]);
            var fuelType = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            var tankCapacity = Convert.ToDouble(reader["CAPACIDADETANQUE"]);
            var year = Convert.ToInt32(reader["ANO"]);
            var mileage = Convert.ToDouble(reader["KILOMETRAGEM"]);
            var numberOfDoors = Convert.ToInt32(reader["NUMEROPORTAS"]);
            var passengerCapacity = Convert.ToInt32(reader["CAPACIDADEPESSOAS"]);
            var trunkSize = Convert.ToChar(reader["TAMANHOPORTAMALA"]);
            var hasAirConditioning = Convert.ToBoolean(reader["TEMARCONDICIONADO"]);
            var hasPowerSteering = Convert.ToBoolean(reader["TEMDIRECAOHIDRAULICA"]);
            var hasAbsBrakes = Convert.ToBoolean(reader["TEMFREIOSABS"]);
            var isRented = Convert.ToBoolean(reader["ESTAALUGADO"]);

            string name = Convert.ToString(reader["NOME"]);
            double dailyPlanRate = Convert.ToDouble(reader["TAXAPLANODIARIO"]);
            double dailyPerKmRate = Convert.ToDouble(reader["TAXAPORKMDIARIO"]);
            double controlledPlanRate = Convert.ToDouble(reader["TAXAPLANOCONTROLADO"]);
            int controlledKmLimit = Convert.ToInt32(reader["LIMITEKMCONTROLADO"]);
            double controlledExceededKmRate = Convert.ToDouble(reader["TAXAKMEXCEDIDOCONTROLADO"]);
            double unlimitedPlanRate = Convert.ToDouble(reader["TAXAPLANOLIVRE"]);

            VehicleGroup group = new VehicleGroup(vehicleGroupId, name, dailyPlanRate, dailyPerKmRate, controlledPlanRate, controlledKmLimit, controlledExceededKmRate, unlimitedPlanRate);

            Vehicle vehicle = new Vehicle(id, model, group, licensePlate, chassis, brand, color, fuelType, tankCapacity, year, mileage, numberOfDoors, passengerCapacity, trunkSize, hasAirConditioning, hasPowerSteering, hasAbsBrakes, isRented, null);

            vehicle.Id = id;

            return vehicle;
        }
        private int ConvertData(IDataReader reader)
        {
            return Convert.ToInt32(reader["QTD"]);
        }
    }
}

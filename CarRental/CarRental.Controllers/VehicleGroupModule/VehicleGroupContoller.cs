using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleGroupModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRental.Controllers.VehicleGroupModule
{
    public class VehicleGroupContoller : Controller<VehicleGroup>
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

        public override string InsertNew(VehicleGroup registro)
        {
            string resultadoValidacao = registro.Validate();

            List<VehicleGroup> grupoDeVeiculosRegistrados = SelectAll();
            foreach (VehicleGroup grupo in grupoDeVeiculosRegistrados)
            {
                if (registro.Name == grupo.Name)
                    resultadoValidacao = "O nome do grupo de veículos deve ser único\n";
            }

            if (resultadoValidacao == "VALID")
            {
                registro.Id = Db.Insert(sqlInsertVehicleGroup, GetVehicleGroupParameters(registro));
            }

            return resultadoValidacao;
        }

        public override string Edit(int id, VehicleGroup registro)
        {
            string resultadoValidacao = registro.Validate();

            List<VehicleGroup> grupoDeVeiculosRegistrados = SelectAll();
            foreach (VehicleGroup grupo in grupoDeVeiculosRegistrados)
            {
                if (id != grupo.Id && registro.Name == grupo.Name)
                    resultadoValidacao = "O nome do grupo de veículos deve ser único\n";
            }

            if (resultadoValidacao == "VALID")
            {
                registro.Id = id;
                Db.Update(sqlUpdateVehicleGroup, GetVehicleGroupParameters(registro));
            }

            return resultadoValidacao;
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

        private Dictionary<string, object> GetVehicleGroupParameters(VehicleGroup grupoDeVeiculos)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", grupoDeVeiculos.Id);
            parametros.Add("NOME", grupoDeVeiculos.Name);
            parametros.Add("TAXAPLANODIARIO", grupoDeVeiculos.DailyPlanRate);
            parametros.Add("TAXAPORKMDIARIO", grupoDeVeiculos.DailyPerKmRate);
            parametros.Add("TAXAPLANOCONTROLADO", grupoDeVeiculos.ControlledPlanRate);
            parametros.Add("LIMITEKMCONTROLADO", grupoDeVeiculos.ControlledKmLimit);
            parametros.Add("TAXAKMEXCEDIDOCONTROLADO", grupoDeVeiculos.ControlledExceededKmRate);
            parametros.Add("TAXAPLANOLIVRE", grupoDeVeiculos.UnlimitedPlanRate);

            return parametros;
        }

        private VehicleGroup ConvertToVehicleGroup(IDataReader reader)
        {
            int id = Convert.ToInt32(reader["ID"]); ;
            string nome = Convert.ToString(reader["NOME"]); ;
            double taxaPlanoDiario = Convert.ToDouble(reader["TAXAPLANODIARIO"]);
            double taxaPorKmDiario = Convert.ToDouble(reader["TAXAPORKMDIARIO"]);
            double taxaPlanoControlado = Convert.ToDouble(reader["TAXAPLANOCONTROLADO"]);
            int limiteKmControlado = Convert.ToInt32(reader["LIMITEKMCONTROLADO"]);
            double taxaKmExcedidoControlado = Convert.ToDouble(reader["TAXAKMEXCEDIDOCONTROLADO"]);
            double taxaPlanoLivre = Convert.ToDouble(reader["TAXAPLANOLIVRE"]);

            VehicleGroup grupoDeVeiculos = new VehicleGroup(id, nome, taxaPlanoDiario, taxaPorKmDiario, taxaPlanoControlado,
                limiteKmControlado, taxaKmExcedidoControlado,taxaPlanoLivre);

            return grupoDeVeiculos;
        }
    }
}

using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleGroupModule;
using System;
using System.Collections.Generic;
using System.Data;

namespace CarRental.Controllers.GrupoDeVeiculosModule
{
    public class ControladorGrupoDeVeiculos : Controller<VehicleGroup>
    {
        private const string sqlInserirGrupoDeVeiculos =
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

        private const string sqlEditarGrupoDeVeiculos =
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

        private const string sqlExcluirGrupoDeVeiculos =
                @"DELETE FROM TBGRUPOVEICULO  WHERE [ID] = @ID;";

        private const string sqlSelecionarGrupoDeVeiculosPorId =
                @"SELECT * FROM TBGRUPOVEICULO WHERE [ID] = @ID;";

        private const string sqlSelecionarTodosGrupoDeVeiculoss =
                @"SELECT * FROM TBGRUPOVEICULO;";

        private const string sqlExisteGrupoDeVeiculos =
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

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirGrupoDeVeiculos, ObtemParametrosGrupoDeVeiculos(registro));
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

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarGrupoDeVeiculos, ObtemParametrosGrupoDeVeiculos(registro));
            }

            return resultadoValidacao;
        }

        public override bool Delete(int id)
        {
            try
            {
                Db.Delete(sqlExcluirGrupoDeVeiculos, AddParameter("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public override bool Exists(int id)
        {
            return Db.Exists(sqlExisteGrupoDeVeiculos, AddParameter("ID", id));
        }

        public override VehicleGroup SelectById(int id)
        {
            return Db.Get(sqlSelecionarGrupoDeVeiculosPorId, ConverterEmGrupoDeVeiculos, AddParameter("ID", id));
        }

        public override List<VehicleGroup> SelectAll()
        {
            return Db.GetAll(sqlSelecionarTodosGrupoDeVeiculoss, ConverterEmGrupoDeVeiculos);
        }

        private Dictionary<string, object> ObtemParametrosGrupoDeVeiculos(VehicleGroup grupoDeVeiculos)
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

        private VehicleGroup ConverterEmGrupoDeVeiculos(IDataReader reader)
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

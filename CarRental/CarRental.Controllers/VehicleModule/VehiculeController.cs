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
    public class VehiculeController : Controller<Vehicle>
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
        public override string InsertNew(Vehicle registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = Db.Insert(sqlInsertVehicle, GetVehicleParameters(registro));
                if (registro.images != null)
                {
                    foreach (VehicleImage imagemVeiculo in registro.images)
                    {
                        imagemVeiculo.VehicleId = registro.Id;
                        imageController.InsertNew(imagemVeiculo);
                    }
                }
            }
            return resultadoValidacao;
        }
        public override List<Vehicle> SelectAll()
        {
            List<Vehicle>veiculos = Db.GetAll(sqlSelectAllVehicles, ConvertToVehicle);

            foreach (Vehicle veiculo in veiculos)
            {
                veiculo.images = imageController.SelectAllImagesOfVehicle(veiculo.Id);
            }

            return veiculos;
        }
        public override Vehicle SelectById(int id)
        {
            Vehicle veiculo = Db.Get(sqlSelectVehicleById, ConvertToVehicle, AddParameter("ID", id));
            veiculo.images = imageController.SelectAllImagesOfVehicle(id);
            return veiculo;
        }
        public override string Edit(int id, Vehicle registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditVehicle, GetVehicleParameters(registro));
                foreach (VehicleImage imagem in registro.images)
                    imagem.VehicleId = registro.Id;
                imageController.EditList(registro.images);
            }

            return resultadoValidacao;
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

        private Dictionary<string, object> GetVehicleParameters(Vehicle veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("MODELO", veiculo.model);
            parametros.Add("ID_GRUPOVEICULO", veiculo.vehicleGroup.Id);
            parametros.Add("PLACA", veiculo.licensePlate);
            parametros.Add("CHASSI", veiculo.chassis);
            parametros.Add("MARCA", veiculo.brand);
            parametros.Add("COR", veiculo.color);
            parametros.Add("TIPOCOMBUSTIVEL", veiculo.fuelType);
            parametros.Add("CAPACIDADETANQUE", veiculo.tankCapacity);
            parametros.Add("ANO", veiculo.year);
            parametros.Add("KILOMETRAGEM", veiculo.mileage);
            parametros.Add("NUMEROPORTAS", veiculo.numberOfDoors);
            parametros.Add("CAPACIDADEPESSOAS", veiculo.passengerCapacity);
            parametros.Add("TAMANHOPORTAMALA", veiculo.trunkSize);
            parametros.Add("TEMARCONDICIONADO", veiculo.hasAirConditioning);
            parametros.Add("TEMDIRECAOHIDRAULICA", veiculo.hasPowerSteering);
            parametros.Add("TEMFREIOSABS", veiculo.hasAbsBrakes);
            parametros.Add("ESTAALUGADO", veiculo.isRented);

            return parametros;
        }

        private Vehicle ConvertToVehicle(IDataReader reader)
        {
            var id = Convert.ToInt32(reader["ID"]);
            var modelo = Convert.ToString(reader["MODELO"]);
            var id_grupoveiculo = Convert.ToInt32(reader["ID_GRUPOVEICULO"]);
            var placa = Convert.ToString(reader["PLACA"]);
            var chassi = Convert.ToString(reader["CHASSI"]);
            var marca = Convert.ToString(reader["MARCA"]);
            var cor = Convert.ToString(reader["COR"]);
            var tipoCombustivel = Convert.ToString(reader["TIPOCOMBUSTIVEL"]);
            var capacidadeTanque = Convert.ToDouble(reader["capacidadeTanque"]);
            var ano = Convert.ToInt32(reader["ANO"]);
            var quilometragem = Convert.ToDouble(reader["KILOMETRAGEM"]);
            var numeroPortas = Convert.ToInt32(reader["NUMEROPORTAS"]);
            var capacidadePessoas = Convert.ToInt32(reader["CAPACIDADEPESSOAS"]);
            var tamanhoPortaMala = Convert.ToChar(reader["TAMANHOPORTAMALA"]);
            var temArCondicionado = Convert.ToBoolean(reader["TEMARCONDICIONADO"]);
            var temDirecaoHidraulica = Convert.ToBoolean(reader["TEMDIRECAOHIDRAULICA"]);
            var temFreioAbs = Convert.ToBoolean(reader["TEMFREIOSABS"]);
            var estaAlugado = Convert.ToBoolean(reader["ESTAALUGADO"]);

            string nome = Convert.ToString(reader["NOME"]); ;
            double taxaPlanoDiario = Convert.ToDouble(reader["TAXAPLANODIARIO"]);
            double taxaPorKmDiario = Convert.ToDouble(reader["TAXAPORKMDIARIO"]);
            double taxaPlanoControlado = Convert.ToDouble(reader["TAXAPLANOCONTROLADO"]);
            int limiteKmControlado = Convert.ToInt32(reader["LIMITEKMCONTROLADO"]);
            double taxaKmExcedidoControlado = Convert.ToDouble(reader["TAXAKMEXCEDIDOCONTROLADO"]);
            double taxaPlanoLivre = Convert.ToDouble(reader["TAXAPLANOLIVRE"]);

            VehicleGroup grupo = new VehicleGroup(id_grupoveiculo, nome, taxaPlanoDiario, taxaPorKmDiario, taxaPlanoControlado, limiteKmControlado, taxaKmExcedidoControlado, taxaPlanoLivre);

            Vehicle veiculo = new Vehicle(id, modelo, grupo, placa, chassi, marca, cor, tipoCombustivel, capacidadeTanque, ano, quilometragem, numeroPortas, capacidadePessoas, tamanhoPortaMala, temArCondicionado, temDirecaoHidraulica, temFreioAbs, estaAlugado,null);

            veiculo.Id = id;

            return veiculo;
        }
        private int ConvertData(IDataReader reader)
        {
            return Convert.ToInt32(reader["qtd"]);
        }
    }
}

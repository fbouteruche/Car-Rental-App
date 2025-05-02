using CarRental.Controllers.Shared;
using CarRental.Domain.GrupoDeVeiculosModule;
using CarRental.Domain.ImagemVeiculoModule;
using CarRental.Controllers.ImagemVeiculoModule;
using CarRental.Domain.VeiculoModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

namespace CarRental.Controllers.VeiculoModule
{
    public class ControladorVeiculo : Controlador<Vehicle>
    {
        private ControladorImagemVeiculo controladorImagem = new ControladorImagemVeiculo();
        #region queries
        private const string sqlInserirVeiculo =
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
        private const string sqlSelecionarTodosVeiculos =
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
        private const string sqlSelecionarVeiculoPorId =
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
        private const string sqlEditarVeiculo =
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
        private const string sqlDeletarVeiculo =
            @"DELETE 
                FROM 
                TBVEICULO 
            WHERE 
                [ID] = @ID";
        private const string sqlExisteVeiculo =
            @"SELECT 
                COUNT(*) 
            FROM 
                [TBVEICULO]
            WHERE 
                [ID] = @ID";

        private const string sqlVeiculoTotal =
            @"SELECT COUNT(*) AS QTD FROM[TBVEICULO]";
        #endregion
        public override string InserirNovo(Vehicle registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = Db.Insert(sqlInserirVeiculo, ObtemParametrosVeiculo(registro));
                if (registro.images != null)
                {
                    foreach (ImagemVeiculo imagemVeiculo in registro.images)
                    {
                        imagemVeiculo.idVeiculo = registro.Id;
                        controladorImagem.InserirNovo(imagemVeiculo);
                    }
                }
            }
            return resultadoValidacao;
        }
        public override List<Vehicle> SelecionarTodos()
        {
            List<Vehicle>veiculos = Db.GetAll(sqlSelecionarTodosVeiculos, ConverterEmVeiculo);

            foreach (Vehicle veiculo in veiculos)
            {
                veiculo.images = controladorImagem.SelecioanrTodasImagensDeUmVeiculo(veiculo.Id);
            }

            return veiculos;
        }
        public override Vehicle SelecionarPorId(int id)
        {
            Vehicle veiculo = Db.Get(sqlSelecionarVeiculoPorId, ConverterEmVeiculo, AdicionarParametro("ID", id));
            veiculo.images = controladorImagem.SelecioanrTodasImagensDeUmVeiculo(id);
            return veiculo;
        }
        public override string Editar(int id, Vehicle registro)
        {
            string resultadoValidacao = registro.Validate();

            if (resultadoValidacao == "VALIDO")
            {
                registro.Id = id;
                Db.Update(sqlEditarVeiculo, ObtemParametrosVeiculo(registro));
                foreach (ImagemVeiculo imagem in registro.images)
                    imagem.idVeiculo = registro.Id;
                controladorImagem.EditarLista(registro.images);
            }

            return resultadoValidacao;
        }
        public override bool Excluir(int id)
        {
            try
            {
                Db.Delete(sqlDeletarVeiculo, AdicionarParametro("ID", id));
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
     
        public override bool Existe(int id)
        {
            return Db.Exists(sqlExisteVeiculo, AdicionarParametro("ID", id));
        }

        private Dictionary<string, object> ObtemParametrosVeiculo(Vehicle veiculo)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("ID", veiculo.Id);
            parametros.Add("MODELO", veiculo.model);
            parametros.Add("ID_GRUPOVEICULO", veiculo.vehicleGroup.Id);
            parametros.Add("PLACA", veiculo.licensePlate);
            parametros.Add("CHASSI", veiculo.chassis);
            parametros.Add("MARCA", veiculo.marca);
            parametros.Add("COR", veiculo.color);
            parametros.Add("TIPOCOMBUSTIVEL", veiculo.fuelType);
            parametros.Add("CAPACIDADETANQUE", veiculo.capacidadeTanque);
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

        private Vehicle ConverterEmVeiculo(IDataReader reader)
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

            GrupoDeVeiculo grupo = new GrupoDeVeiculo(id_grupoveiculo, nome, taxaPlanoDiario, taxaPorKmDiario, taxaPlanoControlado, limiteKmControlado, taxaKmExcedidoControlado, taxaPlanoLivre);

            Vehicle veiculo = new Vehicle(id, modelo, grupo, placa, chassi, marca, cor, tipoCombustivel, capacidadeTanque, ano, quilometragem, numeroPortas, capacidadePessoas, tamanhoPortaMala, temArCondicionado, temDirecaoHidraulica, temFreioAbs, estaAlugado,null);

            veiculo.Id = id;

            return veiculo;
        }
        private int ConverterDados(IDataReader reader)
        {
            return Convert.ToInt32(reader["qtd"]);
        }
    }
}

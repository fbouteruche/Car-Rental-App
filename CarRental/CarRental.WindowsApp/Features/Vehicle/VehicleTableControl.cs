using CarRental.Domain.VehicleModule;
using CarRental.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public partial class VehicleTableControl : UserControl
    {
        public VehicleTableControl()
        {
            InitializeComponent();
            gridVeiculos.ConfigureZebraGrid();
            gridVeiculos.ConfigureReadOnlyGrid();
            gridVeiculos.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "model", HeaderText = "Modelo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "vehicleGroup", HeaderText = "Grupo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "licensePlate", HeaderText = "Placa"},
                new DataGridViewTextBoxColumn { DataPropertyName = "marca", HeaderText = "Marca"},
                new DataGridViewTextBoxColumn { DataPropertyName = "color", HeaderText = "Cor"},
                new DataGridViewTextBoxColumn { DataPropertyName = "fuelType", HeaderText = "Combustivel"},
                new DataGridViewTextBoxColumn { DataPropertyName = "year", HeaderText = "Ano"},
                new DataGridViewTextBoxColumn { DataPropertyName = "numberOfDoors", HeaderText = "Qtd. Portas"},
                new DataGridViewTextBoxColumn { DataPropertyName = "passengerCapacity", HeaderText = "Cap. Pessoas"},
                new DataGridViewTextBoxColumn { DataPropertyName = "trunkSize", HeaderText = "Tam. Porta Malas"}
           };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Vehicle> veiculos)
        {
            gridVeiculos.Rows.Clear();

            foreach (Vehicle veiculo in veiculos)
                gridVeiculos.Rows.Add(veiculo.Id, veiculo.model, veiculo.vehicleGroup, veiculo.licensePlate, veiculo.brand, veiculo.color, veiculo.fuelType, veiculo.year, veiculo.numberOfDoors, veiculo.passengerCapacity, veiculo.trunkSize);
        }
    }
}

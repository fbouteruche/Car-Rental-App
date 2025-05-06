using CarRental.Domain.RentalModule;
using CarRental.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Rentals
{
    public partial class RentalTableControl : UserControl
    {
        public RentalTableControl()
        {
            InitializeComponent();
            gridLocacao.ConfigureZebraGrid();
            gridLocacao.ConfigureReadOnlyGrid();
            gridLocacao.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Vehicle", HeaderText = "Vehicle"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ContractingCustomer", HeaderText = "Customer"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn {DataPropertyName = "RentalPrice", HeaderText = "Value Inicial"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DepartureDate", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ExpectedReturnDate", HeaderText = "Devolução"}
           };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Rental> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (Rental locacao in locacoes)
            {
                gridLocacao.Rows.Add(locacao.Id, locacao.Vehicle, locacao.ContractingCustomer, locacao.DriverCustomer, locacao.RentalPrice,
                    locacao.DepartureDate, locacao.ExpectedReturnDate);
            }
        }
    }
}

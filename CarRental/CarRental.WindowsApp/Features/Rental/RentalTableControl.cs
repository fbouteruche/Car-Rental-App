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
            rentalGrid.ConfigureZebraGrid();
            rentalGrid.ConfigureReadOnlyGrid();
            rentalGrid.Columns.AddRange(GetColumns());
        }
        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Vehicle", HeaderText = "Vehicle"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ContractingCustomer", HeaderText = "Customer"},
                new DataGridViewTextBoxColumn { DataPropertyName = "DriverCustomer", HeaderText = "Driver"},
                new DataGridViewTextBoxColumn {DataPropertyName = "RentalPrice", HeaderText = "Initial Value"},
                new DataGridViewTextBoxColumn {DataPropertyName = "DepartureDate", HeaderText = "Rental Date"},
                new DataGridViewTextBoxColumn {DataPropertyName = "ExpectedReturnDate", HeaderText = "Return Date"}
           };

            return columns;
        }

        public int GetSelectedId()
        {
            return rentalGrid.SelectId<int>();
        }

        public void UpdateRecords(List<Rental> rentals)
        {
            rentalGrid.Rows.Clear();

            foreach (Rental rental in rentals)
            {
                rentalGrid.Rows.Add(rental.Id, rental.Vehicle, rental.ContractingCustomer, rental.DriverCustomer, rental.RentalPrice,
                    rental.DepartureDate, rental.ExpectedReturnDate);
            }
        }
    }
}

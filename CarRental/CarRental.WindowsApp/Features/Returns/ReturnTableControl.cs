using CarRental.Domain.RentalModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Returns
{
    public partial class ReturnTableControl : UserControl
    {
        public ReturnTableControl()
        {
            InitializeComponent();
            gridReturns.ConfigureZebraGrid();
            gridReturns.ConfigureReadOnlyGrid();
            gridReturns.Columns.AddRange(GetColumns());
        }
        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Model", HeaderText = "Model"},
                new DataGridViewTextBoxColumn { DataPropertyName = "LicensePlate", HeaderText = "License Plate"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ContractingCustomer", HeaderText = "Customer"},
                new DataGridViewTextBoxColumn { DataPropertyName = "RentalPrice", HeaderText = "Initial Price"},
                new DataGridViewTextBoxColumn { DataPropertyName = "IsOpen", HeaderText = "Active Rental"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ReturnPrice", HeaderText = "Final Price"},
                new DataGridViewTextBoxColumn {DataPropertyName = "ExpectedReturnDate", HeaderText = "Return"}
           };

            return columns;
        }

        public int GetSelectedId()
        {
            return gridReturns.SelectId<int>();
        }

        public void UpdateRecords(List<Rental> returns)
        {
            gridReturns.Rows.Clear();

            foreach (Rental returnRental in returns)
                gridReturns.Rows.Add(returnRental.Id, returnRental.Vehicle.model, returnRental.Vehicle.licensePlate, returnRental.ContractingCustomer.Name, returnRental.RentalPrice, returnRental.IsOpen, returnRental.ReturnPrice, returnRental.ExpectedReturnDate);
        }
    }
}

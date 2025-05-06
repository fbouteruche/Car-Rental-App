using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.Controllers.CustomersModule;
using CarRental.Domain.CustomerModule;
using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.CustomerModule
{
    public partial class CustomerTableControl : UserControl
    {
        private CustomerController customerController = null;
        public CustomerTableControl()
        {
            customerController = new CustomerController();
            InitializeComponent();
            gridCustomers.ConfigureZebraGrid();
            gridCustomers.ConfigureReadOnlyGrid();
            gridCustomers.Columns.AddRange(GetColumns());
        }

        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},
                new DataGridViewTextBoxColumn { DataPropertyName = "UniqueId", HeaderText = "Unique Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Address"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Phone", HeaderText = "Phone"},
                new DataGridViewTextBoxColumn {DataPropertyName = "Email", HeaderText = "Email"},
                new DataGridViewTextBoxColumn {DataPropertyName = "DriverLicense", HeaderText = "Driver License"},
                new DataGridViewTextBoxColumn {DataPropertyName = "LicenseExpiryDate", HeaderText = "License Expiry"},
                new DataGridViewTextBoxColumn {DataPropertyName = "IsPhysicalPerson", HeaderText = "Is Physical Person"}
           };
            return columns;
        }
        public int GetSelectedId()
        {
            return gridCustomers.SelectId<int>();
        }

        public void UpdateRecords()
        {
            var customers = customerController.SelectAll();
            LoadTable(customers);
        }

        private void LoadTable(List<Customer> customers)
        {
            gridCustomers.DataSource = customers;
        }
    }
}

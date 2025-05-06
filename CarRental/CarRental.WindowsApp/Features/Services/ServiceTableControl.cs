using CarRental.Domain.ServiceModule;
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

namespace CarRental.WindowsApp.Features.Services
{
    public partial class ServiceTableControl : UserControl
    {
        public ServiceTableControl()
        {
            InitializeComponent();
            gridServices.ConfigureZebraGrid();
            gridServices.ConfigureReadOnlyGrid();
            gridServices.Columns.AddRange(GetColumns());
        }

        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "IsChargedDaily", HeaderText = "Charged Daily"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Value"},
            };

            return columns;
        }

        public int GetSelectedId()
        {
            return gridServices.SelectId<int>();
        }

        public void UpdateRecords(List<Service> services)
        {
            gridServices.Rows.Clear();

            foreach (Service service in services)
            {
                gridServices.Rows.Add(service.Id, service.Name, service.IsChargedDaily, service.Value);
            }
        }
    }
}
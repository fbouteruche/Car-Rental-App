using CarRental.Domain.VehicleGroupModule;
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

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    public partial class VehicleGroupTableControl : UserControl
    {
        public VehicleGroupTableControl()
        {
            InitializeComponent();
            gridVehicleGroups.ConfigureZebraGrid();
            gridVehicleGroups.ConfigureReadOnlyGrid();
            gridVehicleGroups.Columns.AddRange(GetColumns());
        }

        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Group Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DailyPlanRate", HeaderText = "Daily Plan Rate"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DailyPerKmRate", HeaderText = "Daily Per Km Rate"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledPlanRate", HeaderText = "Controlled Plan Rate"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledKmLimit", HeaderText = "Controlled Km Limit"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledExceededKmRate", HeaderText = "Controlled Exceeded Km Rate"},

                new DataGridViewTextBoxColumn {DataPropertyName = "UnlimitedPlanRate", HeaderText = "Unlimited Plan Rate"}
           };

            return columns;
        }
        public int GetSelectedId()
        {
            return gridVehicleGroups.SelectId<int>();
        }

        public void UpdateRecords(List<VehicleGroup> vehicleGroups)
        {
            gridVehicleGroups.Rows.Clear();

            foreach (VehicleGroup group in vehicleGroups)
            {
                gridVehicleGroups.Rows.Add(group.Id, group.Name, group.DailyPlanRate, group.DailyPerKmRate, group.ControlledPlanRate,
                    group.ControlledKmLimit, group.ControlledExceededKmRate, group.UnlimitedPlanRate);
            }
        }
    }
}
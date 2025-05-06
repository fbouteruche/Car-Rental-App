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
            dataGridVehicles.ConfigureZebraGrid();
            dataGridVehicles.ConfigureReadOnlyGrid();
            dataGridVehicles.Columns.AddRange(GetColumns());
        }
        public DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},
                new DataGridViewTextBoxColumn { DataPropertyName = "model", HeaderText = "Model"},
                new DataGridViewTextBoxColumn { DataPropertyName = "vehicleGroup", HeaderText = "Group"},
                new DataGridViewTextBoxColumn { DataPropertyName = "licensePlate", HeaderText = "License Plate"},
                new DataGridViewTextBoxColumn { DataPropertyName = "brand", HeaderText = "Brand"},
                new DataGridViewTextBoxColumn { DataPropertyName = "color", HeaderText = "Color"},
                new DataGridViewTextBoxColumn { DataPropertyName = "fuelType", HeaderText = "Fuel Type"},
                new DataGridViewTextBoxColumn { DataPropertyName = "year", HeaderText = "Year"},
                new DataGridViewTextBoxColumn { DataPropertyName = "numberOfDoors", HeaderText = "No. Doors"},
                new DataGridViewTextBoxColumn { DataPropertyName = "passengerCapacity", HeaderText = "Passenger Cap."},
                new DataGridViewTextBoxColumn { DataPropertyName = "trunkSize", HeaderText = "Trunk Size"}
           };

            return columns;
        }
        public int GetSelectedId()
        {
            return dataGridVehicles.SelectId<int>();
        }

        public void UpdateRecords(List<Vehicle> vehicles)
        {
            dataGridVehicles.Rows.Clear();

            foreach (Vehicle vehicle in vehicles)
                dataGridVehicles.Rows.Add(vehicle.Id, vehicle.model, vehicle.vehicleGroup, vehicle.licensePlate, vehicle.brand, vehicle.color, vehicle.fuelType, vehicle.year, vehicle.numberOfDoors, vehicle.passengerCapacity, vehicle.trunkSize);
        }
    }
}

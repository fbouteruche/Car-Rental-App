using CarRental.Domain.VehicleModule;
using System;
using System.IO;
using System.Windows.Forms;
using CarRental.Controllers.VehicleGroupModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.VehicleImageModule;
using CarRental.WindowsApp.Features.VehicleImages;
using System.Collections.Generic;
using System.Drawing;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public partial class VehicleForm : Form
    {
        private Vehicle vehicle;
        private VehicleGroupController vehicleGroupController = new VehicleGroupController();
        public VehicleForm(string title)
        {            
            InitializeComponent();
            LoadVehicleGroups();
            labelTitle.Text = title;
            cBoxTrunkSize.SelectedIndex = 0;           
        }
        public List<VehicleImage> vehicleImages = new List<VehicleImage>();

        private void LoadVehicleGroups()
        {
            cBoxGroup.DataSource = vehicleGroupController.SelectAll();
        }

        public Vehicle Vehicle
        {
            get { return vehicle; }

            set
            {
                vehicle = value;

                vehicleImages = vehicle.images;
                textId.Text = vehicle.Id.ToString();
                textModel.Text = vehicle.model;
                cBoxGroup.Text = vehicle.vehicleGroup.Name;
                textLicensePlate.Text = vehicle.licensePlate;
                textChassis.Text = vehicle.chassis;
                textBrand.Text = vehicle.brand;
                textColor.Text = vehicle.color;
                cBoxFuelType.Text = vehicle.fuelType;
                numUpDownTankCapacity.Text = vehicle.tankCapacity.ToString();
                textYear.Text = vehicle.year.ToString();
                textMileage.Text = vehicle.mileage.ToString();
                numUpDownNoDoors.Text = vehicle.numberOfDoors.ToString();
                numUpDownPassengerCap.Text = vehicle.passengerCapacity.ToString();
                cBoxTrunkSize.Text = vehicle.trunkSize.ToString();
                if (vehicle.hasAirConditioning)
                    checkedListBoxOptionals.SetItemChecked(0, true);
                if (vehicle.hasPowerSteering)
                    checkedListBoxOptionals.SetItemChecked(1, true);
                if (vehicle.hasAbsBrakes)
                    checkedListBoxOptionals.SetItemChecked(2, true);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = 0;
            int year = 0;
            VehicleGroup vehicleGroup = null;
            if (textId.Text.Length > 0)
                id = Convert.ToInt32(textId.Text);            
            string licensePlate = textLicensePlate.Text;
            string chassis = textChassis.Text;
            string brand = textBrand.Text;
            string model = textModel.Text;
            if(textYear.Text.Length > 0)
                year = Convert.ToInt32(textYear.Text);
            string color = textColor.Text;
            vehicleGroup = cBoxGroup.SelectedItem as VehicleGroup;
            int tankCapacity = Convert.ToInt32(numUpDownTankCapacity.Value);
            string fuelType = cBoxFuelType.Text;
            int noDoors = Convert.ToInt32(numUpDownNoDoors.Value);
            int passengerCap = Convert.ToInt32(numUpDownPassengerCap.Value);
            double mileage = Convert.ToDouble(textMileage.Text);
            char trunkSize = Convert.ToChar(cBoxTrunkSize.Text[0]);
            bool hasAirConditioning = false;
            bool hasPowerSteering = false;
            bool hasAbsBrakes = false;
            List<VehicleImage> images = vehicleImages;

            if (checkedListBoxOptionals.CheckedIndices.Contains(0))
                hasAirConditioning = true;
            if (checkedListBoxOptionals.CheckedIndices.Contains(1))
                hasPowerSteering = true;
            if (checkedListBoxOptionals.CheckedIndices.Contains(2))
                hasAbsBrakes = true;

            vehicle = new Vehicle(id, model, vehicleGroup, licensePlate, chassis, brand, color, fuelType, tankCapacity, year, mileage, noDoors, passengerCap, trunkSize, hasAirConditioning, hasPowerSteering, hasAbsBrakes, false, vehicleImages);

            string validationResult = vehicle.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();

                MainForm.Instance.UpdateFooter(firstError);

                DialogResult = DialogResult.None;
            }
        }

        private void textYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (textYear.Text.IndexOf(".") >= 0 || textYear.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (textMileage.Text.IndexOf(".") >= 0 || textMileage.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void btnImage_Click(object sender, EventArgs e)
        {
            VehicleImageForm imageForm = new VehicleImageForm(this);
            imageForm.Show();
        }

        public void UpdateImageList(List<VehicleImage> images)
        {
            this.vehicleImages = images;
        }
    }
}

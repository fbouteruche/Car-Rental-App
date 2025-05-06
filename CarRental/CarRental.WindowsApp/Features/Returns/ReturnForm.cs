using CarRental.Controllers.VehicleModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.Shared;
using CarRental.Domain.VehicleModule;
using CarRental.WindowsApp.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Returns
{
    public partial class ReturnForm : Form
    {
        private Rental returnRental;
        ServiceSelectionForm serviceForm;
        VehicleController vehicleController = new VehicleController();
        public ReturnForm(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
            cbxTankAmount.SelectedIndex = 0;
            serviceForm = new ServiceSelectionForm();
        }

        public Rental Return
        {
            get { return returnRental; }

            set
            {
                returnRental = value;

                txtId.Text = returnRental.Id.ToString();
                txtInitialKm.Text = returnRental.Vehicle.mileage.ToString();
                txtVehicle.Text = returnRental.Vehicle.model;
                txtEmployee.Text = returnRental.RentingEmployee.Name;
                txtCustomer.Text = returnRental.ContractingCustomer.Name;
                txtDriver.Text = returnRental.DriverCustomer.Name;
                txtPlan.Text = returnRental.PlanType;
                txtRentalDate.Text = returnRental.DepartureDate.ToString();
                txtReturnDate.Text = returnRental.ExpectedReturnDate.ToString();
                dtpReturn.Value = returnRental.ExpectedReturnDate;
                txtInitialValue.Text = returnRental.RentalPrice.ToString();
                serviceForm.InitializeFields(Return.Services, returnRental.InsuranceType, false);
                UpdateListBox();
            }
        }

        #region Button Events
        private void btnSelectServices_Click(object sender, EventArgs e)
        {
            serviceForm.InitializeFields(Return.Services, returnRental.InsuranceType, false);
            Return.Services.Clear();
            if (serviceForm.ShowDialog() == DialogResult.OK)
            {
                Return.Services = serviceForm.selectedServices;
                UpdateListBox();
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dtpReturn.Value <= returnRental.DepartureDate)
            {
                MainForm.Instance.UpdateFooter("Return date is earlier than rental date");
                DialogResult = DialogResult.None;
            }
            else
            {
                double fuelPrice = GetFuelPrice();
                Return.CloseRental(dtpReturn.Value, fuelPrice, Convert.ToDouble(txtFinalKm.Text));

                string validationResult = Return.Validate();
                Vehicle updatedVehicle = returnRental.Vehicle;
                vehicleController.Edit(returnRental.Vehicle.Id, updatedVehicle);

                if (validationResult != "VALID")
                {
                    string firstError = new StringReader(validationResult).ReadLine();
                    MainForm.Instance.UpdateFooter(firstError);
                    DialogResult = DialogResult.None;
                }
            }
        }

        private double GetFuelPrice()
        {
            double tankPercentage = 0;
            switch (cbxTankAmount.SelectedItem.ToString())
            {
                case "1/4":
                    tankPercentage = 0.25;
                    break;
                case "1/2":
                    tankPercentage = 0.5;
                    break;
                case "3/4":
                    tankPercentage = 0.75;
                    break;
                case "1/1":
                    tankPercentage = 1;
                    break;
            }
            if (!double.TryParse(txtFuelValue.Text, out double pricePerLiter))
                pricePerLiter = 0;
            double fuelPrice = CalculateRental.CalculateFuelDifference(Return.Vehicle.tankCapacity, tankPercentage, pricePerLiter);
            return fuelPrice;
        }
        #endregion

        #region Tank RadioButton and ComboBox
        private void cbxTankAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTankAmount.SelectedIndex == 0)
                rbtnEmpty.Checked = true;
            else if (cbxTankAmount.SelectedIndex == 1)
                rbtnQuarter.Checked = true;
            else if (cbxTankAmount.SelectedIndex == 2)
                rbtnHalf.Checked = true;
            else if (cbxTankAmount.SelectedIndex == 3)
                rbtnThreeQuarters.Checked = true;
            else if (cbxTankAmount.SelectedIndex == 4)
                rbtnFull.Checked = true;

            if (Return != null)
                SimulateReturnCalculation();
        }

        private void rbtnEmpty_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnEmpty.Checked)
                cbxTankAmount.SelectedIndex = 0;
        }

        private void rbtnQuarter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnQuarter.Checked)
                cbxTankAmount.SelectedIndex = 1;
        }

        private void rbtnHalf_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHalf.Checked)
                cbxTankAmount.SelectedIndex = 2;
        }

        private void rbtnThreeQuarters_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnThreeQuarters.Checked)
                cbxTankAmount.SelectedIndex = 3;
        }

        private void rbtnFull_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnFull.Checked)
                cbxTankAmount.SelectedIndex = 4;
        }
        #endregion

        #region Validation for Numeric Input
        private void txtFuelValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtFuelValue.Text.IndexOf(".") >= 0 || txtFuelValue.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            SimulateReturnCalculation();
        }
        private void txtFinalKm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtFinalKm.Text.IndexOf(".") >= 0 || txtFinalKm.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

            SimulateReturnCalculation();
        }

        private void dtpReturn_ValueChanged(object sender, EventArgs e)
        {
            SimulateReturnCalculation();
        }
        #endregion

        #region Update List
        private void UpdateListBox()
        {
            if (string.IsNullOrEmpty(txtFinalKm.Text))
                txtFinalKm.Text = "0";
            if (string.IsNullOrEmpty(txtFuelValue.Text))
                txtFuelValue.Text = "0";
            if (Return.Services != null)
            {
                clbSelectedServices.Items.Clear();
                int i = 0;
                foreach (Service service in Return.Services)
                {
                    clbSelectedServices.Items.Add(service);
                    clbSelectedServices.SetItemChecked(i++, true);
                }
            }
            SimulateReturnCalculation();
        }
        #endregion

        private void SimulateReturnCalculation()
        {
            if (!double.TryParse(txtInitialValue.Text, out double returnPrice))
                returnPrice = 0;
            if (!double.TryParse(txtFinalKm.Text, out double kilometersDriven))
                returnPrice = 0;

            returnPrice += GetFuelPrice();
            returnPrice += CalculateRental.CalculatePlan(Return.PlanType, Return.Vehicle.vehicleGroup, kilometersDriven, Return.DepartureDate, dtpReturn.Value);
            returnPrice += CalculateRental.CalculateServices(Return.Services, Return.DepartureDate, dtpReturn.Value);
            returnPrice += CalculateRental.CalculateLateReturnFee(Return.ReturnPrice, Return.ExpectedReturnDate, Return.ReturnDate);
            returnPrice -= CalculateRental.CalculateDiscountCoupon(returnPrice, Return.Coupon);
            txtTotalValue.Text = Math.Round(returnPrice, 2).ToString();
        }
    }
}

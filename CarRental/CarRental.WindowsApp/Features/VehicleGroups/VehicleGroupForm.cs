using CarRental.Domain.VehicleGroupModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    public partial class VehicleGroupForm : Form
    {
        private VehicleGroup vehicleGroup;
        public VehicleGroupForm(string title)
        {
            InitializeComponent();
            this.Text = title;
            lblVehicleGroupRegistration.Text = title;
        }

        public VehicleGroup VehicleGroup
        {
            get { return vehicleGroup; }

            set
            {
                vehicleGroup = value;

                textId.Text = vehicleGroup.Id.ToString();
                textGroupName.Text = vehicleGroup.Name;
                txtDailyPlanRate.Text = vehicleGroup.DailyPlanRate.ToString();
                txtDailyPerKmRate.Text = vehicleGroup.DailyPerKmRate.ToString();
                txtControlledPlanRate.Text = vehicleGroup.ControlledPlanRate.ToString();
                txtControlledKmLimit.Text = vehicleGroup.ControlledKmLimit.ToString();
                txtControlledExceededKmRate.Text = vehicleGroup.ControlledExceededKmRate.ToString();
                txtUnlimitedPlanRate.Text = vehicleGroup.UnlimitedPlanRate.ToString();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textId.Text);
            string name = textGroupName.Text;
            double dailyPlanRate = 0;
            double dailyPerKmRate = 0;
            double controlledPlanRate = 0;
            int controlledKmLimit = 0;
            double controlledExceededKmRate = 0;
            double unlimitedPlanRate = 0;
            if (txtDailyPlanRate.Text.Length > 0)
                dailyPlanRate = Convert.ToDouble(txtDailyPlanRate.Text, CultureInfo.InvariantCulture);
            if (txtDailyPerKmRate.Text.Length > 0)
                dailyPerKmRate = Convert.ToDouble(txtDailyPerKmRate.Text, CultureInfo.InvariantCulture);
            if (txtControlledPlanRate.Text.Length > 0)
                controlledPlanRate = Convert.ToDouble(txtControlledPlanRate.Text, CultureInfo.InvariantCulture);
            if (txtControlledKmLimit.Text.Length > 0)
                controlledKmLimit = Convert.ToInt32(txtControlledKmLimit.Text);
            if (txtControlledExceededKmRate.Text.Length > 0)
                controlledExceededKmRate = Convert.ToDouble(txtControlledExceededKmRate.Text, CultureInfo.InvariantCulture);
            if (txtUnlimitedPlanRate.Text.Length > 0)
                unlimitedPlanRate = Convert.ToDouble(txtUnlimitedPlanRate.Text, CultureInfo.InvariantCulture);

            vehicleGroup = new VehicleGroup(id, name, dailyPlanRate, dailyPerKmRate, controlledPlanRate, controlledKmLimit, controlledExceededKmRate, unlimitedPlanRate);

            string validationResult = vehicleGroup.Validate();

            if (validationResult != "VALID")
            {
                string error = new StringReader(validationResult).ReadLine();

                MainForm.Instance.UpdateFooter(error);

                DialogResult = DialogResult.None;
            }
        }

        private void txtDailyPlanRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtDailyPlanRate.Text.IndexOf(".") >= 0 || txtDailyPlanRate.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtDailyPerKmRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtDailyPerKmRate.Text.IndexOf(".") >= 0 || txtDailyPerKmRate.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtControlledPlanRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtControlledPlanRate.Text.IndexOf(".") >= 0 || txtControlledPlanRate.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtControlledKmLimit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtControlledExceededKmRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtControlledExceededKmRate.Text.IndexOf(".") >= 0 || txtControlledExceededKmRate.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void txtUnlimitedPlanRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtUnlimitedPlanRate.Text.IndexOf(".") >= 0 || txtUnlimitedPlanRate.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}

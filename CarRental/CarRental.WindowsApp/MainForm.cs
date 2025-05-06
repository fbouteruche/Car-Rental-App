using CarRental.Controllers.CouponModule;
using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.Controllers.PartnerModule;
using CarRental.Controllers.RentalModule;
using CarRental.Controllers.ServiceModule;
using CarRental.Controllers.VehicleGroupModule;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.EmployeeModule;
using CarRental.WindowsApp.CustomerModule;
using CarRental.WindowsApp.Features.Coupons;
using CarRental.WindowsApp.Features.Customers;
using CarRental.WindowsApp.Features.Dashboards;
using CarRental.WindowsApp.Features.Returns;
using CarRental.WindowsApp.Features.Employees;
using CarRental.WindowsApp.Features.VehicleGroups;
using CarRental.WindowsApp.Features.Rentals;
using CarRental.WindowsApp.Features.Partners;
using CarRental.WindowsApp.Features.Services;
using CarRental.WindowsApp.Features.Vehicles;
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

namespace CarRental.WindowsApp
{
    public partial class MainForm : Form
    {
        private IRecordable operations;
        public static MainForm Instance;

        public MainForm()
        {
            InitializeComponent();

            Instance = this;
            ShowDashboard();
        }

        #region Menu strip options
        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmployeeConfigurationToolbox configuration = new EmployeeConfigurationToolbox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new EmployeeOperation(new EmployeeController());

            ConfigureRecordsPanel();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceConfigurationToolBox configuration = new ServiceConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new ServiceOperation(new ServiceController());

            ConfigureRecordsPanel();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerConfigurationToolBox configuration = new CustomerConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new CustomerOperation(new CustomerController());

            ConfigureRecordsPanel();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleConfigurationToolBox configuration = new VehicleConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new VehicleOperation(new VehicleController());

            ConfigureRecordsPanel();
        }

        private void vehicleGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleGroupConfigurationToolBox configuration = new VehicleGroupConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new VehicleGroupOperation(new VehicleGroupController());

            ConfigureRecordsPanel();
        }
        private void rentalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RentalConfigurationToolBox configuration = new RentalConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new RentalOperation(new RentalController(new VehicleController(), new EmployeeController(), new CustomerController(), new ServiceController(), new CouponController()));

            ConfigureRecordsPanel();
        }

        private void returnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnConfigurationToolBox configuration = new ReturnConfigurationToolBox();

            ConfigureToolBox(configuration, true);
            btnAdd.Image = Properties.Resources.car_32px;

            UpdateFooter(configuration.RegistrationType);

            operations = new ReturnOperation(new RentalController(new VehicleController(), new EmployeeController(), new CustomerController(), new ServiceController(), new CouponController()));

            ConfigureRecordsPanel();
        }

        private void couponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CouponConfigurationToolBox configuration = new CouponConfigurationToolBox();

            ConfigureToolBox(configuration, false);

            UpdateFooter(configuration.RegistrationType);

            operations = new CouponOperations(new CouponController());

            ConfigureRecordsPanel();
        }

        private void partnersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PartnerConfigurationToolBox configuration = new PartnerConfigurationToolBox();

            ConfigureToolBox(configuration, false);
            btnAdd.Image = Properties.Resources._36x1;

            UpdateFooter(configuration.RegistrationType);

            operations = new PartnerOperation(new PartnerController());

            ConfigureRecordsPanel();
        }
        #endregion

        #region Button actions
        private void btnAdd_Click(object sender, EventArgs e)
        {
            operations.InsertNewRecord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            operations.EditRecord();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            operations.DeleteRecord();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            operations.FilterRecords();
        }
        #endregion

        #region Private methods
        private void ConfigureRecordsPanel()
        {
            UserControl table = operations.GetTable();

            table.Dock = DockStyle.Fill;

            recordsPanel.Controls.Clear();

            recordsPanel.Controls.Add(table);
        }

        private void ConfigureDashboardPanel()
        {
            UserControl table = new DashboardControl();
            table.Dock = DockStyle.Fill;
            recordsPanel.Controls.Clear();
            recordsPanel.Controls.Add(table);
        }

        private void ConfigureToolBox(IConfigurationToolBox configuration, bool canFilter)
        {
            toolBoxActions.Enabled = true;
            if (canFilter)
                btnFilter.Enabled = true;
            else
                btnFilter.Enabled = false;
            labelRecordType.Text = configuration.RegistrationType;
            btnAdd.ToolTipText = configuration.AddToolTip;
            btnEdit.ToolTipText = configuration.EditToolTip;
            btnDelete.ToolTipText = configuration.DeleteToolTip;
        }
        #endregion

        public void UpdateFooter(string message) { labelFooter.Text = message; }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDashboard();
        }
        private void ShowDashboard()
        {
            ConfigurationDashboardToolBox configuration = new ConfigurationDashboardToolBox();
            ConfigureToolBox(configuration, false);
            toolBoxActions.Enabled = false;
            UpdateFooter(configuration.RegistrationType);
            ConfigureDashboardPanel();
        }
    }
}

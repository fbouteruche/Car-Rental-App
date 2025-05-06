using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.CouponModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
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

namespace CarRental.WindowsApp.Features.Rentals
{
    public partial class RentalForm : Form
    {
        private Rental rental;
        private EmployeeController employeeController = new EmployeeController();
        private VehicleController vehicleController = new VehicleController();
        private CustomerController customerController = new CustomerController();
        private CouponController couponController = new CouponController();
        public List<Service> Services;
        public string InsuranceType = "None";
        ServiceSelectionForm serviceForm = new ServiceSelectionForm();
        public RentalForm(string title)
        {
            Services = new List<Service>();
            InitializeComponent();
            lblTitle.Text = title;
            LoadData();
            LoadDrivers();
            cBoxPlan.SelectedIndex = 0;
        }

        public Rental Rental
        {
            get { return rental; }

            set
            {
                rental = value;

                txtId.Text = rental.Id.ToString();
                cBoxVehicle.SelectedItem = rental.Vehicle;
                cBoxEmployee.SelectedItem = rental.RentingEmployee;
                cBoxCustomer.SelectedItem = rental.ContractingCustomer;
                cBoxDriver.SelectedItem = rental.DriverCustomer;
                cBoxPlan.SelectedItem = rental.PlanType;
                dateTPDepartureDate.Text = rental.DepartureDate.ToLongDateString();
                dateTPReturnDate.Text = rental.ExpectedReturnDate.ToLongDateString();
                txtTotal.Text = rental.RentalPrice.ToString();
                Services = rental.Services;
                InsuranceType = rental.InsuranceType;
            }
        }

        private void LoadData()
        {
            cBoxEmployee.DataSource = employeeController.SelectAll();
            List<Vehicle> availableVehicles = new List<Vehicle>();
            if (lblTitle.Text.Contains("Edit"))
                availableVehicles = vehicleController.SelectAll();
            else
                AddOnlyAvailableVehicles(availableVehicles);
            cBoxVehicle.DataSource = availableVehicles;
            cBoxCustomer.DataSource = customerController.SelectAll();
        }

        private void AddOnlyAvailableVehicles(List<Vehicle> availableVehicles)
        {
            foreach (Vehicle item in vehicleController.SelectAll())
                if (!item.isRented)
                    availableVehicles.Add(item);
        }

        private void LoadDrivers()
        {
            List<Customer> physicalCustomers = new List<Customer>();
            foreach (Customer customer in customerController.SelectAll())
                if (customer.IsPhysicalPerson)
                    physicalCustomers.Add(customer);
            cBoxDriver.DataSource = physicalCustomers;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string planType = cBoxPlan.Text.Replace(" ", "");
            Vehicle vehicle = cBoxVehicle.SelectedItem as Vehicle;
            Domain.EmployeeModule.Employee rentingEmployee = cBoxEmployee.SelectedItem as Domain.EmployeeModule.Employee;
            Customer contractingCustomer = cBoxCustomer.SelectedItem as Customer;
            Customer driver = cBoxDriver.SelectedItem as Customer;
            DateTime departureDate = dateTPDepartureDate.Value;
            DateTime expectedReturnDate = dateTPReturnDate.Value;
            string insuranceType = "None";
            if (serviceForm.insurance.Length > 0)
                insuranceType = serviceForm.insurance;
            Coupon coupon = null;
            bool exists = couponController.CodeExists(txtCoupon.Text);
            if (exists)
            {
                coupon = couponController.SelectByCode(txtCoupon.Text);
                if (coupon.ExpirationDate < DateTime.Now)
                    coupon = null;
            }

            rental = new Rental(id, vehicle, rentingEmployee, contractingCustomer, driver, coupon, departureDate, expectedReturnDate, planType, insuranceType, Services);
            Vehicle updatedVehicle = rental.Vehicle;
            vehicleController.Edit(rental.Vehicle.Id, updatedVehicle);
            string validationResult = rental.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();
                MainForm.Instance.UpdateFooter(firstError);
                DialogResult = DialogResult.None;
            }
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            serviceForm = new ServiceSelectionForm();
            serviceForm.InitializeFields(Services, InsuranceType, true);

            if (serviceForm.ShowDialog() == DialogResult.OK)
            {
                Services = serviceForm.selectedServices;
                InsuranceType = serviceForm.insurance;
                double guaranteePrice = CalculateRental.CalculateGuarantee();
                double insurancePrice = CalculateRental.CalculateInsurance(serviceForm.insurance);
                txtTotal.Text = Convert.ToString(guaranteePrice + insurancePrice);
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string coupon = txtCoupon.Text;
            bool exists = couponController.CodeExists(coupon);
            if (exists)
                txtCoupon.BackColor = Color.Green;
            else
                txtCoupon.BackColor = Color.Red;
        }
    }
}

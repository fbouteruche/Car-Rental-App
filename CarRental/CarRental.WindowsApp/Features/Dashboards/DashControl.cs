using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.Controllers.RentalModule;
using CarRental.Controllers.ServiceModule;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.VehicleModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public partial class DashboardControl : UserControl
    {
        VehicleController vehicleController;
        CustomerController customerController;
        ServiceController serviceController;
        RentalController rentalController;
        EmployeeController employeeController;
        CouponController couponController;
        public DashboardControl()
        {
            InitializeComponent();
            vehicleController = new VehicleController();
            customerController = new CustomerController();
            serviceController = new ServiceController();
            employeeController = new EmployeeController();
            rentalController = new RentalController(vehicleController, employeeController, customerController, serviceController, couponController);
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            LoadVehicleDashboard();
            LoadCustomerDashboard();
            LoadServiceDashboard();
            LoadRentalDashboard();
        }

        private void LoadRentalDashboard()
        {
            List<Rental> allRentals = rentalController.SelectAll();
            List<Rental> openRentals = new List<Rental>();
            foreach (Rental rental in allRentals)
                if (rental.IsOpen)
                    openRentals.Add(rental);

            int returnsToday = 0;
            int returnsIn7Days = 0;
            

            foreach (Rental rental in openRentals)
            {
                if (rental.ReturnDate.Date == DateTime.Today )
                {
                    returnsToday++;
                }
                else if (rental.ReturnDate.Date <= DateTime.Today.AddDays(7))
                {
                    returnsIn7Days++;
                }
            }
            lblReturnsToday.Text = returnsToday.ToString();
            lblRentedCars.Text = openRentals.Count.ToString();
            lblReturnsIn7Days.Text = returnsIn7Days.ToString();
           
        }

        private void LoadServiceDashboard()
        {
            List<Service> allServices = serviceController.SelectAll();
            int totalServices = allServices.Count;

            lblTotalServices.Text = totalServices.ToString();
        }

        private void LoadCustomerDashboard()
        {
            List<Customer> allCustomers = customerController.SelectAll();
            int totalCustomers = allCustomers.Count;
            int individualCustomers = 0;
            int companyCustomers = 0;

            foreach (Customer customer in allCustomers)
            {
                if (customer.IsPhysicalPerson)
                {
                    individualCustomers++;
                }
                else
                {
                    companyCustomers++;
                }
            }
            lblCompanyCustomers.Text = companyCustomers.ToString();
            lblIndividualCustomers.Text = individualCustomers.ToString();
            lblTotalCustomers.Text = totalCustomers.ToString();
          
        }

        private void LoadVehicleDashboard()
        {
            List<Vehicle> allVehicles = vehicleController.SelectAll();
            int totalCars = allVehicles.Count;
            int rentedCars = 0;
            int availableCars = 0;


            foreach (Vehicle vehicle in allVehicles)
            {
                if (vehicle.isRented)
                {
                    rentedCars++;
                }
                else
                {
                    availableCars++;
                }
            }
            lblAvailableCars.Text = availableCars.ToString();
            lblUnavailableCars.Text = rentedCars.ToString();
            lblTotalCars.Text = totalCars.ToString();
        }


    }
}

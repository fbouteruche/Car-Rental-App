using CarRental.Controllers.VehicleModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public class OperationsDashboard
    {
        private readonly VehicleController vehicleController = null;
        //private readonly RentalController rentalController = null;
        //private readonly DashboardControl dashboardControl = null;

        public OperationsDashboard(VehicleController vehicleController) //RentalController rentalController)
        {
            //this.rentalController = rentalController;
            this.vehicleController = vehicleController;
            //dashboardControl = new DashboardControl();
        }
    }
}

using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public class VehicleConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Register Vehicle"; }
        }

        public string RegistrationType
        {
            get { return "Register a new Vehicle"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Vehicle"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Vehicle"; }
        }
    }
}

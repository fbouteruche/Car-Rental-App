using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Rentals
{
    public class RentalConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType
        {
            get { return "Vehicle Rental Registration"; }
        }

        public string AddToolTip
        {
            get { return "Register Vehicle Rental"; }
        }

        public string EditToolTip
        {
            get { return "Edit Vehicle Rental"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete a Vehicle Rental"; }
        }
    }
}
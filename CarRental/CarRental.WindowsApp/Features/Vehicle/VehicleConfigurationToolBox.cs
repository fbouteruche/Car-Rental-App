using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public class VehicleConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Cadastro de Vehicles"; }
        }

        public string RegistrationType
        {
            get { return "Cadastro de um novo Vehicle"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Vehicle existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Vehicle existente"; }
        }
    }
}

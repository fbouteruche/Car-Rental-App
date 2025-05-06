using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Locacoes
{
    public class RentalConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType
        {
            get { return "Registro Locação de Vehicle"; }
        }

        public string AddToolTip
        {
            get { return "Realizar Locação de Vehicle"; }
        }

        public string EditToolTip
        {
            get { return "Edit Locação de Vehicle"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete uma Locação de Vehicle"; }
        }
    }
}
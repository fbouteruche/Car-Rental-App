using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    public class VehicleGroupConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType
        {
            get { return "Cadastro de Grupo de Vehicles"; }
        }

        public string AddToolTip
        {
            get { return "Adicionar uma novo Grupo de Vehicles"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Grupo de Vehicles existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Grupo de Vehicles existente"; }
        }
    }
}
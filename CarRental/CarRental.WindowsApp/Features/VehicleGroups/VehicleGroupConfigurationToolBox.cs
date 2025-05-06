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
            get { return "Vehicle Group Registration"; }
        }

        public string AddToolTip
        {
            get { return "Add a new Vehicle Group"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Vehicle Group"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Vehicle Group"; }
        }
    }
}
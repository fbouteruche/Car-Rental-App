using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Services
{
    class ServiceConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Service Registration"; }
        }

        public string RegistrationType
        {
            get { return "Add a new Service"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Service"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Service"; }
        }
    }
}

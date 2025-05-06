using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public class ConfigurationDashboardToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Add"; }
        }
        public string RegistrationType
        {
            get { return "Dashboard"; }
        }

        public string EditToolTip
        {
            get { return "Edit"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete"; }
        }
    }
}

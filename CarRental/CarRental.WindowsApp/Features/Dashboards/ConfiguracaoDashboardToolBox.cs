using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public class ConfiguracaoDashboardToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Adicionar"; }
        }
        public string RegistrationType
        {
            get { return "DashBoard"; }
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

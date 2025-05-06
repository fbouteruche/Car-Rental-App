using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.CustomerModule
{
    public class CustomerConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType
        {
            get { return "Customer Registration"; }
        }

        public string AddToolTip
        {
            get { return "Add a new Customer"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Customer"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Customer"; }
        }
    }
}

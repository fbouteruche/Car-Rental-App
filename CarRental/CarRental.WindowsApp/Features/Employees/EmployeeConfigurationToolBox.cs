using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Employees
{
    public class EmployeeConfigurationToolbox : IConfigurationToolBox
    {
        public string RegistrationType { get { return "Employee Registration"; } }

        public string AddToolTip { get { return "Add an Employee"; } }

        public string EditToolTip { get { return "Edit an Employee"; } }

        public string DeleteToolTip { get { return "Delete an Employee"; } }
    }
}

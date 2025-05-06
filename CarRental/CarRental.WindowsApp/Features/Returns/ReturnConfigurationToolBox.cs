using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Returns
{
    public class ReturnConfigurationToolBox : IConfigurationToolBox
    {
        public string RegistrationType { get { return "Vehicle Return"; } }

        public string AddToolTip { get { return "Register Return"; } }

        public string EditToolTip {get { return "Edit Return"; } }

        public string DeleteToolTip { get { return "Delete Return"; } }
    }
}

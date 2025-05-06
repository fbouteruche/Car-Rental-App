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
        public string RegistrationType { get { return "Devolução de Veículo"; } }

        public string AddToolTip { get { return "Registrar Devolução"; } }

        public string EditToolTip { get { return "Edit Devolução"; } }

        public string DeleteToolTip { get { return "Delete devolução"; } }
    }
}

using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Parceiros
{
    public class PartnerConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Cadastro de Parceiros"; }
        }

        public string RegistrationType
        {
            get { return "Cadastro de um novo Partner"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Partner existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Partner existente"; }
        }
    }
}

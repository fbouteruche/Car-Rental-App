using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Partners
{
    public class PartnerConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Register Partner"; }
        }

        public string RegistrationType
        {
            get { return "Register a new Partner"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Partner"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Partner"; }
        }
    }
}

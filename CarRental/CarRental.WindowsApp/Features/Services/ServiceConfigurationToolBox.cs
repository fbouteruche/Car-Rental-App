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
            get { return "Cadastro de Serviços"; }
        }

        public string RegistrationType
        {
            get { return "Adicionar um novo Serviço"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Serviço existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Serviço existente"; }
        }
    }
}

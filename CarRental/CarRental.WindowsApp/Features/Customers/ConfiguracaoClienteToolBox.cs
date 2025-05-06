using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Clientes
{
    public class ConfiguracaoClienteToolBox : IConfigurationToolBox
    {


        public string RegistrationType
        {
            get { return "Cadastro de Clientes"; }
        }

        public string AddToolTip
        {
            get { return "Adicionar um novo Customer"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Customer existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Customer existente"; }
        }


    }
}

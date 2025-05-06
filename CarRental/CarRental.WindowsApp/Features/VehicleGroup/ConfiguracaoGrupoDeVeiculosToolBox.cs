using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.GrupoDeVeiculos
{
    public class ConfiguracaoGrupoDeVeiculosToolBox : IConfigurationToolBox
    {
        public string RegistrationType
        {
            get { return "Cadastro de Grupo de Veiculos"; }
        }

        public string AddToolTip
        {
            get { return "Adicionar uma novo Grupo de Veiculos"; }
        }

        public string EditToolTip
        {
            get { return "Edit um Grupo de Veiculos existente"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete um Grupo de Veiculos existente"; }
        }
    }
}
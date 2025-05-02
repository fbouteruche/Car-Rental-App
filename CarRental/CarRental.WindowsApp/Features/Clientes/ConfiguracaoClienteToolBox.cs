using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.Clientes
{
    public class ConfiguracaoClienteToolBox : IConfiguracaoToolBox
    {


        public string TipoCadastro
        {
            get { return "Cadastro de Clientes"; }
        }

        public string ToolTipAdicionar
        {
            get { return "Adicionar um novo Customer"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Customer existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Customer existente"; }
        }


    }
}

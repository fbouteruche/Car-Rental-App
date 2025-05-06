using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.WindowsApp.Features.GrupoDeVeiculos
{
    public class ConfiguracaoGrupoDeVeiculosToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Cadastro de Grupo de Veiculos"; }
        }

        public string ToolTipAdicionar
        {
            get { return "Adicionar uma novo Grupo de Veiculos"; }
        }

        public string ToolTipEditar
        {
            get { return "Edit um Grupo de Veiculos existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Delete um Grupo de Veiculos existente"; }
        }
    }
}
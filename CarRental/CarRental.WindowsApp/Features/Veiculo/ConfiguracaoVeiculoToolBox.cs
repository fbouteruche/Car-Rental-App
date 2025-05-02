using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Veiculos
{
    public class ConfiguracaoVeiculoToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Cadastro de Veiculos"; }
        }

        public string TipoCadastro
        {
            get { return "Cadastro de um novo Vehicle"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um Vehicle existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um Vehicle existente"; }
        }
    }
}

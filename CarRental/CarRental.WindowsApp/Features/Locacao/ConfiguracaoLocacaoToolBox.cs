using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Locacoes
{
    public class ConfiguracaoLocacaoToolBox : IConfiguracaoToolBox
    {
        public string TipoCadastro
        {
            get { return "Registro Locação de Vehicle"; }
        }

        public string ToolTipAdicionar
        {
            get { return "Realizar Locação de Vehicle"; }
        }

        public string ToolTipEditar
        {
            get { return "Edit Locação de Vehicle"; }
        }

        public string ToolTipExcluir
        {
            get { return "Delete uma Locação de Vehicle"; }
        }
    }
}
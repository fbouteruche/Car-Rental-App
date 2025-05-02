using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Cupons
{
    public class ConfiguracaoCupomToolBox : IConfiguracaoToolBox
    {
        public string ToolTipAdicionar
        {
            get { return "Cadastro de CouponModule de Desconto"; }
        }

        public string TipoCadastro
        {
            get { return "Cadastro de um novo CouponModule"; }
        }

        public string ToolTipEditar
        {
            get { return "Editar um CouponModule existente"; }
        }

        public string ToolTipExcluir
        {
            get { return "Excluir um CouponModule existente"; }
        }
    }
}

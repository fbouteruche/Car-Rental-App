using CarRental.Domain.CouponModule;
using CarRental.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Cupons
{
    public partial class TabelaCupomControl : UserControl
    {
        public TabelaCupomControl()
        {
            InitializeComponent();
            gridCupons.ConfigurarGridZebrado();
            gridCupons.ConfigurarGridSomenteLeitura();
            gridCupons.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Code", HeaderText = "Code"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Value"},
                new DataGridViewTextBoxColumn { DataPropertyName = "IsFixedDiscount", HeaderText = "Desconto Fixo"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ExpirationDate", HeaderText = "ExpirationDate"},
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Coupon> cupons)
        {
            gridCupons.Rows.Clear();

            foreach (Coupon cupom in cupons)
                gridCupons.Rows.Add(cupom.Id, cupom.Name, cupom.Code, cupom.Value, cupom.IsFixedDiscount, cupom.ExpirationDate);
        }

        internal int ObtemIdSelecionado()
        {
            return gridCupons.SelecionarId<int>();
        }
    }
}

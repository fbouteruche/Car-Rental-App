using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public partial class PartnerTableControl : UserControl
    {
        public PartnerTableControl()
        {
            InitializeComponent();
            gridParceiros.ConfigureZebraGrid();
            gridParceiros.ConfigureReadOnlyGrid();
            gridParceiros.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "nome", HeaderText = "Name"}
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Partner> parceiros)
        {
            gridParceiros.Rows.Clear();

            foreach (Partner parceiro in parceiros)
                gridParceiros.Rows.Add(parceiro.Id, parceiro.Name);

        }

        internal int ObtemIdSelecionado()
        {
            return gridParceiros.SelecionarId<int>();
        }
    }
}

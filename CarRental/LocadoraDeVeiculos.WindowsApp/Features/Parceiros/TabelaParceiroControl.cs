using CarRental.Domain.ParceiroModule;
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

namespace CarRental.WindowsApp.Features.Parceiros
{
    public partial class TabelaParceiroControl : UserControl
    {
        public TabelaParceiroControl()
        {
            InitializeComponent();
            gridParceiros.ConfigurarGridZebrado();
            gridParceiros.ConfigurarGridSomenteLeitura();
            gridParceiros.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "nome", HeaderText = "Nome"}
           };

            return colunas;
        }

        internal void AtualizarRegistros(List<Parceiro> parceiros)
        {
            gridParceiros.Rows.Clear();

            foreach (Parceiro parceiro in parceiros)
                gridParceiros.Rows.Add(parceiro.Id, parceiro.Nome);

        }

        internal int ObtemIdSelecionado()
        {
            return gridParceiros.SelecionarId<int>();
        }
    }
}

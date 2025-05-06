using CarRental.Domain.ServiceModule;
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

namespace CarRental.WindowsApp.Features.Servicos
{
    public partial class TabelaServicoControl : UserControl
    {
        public TabelaServicoControl()
        {
            InitializeComponent();
            gridServicos.ConfigureZebraGrid();
            gridServicos.ConfigureReadOnlyGrid();
            gridServicos.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "IsChargedDaily", HeaderText = "É taxado diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Value"},
            };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridServicos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Service> servicos)
        {
            gridServicos.Rows.Clear();

            foreach (Service servico in servicos)
            {
                gridServicos.Rows.Add(servico.Id, servico.Name, servico.IsChargedDaily, servico.Value);
            }
        }
    }
}
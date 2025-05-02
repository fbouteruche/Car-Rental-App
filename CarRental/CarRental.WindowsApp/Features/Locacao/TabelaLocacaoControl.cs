using CarRental.Domain.RentalModule;
using CarRental.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Locacoes
{
    public partial class TabelaLocacaoControl : UserControl
    {
        public TabelaLocacaoControl()
        {
            InitializeComponent();
            gridLocacao.ConfigurarGridZebrado();
            gridLocacao.ConfigurarGridSomenteLeitura();
            gridLocacao.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Vehicle", HeaderText = "Vehicle"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ClienteContratante", HeaderText = "Customer"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Condutor", HeaderText = "Condutor"},

                new DataGridViewTextBoxColumn {DataPropertyName = "PrecoLocacao", HeaderText = "Value Inicial"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataDeSaida", HeaderText = "Data de Locação"},

                new DataGridViewTextBoxColumn {DataPropertyName = "DataPrevistaDeChegada", HeaderText = "Devolução"}
           };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridLocacao.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Rental> locacoes)
        {
            gridLocacao.Rows.Clear();

            foreach (Rental locacao in locacoes)
            {
                gridLocacao.Rows.Add(locacao.Id, locacao.Veiculo, locacao.ClienteContratante, locacao.ClienteCondutor, locacao.PrecoLocacao,
                    locacao.DataDeSaida, locacao.DataPrevistaDeChegada);
            }
        }
    }
}

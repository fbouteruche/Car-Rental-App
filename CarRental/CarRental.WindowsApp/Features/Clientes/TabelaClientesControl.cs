using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.Controllers.ClientesModule;
using CarRental.Domain.CustomerModule;
using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Clientes
{
    public partial class TabelaClientesControl : UserControl
    {
        private ControladorCliente controladorCliente = null;
        public TabelaClientesControl()
        {
            controladorCliente = new ControladorCliente();
            InitializeComponent();
            gridClientes.ConfigurarGridZebrado();
            gridClientes.ConfigurarGridSomenteLeitura();
            gridClientes.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "UniqueId", HeaderText = "Registro"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Phone", HeaderText = "Phone"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Email", HeaderText = "Email"},

                new DataGridViewTextBoxColumn {DataPropertyName = "CNH", HeaderText = "CNH"},

                new DataGridViewTextBoxColumn {DataPropertyName = "LicenseExpiryDate", HeaderText = "ExpirationDate CHN"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ehpessoafisica", HeaderText = "É pessoa física "}
               
           };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridClientes.SelecionarId<int>();
        }

        public void AtualizarRegistros()
        {
            var clientes = controladorCliente.SelectAll();
            CarregarTabela(clientes);
        }

        private void CarregarTabela(List<Customer> clientes)
        {
            gridClientes.DataSource = clientes;
        }

    }
}

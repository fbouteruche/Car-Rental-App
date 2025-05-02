using CarRental.Controllers.ServicoModule;
using CarRental.Domain.ServiceModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Servicos
{
    public partial class TelaServicoForm : Form
    {
        private Service servico;

        public TelaServicoForm(string titulo)
        {
            InitializeComponent();
            this.Text = titulo;
            lblCadastroServico.Text = titulo;
        }

        public Service Servico
        {
            get { return servico; }
            set
            {
                servico = value;

                txtId.Text = servico.Id.ToString();
                txtNome.Text = servico.Name.ToString();
                txtValor.Text = servico.Value.ToString();
                if (servico.IsChargedDaily)
                    rdbCalcDiaria.Checked = true;
                else
                    rdbTaxaFixa.Checked = true;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            if (!double.TryParse(txtValor.Text, out double valor))
                valor = 0;
            bool ehTaxadoDiario = rdbCalcDiaria.Checked;

            servico = new Service(id, nome, ehTaxadoDiario, valor);

            string resultadoValidacao = servico.Validate();

            if (resultadoValidacao != "VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (txtValor.Text.IndexOf(".") >= 0 || txtValor.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void ServicoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}

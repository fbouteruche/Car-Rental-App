using CarRental.Domain.PartnerModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public partial class PartnerForm : Form
    {
        Partner parceiro;
        public PartnerForm(string titulo)
        {
            InitializeComponent();
            labelTitulo.Text = titulo;
        }
        public Partner Parceiro
        {
            get { return parceiro; }

            set
            {
                parceiro = value;

                txtId.Text = parceiro.Id.ToString();
                txtNome.Text = parceiro.Name;
            }
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = 0;
            string nome = txtNome.Text;
            if (txtId.Text.Length > 0)
                id = Convert.ToInt32(txtId.Text);

            parceiro = new Partner(id, nome);

            string resultadoValidacao = parceiro.Validate();

            if (resultadoValidacao != "VALID")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CarRental.Domain.ClienteModule;

namespace CarRental.WindowsApp.ClientesModule
{
    public partial class ClientesForm : Form
    {
        private Customer cliente;
        public ClientesForm(string titulo)
        {
            InitializeComponent();
            label8.Text = titulo;
            this.Text = titulo;
        }

        public Customer Clientes
        {
            get { return cliente; }

            set
            {
                cliente = value;
                
                if (cliente.IsPhysicalPerson)
                {
                    radioButton1.Checked = true;
                    radioButton2.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    radioButton2.Checked = true;
                    dtpValidade.Text = cliente.LicenseExpiryDate.ToString();
                }
                textId.Text = cliente.Id.ToString();

                textNome.Text = cliente.Name;
                maskRegistro.Text = cliente.UniqueId;
                textEndereco.Text = cliente.Address;
                maskTelefone.Text = cliente.Phone;
                tetxtEmail.Text = cliente.Email;
                maskedCNH.Text = cliente.DriverLicense;
                //dtpValidade.Text = cliente.LicenseExpiryDate.ToShortDateString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            labelRegistro.Text = "CPF";
            maskRegistro.Mask =  "000.000.000-00";
            maskedCNH.Enabled = true;
            dtpValidade.Enabled = true;
            maskRegistro.Size = new Size(90, 20);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            labelRegistro.Text = "CNPJ";
            maskRegistro.Mask = "00.000.000/0000-00";
            maskedCNH.Enabled = false;
            dtpValidade.Enabled = false;
            maskRegistro.Size = new Size(113, 20);
        }       

        private void btnConfirmar_Click_1(object sender, EventArgs e)
        {
            DateTime? validade = null;
            bool ehPessoaFisica = false;
            string CNH = "";
            int Id = Convert.ToInt32(textId.Text);
            string Nome = textNome.Text;
            string Registro = maskRegistro.Text.Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "");
            string Endereco = textEndereco.Text;
            string TeleFone = maskTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string Email = tetxtEmail.Text;            
            if (radioButton1.Checked == true)
            {
                ehPessoaFisica = true;
                validade = Convert.ToDateTime(dtpValidade.Text);
                CNH = maskedCNH.Text.Replace("-", "").Replace(" ", "");
            }

            Id = 0;
            cliente = new Customer(Id, Nome, Registro, Endereco, TeleFone, Email, CNH, validade, ehPessoaFisica);

            string resultadoValidacao = cliente.Validate();


            if (resultadoValidacao != "VALIDO")
            {
                string erro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }        
    }
  
}

using CarRental.Controllers.PartnerModule;
using CarRental.Domain.CouponModule;
using CarRental.Domain.PartnerModule;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Cupons
{
    public partial class TelaCupomForm : Form
    {
        Coupon cupom;
        PartnerController controladorParceiro;
        public TelaCupomForm(string titulo)
        {
            controladorParceiro = new PartnerController();
            InitializeComponent();
            rBtnValorFixo.Checked = true;
            labelTitulo.Text = titulo;
            CarregarParceiros();
        }

        private void CarregarParceiros()
        {
            cBoxParceiro.DataSource = controladorParceiro.SelectAll();
        }

        public Coupon Cupom
        {
            get { return cupom; }

            set
            {
                cupom = value;

                txtId.Text = cupom.Id.ToString();
                txtNome.Text = cupom.Name;
                txtCodigo.Text = cupom.Code;
                if (cupom.IsFixedDiscount)
                {
                    rBtnValorFixo.Checked = true;
                    rBtnPorcentagem.Checked = false;
                    numUpDownValor.Maximum = 15000;
                }
                else
                {
                    rBtnValorFixo.Checked = false;
                    rBtnPorcentagem.Checked = true;
                    numUpDownValor.Maximum = 100;
                }
                numUpDownValor.Value = Convert.ToDecimal(cupom.Value);
                numUpDownValorMinimo.Value = Convert.ToDecimal(cupom.MinimumValue);
                dtpValidade.Value = cupom.ExpirationDate;
                cBoxParceiro.SelectedItem = cupom.Partner;
            }
        }
        #region Radio Buttons
        private void rBtnValorFixo_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnValorFixo.Checked == true)
            {
                lbValor.Text = "Value";
                lbValor.Location = new Point(70, 215);
                numUpDownValor.Maximum = 15000;
            }
        }

        private void rBtnPorcentagem_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPorcentagem.Checked == true)
            {
                lbValor.Text = "Porcentagem";
                lbValor.Location = new Point(31, 215);
                numUpDownValor.Maximum = 100;
            }
        }
        #endregion
        private void btnConfirmar_Click(object sender, EventArgs e)
        {            
            bool ehDescontoFixo = false;

            int id = 0;
            if (txtId.Text.Length > 0)
                id = Convert.ToInt32(txtId.Text);
            string nome = txtNome.Text;
            string codigo = txtCodigo.Text;
            double valorMinimo = Convert.ToDouble(numUpDownValorMinimo.Value);
            double valor = Convert.ToDouble(numUpDownValor.Value);
            if (rBtnValorFixo.Checked == true)
                ehDescontoFixo = true;
            DateTime validade = dtpValidade.Value;

            Partner parceiro = cBoxParceiro.SelectedItem as Partner;

            cupom = new Coupon(id, nome, codigo, valor, valorMinimo, ehDescontoFixo, validade, parceiro);

            string resultadoValidacao = cupom.Validate();

            if (resultadoValidacao != "VALID")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }
    }
}

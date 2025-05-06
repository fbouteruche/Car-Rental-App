using CarRental.Controllers.ServiceModule;
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

namespace CarRental.WindowsApp.Features.Services
{
    public partial class ServiceForm : Form
    {
        private Service service;

        public ServiceForm(string title)
        {
            InitializeComponent();
            this.Text = title;
            lblCadastroServico.Text = title;
        }

        public Service Service
        {
            get { return service; }
            set
            {
                service = value;

                txtId.Text = service.Id.ToString();
                txtNome.Text = service.Name.ToString();
                txtValor.Text = service.Value.ToString();
                if (service.IsChargedDaily)
                    rdbCalcDiaria.Checked = true;
                else
                    rdbTaxaFixa.Checked = true;
            }
        }

        private void btnConfirma_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string name = txtNome.Text;
            if (!double.TryParse(txtValor.Text, out double value))
                value = 0;
            bool isChargedDaily = rdbCalcDiaria.Checked;

            service = new Service(id, name, isChargedDaily, value);

            string validationResult = service.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();

                MainForm.Instance.UpdateFooter(firstError);

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

        private void ServiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainForm.Instance.UpdateFooter("");
        }
    }
}

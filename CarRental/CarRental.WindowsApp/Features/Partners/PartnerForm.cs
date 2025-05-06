using CarRental.Domain.PartnerModule;
using System;
using System.IO;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public partial class PartnerForm : Form
    {
        Partner partner;
        public PartnerForm(string title)
        {
            InitializeComponent();
            labelTitle.Text = title;
        }
        public Partner Partner
        {
            get { return partner; }

            set
            {
                partner = value;

                txtId.Text = partner.Id.ToString();
                txtName.Text = partner.Name;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int id = 0;
            string name = txtName.Text;
            if (txtId.Text.Length > 0)
                id = Convert.ToInt32(txtId.Text);

            partner = new Partner(id, name);

            string validationResult = partner.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();

                MainForm.Instance.UpdateFooter(firstError);

                DialogResult = DialogResult.None;
            }
        }
    }
}

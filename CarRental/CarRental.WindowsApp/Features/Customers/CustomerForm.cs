using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CarRental.Domain.CustomerModule;

namespace CarRental.WindowsApp.CustomerModule
{
    public partial class CustomerForm : Form
    {
        private Customer customer;
        public CustomerForm(string title)
        {
            InitializeComponent();
            labelTitle.Text = title;
            this.Text = title;
        }

        public Customer CustomerData
        {
            get { return customer; }
            set
            {
                customer = value;
                if (customer.IsPhysicalPerson)
                {
                    radioButtonIndividual.Checked = true;
                    radioButtonCompany.Checked = false;
                }
                else
                {
                    radioButtonIndividual.Checked = false;
                    radioButtonCompany.Checked = true;
                    datePickerLicenseExpiry.Text = customer.LicenseExpiryDate.ToString();
                }
                textBoxId.Text = customer.Id.ToString();
                textBoxName.Text = customer.Name;
                maskedTextBoxUniqueId.Text = customer.UniqueId;
                textBoxAddress.Text = customer.Address;
                maskedTextBoxPhone.Text = customer.Phone;
                textBoxEmail.Text = customer.Email;
                maskedTextBoxDriverLicense.Text = customer.DriverLicense;
            }
        }

        private void radioButtonIndividual_CheckedChanged(object sender, EventArgs e)
        {
            labelUniqueId.Text = "CPF";
            maskedTextBoxUniqueId.Mask = "000.000.000-00";
            maskedTextBoxDriverLicense.Enabled = true;
            datePickerLicenseExpiry.Enabled = true;
            maskedTextBoxUniqueId.Size = new Size(90, 20);
        }

        private void radioButtonCompany_CheckedChanged(object sender, EventArgs e)
        {
            labelUniqueId.Text = "CNPJ";
            maskedTextBoxUniqueId.Mask = "00.000.000/0000-00";
            maskedTextBoxDriverLicense.Enabled = false;
            datePickerLicenseExpiry.Enabled = false;
            maskedTextBoxUniqueId.Size = new Size(113, 20);
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            DateTime? licenseExpiry = null;
            bool isPhysicalPerson = false;
            string driverLicense = "";
            int id = Convert.ToInt32(textBoxId.Text);
            string name = textBoxName.Text;
            string uniqueId = maskedTextBoxUniqueId.Text.Replace("-", "").Replace(".", "").Replace("/", "").Replace(" ", "");
            string address = textBoxAddress.Text;
            string phone = maskedTextBoxPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = textBoxEmail.Text;
            if (radioButtonIndividual.Checked == true)
            {
                isPhysicalPerson = true;
                licenseExpiry = Convert.ToDateTime(datePickerLicenseExpiry.Text);
                driverLicense = maskedTextBoxDriverLicense.Text.Replace("-", "").Replace(" ", "");
            }
            id = 0;
            customer = new Customer(id, name, uniqueId, address, phone, email, driverLicense, licenseExpiry, isPhysicalPerson);
            string validationResult = customer.Validate();
            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();
                MainForm.Instance.UpdateFooter(firstError);
                DialogResult = DialogResult.None;
            }
        }
    }
}

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
using CarRental.Domain.EmployeeModule;
using CarRental.WindowsApp.Features;

namespace CarRental.WindowsApp.Features.Employee
{
    public partial class EmployeeForm : Form
    {
        private Domain.EmployeeModule.Employee employee;

        public EmployeeForm(string title)
        {
            InitializeComponent();
            lbEmployeeFormTitle.Text = title;
        }

        public Domain.EmployeeModule.Employee Employee
        {
            get { return employee; }

            set
            {
                employee = value;

                textId.Text = employee.Id.ToString();
                textName.Text = employee.Name.ToString();
                mskTxtCpf.Text = employee.UniqueId;
                textAddress.Text = employee.Address.ToString();
                mskTxtPhone.Text = employee.Phone.ToString();
                textEmail.Text = employee.Email.ToString();
                textInternalRegistration.Text = employee.InternalRegistration.ToString();
                textUsername.Text = employee.LoginUsername.ToString();
                textPassword.Text = employee.UserPassword.ToString();
                mskTxtHiringDate.Text = employee.HiringDate.ToString();
                textJobTitle.Text = employee.JobTitle.ToString();
                textSalary.Text = employee.Salary.ToString();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = textName.Text;
            string uniqueId = mskTxtCpf.Text.Replace("-", "").Replace(".", "").Replace(" ", "");
            string address = textAddress.Text;
            string phone = mskTxtPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = textEmail.Text;
            int internalRegistration = Convert.ToInt32(textInternalRegistration.Text);
            string loginUsername = textUsername.Text;
            string password = textPassword.Text;
            DateTime hiringDate;
            if (mskTxtHiringDate.Text == null)
                hiringDate = DateTime.Now;
            else
                hiringDate = Convert.ToDateTime(mskTxtHiringDate.Text);
            string jobTitle = textJobTitle.Text;
            double salary = Convert.ToDouble(textSalary.Text);

            employee = new Domain.EmployeeModule.Employee(0, name, uniqueId, address, phone, email, internalRegistration, loginUsername, password, hiringDate, jobTitle, salary, true);

            string validationResult = employee.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();
                MainForm.Instance.UpdateFooter(firstError);
                DialogResult = DialogResult.None;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm.Instance.UpdateFooter("");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            btnConfirm_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }
    }
}

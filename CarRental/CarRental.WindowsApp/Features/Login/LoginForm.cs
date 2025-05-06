using CarRental.Controllers.EmployeeModule;
using CarRental.Domain.EmployeeModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Login
{
    public partial class LoginForm : Form
    {
        private readonly EmployeeController controller;
        Thread thread;
        public LoginForm()
        {
            InitializeComponent();
            controller = new EmployeeController();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (textUsername.Text == "admin" && textPassword.Text == "admin")
                PerformLogin();
            else
            {
                foreach (Domain.EmployeeModule.Employee employee in controller.SelectAll())
                {
                    if (textUsername.Text == employee.LoginUsername && textPassword.Text == employee.UserPassword)
                    {
                        PerformLogin();
                        return;
                    }
                }
                textUsername.Clear();
                textPassword.Clear();
                MessageBox.Show("Invalid username or password");
            }
        }

        private void PerformLogin()
        {
            MessageBox.Show("Welcome " + textUsername.Text);
            thread = new Thread(OpenMainScreen);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            LoginForm login = new LoginForm();
            this.Dispose();
            login.Close();
        }

        public void OpenMainScreen()
        {
            Application.Run(new MainForm());
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the administrator to reset your password");
        }
    }
}

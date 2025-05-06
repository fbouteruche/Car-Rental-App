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
    public partial class TelaLogin : Form
    {
        private readonly EmployeeController controlador;
        Thread thread;
        public TelaLogin()
        {
            InitializeComponent();
            controlador = new EmployeeController();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (textUsuario.Text == "admin" && textSenha.Text == "admin")
                EfetuarLogin();

            else
            {
                foreach (Employee funcionario in controlador.SelectAll())
                {
                    if (textUsuario.Text == funcionario.LoginUsername && textSenha.Text == funcionario.UserPassword)
                    {
                        EfetuarLogin();
                        return;
                    }
                }

                textUsuario.Clear();
                textSenha.Clear();
                MessageBox.Show("Login ou senha inválidos");
            }

        }

        private void EfetuarLogin()
        {
            MessageBox.Show("Bem vindo " + textUsuario.Text);
            thread = new Thread(ChamarTelaPrincipal);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();


            TelaLogin login = new TelaLogin();
            this.Dispose();
            login.Close();
        }

        public void ChamarTelaPrincipal()
        {
            Application.Run(new TelaPrincipalForm()); ;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Por favor contatar o usuário administrador para refazer sua senha");
        }
    }
}
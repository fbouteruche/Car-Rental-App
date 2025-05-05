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
using CarRental.WindowsApp.Funcionarios;

namespace CarRental.WindowsApp.Funcionarios
{
    public partial class FuncionarioForm : Form
    {
        private Employee funcionario;

        public FuncionarioForm(string titulo)
        {
            InitializeComponent();
            lbTituloCadastroDeFuncionarios.Text = titulo;
        }

        public Employee Funcionario
        {
            get { return funcionario; }

            set
            {
                funcionario = value;

                textId.Text = funcionario.Id.ToString();
                textNome.Text = funcionario.Name.ToString();
                mskTxtCpf.Text = funcionario.UniqueId;
                textEndereco.Text = funcionario.Address.ToString();
                mskTxtTelefone.Text = funcionario.Phone.ToString();
                textEmail.Text = funcionario.Email.ToString();
                textMatriculaInterna.Text = funcionario.InternalRegistration.ToString();
                textUsuarioAcesso.Text = funcionario.LoginUsername.ToString();
                textSenha.Text = funcionario.UserPassword.ToString();
                mskTxtDataAdmissao.Text = funcionario.HiringDate.ToString();
                textCargo.Text = funcionario.JobTitle.ToString();
                textSalario.Text = funcionario.Salary.ToString();
                
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string nome = textNome.Text;
            string registroUnico = mskTxtCpf.Text.Replace("-", "").Replace(".", "").Replace(" ", "");
            string endereco = textEndereco.Text;
            string telefone = mskTxtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = textEmail.Text;
            int matriculaInterna = Convert.ToInt32(textMatriculaInterna.Text);
            string usuarioAcesso = textUsuarioAcesso.Text;
            string senha = textSenha.Text;
            DateTime dataAdmissao;
            if (mskTxtDataAdmissao.Text == null)
                dataAdmissao = DateTime.Now;
            else
                dataAdmissao = Convert.ToDateTime(mskTxtDataAdmissao.Text);
            string cargo = textCargo.Text;
            double salario = Convert.ToDouble(textSalario.Text);
             
            funcionario = new Employee(0,nome,registroUnico,endereco,telefone,email,matriculaInterna,usuarioAcesso,senha,dataAdmissao,cargo,salario,true);

            string resultadoValidacao = funcionario.Validate();

            if (resultadoValidacao != "VALID")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
                DialogResult = DialogResult.None;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }
    }
}

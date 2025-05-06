using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.Shared;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Funcionarios
{
    public partial class TabelaFuncionarioControl : UserControl
    {
        public TabelaFuncionarioControl()
        {
            InitializeComponent();
            gridFuncionarios.ConfigureZebraGrid();
            gridFuncionarios.ConfigureReadOnlyGrid();
            gridFuncionarios.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Address", HeaderText = "Endereço"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Phone", HeaderText = "Phone"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Email", HeaderText = "E-mail"},

                new DataGridViewTextBoxColumn {DataPropertyName = "InternalRegistration", HeaderText = "Matricula"},

                new DataGridViewTextBoxColumn {DataPropertyName = "LoginUsername", HeaderText = "Usuário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "JobTitle", HeaderText = "JobTitle"},

                new DataGridViewTextBoxColumn {DataPropertyName = "Salary", HeaderText = "Salário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "HiringDate", HeaderText = "Data de admissão"}
           };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridFuncionarios.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Employee> funcionarios)
        {
            gridFuncionarios.Rows.Clear();

            foreach (Employee funcionario in funcionarios)
            {
                gridFuncionarios.Rows.Add(funcionario.Id, funcionario.Name, funcionario.UniqueId,
                    funcionario.Address, funcionario.Phone, funcionario.Email, funcionario.InternalRegistration,
                    funcionario.LoginUsername, funcionario.JobTitle, funcionario.Salary, funcionario.HiringDate);
            }
        }
    }
}

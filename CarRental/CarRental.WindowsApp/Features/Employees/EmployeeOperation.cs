using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Controllers.EmployeeModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.Shared;
using CarRental.Domain.PersonModule;
using CarRental.Controllers.Shared;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Features.Employee;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Employees
{
    public class EmployeeOperation : ICadastravel
    {
        private readonly EmployeeController controlador = null;
        private readonly EmployeeTableControl tabelaFuncionarios = null;

        public EmployeeOperation(EmployeeController ctrlFuncionario)
        {
            controlador = ctrlFuncionario;
            tabelaFuncionarios = new EmployeeTableControl();
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void EditRecord()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder Edit!","Edição de Funcionários",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            Domain.EmployeeModule.Employee funcionarioSelecionado = controlador.SelectById(id);
            EmployeeForm tela = new EmployeeForm("Edição de Funcionário");
            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Funcionario);
                List<Domain.EmployeeModule.Employee> funcionarios = controlador.SelectAll();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Name}] editado com sucesso");
            }

        }

        public void DeleteRecord()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para excluir","Exclusão de Funcionários",MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                return;
            }

            Domain.EmployeeModule.Employee funcionarioSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o funcionário: [{funcionarioSelecionado.Name}] ?", "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Delete(id);
                List<Domain.EmployeeModule.Employee> funcionarios = controlador.SelectAll();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Name}] removido com sucesso");
            }
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void InsertNewRecord()
        {
            EmployeeForm tela = new EmployeeForm("Cadastro de Funcionário");           

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Funcionario);
                List<Domain.EmployeeModule.Employee> funcionarios = controlador.SelectAll();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Name}] inserido com sucesso");
            }
        }

        public UserControl GetTable()
        {
            List<Domain.EmployeeModule.Employee> funcionarios = controlador.SelectAll();
            tabelaFuncionarios.AtualizarRegistros(funcionarios);
            return tabelaFuncionarios;
        }
    }
}

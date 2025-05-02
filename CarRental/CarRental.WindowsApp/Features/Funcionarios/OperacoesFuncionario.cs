using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Controladores.FuncionarioModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.Shared;
using CarRental.Domain.PersonModule;
using CarRental.Controladores.Shared;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Funcionarios;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Funcionarios
{
    public class OperacoesFuncionario : ICadastravel
    {
        private readonly ControladorFuncionario controlador = null;
        private readonly TabelaFuncionarioControl tabelaFuncionarios = null;

        public OperacoesFuncionario(ControladorFuncionario ctrlFuncionario)
        {
            controlador = ctrlFuncionario;
            tabelaFuncionarios = new TabelaFuncionarioControl();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void EditarRegistro()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para poder Editar!","Edição de Funcionários",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            Employee funcionarioSelecionado = controlador.SelecionarPorId(id);
            FuncionarioForm tela = new FuncionarioForm("Edição de Funcionário");
            tela.Funcionario = funcionarioSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Funcionario);
                List<Employee> funcionarios = controlador.SelecionarTodos();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Name}] editado com sucesso");
            }

        }

        public void ExcluirRegistro()
        {
            int id = tabelaFuncionarios.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Funcionário para excluir","Exclusão de Funcionários",MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
                return;
            }

            Employee funcionarioSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o funcionário: [{funcionarioSelecionado.Name}] ?", "Exclusão de Funcionários", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Excluir(id);
                List<Employee> funcionarios = controlador.SelecionarTodos();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{funcionarioSelecionado.Name}] removido com sucesso");
            }
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void InserirNovoRegistro()
        {
            FuncionarioForm tela = new FuncionarioForm("Cadastro de Funcionário");           

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Funcionario);
                List<Employee> funcionarios = controlador.SelecionarTodos();
                tabelaFuncionarios.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Funcionário: [{tela.Funcionario.Name}] inserido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Employee> funcionarios = controlador.SelecionarTodos();
            tabelaFuncionarios.AtualizarRegistros(funcionarios);
            return tabelaFuncionarios;
        }
    }
}

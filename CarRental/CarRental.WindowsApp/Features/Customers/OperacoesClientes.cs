using CarRental.Controllers.CustomersModule;
using CarRental.Domain.CustomerModule;
using CarRental.WindowsApp.Clientes;
using CarRental.WindowsApp.ClientesModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Clientes
{
    public class OperacoesClientes : ICadastravel
    {
        private readonly CustomerController controlador = null;
        private readonly TabelaClientesControl tabelaCliente = null;
        public OperacoesClientes (CustomerController ctrlCliente)
        {
            controlador = ctrlCliente;
            tabelaCliente = new TabelaClientesControl();
        }


        public void EditRecord()
        {
            int id = tabelaCliente.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente para editar", "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Customer clienteSelecionado = controlador.SelectById(id);

            ClientesForm tela = new ClientesForm("Edição de Clientes");

            tela.Clientes = clienteSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Clientes);

                List<Customer> contatos = controlador.SelectAll();

                tabelaCliente.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Customer: [{tela.Clientes.Name}] editado com sucesso");
            }
        }
        public void DeleteRecord()
        {
            int id = tabelaCliente.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione um cliente para excluir", "Exclusão de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Customer clienteSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cliente: [{clienteSelecionado.Name}] ?",
                "Exclusão de Customer", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Delete(id);

                List<Customer> contatos = controlador.SelectAll();

                tabelaCliente.AtualizarRegistros();

                TelaPrincipalForm.Instancia.AtualizarRodape($"Customer: [{clienteSelecionado.Name}] removido com sucesso");
            }
        }
        public void InsertNewRecord()
        {
            ClientesForm tela = new ClientesForm("Cadastro de Clientes");
            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Clientes);
                List<Customer> clientes = controlador.SelectAll();

                tabelaCliente.AtualizarRegistros();
                TelaPrincipalForm.Instancia.AtualizarRodape($"Customer: [{tela.Clientes.Name}] inserido com sucesso");
            }
        }

        public UserControl GetTable()
        {
            List<Customer> contatos = controlador.SelectAll();
            tabelaCliente.AtualizarRegistros();

            return tabelaCliente;
        }
        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

    }
}

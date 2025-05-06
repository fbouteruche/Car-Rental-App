using CarRental.Controllers.ServiceModule;
using CarRental.Domain.ServiceModule;
using CarRental.WindowsApp.Servicos;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Services
{
    class ServiceOperation : ICadastravel
    {
        private readonly ServiceController controlador = null;
        private readonly ServiceTableControl tabelaServicos = null;

        public ServiceOperation(ServiceController ctrlServico)
        {
            controlador = ctrlServico;
            tabelaServicos = new ServiceTableControl();
        }

        public void InsertNewRecord()
        {
            ServiceForm tela = new ServiceForm("Cadastro de Serviços");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Servico);

                List<Service> servicos = controlador.SelectAll();

                tabelaServicos.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Service: [{tela.Servico.Name}] inserido com sucesso");
            }
        }

        public void EditRecord()
        {
            int id = tabelaServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um servico para poder editar!", "Edição de Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Service servicoSelecionada = controlador.SelectById(id);

            ServiceForm tela = new ServiceForm("Edição de Serviços");

            tela.Servico = servicoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Servico);

                List<Service> servicos = controlador.SelectAll();

                tabelaServicos.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Service: [{tela.Servico.Name}] editado com sucesso");
            }
        }

        public void DeleteRecord()
        {
            int id = tabelaServicos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma servico para poder excluir!", "Exclusão de Services",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Service servicoSelecionada = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o servico: [{servicoSelecionada.Name}] ?",
                "Exclusão de Services", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Delete(id);

                List<Service> servicos = controlador.SelectAll();

                tabelaServicos.AtualizarRegistros(servicos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Service: [{servicoSelecionada.Name}] removido com sucesso");
            }
        }

        public UserControl GetTable()
        {
            List<Service> servicos = controlador.SelectAll();

            tabelaServicos.AtualizarRegistros(servicos);

            return tabelaServicos;
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }
    }
}

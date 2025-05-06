using CarRental.Controllers.RentalModule;
using CarRental.Domain.RentalModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Devolucoes
{
    public class OperacoesDevolucao : ICadastravel
    {
        private readonly RentalController controlador = null;
        private readonly TabelaDevolucaoControl tabelaDevolucao = null;
        public OperacoesDevolucao(RentalController ctrlDevolucao)
        {
            controlador = ctrlDevolucao;
            tabelaDevolucao = new TabelaDevolucaoControl();
        }
        public void InsertNewRecord()
        {
            int id = tabelaDevolucao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um registro para realizar a devolução!", "Registrar Devolução",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental locacaoSelecionada = controlador.SelectById(id);

            TelaDevolucaoForm tela = new TelaDevolucaoForm("Devolução de Veículo");

            tela.Devolucao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(tela.Devolucao.Id , tela.Devolucao);
                List<Rental> funcionarios = controlador.SelectAll();
                tabelaDevolucao.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Devolução: [{tela.Devolucao.Id}] realizada com sucesso");
            }
        }

        public void EditRecord()
        {
            MessageBox.Show("Não é possivel editar uma devolução encerrada!! \nPara editar uma locação em aberta, vá ao menu Locação");
        }

        public void DeleteRecord()
        {
            int id = tabelaDevolucao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um registro de Devolução para poder excluir!", "Exclusão de Registro",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental locacaoSelecionada = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir todo o registro da locação e devolução: [{locacaoSelecionada.Id}] ?",
                "Exclusão de Registro", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Delete(id);

                List<Rental> veiculos = controlador.SelectAll();

                tabelaDevolucao.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Registro de: [{locacaoSelecionada.ContractingCustomer}] removida com sucesso");
            }
        }

        public void FilterRecords()
        {
            FiltroDevolucaoForm telaFiltro = new FiltroDevolucaoForm();

            if (telaFiltro.ShowDialog() == DialogResult.OK)
            {
                List<Rental> devolucoes = controlador.SelectAll();
                string tipoLocacao = "";

                switch (telaFiltro.TipoFiltro)
                {
                    case FiltroDevolucaoEnum.TodasDevolucoes:
                        break;

                    case FiltroDevolucaoEnum.DevolucoesPendentes:
                        {
                            List<Rental> filtro = new List<Rental>();
                            foreach (Rental devolucao in devolucoes)
                                if (devolucao.IsOpen)
                                    filtro.Add(devolucao);
                            devolucoes = filtro;
                            tipoLocacao = "pendente(s)";
                            break;
                        }

                    case FiltroDevolucaoEnum.DevolucoesFinalizadas:
                        {
                            List<Rental> filtro = new List<Rental>();
                            foreach (Rental devolucao in devolucoes)
                                if (!devolucao.IsOpen)
                                    filtro.Add(devolucao);
                            devolucoes = filtro;
                            tipoLocacao = "concluída(s)";
                            break;
                        }

                    default:
                        break;
                }

                tabelaDevolucao.AtualizarRegistros(devolucoes);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {devolucoes.Count} devolucao(s) {tipoLocacao}");
            }
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public UserControl GetTable()
        {
            List<Rental> locacoes = controlador.SelectAll();

            tabelaDevolucao.AtualizarRegistros(locacoes);

            return tabelaDevolucao;
        }
    }
}

using CarRental.Controladores.ParceiroModule;
using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Parceiros
{
    public class OperacoesParceiro : ICadastravel
    {
        private readonly ControladorParceiro controlador;
        private readonly TabelaParceiroControl tabela;

        public OperacoesParceiro(ControladorParceiro controladorParceiro)
        {
            controlador = controladorParceiro;
            tabela = new TabelaParceiroControl();
        }

        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm("Cadastro de Partner");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Parceiro);

                List<Partner> parceiros = controlador.SelecionarTodos();

                tabela.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{tela.Parceiro.Nome}] inserido com sucesso");
            }
        }        

        public void EditarRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Partner para poder Editar!", "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner parceiroSelecionado = controlador.SelecionarPorId(id);
            TelaParceiroForm tela = new TelaParceiroForm("Edição de Partner");
            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Parceiro);
                List<Partner> parceiros = controlador.SelecionarTodos();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Nome}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Partner para excluir", "Exclusão de Partner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner parceiroSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Partner: [{parceiroSelecionado.Nome}] ?", "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Excluir(id);
                List<Partner> parceiros = controlador.SelecionarTodos();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Nome}] removido com sucesso");
            }
        }
        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }
        public UserControl ObterTabela()
        {
            List<Partner> cupons = controlador.SelecionarTodos();
            tabela.AtualizarRegistros(cupons);
            return tabela;
        }
    }
}

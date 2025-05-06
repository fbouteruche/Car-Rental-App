using CarRental.Controllers.PartnerModule;
using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Parceiros
{
    public class OperacoesParceiro : ICadastravel
    {
        private readonly PartnerController controlador;
        private readonly TabelaParceiroControl tabela;

        public OperacoesParceiro(PartnerController controladorParceiro)
        {
            controlador = controladorParceiro;
            tabela = new TabelaParceiroControl();
        }

        public void InserirNovoRegistro()
        {
            TelaParceiroForm tela = new TelaParceiroForm("Cadastro de Partner");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Parceiro);

                List<Partner> parceiros = controlador.SelectAll();

                tabela.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{tela.Parceiro.Name}] inserido com sucesso");
            }
        }        

        public void EditarRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Partner para poder Edit!", "Edição de Parceiros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner parceiroSelecionado = controlador.SelectById(id);
            TelaParceiroForm tela = new TelaParceiroForm("Edição de Partner");
            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Parceiro);
                List<Partner> parceiros = controlador.SelectAll();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Name}] editado com sucesso");
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

            Partner parceiroSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Partner: [{parceiroSelecionado.Name}] ?", "Exclusão de Parceiros", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Delete(id);
                List<Partner> parceiros = controlador.SelectAll();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Name}] removido com sucesso");
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
            List<Partner> cupons = controlador.SelectAll();
            tabela.AtualizarRegistros(cupons);
            return tabela;
        }
    }
}

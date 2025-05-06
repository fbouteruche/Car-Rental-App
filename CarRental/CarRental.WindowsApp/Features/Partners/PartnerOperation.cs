using CarRental.Controllers.PartnerModule;
using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public class PartnerOperation : ICadastravel
    {
        private readonly PartnerController controlador;
        private readonly PartnerTableControl tabela;

        public PartnerOperation(PartnerController controladorParceiro)
        {
            controlador = controladorParceiro;
            tabela = new PartnerTableControl();
        }

        public void InsertNewRecord()
        {
            PartnerForm tela = new PartnerForm("Cadastro de Partner");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Parceiro);

                List<Partner> parceiros = controlador.SelectAll();

                tabela.AtualizarRegistros(parceiros);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{tela.Parceiro.Name}] inserido com sucesso");
            }
        }        

        public void EditRecord()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Partner para poder Edit!", "Edição de Partners", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner parceiroSelecionado = controlador.SelectById(id);
            PartnerForm tela = new PartnerForm("Edição de Partner");
            tela.Parceiro = parceiroSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Parceiro);
                List<Partner> parceiros = controlador.SelectAll();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Name}] editado com sucesso");
            }
        }

        public void DeleteRecord()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Partner para excluir", "Exclusão de Partner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner parceiroSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Partner: [{parceiroSelecionado.Name}] ?", "Exclusão de Partners", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Delete(id);
                List<Partner> parceiros = controlador.SelectAll();
                tabela.AtualizarRegistros(parceiros);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Partner: [{parceiroSelecionado.Name}] removido com sucesso");
            }
        }
        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }
        public UserControl GetTable()
        {
            List<Partner> cupons = controlador.SelectAll();
            tabela.AtualizarRegistros(cupons);
            return tabela;
        }
    }
}

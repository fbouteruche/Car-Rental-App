using CarRental.Controllers.CouponModule;
using CarRental.Domain.CouponModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Coupons
{
    public class OperacoesCupom : ICadastravel
    {
        private CouponController controlador;
        private readonly TabelaCupomControl tabela;

        public OperacoesCupom(CouponController controladorCupom)
        {
            controlador = controladorCupom;
            tabela = new TabelaCupomControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCupomForm tela = new TelaCupomForm("Cadastro de CouponModule");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.Cupom);

                List<Coupon> cupons = controlador.SelectAll();

                tabela.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{tela.Cupom.Name}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um CouponModule para poder Edit!", "Edição de Coupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon cupomSelecionado = controlador.SelectById(id);
            TelaCupomForm tela = new TelaCupomForm("Edição de CouponModule");
            tela.Cupom = cupomSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Cupom);
                List<Coupon> funcionarios = controlador.SelectAll();
                tabela.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{cupomSelecionado.Name}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um CouponModule para excluir", "Exclusão de CouponModule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon parceiroSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cupom: [{parceiroSelecionado.Name}] ?", "Exclusão de Coupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Delete(id);
                List<Coupon> cupons = controlador.SelectAll();
                tabela.AtualizarRegistros(cupons);
                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{parceiroSelecionado.Name}] removido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Coupon> cupons = controlador.SelectAll();
            tabela.AtualizarRegistros(cupons);
            return tabela;
        }

        public void FiltrarRegistros()
        {
            throw new NotImplementedException();
        }

        public void AgruparRegistros()
        {
            throw new NotImplementedException();
        }
    }
}

using CarRental.Controllers.CupomModule;
using CarRental.Domain.CouponModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Cupons
{
    public class OperacoesCupom : ICadastravel
    {
        private ControladorCupom controlador;
        private readonly TabelaCupomControl tabela;

        public OperacoesCupom(ControladorCupom controladorCupom)
        {
            controlador = controladorCupom;
            tabela = new TabelaCupomControl();
        }

        public void InserirNovoRegistro()
        {
            TelaCupomForm tela = new TelaCupomForm("Cadastro de CouponModule");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InserirNovo(tela.Cupom);

                List<Coupon> cupons = controlador.SelecionarTodos();

                tabela.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{tela.Cupom.Name}] inserido com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabela.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um CouponModule para poder Editar!", "Edição de Cupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon cupomSelecionado = controlador.SelecionarPorId(id);
            TelaCupomForm tela = new TelaCupomForm("Edição de CouponModule");
            tela.Cupom = cupomSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Cupom);
                List<Coupon> funcionarios = controlador.SelecionarTodos();
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

            Coupon parceiroSelecionado = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cupom: [{parceiroSelecionado.Name}] ?", "Exclusão de Cupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controlador.Excluir(id);
                List<Coupon> cupons = controlador.SelecionarTodos();
                tabela.AtualizarRegistros(cupons);
                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{parceiroSelecionado.Name}] removido com sucesso");
            }
        }

        public UserControl ObterTabela()
        {
            List<Coupon> cupons = controlador.SelecionarTodos();
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

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
    public class CouponOperations : ICadastravel
    {
        private CouponController controller;
        private readonly TabelaCupomControl table;

        public CouponOperations(CouponController couponController)
        {
            controller = couponController;
            table = new TabelaCupomControl();
        }

        public void InsertNewRecord()
        {
            TelaCupomForm tela = new TelaCupomForm("Cadastro de CouponModule");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(tela.Cupom);

                List<Coupon> cupons = controller.SelectAll();

                table.AtualizarRegistros(cupons);

                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{tela.Cupom.Name}] inserido com sucesso");
            }
        }

        public void EditRecord()
        {
            int id = table.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um CouponModule para poder Edit!", "Edição de Coupons", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon cupomSelecionado = controller.SelectById(id);
            TelaCupomForm tela = new TelaCupomForm("Edição de CouponModule");
            tela.Cupom = cupomSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, tela.Cupom);
                List<Coupon> funcionarios = controller.SelectAll();
                table.AtualizarRegistros(funcionarios);
                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{cupomSelecionado.Name}] editado com sucesso");
            }
        }

        public void DeleteRecord()
        {
            int id = table.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um CouponModule para excluir", "Exclusão de CouponModule", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon parceiroSelecionado = controller.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o cupom: [{parceiroSelecionado.Name}] ?", "Exclusão de Coupons", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controller.Delete(id);
                List<Coupon> cupons = controller.SelectAll();
                table.AtualizarRegistros(cupons);
                TelaPrincipalForm.Instancia.AtualizarRodape($"CouponModule: [{parceiroSelecionado.Name}] removido com sucesso");
            }
        }

        public UserControl GetTable()
        {
            List<Coupon> cupons = controller.SelectAll();
            table.AtualizarRegistros(cupons);
            return table;
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

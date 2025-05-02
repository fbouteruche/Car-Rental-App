using CarRental.Controllers.LocacaoModule;
using CarRental.Controllers.RelacionamentoLocServModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.WindowsApp.Servicos;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Locacoes
{
    public class OperacoesLocacao : ICadastravel
    {
        private readonly ControladorLocacao controlador = null;
        private readonly ControladorRelacionamentoLocServ controladorRelacionamento = null;
        private RentalServiceRelationship relacionamento;
        private readonly TabelaLocacaoControl tabelaLocacao = null;
        PdfConverter conversorPdf;
        public OperacoesLocacao(ControladorLocacao ctrlLocacao)
        {
            conversorPdf = new PdfConverter(10, 18);
            controlador = ctrlLocacao;
            controladorRelacionamento = new ControladorRelacionamentoLocServ();
            tabelaLocacao = new TabelaLocacaoControl();
        }

        public void InserirNovoRegistro()
        {
            TelaLocacaoForm tela = new TelaLocacaoForm("Locação de Veiculos");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                string resultadoLocacao = controlador.InserirNovo(tela.Locacao);

                if (resultadoLocacao == "VALIDO")
                {
                    relacionamento = new RentalServiceRelationship(0, tela.Locacao, tela.Servicos);
                    controladorRelacionamento.InserirNovo(relacionamento);
                    conversorPdf.ConvertRentalToPdf(tela.Locacao);

                    try
                    {
                        EnviarEmail(tela);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao tentar enviar os dados de locação por e-mail.\nO recibo está salvo na pasta Recibos e deverá ser enviado manualmente assim que possível!!\n" + ex.Message, "Erro ao enviar e-mail");
                    }
                }

                List<Rental> veiculos = controlador.SelecionarTodos();

                tabelaLocacao.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação: [{tela.Locacao.Vehicle}] realizada com sucesso");
            }
        }

        public void EditarRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locação para poder editar!", "Edição de locação", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental locacaoSelecionada = controlador.SelecionarPorId(id);

            TelaLocacaoForm tela = new TelaLocacaoForm("Edição de Locação");

            tela.Locacao = locacaoSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Locacao);

                List<Rental> veiculos = controlador.SelecionarTodos();

                tabelaLocacao.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação de: [{tela.Locacao.ContractingCustomer}] editado com sucesso");
            }
        }

        public void ExcluirRegistro()
        {
            int id = tabelaLocacao.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione uma locação para poder excluir!", "Exclusão de Locação",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental locacaoSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir a locação: [{locacaoSelecionada.Id}] ?",
                "Exclusão de Locação", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Rental> veiculos = controlador.SelecionarTodos();

                tabelaLocacao.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Locação de: [{locacaoSelecionada.ContractingCustomer}] removida com sucesso");
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
            List<Rental> locacoes = controlador.SelecionarTodos();
            tabelaLocacao.AtualizarRegistros(locacoes);

            return tabelaLocacao;
        }

        private void EnviarEmail(TelaLocacaoForm tela)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                using (MailMessage email = new MailMessage())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("matriquisdevelopers@gmail.com", "matrixadm");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    email.From = new MailAddress("matriquisdevelopers@gmail.com");
                    email.To.Add(tela.Locacao.ContractingCustomer.Email);

                    email.Subject = "Matrix";
                    email.IsBodyHtml = false;
                    email.Body = "Obrigado por utilizar nossos serviços, volte sempre!";


                    email.Attachments.Add(new Attachment($@"..\..\..\Recibos\recibo{tela.Locacao.Id}.pdf"));

                    smtp.Send(email);
                }
            }
        }
    }
}

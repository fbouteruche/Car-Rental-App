using CarRental.Controladores.ClientesModule;
using CarRental.Controladores.CupomModule;
using CarRental.Controladores.FuncionarioModule;
using CarRental.Controladores.VeiculoModule;
using CarRental.Domain.ClienteModule;
using CarRental.Domain.Coupon;
using CarRental.Domain.FuncionarioModule;
using CarRental.Domain.LocacaoModule;
using CarRental.Domain.RelacionamentoLocServModule;
using CarRental.Domain.SevicosModule;
using CarRental.Domain.Shared;
using CarRental.Domain.VeiculoModule;
using CarRental.WindowsApp.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Locacoes
{
    public partial class TelaLocacaoForm : Form
    {
        private Locacao locacao;
        private ControladorFuncionario controladorFuncionario = new ControladorFuncionario();
        private ControladorVeiculo controladorVeiculo = new ControladorVeiculo();
        private ControladorCliente controladorCliente = new ControladorCliente();
        private ControladorCupom controladorCupom = new ControladorCupom();
        public List<Servico> Servicos;
        public string TipoSeguro = "Nenhum";
        ServicosForm telaServico = new ServicosForm();
        public TelaLocacaoForm(string titulo)
        {
            Servicos = new List<Servico>();
            InitializeComponent();
            lblTitulo.Text = titulo;
            CarregarDados();
            CarregaCondutor();
            cBoxPlano.SelectedIndex = 0;
        }

        public Locacao Locacao
        {
            get { return locacao; }

            set
            {
                locacao = value;

                txtId.Text = locacao.Id.ToString();
                cBoxVeiculo.SelectedItem = locacao.Veiculo;
                cBoxFuncionario.SelectedItem = locacao.FuncionarioLocador;
                cBoxCliente.SelectedItem = locacao.ClienteContratante;
                cBoxCondutor.SelectedItem = locacao.ClienteCondutor;
                cBoxPlano.SelectedItem = locacao.TipoDoPlano;
                dateTPDataSaida.Text = locacao.DataDeSaida.ToLongDateString();
                dateTPDataDevolucao.Text = locacao.DataPrevistaDeChegada.ToLongDateString();
                txtTotal.Text = locacao.PrecoLocacao.ToString();
                Servicos = locacao.Servicos;
                TipoSeguro = locacao.TipoDeSeguro;

            }
        }

        private void CarregarDados()
        {
            cBoxFuncionario.DataSource = controladorFuncionario.SelecionarTodos();
            List<Veiculo> veiculosDisponiveis = new List<Veiculo>();
            if (lblTitulo.Text.Contains("Edição"))
                veiculosDisponiveis = controladorVeiculo.SelecionarTodos();
            else
                AdicionaApenasVeiculoDisponivel(veiculosDisponiveis);
            cBoxVeiculo.DataSource = veiculosDisponiveis;
            cBoxCliente.DataSource = controladorCliente.SelecionarTodos();
        }

        private void AdicionaApenasVeiculoDisponivel(List<Veiculo> veiculosDisponiveis)
        {
            foreach (Veiculo item in controladorVeiculo.SelecionarTodos())
                if (!item.estaAlugado)
                    veiculosDisponiveis.Add(item);
        }

        private void CarregaCondutor()
        {
            List<Customer> clientesPf = new List<Customer>();
            foreach (Customer cliente in controladorCliente.SelecionarTodos())
                if (cliente.IsPhysicalPerson)
                    clientesPf.Add(cliente);
            cBoxCondutor.DataSource = clientesPf;
        }

        private void brnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string tipoDoPlano = cBoxPlano.Text.Replace(" ", "");
            Veiculo veiculo = cBoxVeiculo.SelectedItem as Veiculo;
            Employee funcionarioLocador = cBoxFuncionario.SelectedItem as Employee;
            Customer clienteContratante = cBoxCliente.SelectedItem as Customer;
            Customer condutor = cBoxCondutor.SelectedItem as Customer;
            DateTime dataDeSaida = dateTPDataSaida.Value;
            DateTime dataPrevistaDeChegada = dateTPDataDevolucao.Value;
            string tipoDeSeguro = "Nenhum";
            if (telaServico.seguro.Length > 0)
                tipoDeSeguro = telaServico.seguro;
            Coupon cupom = null;
            bool existe = controladorCupom.ExisteCodigo(txtCupom.Text);
            if (existe)
            {
                cupom = controladorCupom.SelecionarPorCodigo(txtCupom.Text);
                if (cupom.ExpirationDate < DateTime.Now)
                    cupom = null;
            }

            locacao = new Locacao(id, veiculo, funcionarioLocador, clienteContratante, condutor, cupom, dataDeSaida, dataPrevistaDeChegada, tipoDoPlano, tipoDeSeguro, Servicos);
            Veiculo veiculoAtualizado = locacao.Veiculo;
            controladorVeiculo.Editar(locacao.Veiculo.Id, veiculoAtualizado);
            string resultadoValidacao = locacao.Validate();

            if (resultadoValidacao != "VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();
                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);
                DialogResult = DialogResult.None;
            }
        }



        private void btnServicos_Click(object sender, EventArgs e)
        {
            telaServico = new ServicosForm();
            telaServico.InicializarCampos(Servicos, TipoSeguro, true);

            if (telaServico.ShowDialog() == DialogResult.OK)
            {
                Servicos = telaServico.servicosSelecionados;
                TipoSeguro = telaServico.seguro;
                double precoGarantia = CalculateRental.CalculateGuarantee();
                double precoSeguro = CalculateRental.CalculateInsurance(telaServico.seguro);
                txtTotal.Text = Convert.ToString(precoGarantia + precoSeguro);
            }
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            string cupom = txtCupom.Text;
            bool existe = controladorCupom.ExisteCodigo(cupom);
            if (existe)
                txtCupom.BackColor = Color.Green;
            else
                txtCupom.BackColor = Color.Red;
        }
    }
}

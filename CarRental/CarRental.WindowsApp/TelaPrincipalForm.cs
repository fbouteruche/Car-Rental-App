using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRental.WindowsApp.Clientes;
using CarRental.WindowsApp.Funcionarios;
using CarRental.WindowsApp.ClientesModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Features.Funcionarios;
using CarRental.WindowsApp.Features.Servicos;
using CarRental.Controllers.ServiceModule;
using CarRental.WindowsApp.Features.Clientes;
using CarRental.Controllers.CustomersModule;
using CarRental.WindowsApp.Features.Veiculos;
using CarRental.Controllers.VehicleModule;
using CarRental.WindowsApp.Features.GrupoDeVeiculos;
using CarRental.Controllers.VehicleGroupModule;
using CarRental.WindowsApp.Features.Locacoes;
using CarRental.Controllers.RentalModule;
using CarRental.WindowsApp.Features.Devolucoes;
using CarRental.WindowsApp.Features.Dashboards;
using CarRental.WindowsApp.Features.Parceiros;
using CarRental.Controllers.PartnerModule;
using CarRental.WindowsApp.Features.Coupons;
using CarRental.Controllers.CouponModule;

namespace CarRental.WindowsApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ICadastravel operacoes;
        public static TelaPrincipalForm Instancia;
        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;
            MostrarDashBoard();
        }

        #region Opções do menu strip
        private void funcionariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoFuncionarioToolBox configuracao = new ConfiguracaoFuncionarioToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesFuncionario(new EmployeeController());

            ConfigurarPainelRegistros();
        }

        private void servicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoServicoToolBox configuracao = new ConfiguracaoServicoToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesServico(new ServiceController());

            ConfigurarPainelRegistros();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoClienteToolBox configuracao = new ConfiguracaoClienteToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesClientes(new CustomerController());

            ConfigurarPainelRegistros();
        }

        private void veiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoVeiculoToolBox configuracao = new ConfiguracaoVeiculoToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesVeiculo(new VehicleController());

            ConfigurarPainelRegistros();
        }

        private void grupoDeVeículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoGrupoDeVeiculosToolBox configuracao = new ConfiguracaoGrupoDeVeiculosToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesGrupoDeVeiculos(new VehicleGroupController());

            ConfigurarPainelRegistros();
        }
        private void locarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoLocacaoToolBox configuracao = new ConfiguracaoLocacaoToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesLocacao(new RentalController(new VehicleController(), new EmployeeController(), new CustomerController(), new ServiceController(), new CouponController()));

            ConfigurarPainelRegistros();
        }

        private void devoluçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDevolucaoToolBox configuracao = new ConfiguracaoDevolucaoToolBox();

            ConfigurarToolBox(configuracao, true);
            btnAdicionar.Image = Properties.Resources.car_32px;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesDevolucao(new RentalController(new VehicleController(), new EmployeeController(), new CustomerController(), new ServiceController(), new CouponController()));

            ConfigurarPainelRegistros();
        }

        private void cuponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CouponConfigurationToolBox configuracao = new CouponConfigurationToolBox();

            ConfigurarToolBox(configuracao, false);

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesCupom(new CouponController());

            ConfigurarPainelRegistros();
        }

        private void parceirosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoParceiroToolBox configuracao = new ConfiguracaoParceiroToolBox();

            ConfigurarToolBox(configuracao, false);
            btnAdicionar.Image = Properties.Resources._36x1;

            AtualizarRodape(configuracao.RegistrationType);

            operacoes = new OperacoesParceiro(new PartnerController());

            ConfigurarPainelRegistros();
        }
        #endregion

        #region Ações dos botões
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            operacoes.InserirNovoRegistro();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            operacoes.EditarRegistro();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            operacoes.ExcluirRegistro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            operacoes.FiltrarRegistros();
        }
        #endregion

        #region Métodos privados
        private void ConfigurarPainelRegistros()
        {
            UserControl tabela = operacoes.ObterTabela();

            tabela.Dock = DockStyle.Fill;

            panelRegistros.Controls.Clear();

            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarPainelDashBoard()
        {
            UserControl tabela = new DashControl();
            tabela.Dock = DockStyle.Fill;
            panelRegistros.Controls.Clear();
            panelRegistros.Controls.Add(tabela);
        }

        private void ConfigurarToolBox(IConfigurationToolBox configuracao, bool possivelFiltrar)
        {
            toolBoxAcoes.Enabled = true;
            if (possivelFiltrar)
                btnFiltrar.Enabled = true;
            else
                btnFiltrar.Enabled = false;
            labelTipoCadastro.Text = configuracao.RegistrationType;
            btnAdicionar.ToolTipText = configuracao.AddToolTip;
            btnEditar.ToolTipText = configuracao.EditToolTip;
            btnExcluir.ToolTipText = configuracao.DeleteToolTip;
        }
        #endregion
        public void AtualizarRodape(string mensagem) { labelRodape.Text = mensagem; }
        private void inícioToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MostrarDashBoard();
        }
        private void MostrarDashBoard()
        {
            ConfiguracaoDashboardToolBox configuracao = new ConfiguracaoDashboardToolBox();
            ConfigurarToolBox(configuracao, false);
            toolBoxAcoes.Enabled = false;
            AtualizarRodape(configuracao.RegistrationType);
            ConfigurarPainelDashBoard();
        }
    }
}

using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CouponModule;
using CarRental.Controllers.EmployeeModule;
using CarRental.Controllers.VehicleModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.CouponModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.Shared;
using CarRental.Domain.VehicleModule;
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

namespace CarRental.WindowsApp.Features.Rentals
{
    public partial class RentalForm : Form
    {
        private Rental locacao;
        private EmployeeController controladorFuncionario = new EmployeeController();
        private VehicleController controladorVeiculo = new VehicleController();
        private CustomerController controladorCliente = new CustomerController();
        private CouponController controladorCupom = new CouponController();
        public List<Service> Servicos;
        public string TipoSeguro = "Nenhum";
        ServicosForm telaServico = new ServicosForm();
        public RentalForm(string titulo)
        {
            Servicos = new List<Service>();
            InitializeComponent();
            lblTitulo.Text = titulo;
            CarregarDados();
            CarregaCondutor();
            cBoxPlano.SelectedIndex = 0;
        }

        public Rental Locacao
        {
            get { return locacao; }

            set
            {
                locacao = value;

                txtId.Text = locacao.Id.ToString();
                cBoxVeiculo.SelectedItem = locacao.Vehicle;
                cBoxFuncionario.SelectedItem = locacao.RentingEmployee;
                cBoxCliente.SelectedItem = locacao.ContractingCustomer;
                cBoxCondutor.SelectedItem = locacao.DriverCustomer;
                cBoxPlano.SelectedItem = locacao.PlanType;
                dateTPDataSaida.Text = locacao.DepartureDate.ToLongDateString();
                dateTPDataDevolucao.Text = locacao.ExpectedReturnDate.ToLongDateString();
                txtTotal.Text = locacao.RentalPrice.ToString();
                Servicos = locacao.Services;
                TipoSeguro = locacao.InsuranceType;

            }
        }

        private void CarregarDados()
        {
            cBoxFuncionario.DataSource = controladorFuncionario.SelectAll();
            List<Vehicle> veiculosDisponiveis = new List<Vehicle>();
            if (lblTitulo.Text.Contains("Edição"))
                veiculosDisponiveis = controladorVeiculo.SelectAll();
            else
                AdicionaApenasVeiculoDisponivel(veiculosDisponiveis);
            cBoxVeiculo.DataSource = veiculosDisponiveis;
            cBoxCliente.DataSource = controladorCliente.SelectAll();
        }

        private void AdicionaApenasVeiculoDisponivel(List<Vehicle> veiculosDisponiveis)
        {
            foreach (Vehicle item in controladorVeiculo.SelectAll())
                if (!item.isRented)
                    veiculosDisponiveis.Add(item);
        }

        private void CarregaCondutor()
        {
            List<Customer> clientesPf = new List<Customer>();
            foreach (Customer cliente in controladorCliente.SelectAll())
                if (cliente.IsPhysicalPerson)
                    clientesPf.Add(cliente);
            cBoxCondutor.DataSource = clientesPf;
        }

        private void brnConfirmar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtId.Text);
            string tipoDoPlano = cBoxPlano.Text.Replace(" ", "");
            Vehicle veiculo = cBoxVeiculo.SelectedItem as Vehicle;
            Domain.EmployeeModule.Employee funcionarioLocador = cBoxFuncionario.SelectedItem as Domain.EmployeeModule.Employee;
            Customer clienteContratante = cBoxCliente.SelectedItem as Customer;
            Customer condutor = cBoxCondutor.SelectedItem as Customer;
            DateTime dataDeSaida = dateTPDataSaida.Value;
            DateTime dataPrevistaDeChegada = dateTPDataDevolucao.Value;
            string tipoDeSeguro = "Nenhum";
            if (telaServico.seguro.Length > 0)
                tipoDeSeguro = telaServico.seguro;
            Coupon cupom = null;
            bool existe = controladorCupom.CodeExists(txtCupom.Text);
            if (existe)
            {
                cupom = controladorCupom.SelectByCode(txtCupom.Text);
                if (cupom.ExpirationDate < DateTime.Now)
                    cupom = null;
            }

            locacao = new Rental(id, veiculo, funcionarioLocador, clienteContratante, condutor, cupom, dataDeSaida, dataPrevistaDeChegada, tipoDoPlano, tipoDeSeguro, Servicos);
            Vehicle veiculoAtualizado = locacao.Vehicle;
            controladorVeiculo.Edit(locacao.Vehicle.Id, veiculoAtualizado);
            string resultadoValidacao = locacao.Validate();

            if (resultadoValidacao != "VALID")
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
            bool existe = controladorCupom.CodeExists(cupom);
            if (existe)
                txtCupom.BackColor = Color.Green;
            else
                txtCupom.BackColor = Color.Red;
        }
    }
}

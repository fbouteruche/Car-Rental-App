using CarRental.Controllers.CustomersModule;
using CarRental.Controllers.CupomModule;
using CarRental.Controllers.FuncionarioModule;
using CarRental.Controllers.LocacaoModule;
using CarRental.Controllers.ServicoModule;
using CarRental.Controllers.VeiculoModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.VehicleModule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Dashboards
{
    public partial class DashControl : UserControl
    {
        ControladorVeiculo controladorVeiculo;
        CustomerController controladorCliente;
        ControladorServico controladorServicos;
        ControladorLocacao controladorLocacao;
        ControladorFuncionario controladorFuncionario;
        ControladorCupom controladorCupom;
        public DashControl()
        {
            InitializeComponent();
            controladorVeiculo = new ControladorVeiculo();
            controladorCliente = new CustomerController();
            controladorServicos = new ControladorServico();
            controladorFuncionario = new ControladorFuncionario();
            controladorLocacao = new ControladorLocacao(controladorVeiculo, controladorFuncionario,controladorCliente, controladorServicos, controladorCupom);
            MudaLabels();
        }

        private void MudaLabels()
        {
            CarregaDashBoardVeiculo();
            CarregaDashBoardCliente();
            CarregarDashBoardServicos();
            CarregarDashBoardLocacao();
        }

        private void CarregarDashBoardLocacao()
        {
            List<Rental> todasLocacao = controladorLocacao.SelectAll();
            List<Rental> locacoesAbertas = new List<Rental>();
            foreach (Rental locacao in todasLocacao)
                if (locacao.IsOpen)
                    locacoesAbertas.Add(locacao);

            int retornamHJ = 0;
            int retornam7dias = 0;
            

            foreach (Rental locacao in locacoesAbertas)
            {
                if (locacao.ReturnDate.Date == DateTime.Today )
                {
                    retornamHJ++;
                }
                else if (locacao.ReturnDate.Date <= DateTime.Today.AddDays(7))
                {
                    retornam7dias++;
                }
            }
            lbRetornoHJ.Text = retornamHJ.ToString();
            lbCarrosAlugados.Text = locacoesAbertas.Count.ToString();
            lbRetornam7.Text = retornam7dias.ToString();
           
        }

        private void CarregarDashBoardServicos()
        {
            List<Service> todosServicos = controladorServicos.SelectAll();
            int servicosTotal = todosServicos.Count;

            lbServicos.Text = servicosTotal.ToString();
        }

        private void CarregaDashBoardCliente()
        {
            List<Customer> todosClientes = controladorCliente.SelectAll();
            int clientesTotal = todosClientes.Count;
            int clientesPF = 0;
            int clientesPJ = 0;

            foreach (Customer cliente in todosClientes)
            {
                if (cliente.IsPhysicalPerson)
                {
                    clientesPF++;
                }
                else
                {
                    clientesPJ++;
                }
            }
            lbClientesPJ.Text = clientesPJ.ToString();
            lbClientesPF.Text = clientesPF.ToString();
            lbClientesTotal.Text = clientesTotal.ToString();
          
        }

        private void CarregaDashBoardVeiculo()
        {
            List<Vehicle> TodosVeiculos = controladorVeiculo.SelectAll();
            int carrosNoTotal = TodosVeiculos.Count;
            int carrosAlugados = 0;
            int carrosDisponiveis = 0;


            foreach (Vehicle veiculo in TodosVeiculos)
            {
                if (veiculo.isRented)
                {
                    carrosAlugados++;
                }
                else
                {
                    carrosDisponiveis++;
                }
            }
            lbCarDisp.Text = carrosDisponiveis.ToString();
            lbCarInd.Text = carrosAlugados.ToString();
            lbCarTotal.Text = carrosNoTotal.ToString();
        }


    }
}

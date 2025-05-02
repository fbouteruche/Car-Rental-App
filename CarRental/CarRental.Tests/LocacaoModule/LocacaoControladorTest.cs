using FluentAssertions;
using CarRental.Controllers.ClientesModule;
using CarRental.Controllers.CupomModule;
using CarRental.Controllers.FuncionarioModule;
using CarRental.Controllers.GrupoDeVeiculosModule;
using CarRental.Controllers.LocacaoModule;
using CarRental.Controllers.ServicoModule;
using CarRental.Controllers.Shared;
using CarRental.Controllers.VeiculoModule;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.VehicleModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarRental.Tests.LocacaoModule
{
    [TestClass]
    public class LocacaoControladorTest
    {
        ControladorLocacao controlador = null;
        ControladorGrupoDeVeiculos controladorGrupoDeVeiculos = null;
        ControladorVeiculo controladorVeiculo = null;
        ControladorFuncionario controladorFuncionario = null;
        ControladorCliente controladorCliente = null;
        ControladorServico controladorServico = null;
        ControladorCupom controladorCupom = null;
        VehicleGroup grupoVeiculos;
        Vehicle veiculo;
        Employee funcionario;
        Customer clienteContratante;
        Customer clienteCondutor;
        Rental locacao;

        public LocacaoControladorTest()
        {
            controladorGrupoDeVeiculos = new ControladorGrupoDeVeiculos();
            controladorVeiculo = new ControladorVeiculo();
            controladorFuncionario = new ControladorFuncionario();
            controladorCliente = new ControladorCliente();
            controladorServico = new ControladorServico();
            controladorCupom = new ControladorCupom();
            controlador = new ControladorLocacao(controladorVeiculo, controladorFuncionario, controladorCliente, controladorServico, controladorCupom);
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void DeveInserirUmaLocacao()
        {
            grupoVeiculos = new VehicleGroup(0, "nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);
            controladorGrupoDeVeiculos.InserirNovo(grupoVeiculos);
            veiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            controladorVeiculo.InserirNovo(veiculo);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            controladorFuncionario.InserirNovo(funcionario);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteContratante);
            clienteCondutor = new Customer(0, "Nardolindo", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteCondutor);

            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", 0,0,false,null);
            controlador.InserirNovo(locacao);

            var locacaoEncontrada = controlador.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(locacao);
        }

        [TestMethod]
        public void DeveSelecionarDuasLocacoes()
        {
            grupoVeiculos = new VehicleGroup(0, "nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);
            controladorGrupoDeVeiculos.InserirNovo(grupoVeiculos);
            veiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            controladorVeiculo.InserirNovo(veiculo);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            controladorFuncionario.InserirNovo(funcionario);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteContratante);
            clienteCondutor = new Customer(0, "Nardolindo", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteCondutor);

            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);
            controlador.InserirNovo(locacao);
            Rental outraLocacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today.AddDays(-10), DateTime.Today.AddDays(15), "PlanoDiario", "SeguroCliente", null);
            controlador.InserirNovo(outraLocacao);

            List<Rental> locacaoEncontrado = controlador.SelecionarTodos();
            locacaoEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmaLocacao()
        {
            grupoVeiculos = new VehicleGroup(0, "nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);
            controladorGrupoDeVeiculos.InserirNovo(grupoVeiculos);
            veiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            controladorVeiculo.InserirNovo(veiculo);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            controladorFuncionario.InserirNovo(funcionario);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteContratante);
            clienteCondutor = new Customer(0, "Nardolindo", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteCondutor);

            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);
            controlador.InserirNovo(locacao);
            Rental outraLocacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", 0, 0, false, null);
            controlador.Editar(locacao.Id, outraLocacao);

            var locacaoEncontrada = controlador.SelecionarPorId(locacao.Id);
            locacaoEncontrada.Should().Be(outraLocacao);
        }

        [TestMethod]
        public void DeveExcluirUmVeiculo()
        {
            grupoVeiculos = new VehicleGroup(0, "nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);
            controladorGrupoDeVeiculos.InserirNovo(grupoVeiculos);
            veiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            controladorVeiculo.InserirNovo(veiculo);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            controladorFuncionario.InserirNovo(funcionario);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteContratante);
            clienteCondutor = new Customer(0, "Nardolindo", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controladorCliente.InserirNovo(clienteCondutor);

            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);
            controlador.InserirNovo(locacao);
            controlador.Excluir(locacao.Id);

            List<Rental> locacaoEncontrado = controlador.SelecionarTodos();
            locacaoEncontrado.Count.Should().Be(0);
        }

    }
}

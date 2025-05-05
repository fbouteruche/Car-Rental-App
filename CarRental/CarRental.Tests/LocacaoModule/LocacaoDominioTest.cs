using FluentAssertions;
using CarRental.Controllers.Shared;
using CarRental.Domain.CustomerModule;
using CarRental.Domain.EmployeeModule;
using CarRental.Domain.RentalModule;
using CarRental.Domain.VehicleModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarRental.Tests.LocacaoModule
{
    [TestClass]
    [TestCategory("Domain")]
    public class LocacaoDominioTest
    {
        Vehicle veiculo;
        Employee funcionario;
        Customer clienteContratante;
        Customer clienteCondutor;
        Rental locacao;

        [TestMethod]
        public void DeveCriarLocacao_ComContratantePFeCondutorPF()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true,null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum",null);

            string resultado = locacao.Validate();

            resultado.Should().Be("VALIDO");
        }

        [TestMethod]
        public void DeveCriarLocacao_ComContratantePFeSemCondutor()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true,null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, null, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("VALIDO");
        }

        [TestMethod]
        public void DeveCriarLocacao_ComContratantePJeCondutorPF()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true,null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), false);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("VALIDO");
        }

        [TestMethod]
        public void DeveApresentarErro_ComFuncionarioNull()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true,null);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, null, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O funcionário locador não pode ser nulo\n");
        }

        [TestMethod]
        public void DeveApresentarErro_ComContratanteNullo()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, funcionario, null, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), DateTime.Today.AddDays(5f), "KmLivre", "Nenhum",0,0,true, null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O cliente contratante não pode ser nulo\n");
        }

        [TestMethod]
        public void DeveApresentarErro_ComContratantePJsemCondutor()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), false);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, null, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O condutor não pode ser nulo quando o cliente contratante é pessoa juridica\n");
        }

        [TestMethod]
        public void DeveApresentarErro_ComContratantePJeCondutorPJ()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), false);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), false);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O condutor não pode ser pessoa jurídica.\n");
        }

        [TestMethod]
        public void DeveApresentarErro_ComTipoDePlanoErrado()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "PlanoErrado", "Nenhum", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O tipo do plano é inválido.\n");
        }

        [TestMethod]
        public void DeveCriarLocacao_ComTipoDeSeguroErrado()
        {
            veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            clienteContratante = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            clienteCondutor = new Customer(1, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);
            locacao = new Rental(0, veiculo, funcionario, clienteContratante, clienteCondutor, null, DateTime.Today, DateTime.Today.AddDays(5f), "KmLivre", "SeguroErrado", null);

            string resultado = locacao.Validate();

            resultado.Should().Be("O tipo do seguro é inválido.\n");
        }
    }
}

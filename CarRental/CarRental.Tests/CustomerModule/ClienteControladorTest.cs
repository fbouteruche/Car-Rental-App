using FluentAssertions;
using CarRental.Controllers.ClientesModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.CustomerModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarRental.Tests.ClienteModule
{
    [TestClass]
    [TestCategory("Controllers")]
    public class ClienteControladorTest
    {
        ControladorCliente controlador = null;
        Customer cliente;
        public ClienteControladorTest()
        {
            controlador = new ControladorCliente();
            ResetarBanco.ResetarTabelas();
        }
        [TestMethod]
        public void DeveInserir_NovoCliente()
        {
            //arrange
            Customer cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            //action
            controlador.InserirNovo(cliente);

            //assert
            Customer clienteEncontrado = controlador.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().Be(cliente);

        }

        [TestMethod]
        public void DeveAtualizar_Cliente()
        {
            //arrange
            cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controlador.InserirNovo(cliente);

            Customer clienteeditado = new Customer(2, "Arnaldo", "888.777.666.55", "Rua Laguna", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);

            //action
            controlador.Editar(cliente.Id, clienteeditado);

            //assert
            Customer clienteAtualizado = controlador.SelecionarPorId(cliente.Id);
            clienteAtualizado.Should().Be(cliente);
        }

        [TestMethod]
        public void DeveExcluir_Cliente()
        {
            //arrange
            Customer cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controlador.InserirNovo(cliente);

            //action
            controlador.Excluir(cliente.Id);

            //assert
            Customer clienteEncontrado = controlador.SelecionarPorId(cliente.Id);
            clienteEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosClientes()
        {
            Customer c1 = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            controlador.InserirNovo(c1);
            controlador.InserirNovo(c1);

            var clientes = controlador.SelecionarTodos();

            clientes.Should().HaveCount(2);
            clientes[0].Name.Should().Be("Name Teste");
            clientes[1].Name.Should().Be("Name Teste");
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void DeveSelecionar_Cliente_PorID()
        {
            //arrange
            Customer cliente = new Customer(0, "Name Teste", "954.746.736-04", "Address Customer", "4932518000", "teste@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controlador.InserirNovo(cliente);

            //action
            Customer clienteEncontrado = controlador.SelecionarPorId(cliente.Id);

            //assert
            clienteEncontrado.Should().NotBeNull();
        }        
    }
}

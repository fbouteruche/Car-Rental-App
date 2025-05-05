using FluentAssertions;
using CarRental.Controllers.ClientesModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.CustomerModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarRental.Tests.CustomerModule
{
    [TestClass]
    [TestCategory("Controllers")]
    public class CustomerControllerTest
    {
        ControladorCliente controller = null;
        Customer customer;
        public CustomerControllerTest()
        {
            controller = new ControladorCliente();
            ResetarBanco.ResetarTabelas();
        }
        [TestMethod]
        public void ShouldInsert_NewCustomer()
        {
            // arrange
            Customer customer = new Customer(0, "Test Name", "954.746.736-04", "Customer Address", "4932518000", "test@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            // act
            controller.InserirNovo(customer);

            // assert
            Customer foundCustomer = controller.SelecionarPorId(customer.Id);
            foundCustomer.Should().Be(customer);
        }

        [TestMethod]
        public void ShouldUpdate_Customer()
        {
            // arrange
            customer = new Customer(0, "Test Name", "954.746.736-04", "Customer Address", "4932518000", "test@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controller.InserirNovo(customer);

            Customer editedCustomer = new Customer(2, "Arnaldo", "888.777.666.55", "Laguna Street", "97777-6666", "arnaldo@test.com", "98765432103", new DateTime(2020, 11, 11), true);

            // act
            controller.Editar(customer.Id, editedCustomer);

            // assert
            Customer updatedCustomer = controller.SelecionarPorId(customer.Id);
            updatedCustomer.Should().Be(customer);
        }

        [TestMethod]
        public void ShouldDelete_Customer()
        {
            // arrange
            Customer customer = new Customer(0, "Test Name", "954.746.736-04", "Customer Address", "4932518000", "test@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controller.InserirNovo(customer);

            // act
            controller.Excluir(customer.Id);

            // assert
            Customer foundCustomer = controller.SelecionarPorId(customer.Id);
            foundCustomer.Should().BeNull();
        }

        [TestMethod]
        public void ShouldSelect_AllCustomers()
        {
            Customer c1 = new Customer(0, "Test Name", "954.746.736-04", "Customer Address", "4932518000", "test@email.com", "978545956-90", new DateTime(2030, 01, 01), true);

            controller.InserirNovo(c1);
            controller.InserirNovo(c1);

            var customers = controller.SelecionarTodos();

            customers.Should().HaveCount(2);
            customers[0].Name.Should().Be("Test Name");
            customers[1].Name.Should().Be("Test Name");
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void ShouldSelect_Customer_ById()
        {
            // arrange
            Customer customer = new Customer(0, "Test Name", "954.746.736-04", "Customer Address", "4932518000", "test@email.com", "978545956-90", new DateTime(2030, 01, 01), true);
            controller.InserirNovo(customer);

            // act
            Customer foundCustomer = controller.SelecionarPorId(customer.Id);

            // assert
            foundCustomer.Should().NotBeNull();
        }        
    }
}

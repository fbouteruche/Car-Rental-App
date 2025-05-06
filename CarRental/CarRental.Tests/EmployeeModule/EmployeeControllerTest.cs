using CarRental.Controllers.EmployeeModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.EmployeeModule;
using System.Collections.Generic;
using System;
using CarRental.Tests.Shared;

namespace CarRental.Tests.EmployeeModule
{
    [TestClass]
    [TestCategory("Controllers")]
    public class EmployeeControllerTest
    {
        Employee funcionario;
        Employee funcionario2;
        EmployeeController ctr; 

        public EmployeeControllerTest()
        {
            ctr = new EmployeeController();
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void DeveInserirFuncionarioNoBanco()
        {
            //arrange
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);

            //action
            ctr.InsertNew(funcionario);

            //assert
            Assert.AreEqual(funcionario,ctr.SelectById(funcionario.Id));
        }

        [TestMethod]
        public void DeveExcluirFuncionarioNoBanco()
        {
            //arrange
            funcionario = new Employee(0, "Name Teste removido", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            
            //action
            ctr.InsertNew(funcionario);
            ctr.Delete(funcionario.Id);
            Employee funcionarioEncontrado = ctr.SelectById(funcionario.Id);

            //assert
            Assert.IsNull(funcionarioEncontrado);
        }

        [TestMethod]
        public void DeveEditarFuncionarioNoBanco()
        {
            //arrange
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            Employee funcionarioEditado = new Employee(0, "Name Teste2", "954.746.736-04", "Address Funcionario2", "4932518000", "teste2@email.com", 001, "user2 acesso", "12345", new DateTime(2021, 01, 01), "Vendedor2", 1000f, true);

            //action
            ctr.InsertNew(funcionario);
            ctr.Edit(funcionario.Id, funcionarioEditado);

            //acert
            Assert.AreEqual(funcionarioEditado,ctr.SelectById(funcionario.Id));
        }

        [TestMethod]
        public void DeveSelecionarTodosFuncionarioNoBanco()
        {
            //arrange
            funcionario = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);
            funcionario2 = new Employee(0, "Name Teste", "954.746.736-04", "Address Employee", "4932518000", "teste@email.com", 001, "user acesso", "12345", new DateTime(2021, 01, 01), "Vendedor", 1000f, true);

            //action
            ctr.InsertNew(funcionario);
            ctr.InsertNew(funcionario2);
            var lista = ctr.SelectAll();

            //assert
            Assert.IsNotNull(lista);
        }
    }
}

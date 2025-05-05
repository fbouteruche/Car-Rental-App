using FluentAssertions;
using CarRental.Controllers.ServicoModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.ServiceModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarRental.Tests.SevicoModule
{
    [TestClass]
    [TestCategory("Controllers")]
    public class ServicosControladorTest
    {
        ControladorServico controlador = null;
        Service novoServico;
        public ServicosControladorTest()
        {
            controlador = new ControladorServico();
            ResetarBanco.ResetarTabelas();
        }
        [TestMethod]
        public void DeveInserirUmServico()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);

            //action
            controlador.InsertNew(novoServico);

            //assert
            Service servicoEncontrado = controlador.SelectById(novoServico.Id);
            servicoEncontrado.Should().Be(novoServico);
        }
        [TestMethod]
        public void DeveSelecionarDoisServicos()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);

            //action
            controlador.InsertNew(novoServico);
            controlador.InsertNew(novoServico);

            //assert
            List<Service> servicoEncontrado = controlador.SelectAll();
            servicoEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmServico()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);
            Service servicoEditado = new Service(0, "Lavar Carro", false, 80);
            //action
            controlador.InsertNew(novoServico);
            controlador.Edit(novoServico.Id, servicoEditado);

            //assert
            Service servicoEncontrado = controlador.SelectById(novoServico.Id);
            servicoEncontrado.Should().Be(servicoEditado);
        }

        [TestMethod]
        public void DeveExcluirUmServico()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);

            //action
            controlador.InsertNew(novoServico);
            controlador.Delete(novoServico.Id);

            //assert
            List<Service> servicoEncontrado = controlador.SelectAll();
            servicoEncontrado.Count.Should().Be(0);
        }
    }
}

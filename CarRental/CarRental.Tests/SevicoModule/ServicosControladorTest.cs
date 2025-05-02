using FluentAssertions;
using CarRental.Controladores.ServicoModule;
using CarRental.Controladores.Shared;
using CarRental.Domain.ServiceModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CarRental.Tests.SevicoModule
{
    [TestClass]
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
            controlador.InserirNovo(novoServico);

            //assert
            Service servicoEncontrado = controlador.SelecionarPorId(novoServico.Id);
            servicoEncontrado.Should().Be(novoServico);
        }
        [TestMethod]
        public void DeveSelecionarDoisServicos()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);

            //action
            controlador.InserirNovo(novoServico);
            controlador.InserirNovo(novoServico);

            //assert
            List<Service> servicoEncontrado = controlador.SelecionarTodos();
            servicoEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmServico()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);
            Service servicoEditado = new Service(0, "Lavar Carro", false, 80);
            //action
            controlador.InserirNovo(novoServico);
            controlador.Editar(novoServico.Id, servicoEditado);

            //assert
            Service servicoEncontrado = controlador.SelecionarPorId(novoServico.Id);
            servicoEncontrado.Should().Be(servicoEditado);
        }

        [TestMethod]
        public void DeveExcluirUmServico()
        {
            //arrange
            novoServico = new Service(0, "nome", true, 100);

            //action
            controlador.InserirNovo(novoServico);
            controlador.Excluir(novoServico.Id);

            //assert
            List<Service> servicoEncontrado = controlador.SelecionarTodos();
            servicoEncontrado.Count.Should().Be(0);
        }
    }
}

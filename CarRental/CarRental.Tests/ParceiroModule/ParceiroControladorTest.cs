using FluentAssertions;
using CarRental.Controllers.ParceiroModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.PartnerModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.ParceiroModule
{
    [TestClass]
    public class ParceiroControladorTest
    {
        ControladorParceiro controlador = null;
        Partner parceiro;
        public ParceiroControladorTest()
        {
            controlador = new ControladorParceiro();
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void DeveInserirUmParceiro()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");

            //action
            controlador.InserirNovo(parceiro);

            //assert
            var parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveSelecionarDoisParceiros()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");

            //action
            controlador.InserirNovo(parceiro);
            controlador.InserirNovo(parceiro);

            //assert
            List<Partner> parceiroEncontrado = controlador.SelecionarTodos();
            parceiroEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");
            Partner parceiroEditado = new Partner(0, "Name Alterado");

            //action
            controlador.InserirNovo(parceiro);
            controlador.Editar(parceiro.Id, parceiroEditado);

            //assert
            Partner parceiroEncontrado = controlador.SelecionarPorId(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiroEditado);
        }

        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");

            //action
            controlador.InserirNovo(parceiro);
            List<Partner> parceiroInserido = controlador.SelecionarTodos();
            controlador.Excluir(parceiro.Id);

            //assert
            List<Partner> bancoAposExclusao = controlador.SelecionarTodos();
            bancoAposExclusao.Count.Should().NotBe(parceiroInserido.Count);
        }
    }
}

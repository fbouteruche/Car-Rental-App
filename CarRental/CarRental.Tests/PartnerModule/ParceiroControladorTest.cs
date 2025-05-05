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
    [TestCategory("Controllers")]
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
            controlador.InsertNew(parceiro);

            //assert
            var parceiroEncontrado = controlador.SelectById(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiro);
        }

        [TestMethod]
        public void DeveSelecionarDoisParceiros()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");

            //action
            controlador.InsertNew(parceiro);
            controlador.InsertNew(parceiro);

            //assert
            List<Partner> parceiroEncontrado = controlador.SelectAll();
            parceiroEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");
            Partner parceiroEditado = new Partner(0, "Name Alterado");

            //action
            controlador.InsertNew(parceiro);
            controlador.Edit(parceiro.Id, parceiroEditado);

            //assert
            Partner parceiroEncontrado = controlador.SelectById(parceiro.Id);
            parceiroEncontrado.Should().Be(parceiroEditado);
        }

        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            parceiro = new Partner(0, "Name Teste");

            //action
            controlador.InsertNew(parceiro);
            List<Partner> parceiroInserido = controlador.SelectAll();
            controlador.Delete(parceiro.Id);

            //assert
            List<Partner> bancoAposExclusao = controlador.SelectAll();
            bancoAposExclusao.Count.Should().NotBe(parceiroInserido.Count);
        }
    }
}

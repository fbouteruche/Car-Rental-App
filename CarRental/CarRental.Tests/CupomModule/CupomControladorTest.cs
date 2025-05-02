using FluentAssertions;
using CarRental.Controllers.CupomModule;
using CarRental.Controllers.ParceiroModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.Coupon;
using CarRental.Domain.PartnerModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.CupomModule
{
    [TestClass]
    public class CupomControladorTest
    {
        ControladorCupom controlador = null;
        ControladorParceiro controladorParceiro = null;
        Coupon cupom;
        Partner parceiro;
        public CupomControladorTest()
        {
            controlador = new ControladorCupom();
            controladorParceiro = new ControladorParceiro();
            ResetarBanco.ResetarTabelas();            
        }

        [TestMethod]
        public void DeveInserirUmParceiro()
        {
            //arrange
            InserirParceiro();
            cupom = new Coupon(0, "Cupom001", "CODIGOCUPOM", 500, 2000, true, DateTime.Today.AddDays(30), parceiro);

            //action
            controlador.InserirNovo(cupom);

            //assert
            Coupon cupomEncontrado = controlador.SelecionarPorId(cupom.Id);
            cupomEncontrado.Should().Be(cupom);
        }        

        [TestMethod]
        public void DeveSelecionarDoisParceiros()
        {
            //arrange
            InserirParceiro();
            cupom = new Coupon(0, "Cupom001", "CODIGOCUPOM", 500, 2000, true, DateTime.Today.AddDays(30), parceiro);

            //action
            controlador.InserirNovo(cupom);
            controlador.InserirNovo(cupom);

            //assert
            List<Coupon> parceiroEncontrado = controlador.SelecionarTodos();
            parceiroEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmParceiro()
        {
            //arrange
            InserirParceiro();
            cupom = new Coupon(0, "Cupom001", "CODIGOCUPOM", 500, 2000, true, DateTime.Today.AddDays(30), parceiro);
            Coupon cupomEditado = new Coupon(0, "CupomEditado", "EDITADO", 50, 2000, false, DateTime.Today.AddDays(10), parceiro);

            //action
            controlador.InserirNovo(cupom);
            controlador.Editar(cupom.Id, cupomEditado);

            //assert
            Coupon parceiroEncontrado = controlador.SelecionarPorId(cupom.Id);
            parceiroEncontrado.Should().Be(cupomEditado);
        }

        [TestMethod]
        public void DeveExcluirUmParceiro()
        {
            //arrange
            InserirParceiro();
            cupom = new Coupon(0, "Cupom001", "CODIGOCUPOM", 500, 2000, true, DateTime.Today.AddDays(30), parceiro);

            //action
            controlador.InserirNovo(cupom);
            List<Coupon> cupomInserido = controlador.SelecionarTodos();
            controlador.Excluir(cupom.Id);

            //assert
            List<Coupon> bancoAposExclusao = controlador.SelecionarTodos();
            bancoAposExclusao.Count.Should().NotBe(cupomInserido.Count);
        }

        private void InserirParceiro()
        {
            parceiro = new Partner(0, "Name Teste");
            controladorParceiro.InserirNovo(parceiro);
        }
    }
}

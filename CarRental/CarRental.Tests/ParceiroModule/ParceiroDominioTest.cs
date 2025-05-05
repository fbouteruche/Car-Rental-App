using FluentAssertions;
using CarRental.Domain.PartnerModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Tests.ParceiroModule
{
    [TestClass]
    [TestCategory("Domain")]
    public class ParceiroDominioTest
    {
        [TestMethod]
        public void DeveCriarParceiro_Correto()
        {
            //arrange
            Partner parceiro = new Partner(0, "NDD");

            //action
            var resultadoValidacao = parceiro.Validate();

            //assert
            resultadoValidacao.Should().Be("VALIDO");
        }

        [TestMethod]
        public void DeveApresentarErro_NomeIncorreto()
        {
            //arrange
            Partner parceiro = new Partner(0, "");

            //action
            var resultadoValidacao = parceiro.Validate();

            //assert
            resultadoValidacao.Should().Be("O campo nome é obrigatório");
        }
    }
}

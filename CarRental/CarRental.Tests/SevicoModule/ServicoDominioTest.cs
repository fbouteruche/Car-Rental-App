using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.SevicosModule;

namespace CarRental.Tests.SevicoModule
{

    [TestClass]
    public class ServicoDominioTest
    {

        [TestMethod]
        public void DeveCriarServicoCorreto()
        {
            Servico servico = new Servico(0, "nome", true, 100f);
            Assert.AreEqual("VALIDO", servico.Validate());
        }

        [TestMethod]

        public void DeveCriarServicoIncorreto()
        {
            Servico servico = new Servico(0, "", true, 0f);
            Assert.AreEqual("O nome não pode ser nulo\nO valor não pode ser nulo", servico.Validate());
        }
    }
}

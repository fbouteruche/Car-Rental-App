using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.ServiceModule;

namespace CarRental.Tests.SevicoModule
{

    [TestClass]
    [TestCategory("Domain")]
    public class ServicoDominioTest
    {

        [TestMethod]
        public void DeveCriarServicoCorreto()
        {
            Service servico = new Service(0, "nome", true, 100f);
            Assert.AreEqual("VALIDO", servico.Validate());
        }

        [TestMethod]

        public void DeveCriarServicoIncorreto()
        {
            Service servico = new Service(0, "", true, 0f);
            Assert.AreEqual("O nome não pode ser nulo\nO valor não pode ser nulo", servico.Validate());
        }
    }
}

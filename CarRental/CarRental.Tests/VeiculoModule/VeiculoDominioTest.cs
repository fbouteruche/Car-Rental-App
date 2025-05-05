using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CarRental.Domain.VehicleModule;

namespace CarRental.Tests.VeiculoModule
{
    [TestClass]
    [TestCategory("Domain")]
    public class VeiculoTest
    {

        [TestMethod]
        public void DeveCriarVeiculo_Correto()
        {
            Vehicle veiculo = new Vehicle(0, "Ecosport", null, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);

            Assert.AreEqual("VALIDO", veiculo.Validate());

        }

        [TestMethod]
        public void DeveApresentarErroVeiculo_TotalmenteIncorreto()
        {
            Vehicle veiculo = new Vehicle(0, "", null, "", "", "", "", "", 0, 0, 0, 0, 0, 'a', false, false, false,false,null);

            Assert.AreEqual("O campo model não pode ser vazio!\nO campo licensePlate não pode ser vazio!\nO campo chassis não pode ser vazio!\nO campo marca não pode ser vazio!\nO campo color não pode ser vazio!\nO campo tipo de combústivel não pode ser vazio!\nO campo capacidade de tanque não pode ser vazio!\nO campo year não pode ser vazio!\nO campo mileage não pode ser vazio!\nO campo numero de portas não pode ser vazio!\nO campo capacidades de pessoas não pode ser vazio!\nO campo tamanho do porta mala não pode ser vazio!\n",
                veiculo.Validate());
        }
    }
}

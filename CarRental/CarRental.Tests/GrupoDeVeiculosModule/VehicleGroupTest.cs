using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.VehicleGroupModule;
using FluentAssertions;
using System;

namespace CarRental.Tests.GrupoDeVeiculosModule
{
    [TestClass]
    [TestCategory("Domain")]
    public class VehicleGroupTest
    {
        [TestMethod]
        public void ShouldCreateVehicleGroup_Correctly()
        {
            VehicleGroup vehicleGroup = new VehicleGroup(0, "nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);

            string result = vehicleGroup.Validate();

            Assert.AreEqual("VALID", result);
        }

        [TestMethod]
        public void ShouldShowError_CompletelyIncorrectGroup()
        {
            VehicleGroup vehicleGroup = new VehicleGroup(0, "", 0f, 0f, 0f, 0, 0f, 0f);

            string result = vehicleGroup.Validate();
            //Tests with all invalid messages are complicated to maintain. Maybe we should change the model.
            Assert.AreEqual("The name cannot be null\nThe daily rate for the Daily Plan cannot be null\nThe per KM rate for the Daily Plan cannot be null\nThe daily rate for the Controlled Plan cannot be null\nThe KM limit for the Controlled Plan cannot be null\nThe exceeded KM rate for the Controlled Plan cannot be null\nThe daily rate for the Unlimited Plan cannot be null\n", 
                            result);
        }

        [TestMethod]
        public void DeveApresentarErro_SomenteNomeCorreto()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0,"nome", 0f, 0f, 0f, 0, 0f, 0f);

            string resultado = grupoDeVeiculos.Validate();
            //testes com todas as mensagens de invalidez são complicados para dar manutencao. talvez vale a pena mudarmos o model.
            Assert.AreEqual("A taxa diaria do Plano Diário não pode ser nula\nA taxa por KM do Plano Diário não pode ser nula\nA taxa diária do Plano Controlado não pode ser nula\nO limite de KM do plano Controlado não pode ser nulo\nA taxa de KM Excedido do plano Controlado não pode ser nulo\nA taxa diária do do Plano Livre não pode ser nula\n",
                            resultado);
        }

        [TestMethod]
        public void DeveApresentarErro_SomenteNomeIncorreto()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0,"", 10f, 10f, 10f, 10, 10f, 10f);

            string resultado = grupoDeVeiculos.Validate();

            Assert.AreEqual("O nome não pode ser nulo\n",
                            resultado);
        }
    }
}

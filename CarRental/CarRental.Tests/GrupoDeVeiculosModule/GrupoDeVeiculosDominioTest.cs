using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.VehicleGroupModule;
using FluentAssertions;
using System;

namespace CarRental.Tests.GrupoDeVeiculosModule
{
    [TestClass]
    public class GrupoDeVeiculosDominioTest
    {
        [TestMethod]
        public void DeveCriarGrupoDeVeiculo_Correto()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0,"nome", 12.3f, 15.5f, 20.5f, 30, 16.3f, 45.2f);

            string resultado = grupoDeVeiculos.Validate();

            Assert.AreEqual("VALIDO", resultado);
        }

        [TestMethod]
        public void DeveApresentarErro_GrupoTotalmenteIncorreto()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0,"",0f,0f,0f,0,0f,0f);

            string resultado = grupoDeVeiculos.Validate();
            //testes com todas as mensagens de invalidez são complicados para dar manutencao. talvez vale a pena mudarmos o model.
            Assert.AreEqual("O nome não pode ser nulo\nA taxa diaria do Plano Diário não pode ser nula\nA taxa por KM do Plano Diário não pode ser nula\nA taxa diária do Plano Controlado não pode ser nula\nO limite de KM do plano Controlado não pode ser nulo\nA taxa de KM Excedido do plano Controlado não pode ser nulo\nA taxa diária do do Plano Livre não pode ser nula\n", 
                            resultado);
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

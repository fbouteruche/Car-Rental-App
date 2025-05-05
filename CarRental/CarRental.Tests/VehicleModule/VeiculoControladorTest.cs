using FluentAssertions;
using CarRental.Controllers.GrupoDeVeiculosModule;
using CarRental.Controllers.Shared;
using CarRental.Controllers.VeiculoModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.VehicleModule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarRental.Domain.VehicleImageModule;
using System.Collections.Generic;
using CarRental.Tests.Shared;

namespace CarRental.Tests.VeiculoModule
{
    [TestClass]
    [TestCategory("Controllers")]
    public class VeiculoControladorTest
    {
        ControladorVeiculo controlador = null;
        ControladorGrupoDeVeiculos controladorGrupoDeVeiculos = null;        
        Vehicle novoVeiculo;
        VehicleGroup grupoVeiculos;
        List<VehicleImage> imagem;

        public VeiculoControladorTest()
        {
            controlador = new ControladorVeiculo();
            controladorGrupoDeVeiculos = new ControladorGrupoDeVeiculos();

            ResetarBanco.ResetarTabelas();
        }
        [TestMethod]
        public void DeveInserirUmVeiculo()
        {
            //arrange
            grupoVeiculos = new VehicleGroup(0, "SUV", 10.0, 10.5, 10, 100, 15.5, 45.8);
            controladorGrupoDeVeiculos.InsertNew(grupoVeiculos);
            novoVeiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);

            //action
            controlador.InsertNew(novoVeiculo);

            //assert
            Vehicle veiculoEncontrado = controlador.SelectById(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(novoVeiculo);
        }

        [TestMethod]
        public void DeveSelecionarDoisVeiculos()
        {
            //arrange  
            grupoVeiculos = new VehicleGroup(0, "SUV", 10.0, 10.5, 10, 100, 15.5, 45.8);
            controladorGrupoDeVeiculos.InsertNew(grupoVeiculos);
            novoVeiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true,true, null);

            //action
            controlador.InsertNew(novoVeiculo);
            controlador.InsertNew(novoVeiculo);

            //assert
            List<Vehicle> veiculoEncontrado = controlador.SelectAll();
            veiculoEncontrado.Count.Should().Be(2);
        }

        [TestMethod]
        public void DeveEditarUmVeiculo()
        {
            //arrange
            imagem = new List<VehicleImage>();
            grupoVeiculos = new VehicleGroup(0, "SUV", 10.0, 10.5, 10, 100, 15.5, 45.8);
            controladorGrupoDeVeiculos.InsertNew(grupoVeiculos);
            novoVeiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);

            VehicleGroup grupoEditado = new VehicleGroup(0, "Pique Velozes e Furiosos", 100, 60.5, 40, 300, 45.2, 500);
            controladorGrupoDeVeiculos.InsertNew(grupoEditado);
            Vehicle veiculoEditado = new Vehicle(0, "Monza Tubarão Turbão Rebaixado", grupoEditado, "ABC1234", "1ABCD12A12AB1AB1ABC", "Chevrolet", "Bordo", "Etanol", 60.5, 1996, 240000, 4, 5, 'G', false, false, false, false,imagem);
            //action
            controlador.InsertNew(novoVeiculo);
            controlador.Edit(novoVeiculo.Id, veiculoEditado);

            //assert
            Vehicle veiculoEncontrado = controlador.SelectById(novoVeiculo.Id);
            veiculoEncontrado.Should().Be(veiculoEditado);
        }

        [TestMethod]
        public void DeveExcluirUmVeiculo()
        {
            //arrange
            grupoVeiculos = new VehicleGroup(0, "SUV", 10.0, 10.5, 10, 100, 15.5, 45.8);
            controladorGrupoDeVeiculos.InsertNew(grupoVeiculos);
            novoVeiculo = new Vehicle(0, "Ecosport", grupoVeiculos, "LPT-4652", "4DF56F78E8WE9WED", "Ford", "Prata", "Gasolina Comum", 60.5, 2018, 30000, 4, 5, 'G', true, true, true, true, null);

            //action
            controlador.InsertNew(novoVeiculo);
            controlador.Delete(novoVeiculo.Id);

            //assert
            List<Vehicle> veiculoEncontrado = controlador.SelectAll();
            veiculoEncontrado.Count.Should().Be(0);
        }        
    }
}

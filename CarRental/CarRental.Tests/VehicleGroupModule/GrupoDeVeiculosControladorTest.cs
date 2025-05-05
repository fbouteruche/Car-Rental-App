using FluentAssertions;
using CarRental.Controllers.GrupoDeVeiculosModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Tests.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CarRental.Tests.VehiculeGroupTest
{
    [TestClass]
    [TestCategory("Controllers")]
    public class GrupoDeVeiculosControladorTest
    {
        ControladorGrupoDeVeiculos controlador = null;

        public GrupoDeVeiculosControladorTest()
        {
            controlador = new ControladorGrupoDeVeiculos();
            ResetarBanco.ResetarTabelas();
        }

        [TestMethod]
        public void DeveInserir_GrupoDeVeiculos()
        {
            VehicleGroup novoGrupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f); ;

            controlador.InsertNew(novoGrupoDeVeiculos);

            var grupoDeVeiculosEncontrado = controlador.SelectById(novoGrupoDeVeiculos.Id);
            grupoDeVeiculosEncontrado.Should().Be(novoGrupoDeVeiculos);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 14f, 30.2f);
            controlador.InsertNew(grupoDeVeiculos);

            VehicleGroup novoGrupoDeVeiculos = new VehicleGroup(0, "nome", 5.12f, 37.52f, 99.31f, 2, 15f, 11.2f);

            controlador.Edit(grupoDeVeiculos.Id, novoGrupoDeVeiculos);

            var grupoDeVeiculosAtualizado = controlador.SelectById(grupoDeVeiculos.Id);
            grupoDeVeiculosAtualizado.Should().Be(novoGrupoDeVeiculos);
        }

        [TestMethod]
        public void DeveExcluir_GrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            controlador.InsertNew(grupoDeVeiculos);

            controlador.Delete(grupoDeVeiculos.Id);

            var grupoDeVeiculosEncontrado = controlador.SelectById(grupoDeVeiculos.Id);
            grupoDeVeiculosEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoDeVeiculosPorId()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 14f, 65.2f);
            controlador.InsertNew(grupoDeVeiculos);

            var grupoDeVeiculosEncontrado = controlador.SelectById(grupoDeVeiculos.Id);

            grupoDeVeiculosEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosGrupoDeVeiculos()
        {
            VehicleGroup g1 = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 11f, 65f);
            controlador.InsertNew(g1);
            VehicleGroup g2 = new VehicleGroup(0, "emon", 5.12f, 37.52f, 99.31f, 2, 4.5f, 50f);
            controlador.InsertNew(g2);
            VehicleGroup g3 = new VehicleGroup(0, "meno", 5.21f, 35.72f, 93.91f, 20, 5f, 11f);
            controlador.InsertNew(g3);

            List<VehicleGroup> grupoDeVeiculosAgrupado = controlador.SelectAll();

            grupoDeVeiculosAgrupado.Should().HaveCount(3);
            grupoDeVeiculosAgrupado[0].Name.Should().Be("nome");
            grupoDeVeiculosAgrupado[1].Name.Should().Be("emon");
            grupoDeVeiculosAgrupado[2].Name.Should().Be("meno");
        }

        [TestMethod]
        public void DeveRetornarTrue_QuandoExisteGrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 5f, 30f);
            controlador.InsertNew(grupoDeVeiculos);

            bool existeGrupoDeVeiculos = controlador.Exists(grupoDeVeiculos.Id);

            existeGrupoDeVeiculos.Should().BeTrue();
        }

        [TestMethod]
        public void DeveRetornarFalse_QuandoNaoExisteGrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);

            bool existeGrupoDeVeiculos = controlador.Exists(grupoDeVeiculos.Id);

            existeGrupoDeVeiculos.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveInserir_GrupoDeVeiculosQuandoNomeJaExiste()
        {
            VehicleGroup novoGrupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            controlador.InsertNew(novoGrupoDeVeiculos);
            VehicleGroup identicoGrupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            
            string resposta = controlador.InsertNew(identicoGrupoDeVeiculos);

            resposta.Should().Be("O nome do grupo de veículos deve ser único\n");
        }

        [TestMethod]
        public void NaoDeveAtualizar_GrupoDeVeiculosQuandoNomeJaExiste()
        {
            VehicleGroup grupoDeVeiculosParaEditar = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 11f, 50.5f);
            controlador.InsertNew(grupoDeVeiculosParaEditar);
            VehicleGroup grupoDeVeiculosExistente = new VehicleGroup(0, "emon", 5.12f, 37.52f, 99.31f, 2, 5f, 90f);
            controlador.InsertNew(grupoDeVeiculosExistente);

            VehicleGroup grupoDeVeiculosConflitante = new VehicleGroup(0, "emon", 5.21f, 35.72f, 93.91f, 20, 13f, 85.3f);
            string resposta =  controlador.Edit(grupoDeVeiculosParaEditar.Id, grupoDeVeiculosConflitante);

            resposta.Should().Be("O nome do grupo de veículos deve ser único\n");
        }
    }
}

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

            controlador.InserirNovo(novoGrupoDeVeiculos);

            var grupoDeVeiculosEncontrado = controlador.SelecionarPorId(novoGrupoDeVeiculos.Id);
            grupoDeVeiculosEncontrado.Should().Be(novoGrupoDeVeiculos);
        }

        [TestMethod]
        public void DeveAtualizar_GrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 14f, 30.2f);
            controlador.InserirNovo(grupoDeVeiculos);

            VehicleGroup novoGrupoDeVeiculos = new VehicleGroup(0, "nome", 5.12f, 37.52f, 99.31f, 2, 15f, 11.2f);

            controlador.Editar(grupoDeVeiculos.Id, novoGrupoDeVeiculos);

            var grupoDeVeiculosAtualizado = controlador.SelecionarPorId(grupoDeVeiculos.Id);
            grupoDeVeiculosAtualizado.Should().Be(novoGrupoDeVeiculos);
        }

        [TestMethod]
        public void DeveExcluir_GrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            controlador.InserirNovo(grupoDeVeiculos);

            controlador.Excluir(grupoDeVeiculos.Id);

            var grupoDeVeiculosEncontrado = controlador.SelecionarPorId(grupoDeVeiculos.Id);
            grupoDeVeiculosEncontrado.Should().BeNull();
        }

        [TestMethod]
        public void DeveSelecionar_GrupoDeVeiculosPorId()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 14f, 65.2f);
            controlador.InserirNovo(grupoDeVeiculos);

            var grupoDeVeiculosEncontrado = controlador.SelecionarPorId(grupoDeVeiculos.Id);

            grupoDeVeiculosEncontrado.Should().NotBeNull();
        }

        [TestMethod]
        public void DeveSelecionar_TodosGrupoDeVeiculos()
        {
            VehicleGroup g1 = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 11f, 65f);
            controlador.InserirNovo(g1);
            VehicleGroup g2 = new VehicleGroup(0, "emon", 5.12f, 37.52f, 99.31f, 2, 4.5f, 50f);
            controlador.InserirNovo(g2);
            VehicleGroup g3 = new VehicleGroup(0, "meno", 5.21f, 35.72f, 93.91f, 20, 5f, 11f);
            controlador.InserirNovo(g3);

            List<VehicleGroup> grupoDeVeiculosAgrupado = controlador.SelecionarTodos();

            grupoDeVeiculosAgrupado.Should().HaveCount(3);
            grupoDeVeiculosAgrupado[0].Name.Should().Be("nome");
            grupoDeVeiculosAgrupado[1].Name.Should().Be("emon");
            grupoDeVeiculosAgrupado[2].Name.Should().Be("meno");
        }

        [TestMethod]
        public void DeveRetornarTrue_QuandoExisteGrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 5f, 30f);
            controlador.InserirNovo(grupoDeVeiculos);

            bool existeGrupoDeVeiculos = controlador.Existe(grupoDeVeiculos.Id);

            existeGrupoDeVeiculos.Should().BeTrue();
        }

        [TestMethod]
        public void DeveRetornarFalse_QuandoNaoExisteGrupoDeVeiculos()
        {
            VehicleGroup grupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);

            bool existeGrupoDeVeiculos = controlador.Existe(grupoDeVeiculos.Id);

            existeGrupoDeVeiculos.Should().BeFalse();
        }

        [TestMethod]
        public void NaoDeveInserir_GrupoDeVeiculosQuandoNomeJaExiste()
        {
            VehicleGroup novoGrupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            controlador.InserirNovo(novoGrupoDeVeiculos);
            VehicleGroup identicoGrupoDeVeiculos = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 15f, 11.2f);
            
            string resposta = controlador.InserirNovo(identicoGrupoDeVeiculos);

            resposta.Should().Be("O nome do grupo de veículos deve ser único\n");
        }

        [TestMethod]
        public void NaoDeveAtualizar_GrupoDeVeiculosQuandoNomeJaExiste()
        {
            VehicleGroup grupoDeVeiculosParaEditar = new VehicleGroup(0, "nome", 12.50f, 25.73f, 13.99f, 200, 11f, 50.5f);
            controlador.InserirNovo(grupoDeVeiculosParaEditar);
            VehicleGroup grupoDeVeiculosExistente = new VehicleGroup(0, "emon", 5.12f, 37.52f, 99.31f, 2, 5f, 90f);
            controlador.InserirNovo(grupoDeVeiculosExistente);

            VehicleGroup grupoDeVeiculosConflitante = new VehicleGroup(0, "emon", 5.21f, 35.72f, 93.91f, 20, 13f, 85.3f);
            string resposta =  controlador.Editar(grupoDeVeiculosParaEditar.Id, grupoDeVeiculosConflitante);

            resposta.Should().Be("O nome do grupo de veículos deve ser único\n");
        }
    }
}

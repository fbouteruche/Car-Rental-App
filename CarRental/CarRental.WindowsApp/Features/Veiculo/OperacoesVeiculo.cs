using CarRental.Controllers.VeiculoModule;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Veiculos;
using CarRental.Domain.VehicleModule;
using CarRental.Domain.VehicleImageModule;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Veiculos
{
    public class OperacoesVeiculo : ICadastravel
    {
        private readonly ControladorVeiculo controlador = null;
        private readonly TabelaVeiculoControl tabelaVeiculo = null;
        public OperacoesVeiculo(ControladorVeiculo ctrlVeiculo)
        {
            controlador = ctrlVeiculo;
            tabelaVeiculo = new TabelaVeiculoControl();
        }
        public void InserirNovoRegistro()
        {
            VeiculoForm tela = new VeiculoForm("Cadastro de Veiculos");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if(tela.Veiculo.images.Count !=0)
                    foreach (Domain.VehicleImageModule.VehicleImage imagem in tela.Veiculo.images)
                        imagem.VehicleId = tela.Veiculo.Id;
                
                controlador.InserirNovo(tela.Veiculo);

                List<Vehicle> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tela.Veiculo.model}] inserido com sucesso");
            }
        }
        public void EditarRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder editar!", "Edição de Veiculos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle tarefaSelecionada = controlador.SelecionarPorId(id);

            VeiculoForm tela = new VeiculoForm("Edição de Veiculos");

            tela.Veiculo = tarefaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Veiculo);

                List<Vehicle> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tela.Veiculo.model}] editado com sucesso");
            }
        }
        public void ExcluirRegistro()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Veiculos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle tarefaSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o veículo: [{tarefaSelecionada.model}] ?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Vehicle> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tarefaSelecionada.model}] removido com sucesso");
            }
        }
        public void FiltrarRegistros()
        {
            throw new System.NotImplementedException();
        }
        public UserControl ObterTabela()
        {
            List<Vehicle> veiculos = controlador.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
        public void AgruparRegistros()
        {
            throw new System.NotImplementedException();
        }
    }
}

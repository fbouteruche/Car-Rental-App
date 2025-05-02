using CarRental.Controladores.VeiculoModule;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Veiculos;
using CarRental.Domain.VeiculoModule;
using CarRental.Domain.ImagemVeiculoModule;
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
                if(tela.Veiculo.imagens.Count !=0)
                    foreach (Domain.ImagemVeiculoModule.ImagemVeiculo imagem in tela.Veiculo.imagens)
                        imagem.idVeiculo = tela.Veiculo.Id;
                
                controlador.InserirNovo(tela.Veiculo);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.modelo}] inserido com sucesso");
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

            Veiculo tarefaSelecionada = controlador.SelecionarPorId(id);

            VeiculoForm tela = new VeiculoForm("Edição de Veiculos");

            tela.Veiculo = tarefaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Editar(id, tela.Veiculo);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tela.Veiculo.modelo}] editado com sucesso");
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

            Veiculo tarefaSelecionada = controlador.SelecionarPorId(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o veículo: [{tarefaSelecionada.modelo}] ?",
                "Exclusão de Veiculos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Excluir(id);

                List<Veiculo> veiculos = controlador.SelecionarTodos();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Veiculo: [{tarefaSelecionada.modelo}] removido com sucesso");
            }
        }
        public void FiltrarRegistros()
        {
            throw new System.NotImplementedException();
        }
        public UserControl ObterTabela()
        {
            List<Veiculo> veiculos = controlador.SelecionarTodos();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
        public void AgruparRegistros()
        {
            throw new System.NotImplementedException();
        }
    }
}

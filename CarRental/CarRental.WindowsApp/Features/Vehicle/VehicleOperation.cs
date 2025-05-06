using CarRental.Controllers.VehicleModule;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Veiculos;
using CarRental.Domain.VehicleModule;
using CarRental.Domain.VehicleImageModule;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public class VehicleOperation : ICadastravel
    {
        private readonly VehicleController controlador = null;
        private readonly VehicleTableControl tabelaVeiculo = null;
        public VehicleOperation(VehicleController ctrlVeiculo)
        {
            controlador = ctrlVeiculo;
            tabelaVeiculo = new VehicleTableControl();
        }
        public void InsertNewRecord()
        {
            VehicleForm tela = new VehicleForm("Cadastro de Vehicles");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                if(tela.Veiculo.images.Count !=0)
                    foreach (Domain.VehicleImageModule.VehicleImage imagem in tela.Veiculo.images)
                        imagem.VehicleId = tela.Veiculo.Id;
                
                controlador.InsertNew(tela.Veiculo);

                List<Vehicle> veiculos = controlador.SelectAll();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tela.Veiculo.model}] inserido com sucesso");
            }
        }
        public void EditRecord()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder editar!", "Edição de Vehicles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle tarefaSelecionada = controlador.SelectById(id);

            VehicleForm tela = new VehicleForm("Edição de Vehicles");

            tela.Veiculo = tarefaSelecionada;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.Veiculo);

                List<Vehicle> veiculos = controlador.SelectAll();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tela.Veiculo.model}] editado com sucesso");
            }
        }
        public void DeleteRecord()
        {
            int id = tabelaVeiculo.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um veiculo para poder excluir!", "Exclusão de Vehicles",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle tarefaSelecionada = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o veículo: [{tarefaSelecionada.model}] ?",
                "Exclusão de Vehicles", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Delete(id);

                List<Vehicle> veiculos = controlador.SelectAll();

                tabelaVeiculo.AtualizarRegistros(veiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Vehicle: [{tarefaSelecionada.model}] removido com sucesso");
            }
        }
        public void FilterRecords()
        {
            throw new System.NotImplementedException();
        }
        public UserControl GetTable()
        {
            List<Vehicle> veiculos = controlador.SelectAll();

            tabelaVeiculo.AtualizarRegistros(veiculos);

            return tabelaVeiculo;
        }
        public void GroupRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}

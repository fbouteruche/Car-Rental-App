using CarRental.Controllers.VehicleGroupModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.WindowsApp.GrupoDeVeiculos;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    public class VehicleGroupOperation : ICadastravel
    {
        private readonly VehicleGroupController controlador = null;
        private readonly VehicleGroupTableControl tabelaGrupoDeVeiculos = null;

        public VehicleGroupOperation(VehicleGroupController ctrlGrupoDeVeiculos)
        {
            controlador = ctrlGrupoDeVeiculos;
            tabelaGrupoDeVeiculos = new VehicleGroupTableControl();
        }
        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void EditRecord()
        {
            int id = tabelaGrupoDeVeiculos.ObtemIdSelecionado();

            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo de Vehicles para poder editar!", "Edição de Grupo de Vehicles",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VehicleGroup grupoSelecionado = controlador.SelectById(id);

            TarefaGrupoDeVeiculosForm tela = new TarefaGrupoDeVeiculosForm("Edição de Grupo de Vehicles");

            tela.GrupoDeVeiculos = grupoSelecionado;

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.Edit(id, tela.GrupoDeVeiculos);

                List<VehicleGroup> grupoDeVeiculos = controlador.SelectAll();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos: [{tela.GrupoDeVeiculos.Name}] editado com sucesso");
            }
        }

        public void DeleteRecord()
        {
            int id = tabelaGrupoDeVeiculos.ObtemIdSelecionado();
            if (id == 0)
            {
                MessageBox.Show("Selecione um Grupo de Veículos para excluir", "Exclusão de Grupo de Veículos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            VehicleGroup grupoSelecionado = controlador.SelectById(id);

            if (MessageBox.Show($"Tem certeza que deseja excluir o Grupo de Veículos: [{grupoSelecionado.Name}]?",
                "Exclusão de Grupo de Veículos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controlador.Delete(id);

                List<VehicleGroup> grupos = controlador.SelectAll();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos: [{grupoSelecionado.Name}]removido com sucesso");
            }
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void InsertNewRecord()
        {
            TarefaGrupoDeVeiculosForm tela = new TarefaGrupoDeVeiculosForm("Cadastro de Grupo de Vehicles");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                controlador.InsertNew(tela.GrupoDeVeiculos);

                List<VehicleGroup> grupoDeVeiculos = controlador.SelectAll();

                tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

                TelaPrincipalForm.Instancia.AtualizarRodape($"Grupo de Veículos: [{tela.GrupoDeVeiculos.Name}] inserido com sucesso");
            }
        }

        public UserControl GetTable()
        {
            List<VehicleGroup> grupoDeVeiculos = controlador.SelectAll();
            tabelaGrupoDeVeiculos.AtualizarRegistros(grupoDeVeiculos);

            return tabelaGrupoDeVeiculos;
        }
    }
}

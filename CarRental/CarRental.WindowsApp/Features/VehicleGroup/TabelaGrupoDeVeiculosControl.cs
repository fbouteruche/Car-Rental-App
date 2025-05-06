using CarRental.Domain.VehicleGroupModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.GrupoDeVeiculos
{
    public partial class TabelaGrupoDeVeiculosControl : UserControl
    {
        public TabelaGrupoDeVeiculosControl()
        {
            InitializeComponent();
            gridGrupoDeVeiculos.ConfigurarGridZebrado();
            gridGrupoDeVeiculos.ConfigurarGridSomenteLeitura();
            gridGrupoDeVeiculos.Columns.AddRange(ObterColunas());
        }

        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name do Grupo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DailyPlanRate", HeaderText = "Taxa do Plano Diário"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DailyPerKmRate", HeaderText = "Taxa por KM Diário"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledPlanRate", HeaderText = "Taxa do Plano Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledKmLimit", HeaderText = "Limites de KM Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ControlledExceededKmRate", HeaderText = "Taxa por KM Excedidos Controlado"},

                new DataGridViewTextBoxColumn {DataPropertyName = "UnlimitedPlanRate", HeaderText = "Taxa do Plano Livre"}
           };

            return colunas;
        }
        public int ObtemIdSelecionado()
        {
            return gridGrupoDeVeiculos.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<VehicleGroup> grupoDeVeiculos)
        {
            gridGrupoDeVeiculos.Rows.Clear();

            foreach (VehicleGroup grupo in grupoDeVeiculos)
            {
                gridGrupoDeVeiculos.Rows.Add(grupo.Id, grupo.Name, grupo.DailyPlanRate, grupo.DailyPerKmRate, grupo.ControlledPlanRate,
                    grupo.ControlledKmLimit, grupo.ControlledExceededKmRate, grupo.UnlimitedPlanRate);
            }
        }
    }
}
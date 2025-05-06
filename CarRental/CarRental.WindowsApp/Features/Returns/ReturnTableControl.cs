using CarRental.Domain.RentalModule;
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

namespace CarRental.WindowsApp.Features.Returns
{
    public partial class ReturnTableControl : UserControl
    {
        public ReturnTableControl()
        {
            InitializeComponent();
            gridDevolucoes.ConfigureZebraGrid();
            gridDevolucoes.ConfigureReadOnlyGrid();
            gridDevolucoes.Columns.AddRange(ObterColunas());
        }
        public DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Id"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Modelo", HeaderText = "Modelo"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Placa", HeaderText = "Placa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ContractingCustomer", HeaderText = "Customer"},

                new DataGridViewTextBoxColumn { DataPropertyName = "RentalPrice", HeaderText = "Preço Inicial"},

                new DataGridViewTextBoxColumn { DataPropertyName = "IsOpen", HeaderText = "Locação Ativa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ReturnPrice", HeaderText = "Preço Final"},

                new DataGridViewTextBoxColumn {DataPropertyName = "ExpectedReturnDate", HeaderText = "Devolução"}
           };

            return colunas;
        }

        public int ObtemIdSelecionado()
        {
            return gridDevolucoes.SelecionarId<int>();
        }

        public void AtualizarRegistros(List<Rental> devolucoes)
        {
            gridDevolucoes.Rows.Clear();

            foreach (Rental devolucao in devolucoes)
                gridDevolucoes.Rows.Add(devolucao.Id, devolucao.Vehicle.model, devolucao.Vehicle.licensePlate, devolucao.ContractingCustomer.Name, devolucao.RentalPrice, devolucao.IsOpen, devolucao.ReturnPrice, devolucao.ExpectedReturnDate);
        }
    }
}

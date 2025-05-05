using CarRental.Controllers.ServiceModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.Shared;
using CarRental.WindowsApp.Features.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Servicos
{
    public partial class ServicosForm : Form
    {
        public List<Service> servicosSelecionados;
        public string seguro = "Nenhum";
        ServiceController controladorServico;
        public ServicosForm()
        {
            controladorServico = new ServiceController();
            servicosSelecionados = new List<Service>();
            InitializeComponent();
            AtualizarListCheckBox();
            cBoxSeguro.SelectedIndex = 0; 
        }

        public void InicializarCampos(List<Service> servicosIniciais, string seguroInicial, bool campoSeguroEhEditavel)
        {
            if (seguroInicial.Contains("Terceiro"))
                cBoxSeguro.SelectedIndex = 2;
            else if (seguroInicial.Contains("Customer"))
                cBoxSeguro.SelectedIndex = 1;

            if (servicosIniciais != null)
            {
                for (int index = 0; index < cLBoxServicos.Items.Count; index++)
                {
                    cLBoxServicos.SetItemChecked(index, servicosIniciais.Contains(cLBoxServicos.Items[index]));
                }
            }

            cBoxSeguro.Enabled = campoSeguroEhEditavel;
        }

        private void AtualizarListCheckBox()
        {
            cLBoxServicos.Items.Clear();
            foreach (Service servico in controladorServico.SelectAll())
                cLBoxServicos.Items.Add(servico);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            seguro = cBoxSeguro.SelectedItem.ToString().Replace(" ", "");
            foreach (Service servico in cLBoxServicos.CheckedItems)
                servicosSelecionados.Add(servico);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaServicoForm telaServicoForm = new TelaServicoForm("Cadastro de Serviços");
            if (telaServicoForm.ShowDialog() == DialogResult.OK)
            {
                controladorServico.InsertNew(telaServicoForm.Servico);
                AtualizarListCheckBox();                
            }
        }
    }
}

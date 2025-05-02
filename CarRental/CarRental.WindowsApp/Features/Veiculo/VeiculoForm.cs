using CarRental.Domain.VehicleModule;
using System;
using System.IO;
using System.Windows.Forms;
using CarRental.Controllers.GrupoDeVeiculosModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.Domain.VehicleImageModule;
using CarRental.WindowsApp.Features.ImagemVeiculo;
using System.Collections.Generic;
using System.Drawing;

namespace CarRental.WindowsApp.Veiculos
{
    public partial class VeiculoForm : Form
    {
        private Vehicle veiculo;
        private ControladorGrupoDeVeiculos controladorGrupoVeiculos = new ControladorGrupoDeVeiculos();
        public VeiculoForm(string titulo)
        {            
            InitializeComponent();
            CarregarGruposDeVeiculos();
            labelTitulo.Text = titulo;
            cBoxPortaMalas.SelectedIndex = 0;           
        }
        public List<VehicleImage> imagensVeiculo = new List<VehicleImage>();

        private void CarregarGruposDeVeiculos()
        {
            cBoxGrupo.DataSource = controladorGrupoVeiculos.SelecionarTodos();
        }

        public Vehicle Veiculo
        {
            get { return veiculo; }

            set
            {
                veiculo = value;

                imagensVeiculo = veiculo.images;
                textId.Text = veiculo.Id.ToString();
                textModelo.Text = veiculo.model;
                cBoxGrupo.Text = veiculo.vehicleGroup.Name;
                textPlaca.Text = veiculo.licensePlate;
                textChassi.Text = veiculo.chassis;
                textMarca.Text = veiculo.marca;
                textCor.Text = veiculo.color;
                cBoxCombustivel.Text = veiculo.fuelType;
                numUpDownCapTanque.Text = veiculo.capacidadeTanque.ToString();
                textAno.Text = veiculo.year.ToString();
                textKM.Text = veiculo.mileage.ToString();
                numUpDownQtdPortas.Text = veiculo.numberOfDoors.ToString();
                numUpDownQtdPessoas.Text = veiculo.passengerCapacity.ToString();
                cBoxPortaMalas.Text = veiculo.trunkSize.ToString();
                if (veiculo.hasAirConditioning)
                    checkLBoxOpcionais.SetItemChecked(0, true);
                if (veiculo.hasPowerSteering)
                    checkLBoxOpcionais.SetItemChecked(1, true);
                if (veiculo.hasAbsBrakes)
                    checkLBoxOpcionais.SetItemChecked(2, true);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int id = 0;
            int ano = 0;
            VehicleGroup grupoDeVeiculos = null;
            if (textId.Text.Length > 0)
                id = Convert.ToInt32(textId.Text);            
            string placa = textPlaca.Text;
            string chassi = textChassi.Text;
            string marca = textMarca.Text;
            string modelo = textModelo.Text;
            if(textAno.Text.Length > 0)
                ano = Convert.ToInt32(textAno.Text);
            string cor = textCor.Text;
            grupoDeVeiculos = cBoxGrupo.SelectedItem as VehicleGroup;
            int capTanque = Convert.ToInt32(numUpDownCapTanque.Value);
            string combustivel = cBoxCombustivel.Text;
            int numPortas = Convert.ToInt32(numUpDownQtdPortas.Value);
            int numPessoas = Convert.ToInt32(numUpDownQtdPessoas.Value);
            double kilometragem = Convert.ToDouble(textKM.Text);
            char tamPortaMalas = Convert.ToChar(cBoxPortaMalas.Text);
            bool possuiArCondicionado = false;
            bool possuiDirecaoHidraulica = false;
            bool possuiFreioAbs = false;
            List<VehicleImage> imagens = imagensVeiculo;



            if (checkLBoxOpcionais.CheckedIndices.Contains(0))
                possuiArCondicionado = true;
            if (checkLBoxOpcionais.CheckedIndices.Contains(1))
                possuiDirecaoHidraulica = true;
            if (checkLBoxOpcionais.CheckedIndices.Contains(2))
                possuiFreioAbs = true;

            veiculo = new Vehicle(id, modelo, grupoDeVeiculos, placa, chassi, marca, cor, combustivel, capTanque, ano, kilometragem, numPortas, numPessoas, tamPortaMalas, possuiArCondicionado, possuiDirecaoHidraulica, possuiFreioAbs, false, imagensVeiculo);

            string resultadoValidacao = veiculo.Validate();

            if (resultadoValidacao != "VALIDO")
            {
                string primeiroErro = new StringReader(resultadoValidacao).ReadLine();

                TelaPrincipalForm.Instancia.AtualizarRodape(primeiroErro);

                DialogResult = DialogResult.None;
            }
        }

        private void textAno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (textAno.Text.IndexOf(".") >= 0 || textAno.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void textKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                if (textKM.Text.IndexOf(".") >= 0 || textKM.Text.Length == 0)
                {
                    e.Handled = true;
                }
            }
            else if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImagemVeiculoForm telaImagem = new ImagemVeiculoForm(this);
            telaImagem.Show();
        }

        public void AtualizarListaDeFotos(List<VehicleImage> imagens)
        {
            this.imagensVeiculo = imagens;
        }
    }
}

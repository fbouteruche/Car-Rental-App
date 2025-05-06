using CarRental.Controllers.ServiceModule;
using CarRental.Domain.ServiceModule;
using CarRental.Domain.Shared;
using CarRental.WindowsApp.Features.Services;
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
    public partial class ServiceSelectionForm : Form
    {
        public List<Service> selectedServices;
        public string insurance = "None";
        ServiceController serviceController;
        public ServiceSelectionForm()
        {
            serviceController = new ServiceController();
            selectedServices = new List<Service>();
            InitializeComponent();
            UpdateCheckedListBox();
            cBoxSeguro.SelectedIndex = 0; 
        }

        public void InitializeFields(List<Service> initialServices, string initialInsurance, bool insuranceFieldEditable)
        {
            if (initialInsurance.Contains("Third Party"))
                cBoxSeguro.SelectedIndex = 2;
            else if (initialInsurance.Contains("Customer"))
                cBoxSeguro.SelectedIndex = 1;

            if (initialServices != null)
            {
                for (int index = 0; index < cLBoxServicos.Items.Count; index++)
                {
                    cLBoxServicos.SetItemChecked(index, initialServices.Contains(cLBoxServicos.Items[index]));
                }
            }

            cBoxSeguro.Enabled = insuranceFieldEditable;
        }

        private void UpdateCheckedListBox()
        {
            cLBoxServicos.Items.Clear();
            foreach (Service service in serviceController.SelectAll())
                cLBoxServicos.Items.Add(service);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            insurance = cBoxSeguro.SelectedItem.ToString().Replace(" ", "");
            foreach (Service service in cLBoxServicos.CheckedItems)
                selectedServices.Add(service);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceForm serviceForm = new ServiceForm("Service Registration");
            if (serviceForm.ShowDialog() == DialogResult.OK)
            {
                serviceController.InsertNew(serviceForm.Service);
                UpdateCheckedListBox();                
            }
        }
    }
}

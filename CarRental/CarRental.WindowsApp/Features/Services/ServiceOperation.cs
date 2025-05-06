using CarRental.Controllers.ServiceModule;
using CarRental.Domain.ServiceModule;
using CarRental.WindowsApp.Servicos;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Services
{
    class ServiceOperation : IRecordable
    {
        private readonly ServiceController controller = null;
        private readonly ServiceTableControl serviceTable = null;

        public ServiceOperation(ServiceController serviceController)
        {
            controller = serviceController;
            serviceTable = new ServiceTableControl();
        }

        public void InsertNewRecord()
        {
            ServiceForm form = new ServiceForm("Service Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.Service);

                List<Service> services = controller.SelectAll();

                serviceTable.UpdateRecords(services);

                MainForm.Instance.UpdateFooter($"Service: [{form.Service.Name}] successfully added");
            }
        }

        public void EditRecord()
        {
            int id = serviceTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a service to edit!", "Service Editing",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Service selectedService = controller.SelectById(id);

            ServiceForm form = new ServiceForm("Service Editing");

            form.Service = selectedService;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Service);

                List<Service> services = controller.SelectAll();

                serviceTable.UpdateRecords(services);

                MainForm.Instance.UpdateFooter($"Service: [{form.Service.Name}] successfully edited");
            }
        }

        public void DeleteRecord()
        {
            int id = serviceTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a service to delete!", "Service Deletion",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Service selectedService = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the service: [{selectedService.Name}] ?",
                "Service Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);

                List<Service> services = controller.SelectAll();

                serviceTable.UpdateRecords(services);

                MainForm.Instance.UpdateFooter($"Service: [{selectedService.Name}] successfully removed");
            }
        }

        public UserControl GetTable()
        {
            List<Service> services = controller.SelectAll();

            serviceTable.UpdateRecords(services);

            return serviceTable;
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }
    }
}

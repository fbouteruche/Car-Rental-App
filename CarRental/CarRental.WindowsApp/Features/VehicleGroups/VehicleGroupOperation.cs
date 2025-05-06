using CarRental.Controllers.VehicleGroupModule;
using CarRental.Domain.VehicleGroupModule;
using CarRental.WindowsApp.Features.VehicleGroups;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    public class VehicleGroupOperation : IRecordable
    {
        private readonly VehicleGroupController controller = null;
        private readonly VehicleGroupTableControl vehicleGroupTable = null;

        public VehicleGroupOperation(VehicleGroupController vehicleGroupController)
        {
            controller = vehicleGroupController;
            vehicleGroupTable = new VehicleGroupTableControl();
        }
        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void EditRecord()
        {
            int id = vehicleGroupTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a Vehicle Group to edit!", "Edit Vehicle Group",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            VehicleGroup selectedGroup = controller.SelectById(id);

            VehicleGroupForm form = new VehicleGroupForm("Edit Vehicle Group");

            form.VehicleGroup = selectedGroup;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.VehicleGroup);

                List<VehicleGroup> vehicleGroups = controller.SelectAll();

                vehicleGroupTable.UpdateRecords(vehicleGroups);

                MainForm.Instance.UpdateFooter($"Vehicle Group: [{form.VehicleGroup.Name}] successfully edited");
            }
        }

        public void DeleteRecord()
        {
            int id = vehicleGroupTable.GetSelectedId();
            if (id == 0)
            {
                MessageBox.Show("Select a Vehicle Group to delete", "Delete Vehicle Group", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            VehicleGroup selectedGroup = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the Vehicle Group: [{selectedGroup.Name}]?",
                "Delete Vehicle Group", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);

                List<VehicleGroup> groups = controller.SelectAll();

                vehicleGroupTable.UpdateRecords(groups);

                MainForm.Instance.UpdateFooter($"Vehicle Group: [{selectedGroup.Name}] successfully removed");
            }
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void InsertNewRecord()
        {
            VehicleGroupForm form = new VehicleGroupForm("Vehicle Group Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.VehicleGroup);

                List<VehicleGroup> vehicleGroups = controller.SelectAll();

                vehicleGroupTable.UpdateRecords(vehicleGroups);

                MainForm.Instance.UpdateFooter($"Vehicle Group: [{form.VehicleGroup.Name}] successfully inserted");
            }
        }

        public UserControl GetTable()
        {
            List<VehicleGroup> vehicleGroups = controller.SelectAll();
            vehicleGroupTable.UpdateRecords(vehicleGroups);

            return vehicleGroupTable;
        }
    }
}

using CarRental.Controllers.VehicleModule;
using CarRental.WindowsApp.Shared;
using CarRental.WindowsApp.Features.Vehicles;
using CarRental.Domain.VehicleModule;
using CarRental.Domain.VehicleImageModule;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Vehicles
{
    public class VehicleOperation : IRecordable
    {
        private readonly VehicleController controller = null;
        private readonly VehicleTableControl vehicleTable = null;
        public VehicleOperation(VehicleController vehicleController)
        {
            controller = vehicleController;
            vehicleTable = new VehicleTableControl();
        }
        public void InsertNewRecord()
        {
            VehicleForm form = new VehicleForm("Vehicle Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Vehicle.images.Count != 0)
                    foreach (Domain.VehicleImageModule.VehicleImage image in form.Vehicle.images)
                        image.VehicleId = form.Vehicle.Id;

                controller.InsertNew(form.Vehicle);

                List<Vehicle> vehicles = controller.SelectAll();

                vehicleTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Vehicle: [{form.Vehicle.model}] successfully registered");
            }
        }
        public void EditRecord()
        {
            int id = vehicleTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a vehicle to edit!", "Edit Vehicles", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle selectedVehicle = controller.SelectById(id);

            VehicleForm form = new VehicleForm("Edit Vehicle");

            form.Vehicle = selectedVehicle;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Vehicle);

                List<Vehicle> vehicles = controller.SelectAll();

                vehicleTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Vehicle: [{form.Vehicle.model}] successfully edited");
            }
        }
        public void DeleteRecord()
        {
            int id = vehicleTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a vehicle to delete!", "Delete Vehicles",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Vehicle selectedVehicle = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the vehicle: [{selectedVehicle.model}] ?",
                "Delete Vehicles", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);

                List<Vehicle> vehicles = controller.SelectAll();

                vehicleTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Vehicle: [{selectedVehicle.model}] successfully removed");
            }
        }
        public void FilterRecords()
        {
            throw new System.NotImplementedException();
        }
        public UserControl GetTable()
        {
            List<Vehicle> vehicles = controller.SelectAll();

            vehicleTable.UpdateRecords(vehicles);

            return vehicleTable;
        }
        public void GroupRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}

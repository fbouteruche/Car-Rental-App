using CarRental.Controllers.RentalModule;
using CarRental.Domain.RentalModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Returns
{
    public class ReturnOperation : IRecordable
    {
        private readonly RentalController controller = null;
        private readonly ReturnTableControl returnTable = null;
        public ReturnOperation(RentalController returnController)
        {
            controller = returnController;
            returnTable = new ReturnTableControl();
        }
        public void InsertNewRecord()
        {
            int id = returnTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a record to process the return!", "Register Return",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental selectedRental = controller.SelectById(id);

            ReturnForm form = new ReturnForm("Vehicle Return");

            form.Return = selectedRental;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(form.Return.Id , form.Return);
                List<Rental> employees = controller.SelectAll();
                returnTable.UpdateRecords(employees);
                MainForm.Instance.UpdateFooter($"Return: [{form.Return.Id}] successfully processed");
            }
        }

        public void EditRecord()
        {
            MessageBox.Show("It is not possible to edit a closed return!\nTo edit an open rental, go to the Rental menu");
        }

        public void DeleteRecord()
        {
            int id = returnTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a return record to delete!", "Delete Record",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental selectedRental = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the entire rental and return record: [{selectedRental.Id}] ?",
                "Delete Record", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);

                List<Rental> vehicles = controller.SelectAll();

                returnTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Record of: [{selectedRental.ContractingCustomer}] successfully removed");
            }
        }

        public void FilterRecords()
        {
            FilterReturnForm filterForm = new FilterReturnForm();

            if (filterForm.ShowDialog() == DialogResult.OK)
            {
                List<Rental> returns = controller.SelectAll();
                string rentalType = "";

                switch (filterForm.FilterType)
                {
                    case FilterReturnEnum.AllReturns:
                        break;

                    case FilterReturnEnum.PendingReturns:
                        {
                            List<Rental> filter = new List<Rental>();
                            foreach (Rental returnRental in returns)
                                if (returnRental.IsOpen)
                                    filter.Add(returnRental);
                            returns = filter;
                            rentalType = "pending";
                            break;
                        }

                    case FilterReturnEnum.CompletedReturns:
                        {
                            List<Rental> filter = new List<Rental>();
                            foreach (Rental returnRental in returns)
                                if (!returnRental.IsOpen)
                                    filter.Add(returnRental);
                            returns = filter;
                            rentalType = "completed";
                            break;
                        }

                    default:
                        break;
                }

                returnTable.UpdateRecords(returns);
                MainForm.Instance.UpdateFooter($"Viewing {returns.Count} return(s) {rentalType}");
            }
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public UserControl GetTable()
        {
            List<Rental> rentals = controller.SelectAll();

            returnTable.UpdateRecords(rentals);

            return returnTable;
        }
    }
}

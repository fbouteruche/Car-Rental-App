using CarRental.Controllers.RentalModule;
using CarRental.Controllers.RentalServiceRelationshipModule;
using CarRental.Controllers.Shared;
using CarRental.Domain.RentalModule;
using CarRental.Domain.RentalServiceRelationshipModule;
using CarRental.WindowsApp.Servicos;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Rentals
{
    public class RentalOperation : IRecordable
    {
        private readonly RentalController controller = null;
        private readonly RentalServiceRelationshipController relationshipController = null;
        private RentalServiceRelationship relationship;
        private readonly RentalTableControl rentalTable = null;
        PdfConverter pdfConverter;
        public RentalOperation(RentalController rentalController)
        {
            pdfConverter = new PdfConverter(10, 18);
            controller = rentalController;
            relationshipController = new RentalServiceRelationshipController();
            rentalTable = new RentalTableControl();
        }

        public void InsertNewRecord()
        {
            RentalForm form = new RentalForm("Vehicle Rental");

            if (form.ShowDialog() == DialogResult.OK)
            {
                string rentalResult = controller.InsertNew(form.Rental);

                if (rentalResult == "VALID")
                {
                    relationship = new RentalServiceRelationship(0, form.Rental, form.Services);
                    relationshipController.InsertNew(relationship);
                    pdfConverter.ConvertRentalToPdf(form.Rental);

                    try
                    {
                        SendEmail(form);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while trying to send the rental data by email.\nThe receipt is saved in the Receipts folder and should be sent manually as soon as possible!!\n" + ex.Message, "Error sending email");
                    }
                }

                List<Rental> vehicles = controller.SelectAll();

                rentalTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Rental: [{form.Rental.Vehicle}] completed successfully");
            }
        }

        public void EditRecord()
        {
            int id = rentalTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a rental to edit!", "Edit rental", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental selectedRental = controller.SelectById(id);

            RentalForm form = new RentalForm("Edit Rental");

            form.Rental = selectedRental;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Rental);

                List<Rental> vehicles = controller.SelectAll();

                rentalTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Rental of: [{form.Rental.ContractingCustomer}] edited successfully");
            }
        }

        public void DeleteRecord()
        {
            int id = rentalTable.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a rental to delete!", "Delete Rental",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Rental selectedRental = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the rental: [{selectedRental.Id}] ?",
                "Delete Rental", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                controller.Delete(id);

                List<Rental> vehicles = controller.SelectAll();

                rentalTable.UpdateRecords(vehicles);

                MainForm.Instance.UpdateFooter($"Rental of: [{selectedRental.ContractingCustomer}] removed successfully");
            }
        }
        public void GroupRecords()
        {
            throw new NotImplementedException();
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }
        public UserControl GetTable()
        {
            List<Rental> rentals = controller.SelectAll();
            rentalTable.UpdateRecords(rentals);

            return rentalTable;
        }

        private void SendEmail(RentalForm form)
        {
            using (SmtpClient smtp = new SmtpClient())
            {
                using (MailMessage email = new MailMessage())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("matriquisdevelopers@gmail.com", "matrixadm");
                    smtp.Port = 587;
                    smtp.EnableSsl = true;

                    email.From = new MailAddress("matriquisdevelopers@gmail.com");
                    email.To.Add(form.Rental.ContractingCustomer.Email);

                    email.Subject = "Matrix";
                    email.IsBodyHtml = false;
                    email.Body = "Thank you for using our services, come back soon!";

                    email.Attachments.Add(new Attachment($@"..\..\..\Receipts\receipt{form.Rental.Id}.pdf"));

                    smtp.Send(email);
                }
            }
        }
    }
}

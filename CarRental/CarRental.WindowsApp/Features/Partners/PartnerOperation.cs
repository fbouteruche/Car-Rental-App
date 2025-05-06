using CarRental.Controllers.PartnerModule;
using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public class PartnerOperation : IRecordable
    {
        private readonly PartnerController controller;
        private readonly PartnerTableControl table;

        public PartnerOperation(PartnerController partnerController)
        {
            controller = partnerController;
            table = new PartnerTableControl();
        }

        public void InsertNewRecord()
        {
            PartnerForm form = new PartnerForm("Partner Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.Partner);

                List<Partner> partners = controller.SelectAll();

                table.UpdateRecords(partners);

                MainForm.Instance.UpdateFooter($"Partner: [{form.Partner.Name}] successfully added");
            }
        }        

        public void EditRecord()
        {
            int id = table.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a Partner to edit!", "Edit Partner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner selectedPartner = controller.SelectById(id);
            PartnerForm form = new PartnerForm("Edit Partner");
            form.Partner = selectedPartner;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Partner);
                List<Partner> partners = controller.SelectAll();
                table.UpdateRecords(partners);
                MainForm.Instance.UpdateFooter($"Partner: [{selectedPartner.Name}] successfully edited");
            }
        }

        public void DeleteRecord()
        {
            int id = table.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a Partner to delete", "Delete Partner", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Partner selectedPartner = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the Partner: [{selectedPartner.Name}]?", "Delete Partner", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controller.Delete(id);
                List<Partner> partners = controller.SelectAll();
                table.UpdateRecords(partners);
                MainForm.Instance.UpdateFooter($"Partner: [{selectedPartner.Name}] successfully removed");
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
            List<Partner> partners = controller.SelectAll();
            table.UpdateRecords(partners);
            return table;
        }
    }
}

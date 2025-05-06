using CarRental.Controllers.CouponModule;
using CarRental.Domain.CouponModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Coupons
{
    public class CouponOperations : IRecordable
    {
        private CouponController controller;
        private readonly CouponTableControl table;

        public CouponOperations(CouponController couponController)
        {
            controller = couponController;
            table = new CouponTableControl();
        }

        public void InsertNewRecord()
        {
            CouponForm form = new CouponForm("Coupon Registration");

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.InsertNew(form.Coupon);

                List<Coupon> coupons = controller.SelectAll();

                table.UpdateRecords(coupons);

                MainForm.Instance.UpdateFooter($"Coupon: [{form.Coupon.Name}] successfully inserted");
            }
        }

        public void EditRecord()
        {
            int id = table.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a coupon to edit!", "Coupon Editing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon selectedCoupon = controller.SelectById(id);
            CouponForm form = new CouponForm("Coupon Editing");
            form.Coupon = selectedCoupon;

            if (form.ShowDialog() == DialogResult.OK)
            {
                controller.Edit(id, form.Coupon);
                List<Coupon> coupons = controller.SelectAll();
                table.UpdateRecords(coupons);
                MainForm.Instance.UpdateFooter($"Coupon: [{selectedCoupon.Name}] successfully edited");
            }
        }

        public void DeleteRecord()
        {
            int id = table.GetSelectedId();

            if (id == 0)
            {
                MessageBox.Show("Select a coupon to delete", "Coupon Deletion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Coupon selectedCoupon = controller.SelectById(id);

            if (MessageBox.Show($"Are you sure you want to delete the coupon: [{selectedCoupon.Name}]?", "Coupon Deletion", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                controller.Delete(id);
                List<Coupon> coupons = controller.SelectAll();
                table.UpdateRecords(coupons);
                MainForm.Instance.UpdateFooter($"Coupon: [{selectedCoupon.Name}] successfully removed");
            }
        }

        public UserControl GetTable()
        {
            List<Coupon> coupons = controller.SelectAll();
            table.UpdateRecords(coupons);
            return table;
        }

        public void FilterRecords()
        {
            throw new NotImplementedException();
        }

        public void GroupRecords()
        {
            throw new NotImplementedException();
        }
    }
}

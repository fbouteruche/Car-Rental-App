using CarRental.Controllers.PartnerModule;
using CarRental.Domain.CouponModule;
using CarRental.Domain.PartnerModule;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Coupons
{
    public partial class CouponForm : Form
    {
        Coupon coupon;
        PartnerController partnerController;
        public CouponForm(string title)
        {
            partnerController = new PartnerController();
            InitializeComponent();
            rBtnFixedValue.Checked = true;
            lblTitle.Text = title;
            LoadPartners();
        }

        private void LoadPartners()
        {
            cBoxPartner.DataSource = partnerController.SelectAll();
        }

        public Coupon Coupon
        {
            get { return coupon; }

            set
            {
                coupon = value;

                txtId.Text = coupon.Id.ToString();
                txtName.Text = coupon.Name;
                txtCode.Text = coupon.Code;
                if (coupon.IsFixedDiscount)
                {
                    rBtnFixedValue.Checked = true;
                    rBtnPercentage.Checked = false;
                    numUpDownValue.Maximum = 15000;
                }
                else
                {
                    rBtnFixedValue.Checked = false;
                    rBtnPercentage.Checked = true;
                    numUpDownValue.Maximum = 100;
                }
                numUpDownValue.Value = Convert.ToDecimal(coupon.Value);
                numUpDownMinimumValue.Value = Convert.ToDecimal(coupon.MinimumValue);
                dtpExpirationDate.Value = coupon.ExpirationDate;
                cBoxPartner.SelectedItem = coupon.Partner;
            }
        }
        #region Radio Buttons
        private void rBtnFixedValue_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnFixedValue.Checked == true)
            {
                lblValue.Text = "Value";
                lblValue.Location = new Point(70, 215);
                numUpDownValue.Maximum = 15000;
            }
        }

        private void rBtnPercentage_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnPercentage.Checked == true)
            {
                lblValue.Text = "Percentage";
                lblValue.Location = new Point(31, 215);
                numUpDownValue.Maximum = 100;
            }
        }
        #endregion
        private void btnConfirm_Click(object sender, EventArgs e)
        {            
            bool isFixedDiscount = false;

            int id = 0;
            if (txtId.Text.Length > 0)
                id = Convert.ToInt32(txtId.Text);
            string name = txtName.Text;
            string code = txtCode.Text;
            double minimumValue = Convert.ToDouble(numUpDownMinimumValue.Value);
            double value = Convert.ToDouble(numUpDownValue.Value);
            if (rBtnFixedValue.Checked == true)
                isFixedDiscount = true;
            DateTime expirationDate = dtpExpirationDate.Value;

            Partner partner = cBoxPartner.SelectedItem as Partner;

            coupon = new Coupon(id, name, code, value, minimumValue, isFixedDiscount, expirationDate, partner);

            string validationResult = coupon.Validate();

            if (validationResult != "VALID")
            {
                string firstError = new StringReader(validationResult).ReadLine();

                MainForm.Instance.UpdateFooter(firstError);

                DialogResult = DialogResult.None;
            }
        }
    }
}

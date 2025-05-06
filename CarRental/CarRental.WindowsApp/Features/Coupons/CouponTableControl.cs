using CarRental.Domain.CouponModule;
using CarRental.WindowsApp.Shared;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Coupons
{
    public partial class CouponTableControl : UserControl
    {
        public CouponTableControl()
        {
            InitializeComponent();
            gridCoupons.ConfigureZebraGrid();
            gridCoupons.ConfigureReadOnlyGrid();
            gridCoupons.Columns.AddRange(GetColumns());
        }

        private DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Code", HeaderText = "Code"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Value"},
                new DataGridViewTextBoxColumn { DataPropertyName = "IsFixedDiscount", HeaderText = "Fixed Discount"},
                new DataGridViewTextBoxColumn { DataPropertyName = "ExpirationDate", HeaderText = "ExpirationDate"},
           };

            return columns;
        }

        internal void UpdateRecords(List<Coupon> coupons)
        {
            gridCoupons.Rows.Clear();

            foreach (Coupon coupon in coupons)
                gridCoupons.Rows.Add(coupon.Id, coupon.Name, coupon.Code, coupon.Value, coupon.IsFixedDiscount, coupon.ExpirationDate);
        }

        internal int GetSelectedId()
        {
            return gridCoupons.SelectId<int>();
        }
    }
}

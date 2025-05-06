using CarRental.WindowsApp.Shared;

namespace CarRental.WindowsApp.Features.Coupons
{
    public class CouponConfigurationToolBox : IConfigurationToolBox
    {
        public string AddToolTip
        {
            get { return "Register Discount Coupon"; }
        }

        public string RegistrationType
        {
            get { return "Register a new Coupon"; }
        }

        public string EditToolTip
        {
            get { return "Edit an existing Coupon"; }
        }

        public string DeleteToolTip
        {
            get { return "Delete an existing Coupon"; }
        }
    }
}

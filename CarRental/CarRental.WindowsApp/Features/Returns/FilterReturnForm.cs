using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Returns
{
    public partial class FilterReturnForm : Form
    {
        public FilterReturnForm()
        {
            InitializeComponent();
        }
        public FilterReturnEnum FilterType
        {
            get
            {
                if (rdbCompletedReturns.Checked)
                    return FilterReturnEnum.CompletedReturns;

                else if (rdbPendingReturns.Checked)
                    return FilterReturnEnum.PendingReturns;

                else
                    return FilterReturnEnum.AllReturns;
            }
        }
    }
}

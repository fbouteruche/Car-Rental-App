using CarRental.Domain.PartnerModule;
using CarRental.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.WindowsApp.Features.Partners
{
    public partial class PartnerTableControl : UserControl
    {
        public PartnerTableControl()
        {
            InitializeComponent();
            partnerGrid.ConfigureZebraGrid();
            partnerGrid.ConfigureReadOnlyGrid();
            partnerGrid.Columns.AddRange(GetColumns());
        }

        private DataGridViewColumn[] GetColumns()
        {
            var columns = new DataGridViewColumn[]
           {
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID"},
                new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = "Name"}
           };

            return columns;
        }

        internal void UpdateRecords(List<Partner> partners)
        {
            partnerGrid.Rows.Clear();

            foreach (Partner partner in partners)
                partnerGrid.Rows.Add(partner.Id, partner.Name);

        }

        internal int GetSelectedId()
        {
            return partnerGrid.SelectId<int>();
        }
    }
}

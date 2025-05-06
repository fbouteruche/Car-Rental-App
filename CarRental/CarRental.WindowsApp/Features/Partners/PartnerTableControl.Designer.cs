namespace CarRental.WindowsApp.Features.Partners
{
    partial class PartnerTableControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.partnerGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.partnerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // partnerGrid
            // 
            this.partnerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.partnerGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.partnerGrid.Location = new System.Drawing.Point(0, 0);
            this.partnerGrid.Name = "partnerGrid";
            this.partnerGrid.Size = new System.Drawing.Size(150, 150);
            this.partnerGrid.TabIndex = 0;
            // 
            // PartnerTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.partnerGrid);
            this.Name = "PartnerTableControl";
            ((System.ComponentModel.ISupportInitialize)(this.partnerGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView partnerGrid;
    }
}

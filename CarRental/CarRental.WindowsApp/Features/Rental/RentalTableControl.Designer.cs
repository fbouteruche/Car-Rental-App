namespace CarRental.WindowsApp.Features.Rentals
{
    partial class RentalTableControl
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
            this.rentalGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.rentalGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // rentalGrid
            // 
            this.rentalGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rentalGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rentalGrid.Location = new System.Drawing.Point(0, 0);
            this.rentalGrid.Name = "rentalGrid";
            this.rentalGrid.Size = new System.Drawing.Size(150, 150);
            this.rentalGrid.TabIndex = 0;
            // 
            // RentalTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rentalGrid);
            this.Name = "RentalTableControl";
            ((System.ComponentModel.ISupportInitialize)(this.rentalGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView rentalGrid;
    }
}

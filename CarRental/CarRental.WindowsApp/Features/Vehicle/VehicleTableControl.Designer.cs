namespace CarRental.WindowsApp.Features.Vehicles
{
    partial class VehicleTableControl
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

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridVehicles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridVehicles
            // 
            this.dataGridVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVehicles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridVehicles.Location = new System.Drawing.Point(0, 0);
            this.dataGridVehicles.Name = "dataGridVehicles";
            this.dataGridVehicles.Size = new System.Drawing.Size(208, 228);
            this.dataGridVehicles.TabIndex = 0;
            // 
            // VehicleTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridVehicles);
            this.Name = "VehicleTableControl";
            this.Size = new System.Drawing.Size(208, 228);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVehicles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridVehicles;
    }
}

namespace CarRental.WindowsApp.Features.VehicleGroups
{
    partial class VehicleGroupTableControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridVehicleGroups = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicleGroups)).BeginInit();
            this.SuspendLayout();
            // 
            // gridVehicleGroups
            // 
            this.gridVehicleGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVehicleGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridVehicleGroups.Location = new System.Drawing.Point(0, 0);
            this.gridVehicleGroups.Name = "gridVehicleGroups";
            this.gridVehicleGroups.Size = new System.Drawing.Size(237, 219);
            this.gridVehicleGroups.TabIndex = 0;
            // 
            // VehicleGroupTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridVehicleGroups);
            this.Name = "VehicleGroupTableControl";
            this.Size = new System.Drawing.Size(237, 219);
            ((System.ComponentModel.ISupportInitialize)(this.gridVehicleGroups)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridVehicleGroups;
    }
}

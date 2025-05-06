namespace CarRental.WindowsApp.Features.Returns
{
    partial class ReturnTableControl
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
            this.gridReturns = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturns)).BeginInit();
            this.SuspendLayout();
            // 
            // gridReturns
            // 
            this.gridReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReturns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridReturns.Location = new System.Drawing.Point(0, 0);
            this.gridReturns.Name = "gridReturns";
            this.gridReturns.Size = new System.Drawing.Size(150, 150);
            this.gridReturns.TabIndex = 0;
            // 
            // ReturnTableControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridReturns);
            this.Name = "ReturnTableControl";
            ((System.ComponentModel.ISupportInitialize)(this.gridReturns)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridReturns;
    }
}

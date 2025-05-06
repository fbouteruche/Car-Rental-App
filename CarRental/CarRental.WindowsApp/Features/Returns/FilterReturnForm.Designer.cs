namespace CarRental.WindowsApp.Features.Returns
{
    partial class FilterReturnForm
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
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rdbCompletedReturns = new System.Windows.Forms.RadioButton();
            this.rdbPendingReturns = new System.Windows.Forms.RadioButton();
            this.rdbAllReturns = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rdbCompletedReturns
            // 
            this.rdbCompletedReturns.AutoSize = true;
            this.rdbCompletedReturns.Location = new System.Drawing.Point(49, 106);
            this.rdbCompletedReturns.Name = "rdbCompletedReturns";
            this.rdbCompletedReturns.Size = new System.Drawing.Size(226, 17);
            this.rdbCompletedReturns.TabIndex = 9;
            this.rdbCompletedReturns.TabStop = true;
            this.rdbCompletedReturns.Text = "Show only completed returns";
            this.rdbCompletedReturns.UseVisualStyleBackColor = true;
            // 
            // rdbPendingReturns
            // 
            this.rdbPendingReturns.AutoSize = true;
            this.rdbPendingReturns.Location = new System.Drawing.Point(49, 72);
            this.rdbPendingReturns.Name = "rdbPendingReturns";
            this.rdbPendingReturns.Size = new System.Drawing.Size(223, 17);
            this.rdbPendingReturns.TabIndex = 8;
            this.rdbPendingReturns.TabStop = true;
            this.rdbPendingReturns.Text = "Show only pending returns";
            this.rdbPendingReturns.UseVisualStyleBackColor = true;
            // 
            // rdbAllReturns
            // 
            this.rdbAllReturns.AutoSize = true;
            this.rdbAllReturns.Location = new System.Drawing.Point(49, 38);
            this.rdbAllReturns.Name = "rdbAllReturns";
            this.rdbAllReturns.Size = new System.Drawing.Size(170, 17);
            this.rdbAllReturns.TabIndex = 7;
            this.rdbAllReturns.TabStop = true;
            this.rdbAllReturns.Text = "Show all returns";
            this.rdbAllReturns.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(338, 156);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnApply.Location = new System.Drawing.Point(257, 156);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 10;
            this.btnApply.Text = "Filter";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // FilterReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 191);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.rdbCompletedReturns);
            this.Controls.Add(this.rdbPendingReturns);
            this.Controls.Add(this.rdbAllReturns);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterReturnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Filter Return";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbCompletedReturns;
        private System.Windows.Forms.RadioButton rdbPendingReturns;
        private System.Windows.Forms.RadioButton rdbAllReturns;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
    }
}
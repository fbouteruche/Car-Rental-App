namespace CarRental.WindowsApp.Features.VehicleGroups
{
    partial class VehicleGroupForm
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
            this.textGroupName = new System.Windows.Forms.TextBox();
            this.txtDailyPlanRate = new System.Windows.Forms.TextBox();
            this.txtDailyPerKmRate = new System.Windows.Forms.TextBox();
            this.txtControlledPlanRate = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.lblVehicleGroupRegistration = new System.Windows.Forms.Label();
            this.lbId = new System.Windows.Forms.Label();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.lbDailyPlanRate = new System.Windows.Forms.Label();
            this.lbDailyPerKmRate = new System.Windows.Forms.Label();
            this.lbControlledPlanRate = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbUnlimitedPlanRate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtControlledExceededKmRate = new System.Windows.Forms.TextBox();
            this.txtUnlimitedPlanRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtControlledKmLimit = new System.Windows.Forms.TextBox();
            this.lbControlledKmLimit = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textGroupName
            // 
            this.textGroupName.Location = new System.Drawing.Point(235, 37);
            this.textGroupName.Name = "textGroupName";
            this.textGroupName.Size = new System.Drawing.Size(100, 20);
            this.textGroupName.TabIndex = 2;
            // 
            // txtDailyPlanRate
            // 
            this.txtDailyPlanRate.Location = new System.Drawing.Point(235, 63);
            this.txtDailyPlanRate.Name = "txtDailyPlanRate";
            this.txtDailyPlanRate.Size = new System.Drawing.Size(100, 20);
            this.txtDailyPlanRate.TabIndex = 3;
            this.txtDailyPlanRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDailyPlanRate_KeyPress);
            // 
            // txtDailyPerKmRate
            // 
            this.txtDailyPerKmRate.Location = new System.Drawing.Point(235, 89);
            this.txtDailyPerKmRate.Name = "txtDailyPerKmRate";
            this.txtDailyPerKmRate.Size = new System.Drawing.Size(100, 20);
            this.txtDailyPerKmRate.TabIndex = 4;
            this.txtDailyPerKmRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDailyPerKmRate_KeyPress);
            // 
            // txtControlledPlanRate
            // 
            this.txtControlledPlanRate.Location = new System.Drawing.Point(235, 115);
            this.txtControlledPlanRate.Name = "txtControlledPlanRate";
            this.txtControlledPlanRate.Size = new System.Drawing.Size(100, 20);
            this.txtControlledPlanRate.TabIndex = 5;
            this.txtControlledPlanRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControlledPlanRate_KeyPress);
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(235, 11);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(100, 20);
            this.textId.TabIndex = 1;
            this.textId.Text = "0";
            // 
            // lblVehicleGroupRegistration
            // 
            this.lblVehicleGroupRegistration.AutoSize = true;
            this.lblVehicleGroupRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblVehicleGroupRegistration.ForeColor = System.Drawing.Color.Black;
            this.lblVehicleGroupRegistration.Location = new System.Drawing.Point(43, 18);
            this.lblVehicleGroupRegistration.Name = "lblVehicleGroupRegistration";
            this.lblVehicleGroupRegistration.Size = new System.Drawing.Size(260, 20);
            this.lblVehicleGroupRegistration.TabIndex = 47;
            this.lblVehicleGroupRegistration.Text = "Vehicle Group Registration";
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbId.ForeColor = System.Drawing.Color.Black;
            this.lbId.Location = new System.Drawing.Point(6, 14);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(16, 13);
            this.lbId.TabIndex = 41;
            this.lbId.Text = "Id";
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbGroupName.ForeColor = System.Drawing.Color.Black;
            this.lbGroupName.Location = new System.Drawing.Point(6, 40);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Size = new System.Drawing.Size(69, 13);
            this.lbGroupName.TabIndex = 42;
            this.lbGroupName.Text = "Group Name";
            // 
            // lbDailyPlanRate
            // 
            this.lbDailyPlanRate.AutoSize = true;
            this.lbDailyPlanRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbDailyPlanRate.ForeColor = System.Drawing.Color.Black;
            this.lbDailyPlanRate.Location = new System.Drawing.Point(6, 66);
            this.lbDailyPlanRate.Name = "lbDailyPlanRate";
            this.lbDailyPlanRate.Size = new System.Drawing.Size(87, 13);
            this.lbDailyPlanRate.TabIndex = 43;
            this.lbDailyPlanRate.Text = "Daily Plan Rate";
            // 
            // lbDailyPerKmRate
            // 
            this.lbDailyPerKmRate.AutoSize = true;
            this.lbDailyPerKmRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbDailyPerKmRate.ForeColor = System.Drawing.Color.Black;
            this.lbDailyPerKmRate.Location = new System.Drawing.Point(6, 92);
            this.lbDailyPerKmRate.Name = "lbDailyPerKmRate";
            this.lbDailyPerKmRate.Size = new System.Drawing.Size(108, 13);
            this.lbDailyPerKmRate.TabIndex = 44;
            this.lbDailyPerKmRate.Text = "Daily Per KM Rate";
            // 
            // lbControlledPlanRate
            // 
            this.lbControlledPlanRate.AutoSize = true;
            this.lbControlledPlanRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbControlledPlanRate.ForeColor = System.Drawing.Color.Black;
            this.lbControlledPlanRate.Location = new System.Drawing.Point(6, 118);
            this.lbControlledPlanRate.Name = "lbControlledPlanRate";
            this.lbControlledPlanRate.Size = new System.Drawing.Size(110, 13);
            this.lbControlledPlanRate.TabIndex = 45;
            this.lbControlledPlanRate.Text = "Controlled Plan Rate";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(280, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirm.Location = new System.Drawing.Point(199, 286);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lbUnlimitedPlanRate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtControlledExceededKmRate);
            this.groupBox1.Controls.Add(this.txtUnlimitedPlanRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtControlledKmLimit);
            this.groupBox1.Controls.Add(this.lbControlledKmLimit);
            this.groupBox1.Controls.Add(this.lbId);
            this.groupBox1.Controls.Add(this.lbControlledPlanRate);
            this.groupBox1.Controls.Add(this.lbDailyPerKmRate);
            this.groupBox1.Controls.Add(this.textGroupName);
            this.groupBox1.Controls.Add(this.lbDailyPlanRate);
            this.groupBox1.Controls.Add(this.txtDailyPlanRate);
            this.groupBox1.Controls.Add(this.lbGroupName);
            this.groupBox1.Controls.Add(this.txtDailyPerKmRate);
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Controls.Add(this.txtControlledPlanRate);
            this.groupBox1.Location = new System.Drawing.Point(10, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 228);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(208, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "R$";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(208, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 13);
            this.label5.TabIndex = 55;
            this.label5.Text = "R$";
            // 
            // lbUnlimitedPlanRate
            // 
            this.lbUnlimitedPlanRate.AutoSize = true;
            this.lbUnlimitedPlanRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbUnlimitedPlanRate.ForeColor = System.Drawing.Color.Black;
            this.lbUnlimitedPlanRate.Location = new System.Drawing.Point(6, 196);
            this.lbUnlimitedPlanRate.Name = "lbUnlimitedPlanRate";
            this.lbUnlimitedPlanRate.Size = new System.Drawing.Size(102, 13);
            this.lbUnlimitedPlanRate.TabIndex = 54;
            this.lbUnlimitedPlanRate.Text = "Unlimited Plan Rate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(6, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 13);
            this.label7.TabIndex = 53;
            this.label7.Text = "Controlled Exceeded KM Rate";
            // 
            // txtControlledExceededKmRate
            // 
            this.txtControlledExceededKmRate.Location = new System.Drawing.Point(235, 167);
            this.txtControlledExceededKmRate.Name = "txtControlledExceededKmRate";
            this.txtControlledExceededKmRate.Size = new System.Drawing.Size(100, 20);
            this.txtControlledExceededKmRate.TabIndex = 7;
            this.txtControlledExceededKmRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControlledExceededKmRate_KeyPress);
            // 
            // txtUnlimitedPlanRate
            // 
            this.txtUnlimitedPlanRate.Location = new System.Drawing.Point(235, 193);
            this.txtUnlimitedPlanRate.Name = "txtUnlimitedPlanRate";
            this.txtUnlimitedPlanRate.Size = new System.Drawing.Size(100, 20);
            this.txtUnlimitedPlanRate.TabIndex = 8;
            this.txtUnlimitedPlanRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUnlimitedPlanRate_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(208, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "R$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(208, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "R$";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(208, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "R$";
            // 
            // txtControlledKmLimit
            // 
            this.txtControlledKmLimit.Location = new System.Drawing.Point(235, 141);
            this.txtControlledKmLimit.Name = "txtControlledKmLimit";
            this.txtControlledKmLimit.Size = new System.Drawing.Size(100, 20);
            this.txtControlledKmLimit.TabIndex = 6;
            this.txtControlledKmLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtControlledKmLimit_KeyPress);
            // 
            // lbControlledKmLimit
            // 
            this.lbControlledKmLimit.AutoSize = true;
            this.lbControlledKmLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbControlledKmLimit.ForeColor = System.Drawing.Color.Black;
            this.lbControlledKmLimit.Location = new System.Drawing.Point(6, 144);
            this.lbControlledKmLimit.Name = "lbControlledKmLimit";
            this.lbControlledKmLimit.Size = new System.Drawing.Size(110, 13);
            this.lbControlledKmLimit.TabIndex = 46;
            this.lbControlledKmLimit.Text = "Controlled KM Limit";
            // 
            // VehicleGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblVehicleGroupRegistration);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleGroupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textGroupName;
        private System.Windows.Forms.TextBox txtDailyPlanRate;
        private System.Windows.Forms.TextBox txtDailyPerKmRate;
        private System.Windows.Forms.TextBox txtControlledPlanRate;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label lblVehicleGroupRegistration;
        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.Label lbDailyPlanRate;
        private System.Windows.Forms.Label lbDailyPerKmRate;
        private System.Windows.Forms.Label lbControlledPlanRate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtControlledKmLimit;
        private System.Windows.Forms.Label lbControlledKmLimit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbUnlimitedPlanRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtControlledExceededKmRate;
        private System.Windows.Forms.TextBox txtUnlimitedPlanRate;
    }
}
namespace CarRental.WindowsApp.Features.Coupons
{
    partial class CouponForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblMinimumValue = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.rBtnPercentage = new System.Windows.Forms.RadioButton();
            this.rBtnFixedValue = new System.Windows.Forms.RadioButton();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.numUpDownValue = new System.Windows.Forms.NumericUpDown();
            this.numUpDownMinimumValue = new System.Windows.Forms.NumericUpDown();
            this.lblPartner = new System.Windows.Forms.Label();
            this.cBoxPartner = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinimumValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(81, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 20);
            this.lblTitle.TabIndex = 66;
            this.lblTitle.Text = "Coupon Registration";
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpExpirationDate.Location = new System.Drawing.Point(107, 265);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(155, 20);
            this.dtpExpirationDate.TabIndex = 73;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblExpirationDate.ForeColor = System.Drawing.Color.Black;
            this.lblExpirationDate.Location = new System.Drawing.Point(53, 271);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(80, 13);
            this.lblExpirationDate.TabIndex = 82;
            this.lblExpirationDate.Text = "Expiration Date";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(107, 100);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(54, 20);
            this.txtId.TabIndex = 80;
            this.txtId.Text = "0";
            // 
            // lblMinimumValue
            // 
            this.lblMinimumValue.AutoSize = true;
            this.lblMinimumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMinimumValue.ForeColor = System.Drawing.Color.Black;
            this.lblMinimumValue.Location = new System.Drawing.Point(32, 241);
            this.lblMinimumValue.Name = "lblMinimumValue";
            this.lblMinimumValue.Size = new System.Drawing.Size(77, 13);
            this.lblMinimumValue.TabIndex = 78;
            this.lblMinimumValue.Text = "Minimum Value";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblValue.ForeColor = System.Drawing.Color.Black;
            this.lblValue.Location = new System.Drawing.Point(31, 215);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(60, 13);
            this.lblValue.TabIndex = 77;
            this.lblValue.Text = "Percentage";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblCode.ForeColor = System.Drawing.Color.Black;
            this.lblCode.Location = new System.Drawing.Point(66, 155);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(32, 13);
            this.lblCode.TabIndex = 76;
            this.lblCode.Text = "Code";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblName.ForeColor = System.Drawing.Color.Black;
            this.lblName.Location = new System.Drawing.Point(71, 129);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 75;
            this.lblName.Text = "Name";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblId.ForeColor = System.Drawing.Color.Black;
            this.lblId.Location = new System.Drawing.Point(90, 103);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 74;
            this.lblId.Text = "Id";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 126);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(155, 20);
            this.txtName.TabIndex = 1;
            // 
            // rBtnPercentage
            // 
            this.rBtnPercentage.AutoSize = true;
            this.rBtnPercentage.Location = new System.Drawing.Point(165, 186);
            this.rBtnPercentage.Name = "rBtnPercentage";
            this.rBtnPercentage.Size = new System.Drawing.Size(80, 17);
            this.rBtnPercentage.TabIndex = 4;
            this.rBtnPercentage.TabStop = true;
            this.rBtnPercentage.Text = "Percentage";
            this.rBtnPercentage.UseVisualStyleBackColor = true;
            this.rBtnPercentage.CheckedChanged += new System.EventHandler(this.rBtnPercentage_CheckedChanged);
            // 
            // rBtnFixedValue
            // 
            this.rBtnFixedValue.AutoSize = true;
            this.rBtnFixedValue.Location = new System.Drawing.Point(79, 186);
            this.rBtnFixedValue.Name = "rBtnFixedValue";
            this.rBtnFixedValue.Size = new System.Drawing.Size(85, 17);
            this.rBtnFixedValue.TabIndex = 3;
            this.rBtnFixedValue.TabStop = true;
            this.rBtnFixedValue.Text = "Fixed Value";
            this.rBtnFixedValue.UseVisualStyleBackColor = true;
            this.rBtnFixedValue.CheckedChanged += new System.EventHandler(this.rBtnFixedValue_CheckedChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(107, 152);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 2;
            // 
            // numUpDownValue
            // 
            this.numUpDownValue.Location = new System.Drawing.Point(107, 213);
            this.numUpDownValue.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numUpDownValue.Name = "numUpDownValue";
            this.numUpDownValue.Size = new System.Drawing.Size(155, 20);
            this.numUpDownValue.TabIndex = 5;
            // 
            // numUpDownMinimumValue
            // 
            this.numUpDownMinimumValue.Location = new System.Drawing.Point(107, 239);
            this.numUpDownMinimumValue.Maximum = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.numUpDownMinimumValue.Name = "numUpDownMinimumValue";
            this.numUpDownMinimumValue.Size = new System.Drawing.Size(155, 20);
            this.numUpDownMinimumValue.TabIndex = 6;
            // 
            // lblPartner
            // 
            this.lblPartner.AutoSize = true;
            this.lblPartner.Location = new System.Drawing.Point(55, 299);
            this.lblPartner.Name = "lblPartner";
            this.lblPartner.Size = new System.Drawing.Size(44, 13);
            this.lblPartner.TabIndex = 83;
            this.lblPartner.Text = "Partner";
            // 
            // cBoxPartner
            // 
            this.cBoxPartner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPartner.FormattingEnabled = true;
            this.cBoxPartner.Location = new System.Drawing.Point(107, 296);
            this.cBoxPartner.Name = "cBoxPartner";
            this.cBoxPartner.Size = new System.Drawing.Size(155, 21);
            this.cBoxPartner.TabIndex = 84;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(248, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 86;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirm.Location = new System.Drawing.Point(167, 349);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 85;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // CouponForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 384);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.cBoxPartner);
            this.Controls.Add(this.lblPartner);
            this.Controls.Add(this.numUpDownMinimumValue);
            this.Controls.Add(this.numUpDownValue);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.rBtnFixedValue);
            this.Controls.Add(this.rBtnPercentage);
            this.Controls.Add(this.dtpExpirationDate);
            this.Controls.Add(this.lblExpirationDate);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblMinimumValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CouponForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinimumValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblMinimumValue;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RadioButton rBtnPercentage;
        private System.Windows.Forms.RadioButton rBtnFixedValue;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.NumericUpDown numUpDownValue;
        private System.Windows.Forms.NumericUpDown numUpDownMinimumValue;
        private System.Windows.Forms.Label lblPartner;
        private System.Windows.Forms.ComboBox cBoxPartner;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
    }
}
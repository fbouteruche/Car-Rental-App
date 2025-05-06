namespace CarRental.WindowsApp.CustomerModule
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.radioButtonIndividual = new System.Windows.Forms.RadioButton();
            this.radioButtonCompany = new System.Windows.Forms.RadioButton();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxMain = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxUniqueId = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDriverLicense = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxPhone = new System.Windows.Forms.MaskedTextBox();
            this.datePickerLicenseExpiry = new System.Windows.Forms.DateTimePicker();
            this.labelLicenseExpiry = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.labelDriverLicense = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelUniqueId = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.groupBoxMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(72, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(163, 20);
            this.labelTitle.TabIndex = 26;
            this.labelTitle.Text = "Customer Registration";
            // 
            // radioButtonIndividual
            // 
            this.radioButtonIndividual.AutoSize = true;
            this.radioButtonIndividual.Location = new System.Drawing.Point(116, 49);
            this.radioButtonIndividual.Name = "radioButtonIndividual";
            this.radioButtonIndividual.Size = new System.Drawing.Size(38, 17);
            this.radioButtonIndividual.TabIndex = 1;
            this.radioButtonIndividual.TabStop = true;
            this.radioButtonIndividual.Text = "PF";
            this.radioButtonIndividual.UseVisualStyleBackColor = true;
            this.radioButtonIndividual.CheckedChanged += new System.EventHandler(this.radioButtonIndividual_CheckedChanged);
            // 
            // radioButtonCompany
            // 
            this.radioButtonCompany.AutoSize = true;
            this.radioButtonCompany.Location = new System.Drawing.Point(160, 49);
            this.radioButtonCompany.Name = "radioButtonCompany";
            this.radioButtonCompany.Size = new System.Drawing.Size(37, 17);
            this.radioButtonCompany.TabIndex = 28;
            this.radioButtonCompany.TabStop = true;
            this.radioButtonCompany.Text = "PJ";
            this.radioButtonCompany.UseVisualStyleBackColor = true;
            this.radioButtonCompany.CheckedChanged += new System.EventHandler(this.radioButtonCompany_CheckedChanged);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonConfirm.Location = new System.Drawing.Point(151, 322);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.buttonCancel.Location = new System.Drawing.Point(232, 321);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // groupBoxMain
            // 
            this.groupBoxMain.Controls.Add(this.maskedTextBoxUniqueId);
            this.groupBoxMain.Controls.Add(this.maskedTextBoxDriverLicense);
            this.groupBoxMain.Controls.Add(this.maskedTextBoxPhone);
            this.groupBoxMain.Controls.Add(this.datePickerLicenseExpiry);
            this.groupBoxMain.Controls.Add(this.labelLicenseExpiry);
            this.groupBoxMain.Controls.Add(this.textBoxId);
            this.groupBoxMain.Controls.Add(this.labelDriverLicense);
            this.groupBoxMain.Controls.Add(this.labelPhone);
            this.groupBoxMain.Controls.Add(this.labelEmail);
            this.groupBoxMain.Controls.Add(this.textBoxEmail);
            this.groupBoxMain.Controls.Add(this.labelAddress);
            this.groupBoxMain.Controls.Add(this.labelUniqueId);
            this.groupBoxMain.Controls.Add(this.textBoxAddress);
            this.groupBoxMain.Controls.Add(this.labelName);
            this.groupBoxMain.Controls.Add(this.labelId);
            this.groupBoxMain.Controls.Add(this.textBoxName);
            this.groupBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBoxMain.ForeColor = System.Drawing.Color.Black;
            this.groupBoxMain.Location = new System.Drawing.Point(12, 81);
            this.groupBoxMain.Name = "groupBoxMain";
            this.groupBoxMain.Size = new System.Drawing.Size(295, 234);
            this.groupBoxMain.TabIndex = 34;
            this.groupBoxMain.TabStop = false;
            this.groupBoxMain.Text = "Enter the data";
            // 
            // maskedTextBoxUniqueId
            // 
            this.maskedTextBoxUniqueId.Location = new System.Drawing.Point(111, 69);
            this.maskedTextBoxUniqueId.Mask = "999.999.999-99";
            this.maskedTextBoxUniqueId.Name = "maskedTextBoxUniqueId";
            this.maskedTextBoxUniqueId.Size = new System.Drawing.Size(90, 20);
            this.maskedTextBoxUniqueId.TabIndex = 3;
            // 
            // maskedTextBoxDriverLicense
            // 
            this.maskedTextBoxDriverLicense.Location = new System.Drawing.Point(111, 173);
            this.maskedTextBoxDriverLicense.Mask = "000000000-90";
            this.maskedTextBoxDriverLicense.Name = "maskedTextBoxDriverLicense";
            this.maskedTextBoxDriverLicense.Size = new System.Drawing.Size(81, 20);
            this.maskedTextBoxDriverLicense.TabIndex = 7;
            // 
            // maskedTextBoxPhone
            // 
            this.maskedTextBoxPhone.Location = new System.Drawing.Point(111, 121);
            this.maskedTextBoxPhone.Mask = "(99) 99999-9999";
            this.maskedTextBoxPhone.Name = "maskedTextBoxPhone";
            this.maskedTextBoxPhone.Size = new System.Drawing.Size(90, 20);
            this.maskedTextBoxPhone.TabIndex = 5;
            // 
            // datePickerLicenseExpiry
            // 
            this.datePickerLicenseExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerLicenseExpiry.Location = new System.Drawing.Point(111, 199);
            this.datePickerLicenseExpiry.Name = "datePickerLicenseExpiry";
            this.datePickerLicenseExpiry.Size = new System.Drawing.Size(90, 20);
            this.datePickerLicenseExpiry.TabIndex = 8;
            // 
            // labelLicenseExpiry
            // 
            this.labelLicenseExpiry.AutoSize = true;
            this.labelLicenseExpiry.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelLicenseExpiry.ForeColor = System.Drawing.Color.Black;
            this.labelLicenseExpiry.Location = new System.Drawing.Point(31, 205);
            this.labelLicenseExpiry.Name = "labelLicenseExpiry";
            this.labelLicenseExpiry.Size = new System.Drawing.Size(74, 13);
            this.labelLicenseExpiry.TabIndex = 35;
            this.labelLicenseExpiry.Text = "License Expiry";
            // 
            // textBoxId
            // 
            this.textBoxId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxId.Enabled = false;
            this.textBoxId.Location = new System.Drawing.Point(111, 17);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(131, 20);
            this.textBoxId.TabIndex = 23;
            this.textBoxId.Text = "0";
            // 
            // labelDriverLicense
            // 
            this.labelDriverLicense.AutoSize = true;
            this.labelDriverLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelDriverLicense.ForeColor = System.Drawing.Color.Black;
            this.labelDriverLicense.Location = new System.Drawing.Point(75, 176);
            this.labelDriverLicense.Name = "labelDriverLicense";
            this.labelDriverLicense.Size = new System.Drawing.Size(30, 13);
            this.labelDriverLicense.TabIndex = 29;
            this.labelDriverLicense.Text = "CNH";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelPhone.ForeColor = System.Drawing.Color.Black;
            this.labelPhone.Location = new System.Drawing.Point(56, 124);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(38, 13);
            this.labelPhone.TabIndex = 21;
            this.labelPhone.Text = "Phone";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelEmail.ForeColor = System.Drawing.Color.Black;
            this.labelEmail.Location = new System.Drawing.Point(70, 150);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 22;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(111, 147);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(131, 20);
            this.textBoxEmail.TabIndex = 6;
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelAddress.ForeColor = System.Drawing.Color.Black;
            this.labelAddress.Location = new System.Drawing.Point(52, 98);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(48, 13);
            this.labelAddress.TabIndex = 20;
            this.labelAddress.Text = "Address";
            // 
            // labelUniqueId
            // 
            this.labelUniqueId.AutoSize = true;
            this.labelUniqueId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelUniqueId.ForeColor = System.Drawing.Color.Black;
            this.labelUniqueId.Location = new System.Drawing.Point(78, 72);
            this.labelUniqueId.Name = "labelUniqueId";
            this.labelUniqueId.Size = new System.Drawing.Size(27, 13);
            this.labelUniqueId.TabIndex = 19;
            this.labelUniqueId.Text = "CPF";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(111, 95);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(131, 20);
            this.textBoxAddress.TabIndex = 4;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelName.ForeColor = System.Drawing.Color.Black;
            this.labelName.Location = new System.Drawing.Point(70, 46);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 17;
            this.labelName.Text = "Name";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelId.ForeColor = System.Drawing.Color.Black;
            this.labelId.Location = new System.Drawing.Point(89, 20);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(16, 13);
            this.labelId.TabIndex = 14;
            this.labelId.Text = "Id";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(111, 43);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(131, 20);
            this.textBoxName.TabIndex = 2;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(319, 357);
            this.Controls.Add(this.groupBoxMain);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.radioButtonCompany);
            this.Controls.Add(this.radioButtonIndividual);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Registration";
            this.groupBoxMain.ResumeLayout(false);
            this.groupBoxMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.RadioButton radioButtonIndividual;
        private System.Windows.Forms.RadioButton radioButtonCompany;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxMain;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxPhone;
        private System.Windows.Forms.DateTimePicker datePickerLicenseExpiry;
        private System.Windows.Forms.Label labelLicenseExpiry;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label labelDriverLicense;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelUniqueId;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDriverLicense;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxUniqueId;
    }
}
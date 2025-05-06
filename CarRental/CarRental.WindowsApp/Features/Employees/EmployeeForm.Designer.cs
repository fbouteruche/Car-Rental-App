namespace CarRental.WindowsApp.Features.Employee
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false>
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
            this.lbId = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.lbCpf = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbEmployeeFormTitle = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.lbJobTitle = new System.Windows.Forms.Label();
            this.lbSalary = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbInternalRegistration = new System.Windows.Forms.Label();
            this.lbHiringDate = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.mskTxtPhone = new System.Windows.Forms.MaskedTextBox();
            this.mskTxtCpf = new System.Windows.Forms.MaskedTextBox();
            this.textName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.mskTxtHiringDate = new System.Windows.Forms.DateTimePicker();
            this.textInternalRegistration = new System.Windows.Forms.NumericUpDown();
            this.textSalary = new System.Windows.Forms.NumericUpDown();
            this.textJobTitle = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textInternalRegistration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalary)).BeginInit();
            this.SuspendLayout();
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbId.ForeColor = System.Drawing.Color.Black;
            this.lbId.Location = new System.Drawing.Point(73, 18);
            this.lbId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(19, 17);
            this.lbId.TabIndex = 23;
            this.lbId.Text = "Id";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbName.ForeColor = System.Drawing.Color.Black;
            this.lbName.Location = new System.Drawing.Point(48, 50);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(45, 17);
            this.lbName.TabIndex = 24;
            this.lbName.Text = "Name";
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbCpf.ForeColor = System.Drawing.Color.Black;
            this.lbCpf.Location = new System.Drawing.Point(64, 82);
            this.lbCpf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(29, 17);
            this.lbCpf.TabIndex = 25;
            this.lbCpf.Text = "CPF";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbAddress.ForeColor = System.Drawing.Color.Black;
            this.lbAddress.Location = new System.Drawing.Point(24, 114);
            this.lbAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(69, 17);
            this.lbAddress.TabIndex = 26;
            this.lbAddress.Text = "Address";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbEmail.ForeColor = System.Drawing.Color.Black;
            this.lbEmail.Location = new System.Drawing.Point(48, 178);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(47, 17);
            this.lbEmail.TabIndex = 28;
            this.lbEmail.Text = "E-mail";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbPhone.ForeColor = System.Drawing.Color.Black;
            this.lbPhone.Location = new System.Drawing.Point(29, 146);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(64, 17);
            this.lbPhone.TabIndex = 27;
            this.lbPhone.Text = "Phone";
            // 
            // lbEmployeeFormTitle
            // 
            this.lbEmployeeFormTitle.AutoSize = true;
            this.lbEmployeeFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeFormTitle.ForeColor = System.Drawing.Color.Black;
            this.lbEmployeeFormTitle.Location = new System.Drawing.Point(152, 43);
            this.lbEmployeeFormTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmployeeFormTitle.Name = "lbEmployeeFormTitle";
            this.lbEmployeeFormTitle.Size = new System.Drawing.Size(260, 25);
            this.lbEmployeeFormTitle.TabIndex = 29;
            this.lbEmployeeFormTitle.Text = "Employee Registration";
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(103, 15);
            this.textId.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textId.MaxLength = 200;
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(59, 23);
            this.textId.TabIndex = 32;
            this.textId.Text = "0";
            // 
            // textEmail
            // 
            this.textEmail.Location = new System.Drawing.Point(103, 175);
            this.textEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(132, 23);
            this.textEmail.TabIndex = 5;
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(103, 111);
            this.textAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(132, 23);
            this.textAddress.TabIndex = 3;
            // 
            // lbJobTitle
            // 
            this.lbJobTitle.AutoSize = true;
            this.lbJobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbJobTitle.ForeColor = System.Drawing.Color.Black;
            this.lbJobTitle.Location = new System.Drawing.Point(342, 146);
            this.lbJobTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbJobTitle.Name = "lbJobTitle";
            this.lbJobTitle.Size = new System.Drawing.Size(46, 17);
            this.lbJobTitle.TabIndex = 44;
            this.lbJobTitle.Text = "Job Title";
            // 
            // lbSalary
            // 
            this.lbSalary.AutoSize = true;
            this.lbSalary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbSalary.ForeColor = System.Drawing.Color.Black;
            this.lbSalary.Location = new System.Drawing.Point(337, 177);
            this.lbSalary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSalary.Name = "lbSalary";
            this.lbSalary.Size = new System.Drawing.Size(52, 17);
            this.lbSalary.TabIndex = 43;
            this.lbSalary.Text = "Salary";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbUsername.ForeColor = System.Drawing.Color.Black;
            this.lbUsername.Location = new System.Drawing.Point(262, 52);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(127, 17);
            this.lbUsername.TabIndex = 42;
            this.lbUsername.Text = "Username";
            // 
            // lbInternalRegistration
            // 
            this.lbInternalRegistration.AutoSize = true;
            this.lbInternalRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbInternalRegistration.ForeColor = System.Drawing.Color.Black;
            this.lbInternalRegistration.Location = new System.Drawing.Point(323, 20);
            this.lbInternalRegistration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInternalRegistration.Name = "lbInternalRegistration";
            this.lbInternalRegistration.Size = new System.Drawing.Size(65, 17);
            this.lbInternalRegistration.TabIndex = 41;
            this.lbInternalRegistration.Text = "Internal Registration";
            // 
            // lbHiringDate
            // 
            this.lbHiringDate.AutoSize = true;
            this.lbHiringDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lbHiringDate.ForeColor = System.Drawing.Color.Black;
            this.lbHiringDate.Location = new System.Drawing.Point(266, 116);
            this.lbHiringDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHiringDate.Name = "lbHiringDate";
            this.lbHiringDate.Size = new System.Drawing.Size(123, 17);
            this.lbHiringDate.TabIndex = 45;
            this.lbHiringDate.Text = "Hiring Date";
            // 
            // textUsername
            // 
            this.textUsername.Location = new System.Drawing.Point(396, 49);
            this.textUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(132, 23);
            this.textUsername.TabIndex = 7;
            // 
            // mskTxtPhone
            // 
            this.mskTxtPhone.Location = new System.Drawing.Point(103, 143);
            this.mskTxtPhone.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskTxtPhone.Mask = "(00) 00000-0000";
            this.mskTxtPhone.Name = "mskTxtPhone";
            this.mskTxtPhone.Size = new System.Drawing.Size(132, 23);
            this.mskTxtPhone.TabIndex = 4;
            // 
            // mskTxtCpf
            // 
            this.mskTxtCpf.Location = new System.Drawing.Point(103, 79);
            this.mskTxtCpf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskTxtCpf.Mask = "000.000.000-00";
            this.mskTxtCpf.Name = "mskTxtCpf";
            this.mskTxtCpf.Size = new System.Drawing.Size(132, 23);
            this.mskTxtCpf.TabIndex = 2;
            // 
            // textName
            // 
            this.textName.Location = new System.Drawing.Point(103, 47);
            this.textName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(132, 23);
            this.textName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mskTxtPhone);
            this.groupBox2.Controls.Add(this.textPassword);
            this.groupBox2.Controls.Add(this.labelPassword);
            this.groupBox2.Controls.Add(this.mskTxtHiringDate);
            this.groupBox2.Controls.Add(this.mskTxtCpf);
            this.groupBox2.Controls.Add(this.textInternalRegistration);
            this.groupBox2.Controls.Add(this.lbId);
            this.groupBox2.Controls.Add(this.textSalary);
            this.groupBox2.Controls.Add(this.lbPhone);
            this.groupBox2.Controls.Add(this.lbHiringDate);
            this.groupBox2.Controls.Add(this.lbEmail);
            this.groupBox2.Controls.Add(this.lbInternalRegistration);
            this.groupBox2.Controls.Add(this.lbAddress);
            this.groupBox2.Controls.Add(this.textUsername);
            this.groupBox2.Controls.Add(this.lbCpf);
            this.groupBox2.Controls.Add(this.lbUsername);
            this.groupBox2.Controls.Add(this.lbName);
            this.groupBox2.Controls.Add(this.lbSalary);
            this.groupBox2.Controls.Add(this.textId);
            this.groupBox2.Controls.Add(this.textEmail);
            this.groupBox2.Controls.Add(this.textJobTitle);
            this.groupBox2.Controls.Add(this.textAddress);
            this.groupBox2.Controls.Add(this.lbJobTitle);
            this.groupBox2.Controls.Add(this.textName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox2.Location = new System.Drawing.Point(16, 97);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(559, 222);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // textPassword
            // 
            this.textPassword.Location = new System.Drawing.Point(397, 80);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(132, 23);
            this.textPassword.TabIndex = 47;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelPassword.ForeColor = System.Drawing.Color.Black;
            this.labelPassword.Location = new System.Drawing.Point(339, 83);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(49, 17);
            this.labelPassword.TabIndex = 46;
            this.labelPassword.Text = "Password";
            // 
            // mskTxtHiringDate
            // 
            this.mskTxtHiringDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.mskTxtHiringDate.Location = new System.Drawing.Point(397, 111);
            this.mskTxtHiringDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mskTxtHiringDate.Name = "mskTxtHiringDate";
            this.mskTxtHiringDate.Size = new System.Drawing.Size(131, 23);
            this.mskTxtHiringDate.TabIndex = 8;
            // 
            // textInternalRegistration
            // 
            this.textInternalRegistration.Location = new System.Drawing.Point(396, 18);
            this.textInternalRegistration.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textInternalRegistration.Name = "textInternalRegistration";
            this.textInternalRegistration.Size = new System.Drawing.Size(132, 23);
            this.textInternalRegistration.TabIndex = 6;
            // 
            // textSalary
            // 
            this.textSalary.Location = new System.Drawing.Point(397, 175);
            this.textSalary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textSalary.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.textSalary.Name = "textSalary";
            this.textSalary.Size = new System.Drawing.Size(133, 23);
            this.textSalary.TabIndex = 10;
            // 
            // textJobTitle
            // 
            this.textJobTitle.Location = new System.Drawing.Point(397, 143);
            this.textJobTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textJobTitle.Name = "textJobTitle";
            this.textJobTitle.Size = new System.Drawing.Size(132, 23);
            this.textJobTitle.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(475, 326);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirm.Location = new System.Drawing.Point(367, 326);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 28);
            this.btnConfirm.TabIndex = 11;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(591, 368);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbEmployeeFormTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textInternalRegistration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textSalary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbId;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbCpf;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbEmployeeFormTitle;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Label lbJobTitle;
        private System.Windows.Forms.Label lbSalary;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbInternalRegistration;
        private System.Windows.Forms.Label lbHiringDate;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.MaskedTextBox mskTxtPhone;
        private System.Windows.Forms.MaskedTextBox mskTxtCpf;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.NumericUpDown textSalary;
        private System.Windows.Forms.NumericUpDown textInternalRegistration;
        private System.Windows.Forms.DateTimePicker mskTxtHiringDate;
        private System.Windows.Forms.TextBox textJobTitle;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label labelPassword;
    }
}
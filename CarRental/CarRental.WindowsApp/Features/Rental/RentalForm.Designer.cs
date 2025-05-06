namespace CarRental.WindowsApp.Features.Rentals
{
    partial class RentalForm
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
            this.gBoxRegistration = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblInitialValue = new System.Windows.Forms.Label();
            this.btnServices = new System.Windows.Forms.Button();
            this.lblServices = new System.Windows.Forms.Label();
            this.cBoxPlan = new System.Windows.Forms.ComboBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblRentalDate = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.dateTPReturnDate = new System.Windows.Forms.DateTimePicker();
            this.dateTPDepartureDate = new System.Windows.Forms.DateTimePicker();
            this.cBoxDriver = new System.Windows.Forms.ComboBox();
            this.cBoxCustomer = new System.Windows.Forms.ComboBox();
            this.cBoxEmployee = new System.Windows.Forms.ComboBox();
            this.cBoxVehicle = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblCoupon = new System.Windows.Forms.Label();
            this.txtCoupon = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button();
            this.gBoxRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // gBoxRegistration
            // 
            this.gBoxRegistration.Controls.Add(this.btnCheck);
            this.gBoxRegistration.Controls.Add(this.txtCoupon);
            this.gBoxRegistration.Controls.Add(this.lblCoupon);
            this.gBoxRegistration.Controls.Add(this.txtTotal);
            this.gBoxRegistration.Controls.Add(this.lblInitialValue);
            this.gBoxRegistration.Controls.Add(this.btnServices);
            this.gBoxRegistration.Controls.Add(this.lblServices);
            this.gBoxRegistration.Controls.Add(this.cBoxPlan);
            this.gBoxRegistration.Controls.Add(this.lblPlan);
            this.gBoxRegistration.Controls.Add(this.lblVehicle);
            this.gBoxRegistration.Controls.Add(this.lblReturnDate);
            this.gBoxRegistration.Controls.Add(this.lblRentalDate);
            this.gBoxRegistration.Controls.Add(this.lblDriver);
            this.gBoxRegistration.Controls.Add(this.lblCustomer);
            this.gBoxRegistration.Controls.Add(this.lblEmployee);
            this.gBoxRegistration.Controls.Add(this.lblId);
            this.gBoxRegistration.Controls.Add(this.txtId);
            this.gBoxRegistration.Controls.Add(this.dateTPReturnDate);
            this.gBoxRegistration.Controls.Add(this.dateTPDepartureDate);
            this.gBoxRegistration.Controls.Add(this.cBoxDriver);
            this.gBoxRegistration.Controls.Add(this.cBoxCustomer);
            this.gBoxRegistration.Controls.Add(this.cBoxEmployee);
            this.gBoxRegistration.Controls.Add(this.cBoxVehicle);
            this.gBoxRegistration.Location = new System.Drawing.Point(12, 87);
            this.gBoxRegistration.Name = "gBoxRegistration";
            this.gBoxRegistration.Size = new System.Drawing.Size(433, 282);
            this.gBoxRegistration.TabIndex = 0;
            this.gBoxRegistration.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(309, 250);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 17;
            this.txtTotal.Text = "0";
            // 
            // lblInitialValue
            // 
            this.lblInitialValue.AutoSize = true;
            this.lblInitialValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialValue.Location = new System.Drawing.Point(195, 250);
            this.lblInitialValue.Name = "lblInitialValue";
            this.lblInitialValue.Size = new System.Drawing.Size(108, 16);
            this.lblInitialValue.TabIndex = 2;
            this.lblInitialValue.Text = "Initial Value: R$";
            // 
            // btnServices
            // 
            this.btnServices.Location = new System.Drawing.Point(334, 99);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(75, 23);
            this.btnServices.TabIndex = 16;
            this.btnServices.Text = "Select";
            this.btnServices.UseVisualStyleBackColor = true;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(280, 104);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(47, 13);
            this.lblServices.TabIndex = 15;
            this.lblServices.Text = "Services";
            // 
            // cBoxPlan
            // 
            this.cBoxPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxPlan.FormattingEnabled = true;
            this.cBoxPlan.Items.AddRange(new object[] {
            "Daily Plan",
            "Controlled Km",
            "Free Km"});
            this.cBoxPlan.Location = new System.Drawing.Point(89, 99);
            this.cBoxPlan.Name = "cBoxPlan";
            this.cBoxPlan.Size = new System.Drawing.Size(170, 21);
            this.cBoxPlan.TabIndex = 14;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(49, 104);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 13;
            this.lblPlan.Text = "Plan";
            // 
            // lblVehicle
            // 
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Location = new System.Drawing.Point(39, 75);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(42, 13);
            this.lblVehicle.TabIndex = 12;
            this.lblVehicle.Text = "Vehicle";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(216, 183);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(66, 13);
            this.lblReturnDate.TabIndex = 11;
            this.lblReturnDate.Text = "Return Date";
            // 
            // lblRentalDate
            // 
            this.lblRentalDate.AutoSize = true;
            this.lblRentalDate.Location = new System.Drawing.Point(34, 183);
            this.lblRentalDate.Name = "lblRentalDate";
            this.lblRentalDate.Size = new System.Drawing.Size(65, 13);
            this.lblRentalDate.TabIndex = 10;
            this.lblRentalDate.Text = "Rental Date";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(33, 156);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(35, 13);
            this.lblDriver.TabIndex = 9;
            this.lblDriver.Text = "Driver";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(44, 129);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(51, 13);
            this.lblCustomer.TabIndex = 8;
            this.lblCustomer.Text = "Customer";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(21, 48);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(53, 13);
            this.lblEmployee.TabIndex = 7;
            this.lblEmployee.Text = "Employee";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(65, 22);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(18, 13);
            this.lblId.TabIndex = 6;
            this.lblId.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(89, 19);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(68, 20);
            this.txtId.TabIndex = 2;
            this.txtId.Text = "0";
            // 
            // dateTPReturnDate
            // 
            this.dateTPReturnDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTPReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPReturnDate.Location = new System.Drawing.Point(284, 180);
            this.dateTPReturnDate.Name = "dateTPReturnDate";
            this.dateTPReturnDate.Size = new System.Drawing.Size(125, 20);
            this.dateTPReturnDate.TabIndex = 5;
            // 
            // dateTPDepartureDate
            // 
            this.dateTPDepartureDate.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTPDepartureDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTPDepartureDate.Location = new System.Drawing.Point(89, 180);
            this.dateTPDepartureDate.Name = "dateTPDepartureDate";
            this.dateTPDepartureDate.Size = new System.Drawing.Size(121, 20);
            this.dateTPDepartureDate.TabIndex = 4;
            // 
            // cBoxDriver
            // 
            this.cBoxDriver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxDriver.FormattingEnabled = true;
            this.cBoxDriver.Location = new System.Drawing.Point(89, 153);
            this.cBoxDriver.Name = "cBoxDriver";
            this.cBoxDriver.Size = new System.Drawing.Size(320, 21);
            this.cBoxDriver.TabIndex = 3;
            // 
            // cBoxCustomer
            // 
            this.cBoxCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxCustomer.FormattingEnabled = true;
            this.cBoxCustomer.Location = new System.Drawing.Point(89, 126);
            this.cBoxCustomer.Name = "cBoxCustomer";
            this.cBoxCustomer.Size = new System.Drawing.Size(320, 21);
            this.cBoxCustomer.TabIndex = 2;
            // 
            // cBoxEmployee
            // 
            this.cBoxEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxEmployee.FormattingEnabled = true;
            this.cBoxEmployee.Location = new System.Drawing.Point(89, 45);
            this.cBoxEmployee.Name = "cBoxEmployee";
            this.cBoxEmployee.Size = new System.Drawing.Size(320, 21);
            this.cBoxEmployee.TabIndex = 1;
            // 
            // cBoxVehicle
            // 
            this.cBoxVehicle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxVehicle.FormattingEnabled = true;
            this.cBoxVehicle.Location = new System.Drawing.Point(89, 72);
            this.cBoxVehicle.Name = "cBoxVehicle";
            this.cBoxVehicle.Size = new System.Drawing.Size(320, 21);
            this.cBoxVehicle.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(150, 39);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(144, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Register Rental";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(289, 377);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 18;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 377);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 19;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblCoupon
            // 
            this.lblCoupon.AutoSize = true;
            this.lblCoupon.Location = new System.Drawing.Point(43, 209);
            this.lblCoupon.Name = "lblCoupon";
            this.lblCoupon.Size = new System.Drawing.Size(43, 13);
            this.lblCoupon.TabIndex = 18;
            this.lblCoupon.Text = "Coupon";
            // 
            // txtCoupon
            // 
            this.txtCoupon.BackColor = System.Drawing.SystemColors.Window;
            this.txtCoupon.Location = new System.Drawing.Point(89, 206);
            this.txtCoupon.Name = "txtCoupon";
            this.txtCoupon.Size = new System.Drawing.Size(239, 20);
            this.txtCoupon.TabIndex = 19;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(334, 204);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 20;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // RentalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 412);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.gBoxRegistration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RentalForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Rental";
            this.gBoxRegistration.ResumeLayout(false);
            this.gBoxRegistration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gBoxRegistration;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.DateTimePicker dateTPReturnDate;
        private System.Windows.Forms.DateTimePicker dateTPDepartureDate;
        private System.Windows.Forms.ComboBox cBoxDriver;
        private System.Windows.Forms.ComboBox cBoxCustomer;
        private System.Windows.Forms.ComboBox cBoxEmployee;
        private System.Windows.Forms.ComboBox cBoxVehicle;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblRentalDate;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.ComboBox cBoxPlan;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInitialValue;
        private System.Windows.Forms.TextBox txtCoupon;
        private System.Windows.Forms.Label lblCoupon;
        private System.Windows.Forms.Button btnCheck;
    }
}
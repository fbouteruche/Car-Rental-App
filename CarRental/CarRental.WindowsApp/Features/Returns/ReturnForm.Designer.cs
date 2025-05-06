namespace CarRental.WindowsApp.Features.Returns
{
    partial class ReturnForm
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
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpRental = new System.Windows.Forms.GroupBox();
            this.txtInitialKm = new System.Windows.Forms.TextBox();
            this.lblSelectedServices = new System.Windows.Forms.Label();
            this.lblInitialKm = new System.Windows.Forms.Label();
            this.clbSelectedServices = new System.Windows.Forms.CheckedListBox();
            this.txtReturnDate = new System.Windows.Forms.TextBox();
            this.txtRentalDate = new System.Windows.Forms.TextBox();
            this.txtDriver = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.txtVehicle = new System.Windows.Forms.TextBox();
            this.txtEmployee = new System.Windows.Forms.TextBox();
            this.lblPlan = new System.Windows.Forms.Label();
            this.lblVehicle = new System.Windows.Forms.Label();
            this.lblReturnDate = new System.Windows.Forms.Label();
            this.lblRentalDate = new System.Windows.Forms.Label();
            this.lblDriver = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtTotalValue = new System.Windows.Forms.TextBox();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.grpReturn = new System.Windows.Forms.GroupBox();
            this.txtInitialValue = new System.Windows.Forms.TextBox();
            this.lblInitialValue = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.dtpReturn = new System.Windows.Forms.DateTimePicker();
            this.rbtnEmpty = new System.Windows.Forms.RadioButton();
            this.lblFull = new System.Windows.Forms.Label();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.rbtnFull = new System.Windows.Forms.RadioButton();
            this.rbtnThreeQuarters = new System.Windows.Forms.RadioButton();
            this.rbtnHalf = new System.Windows.Forms.RadioButton();
            this.rbtnQuarter = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFinalKm = new System.Windows.Forms.Label();
            this.txtFinalKm = new System.Windows.Forms.TextBox();
            this.lblServices = new System.Windows.Forms.Label();
            this.btnSelectServices = new System.Windows.Forms.Button();
            this.lblTankAmount = new System.Windows.Forms.Label();
            this.cbxTankAmount = new System.Windows.Forms.ComboBox();
            this.lblFuelValue = new System.Windows.Forms.Label();
            this.txtFuelValue = new System.Windows.Forms.TextBox();
            this.grpRental.SuspendLayout();
            this.grpReturn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(357, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(182, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Vehicle Return";
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Location = new System.Drawing.Point(729, 408);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 22;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(810, 408);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpRental
            // 
            this.grpRental.Controls.Add(this.txtInitialKm);
            this.grpRental.Controls.Add(this.lblSelectedServices);
            this.grpRental.Controls.Add(this.lblInitialKm);
            this.grpRental.Controls.Add(this.clbSelectedServices);
            this.grpRental.Controls.Add(this.txtReturnDate);
            this.grpRental.Controls.Add(this.txtRentalDate);
            this.grpRental.Controls.Add(this.txtDriver);
            this.grpRental.Controls.Add(this.txtCustomer);
            this.grpRental.Controls.Add(this.txtPlan);
            this.grpRental.Controls.Add(this.txtVehicle);
            this.grpRental.Controls.Add(this.txtEmployee);
            this.grpRental.Controls.Add(this.lblPlan);
            this.grpRental.Controls.Add(this.lblVehicle);
            this.grpRental.Controls.Add(this.lblReturnDate);
            this.grpRental.Controls.Add(this.lblRentalDate);
            this.grpRental.Controls.Add(this.lblDriver);
            this.grpRental.Controls.Add(this.lblCustomer);
            this.grpRental.Controls.Add(this.lblEmployee);
            this.grpRental.Controls.Add(this.lblId);
            this.grpRental.Controls.Add(this.txtId);
            this.grpRental.Enabled = false;
            this.grpRental.Location = new System.Drawing.Point(12, 83);
            this.grpRental.Name = "grpRental";
            this.grpRental.Size = new System.Drawing.Size(433, 312);
            this.grpRental.TabIndex = 20;
            this.grpRental.TabStop = false;
            this.grpRental.Text = "Rental Details";
            // 
            // txtInitialKm
            // 
            this.txtInitialKm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInitialKm.Enabled = false;
            this.txtInitialKm.Location = new System.Drawing.Point(284, 19);
            this.txtInitialKm.Name = "txtInitialKm";
            this.txtInitialKm.Size = new System.Drawing.Size(141, 20);
            this.txtInitialKm.TabIndex = 25;
            // 
            // lblSelectedServices
            // 
            this.lblSelectedServices.AutoSize = true;
            this.lblSelectedServices.Location = new System.Drawing.Point(35, 204);
            this.lblSelectedServices.Name = "lblSelectedServices";
            this.lblSelectedServices.Size = new System.Drawing.Size(48, 13);
            this.lblSelectedServices.TabIndex = 31;
            this.lblSelectedServices.Text = "Services";
            // 
            // lblInitialKm
            // 
            this.lblInitialKm.AutoSize = true;
            this.lblInitialKm.Location = new System.Drawing.Point(226, 22);
            this.lblInitialKm.Name = "lblInitialKm";
            this.lblInitialKm.Size = new System.Drawing.Size(52, 13);
            this.lblInitialKm.TabIndex = 24;
            this.lblInitialKm.Text = "Initial Km";
            // 
            // clbSelectedServices
            // 
            this.clbSelectedServices.FormattingEnabled = true;
            this.clbSelectedServices.Location = new System.Drawing.Point(89, 204);
            this.clbSelectedServices.Name = "clbSelectedServices";
            this.clbSelectedServices.Size = new System.Drawing.Size(338, 79);
            this.clbSelectedServices.TabIndex = 30;
            // 
            // txtReturnDate
            // 
            this.txtReturnDate.Location = new System.Drawing.Point(284, 175);
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.Size = new System.Drawing.Size(143, 20);
            this.txtReturnDate.TabIndex = 25;
            // 
            // txtRentalDate
            // 
            this.txtRentalDate.Location = new System.Drawing.Point(89, 175);
            this.txtRentalDate.Name = "txtRentalDate";
            this.txtRentalDate.Size = new System.Drawing.Size(121, 20);
            this.txtRentalDate.TabIndex = 29;
            // 
            // txtDriver
            // 
            this.txtDriver.Location = new System.Drawing.Point(89, 149);
            this.txtDriver.Name = "txtDriver";
            this.txtDriver.Size = new System.Drawing.Size(338, 20);
            this.txtDriver.TabIndex = 28;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(89, 123);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(338, 20);
            this.txtCustomer.TabIndex = 27;
            // 
            // txtPlan
            // 
            this.txtPlan.Location = new System.Drawing.Point(89, 97);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.Size = new System.Drawing.Size(338, 20);
            this.txtPlan.TabIndex = 26;
            // 
            // txtVehicle
            // 
            this.txtVehicle.Location = new System.Drawing.Point(89, 71);
            this.txtVehicle.Name = "txtVehicle";
            this.txtVehicle.Size = new System.Drawing.Size(338, 20);
            this.txtVehicle.TabIndex = 25;
            // 
            // txtEmployee
            // 
            this.txtEmployee.Location = new System.Drawing.Point(89, 45);
            this.txtEmployee.Name = "txtEmployee";
            this.txtEmployee.Size = new System.Drawing.Size(338, 20);
            this.txtEmployee.TabIndex = 16;
            // 
            // lblPlan
            // 
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(49, 100);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(31, 13);
            this.lblPlan.TabIndex = 13;
            this.lblPlan.Text = "Plan";
            // 
            // lblVehicle
            // 
            this.lblVehicle.AutoSize = true;
            this.lblVehicle.Location = new System.Drawing.Point(39, 74);
            this.lblVehicle.Name = "lblVehicle";
            this.lblVehicle.Size = new System.Drawing.Size(44, 13);
            this.lblVehicle.TabIndex = 12;
            this.lblVehicle.Text = "Vehicle";
            // 
            // lblReturnDate
            // 
            this.lblReturnDate.AutoSize = true;
            this.lblReturnDate.Location = new System.Drawing.Point(230, 178);
            this.lblReturnDate.Name = "lblReturnDate";
            this.lblReturnDate.Size = new System.Drawing.Size(48, 13);
            this.lblReturnDate.TabIndex = 11;
            this.lblReturnDate.Text = "Forecast";
            // 
            // lblRentalDate
            // 
            this.lblRentalDate.AutoSize = true;
            this.lblRentalDate.Location = new System.Drawing.Point(34, 178);
            this.lblRentalDate.Name = "lblRentalDate";
            this.lblRentalDate.Size = new System.Drawing.Size(49, 13);
            this.lblRentalDate.TabIndex = 10;
            this.lblRentalDate.Text = "Rental";
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(33, 152);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(38, 13);
            this.lblDriver.TabIndex = 9;
            this.lblDriver.Text = "Driver";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(44, 126);
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
            this.lblEmployee.Size = new System.Drawing.Size(56, 13);
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
            this.txtId.Size = new System.Drawing.Size(121, 20);
            this.txtId.TabIndex = 2;
            this.txtId.Text = "0";
            // 
            // txtTotalValue
            // 
            this.txtTotalValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTotalValue.Enabled = false;
            this.txtTotalValue.Location = new System.Drawing.Point(327, 278);
            this.txtTotalValue.Name = "txtTotalValue";
            this.txtTotalValue.Size = new System.Drawing.Size(100, 20);
            this.txtTotalValue.TabIndex = 17;
            this.txtTotalValue.Text = "0";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalValue.Location = new System.Drawing.Point(215, 278);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(116, 16);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "Total Price: R$";
            // 
            // grpReturn
            // 
            this.grpReturn.Controls.Add(this.txtInitialValue);
            this.grpReturn.Controls.Add(this.lblInitialValue);
            this.grpReturn.Controls.Add(this.lblClose);
            this.grpReturn.Controls.Add(this.dtpReturn);
            this.grpReturn.Controls.Add(this.rbtnEmpty);
            this.grpReturn.Controls.Add(this.lblFull);
            this.grpReturn.Controls.Add(this.lblEmpty);
            this.grpReturn.Controls.Add(this.rbtnFull);
            this.grpReturn.Controls.Add(this.rbtnThreeQuarters);
            this.grpReturn.Controls.Add(this.rbtnHalf);
            this.grpReturn.Controls.Add(this.rbtnQuarter);
            this.grpReturn.Controls.Add(this.pictureBox1);
            this.grpReturn.Controls.Add(this.lblFinalKm);
            this.grpReturn.Controls.Add(this.txtFinalKm);
            this.grpReturn.Controls.Add(this.lblServices);
            this.grpReturn.Controls.Add(this.btnSelectServices);
            this.grpReturn.Controls.Add(this.lblTankAmount);
            this.grpReturn.Controls.Add(this.cbxTankAmount);
            this.grpReturn.Controls.Add(this.lblFuelValue);
            this.grpReturn.Controls.Add(this.txtFuelValue);
            this.grpReturn.Controls.Add(this.txtTotalValue);
            this.grpReturn.Controls.Add(this.lblTotalValue);
            this.grpReturn.Location = new System.Drawing.Point(451, 83);
            this.grpReturn.Name = "grpReturn";
            this.grpReturn.Size = new System.Drawing.Size(433, 312);
            this.grpReturn.TabIndex = 24;
            this.grpReturn.TabStop = false;
            this.grpReturn.Text = "Return";
            // 
            // txtInitialValue
            // 
            this.txtInitialValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtInitialValue.Enabled = false;
            this.txtInitialValue.Location = new System.Drawing.Point(327, 252);
            this.txtInitialValue.Name = "txtInitialValue";
            this.txtInitialValue.Size = new System.Drawing.Size(100, 20);
            this.txtInitialValue.TabIndex = 35;
            this.txtInitialValue.Text = "0";
            // 
            // lblInitialValue
            // 
            this.lblInitialValue.AutoSize = true;
            this.lblInitialValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInitialValue.Location = new System.Drawing.Point(215, 254);
            this.lblInitialValue.Name = "lblInitialValue";
            this.lblInitialValue.Size = new System.Drawing.Size(117, 16);
            this.lblInitialValue.TabIndex = 34;
            this.lblInitialValue.Text = "Initial Value: R$";
            // 
            // lblClose
            // 
            this.lblClose.AutoSize = true;
            this.lblClose.Location = new System.Drawing.Point(8, 217);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(59, 13);
            this.lblClose.TabIndex = 33;
            this.lblClose.Text = "Return";
            // 
            // dtpReturn
            // 
            this.dtpReturn.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpReturn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReturn.Location = new System.Drawing.Point(73, 214);
            this.dtpReturn.Name = "dtpReturn";
            this.dtpReturn.Size = new System.Drawing.Size(129, 20);
            this.dtpReturn.TabIndex = 32;
            this.dtpReturn.ValueChanged += new System.EventHandler(this.dtpReturn_ValueChanged);
            // 
            // rbtnEmpty
            // 
            this.rbtnEmpty.AutoSize = true;
            this.rbtnEmpty.Location = new System.Drawing.Point(112, 158);
            this.rbtnEmpty.Name = "rbtnEmpty";
            this.rbtnEmpty.Size = new System.Drawing.Size(14, 13);
            this.rbtnEmpty.TabIndex = 25;
            this.rbtnEmpty.TabStop = true;
            this.rbtnEmpty.UseVisualStyleBackColor = true;
            this.rbtnEmpty.CheckedChanged += new System.EventHandler(this.rbtnEmpty_CheckedChanged);
            // 
            // lblFull
            // 
            this.lblFull.AutoSize = true;
            this.lblFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFull.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFull.Location = new System.Drawing.Point(295, 185);
            this.lblFull.Name = "lblFull";
            this.lblFull.Size = new System.Drawing.Size(17, 16);
            this.lblFull.TabIndex = 31;
            this.lblFull.Text = "F";
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpty.ForeColor = System.Drawing.Color.Red;
            this.lblEmpty.Location = new System.Drawing.Point(139, 185);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(18, 16);
            this.lblEmpty.TabIndex = 30;
            this.lblEmpty.Text = "E";
            // 
            // rbtnFull
            // 
            this.rbtnFull.AutoSize = true;
            this.rbtnFull.Location = new System.Drawing.Point(324, 158);
            this.rbtnFull.Name = "rbtnFull";
            this.rbtnFull.Size = new System.Drawing.Size(14, 13);
            this.rbtnFull.TabIndex = 29;
            this.rbtnFull.TabStop = true;
            this.rbtnFull.UseVisualStyleBackColor = true;
            this.rbtnFull.CheckedChanged += new System.EventHandler(this.rbtnFull_CheckedChanged);
            // 
            // rbtnThreeQuarters
            // 
            this.rbtnThreeQuarters.AutoSize = true;
            this.rbtnThreeQuarters.Location = new System.Drawing.Point(279, 117);
            this.rbtnThreeQuarters.Name = "rbtnThreeQuarters";
            this.rbtnThreeQuarters.Size = new System.Drawing.Size(14, 13);
            this.rbtnThreeQuarters.TabIndex = 28;
            this.rbtnThreeQuarters.TabStop = true;
            this.rbtnThreeQuarters.UseVisualStyleBackColor = true;
            this.rbtnThreeQuarters.CheckedChanged += new System.EventHandler(this.rbtnThreeQuarters_CheckedChanged);
            // 
            // rbtnHalf
            // 
            this.rbtnHalf.AutoSize = true;
            this.rbtnHalf.Location = new System.Drawing.Point(218, 102);
            this.rbtnHalf.Name = "rbtnHalf";
            this.rbtnHalf.Size = new System.Drawing.Size(14, 13);
            this.rbtnHalf.TabIndex = 27;
            this.rbtnHalf.TabStop = true;
            this.rbtnHalf.UseVisualStyleBackColor = true;
            this.rbtnHalf.CheckedChanged += new System.EventHandler(this.rbtnHalf_CheckedChanged);
            // 
            // rbtnQuarter
            // 
            this.rbtnQuarter.AutoSize = true;
            this.rbtnQuarter.Location = new System.Drawing.Point(158, 117);
            this.rbtnQuarter.Name = "rbtnQuarter";
            this.rbtnQuarter.Size = new System.Drawing.Size(14, 13);
            this.rbtnQuarter.TabIndex = 26;
            this.rbtnQuarter.TabStop = true;
            this.rbtnQuarter.UseVisualStyleBackColor = true;
            this.rbtnQuarter.CheckedChanged += new System.EventHandler(this.rbtnQuarter_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CarRental.WindowsApp.Properties.Resources.FuelGauge1;
            this.pictureBox1.Location = new System.Drawing.Point(122, 115);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // lblFinalKm
            // 
            this.lblFinalKm.AutoSize = true;
            this.lblFinalKm.Location = new System.Drawing.Point(8, 47);
            this.lblFinalKm.Name = "lblFinalKm";
            this.lblFinalKm.Size = new System.Drawing.Size(58, 13);
            this.lblFinalKm.TabIndex = 25;
            this.lblFinalKm.Text = "Km driven";
            // 
            // txtFinalKm
            // 
            this.txtFinalKm.Location = new System.Drawing.Point(72, 45);
            this.txtFinalKm.Name = "txtFinalKm";
            this.txtFinalKm.Size = new System.Drawing.Size(141, 20);
            this.txtFinalKm.TabIndex = 24;
            this.txtFinalKm.Text = "0";
            this.txtFinalKm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFinalKm_KeyPress);
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.Location = new System.Drawing.Point(240, 47);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(99, 13);
            this.lblServices.TabIndex = 23;
            this.lblServices.Text = "Additional Services";
            // 
            // btnSelectServices
            // 
            this.btnSelectServices.Location = new System.Drawing.Point(344, 43);
            this.btnSelectServices.Name = "btnSelectServices";
            this.btnSelectServices.Size = new System.Drawing.Size(75, 23);
            this.btnSelectServices.TabIndex = 22;
            this.btnSelectServices.Text = "Select";
            this.btnSelectServices.UseVisualStyleBackColor = true;
            this.btnSelectServices.Click += new System.EventHandler(this.btnSelectServices_Click);
            // 
            // lblTankAmount
            // 
            this.lblTankAmount.AutoSize = true;
            this.lblTankAmount.Location = new System.Drawing.Point(272, 80);
            this.lblTankAmount.Name = "lblTankAmount";
            this.lblTankAmount.Size = new System.Drawing.Size(67, 13);
            this.lblTankAmount.TabIndex = 21;
            this.lblTankAmount.Text = "Tank Amount";
            // 
            // cbxTankAmount
            // 
            this.cbxTankAmount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTankAmount.FormattingEnabled = true;
            this.cbxTankAmount.Items.AddRange(new object[] {
            "0/1",
            "1/4",
            "1/2",
            "3/4",
            "1/1"});
            this.cbxTankAmount.Location = new System.Drawing.Point(344, 80);
            this.cbxTankAmount.Name = "cbxTankAmount";
            this.cbxTankAmount.Size = new System.Drawing.Size(75, 21);
            this.cbxTankAmount.TabIndex = 20;
            this.cbxTankAmount.SelectedIndexChanged += new System.EventHandler(this.cbxTankAmount_SelectedIndexChanged);
            // 
            // lblFuelValue
            // 
            this.lblFuelValue.AutoSize = true;
            this.lblFuelValue.Location = new System.Drawing.Point(8, 80);
            this.lblFuelValue.Name = "lblFuelValue";
            this.lblFuelValue.Size = new System.Drawing.Size(123, 13);
            this.lblFuelValue.TabIndex = 19;
            this.lblFuelValue.Text = "Fuel Value R$";
            // 
            // txtFuelValue
            // 
            this.txtFuelValue.Location = new System.Drawing.Point(136, 80);
            this.txtFuelValue.Name = "txtFuelValue";
            this.txtFuelValue.Size = new System.Drawing.Size(75, 20);
            this.txtFuelValue.TabIndex = 18;
            this.txtFuelValue.Text = "0";
            this.txtFuelValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFuelValue_KeyPress);
            // 
            // ReturnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 443);
            this.Controls.Add(this.grpReturn);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpRental);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReturnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vehicle Rental";
            this.grpRental.ResumeLayout(false);
            this.grpRental.PerformLayout();
            this.grpReturn.ResumeLayout(false);
            this.grpReturn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpRental;
        private System.Windows.Forms.Label lblSelectedServices;
        private System.Windows.Forms.CheckedListBox clbSelectedServices;
        private System.Windows.Forms.TextBox txtReturnDate;
        private System.Windows.Forms.TextBox txtRentalDate;
        private System.Windows.Forms.TextBox txtDriver;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.TextBox txtVehicle;
        private System.Windows.Forms.TextBox txtEmployee;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.Label lblVehicle;
        private System.Windows.Forms.Label lblReturnDate;
        private System.Windows.Forms.Label lblRentalDate;
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtTotalValue;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.GroupBox grpReturn;
        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.Button btnSelectServices;
        private System.Windows.Forms.Label lblTankAmount;
        private System.Windows.Forms.ComboBox cbxTankAmount;
        private System.Windows.Forms.Label lblFuelValue;
        private System.Windows.Forms.TextBox txtFuelValue;
        private System.Windows.Forms.TextBox txtInitialKm;
        private System.Windows.Forms.Label lblInitialKm;
        private System.Windows.Forms.Label lblFinalKm;
        private System.Windows.Forms.TextBox txtFinalKm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFull;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.RadioButton rbtnEmpty;
        private System.Windows.Forms.RadioButton rbtnQuarter;
        private System.Windows.Forms.RadioButton rbtnHalf;
        private System.Windows.Forms.RadioButton rbtnThreeQuarters;
        private System.Windows.Forms.RadioButton rbtnFull;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.DateTimePicker dtpReturn;
        private System.Windows.Forms.Label lblInitialValue;
        private System.Windows.Forms.TextBox txtInitialValue;
    }
}
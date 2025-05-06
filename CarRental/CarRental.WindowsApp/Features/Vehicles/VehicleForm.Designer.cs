namespace CarRental.WindowsApp.Features.Vehicles
{
    partial class VehicleForm
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
            this.textLicensePlate = new System.Windows.Forms.TextBox();
            this.textChassis = new System.Windows.Forms.TextBox();
            this.textBrand = new System.Windows.Forms.TextBox();
            this.textModel = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblImage = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblChassis = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblModel = new System.Windows.Forms.Label();
            this.textColor = new System.Windows.Forms.TextBox();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblFuelType = new System.Windows.Forms.Label();
            this.textMileage = new System.Windows.Forms.TextBox();
            this.lblPassengerCap = new System.Windows.Forms.Label();
            this.lblNoDoors = new System.Windows.Forms.Label();
            this.lblTankCapacity = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblTrunkSize = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grpBoxRequiredData = new System.Windows.Forms.GroupBox();
            this.btnImage = new System.Windows.Forms.Button();
            this.cBoxFuelType = new System.Windows.Forms.ComboBox();
            this.textYear = new System.Windows.Forms.TextBox();
            this.numUpDownTankCapacity = new System.Windows.Forms.NumericUpDown();
            this.cBoxTrunkSize = new System.Windows.Forms.ComboBox();
            this.numUpDownPassengerCap = new System.Windows.Forms.NumericUpDown();
            this.numUpDownNoDoors = new System.Windows.Forms.NumericUpDown();
            this.cBoxGroup = new System.Windows.Forms.ComboBox();
            this.lblLicensePlate = new System.Windows.Forms.Label();
            this.grpBoxOptionals = new System.Windows.Forms.GroupBox();
            this.checkedListBoxOptionals = new System.Windows.Forms.CheckedListBox();
            this.grpBoxRequiredData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTankCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPassengerCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNoDoors)).BeginInit();
            this.grpBoxOptionals.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(105, 26);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(153, 20);
            this.labelTitle.TabIndex = 64;
            this.labelTitle.Text = "Vehicle Registration";
            // 
            // textLicensePlate
            // 
            this.textLicensePlate.Location = new System.Drawing.Point(97, 44);
            this.textLicensePlate.MaxLength = 7;
            this.textLicensePlate.Name = "textLicensePlate";
            this.textLicensePlate.Size = new System.Drawing.Size(217, 20);
            this.textLicensePlate.TabIndex = 1;
            // 
            // textChassis
            // 
            this.textChassis.Location = new System.Drawing.Point(97, 70);
            this.textChassis.Name = "textChassis";
            this.textChassis.Size = new System.Drawing.Size(217, 20);
            this.textChassis.TabIndex = 2;
            // 
            // textBrand
            // 
            this.textBrand.Location = new System.Drawing.Point(97, 96);
            this.textBrand.Name = "textBrand";
            this.textBrand.Size = new System.Drawing.Size(217, 20);
            this.textBrand.TabIndex = 3;
            // 
            // textModel
            // 
            this.textModel.Location = new System.Drawing.Point(97, 122);
            this.textModel.Name = "textModel";
            this.textModel.Size = new System.Drawing.Size(217, 20);
            this.textModel.TabIndex = 4;
            // 
            // textId
            // 
            this.textId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(97, 18);
            this.textId.Name = "textId";
            this.textId.ReadOnly = true;
            this.textId.Size = new System.Drawing.Size(217, 20);
            this.textId.TabIndex = 73;
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblGroup.ForeColor = System.Drawing.Color.Black;
            this.lblGroup.Location = new System.Drawing.Point(55, 177);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(36, 13);
            this.lblGroup.TabIndex = 72;
            this.lblGroup.Text = "Group";
            // 
            // lblImage
            // 
            this.lblImage.AutoSize = true;
            this.lblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblImage.ForeColor = System.Drawing.Color.Black;
            this.lblImage.Location = new System.Drawing.Point(47, 204);
            this.lblImage.Name = "lblImage";
            this.lblImage.Size = new System.Drawing.Size(39, 13);
            this.lblImage.TabIndex = 71;
            this.lblImage.Text = "Image";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblId.ForeColor = System.Drawing.Color.Black;
            this.lblId.Location = new System.Drawing.Point(75, 21);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 65;
            this.lblId.Text = "Id";
            // 
            // lblChassis
            // 
            this.lblChassis.AutoSize = true;
            this.lblChassis.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblChassis.ForeColor = System.Drawing.Color.Black;
            this.lblChassis.Location = new System.Drawing.Point(53, 73);
            this.lblChassis.Name = "lblChassis";
            this.lblChassis.Size = new System.Drawing.Size(43, 13);
            this.lblChassis.TabIndex = 67;
            this.lblChassis.Text = "Chassis";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBrand.ForeColor = System.Drawing.Color.Black;
            this.lblBrand.Location = new System.Drawing.Point(54, 99);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 68;
            this.lblBrand.Text = "Brand";
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblYear.ForeColor = System.Drawing.Color.Black;
            this.lblYear.Location = new System.Drawing.Point(65, 148);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 70;
            this.lblYear.Text = "Year";
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblModel.ForeColor = System.Drawing.Color.Black;
            this.lblModel.Location = new System.Drawing.Point(49, 125);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 69;
            this.lblModel.Text = "Model";
            // 
            // textColor
            // 
            this.textColor.Location = new System.Drawing.Point(195, 148);
            this.textColor.Name = "textColor";
            this.textColor.Size = new System.Drawing.Size(119, 20);
            this.textColor.TabIndex = 6;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblColor.ForeColor = System.Drawing.Color.Black;
            this.lblColor.Location = new System.Drawing.Point(166, 151);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(31, 13);
            this.lblColor.TabIndex = 81;
            this.lblColor.Text = "Color";
            // 
            // lblFuelType
            // 
            this.lblFuelType.AutoSize = true;
            this.lblFuelType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblFuelType.ForeColor = System.Drawing.Color.Black;
            this.lblFuelType.Location = new System.Drawing.Point(25, 256);
            this.lblFuelType.Name = "lblFuelType";
            this.lblFuelType.Size = new System.Drawing.Size(56, 13);
            this.lblFuelType.TabIndex = 81;
            this.lblFuelType.Text = "Fuel Type";
            // 
            // textMileage
            // 
            this.textMileage.Location = new System.Drawing.Point(195, 280);
            this.textMileage.Name = "textMileage";
            this.textMileage.Size = new System.Drawing.Size(119, 20);
            this.textMileage.TabIndex = 13;
            this.textMileage.Text = "0";
            this.textMileage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMileage_KeyPress);
            // 
            // lblPassengerCap
            // 
            this.lblPassengerCap.AutoSize = true;
            this.lblPassengerCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPassengerCap.ForeColor = System.Drawing.Color.Black;
            this.lblPassengerCap.Location = new System.Drawing.Point(29, 282);
            this.lblPassengerCap.Name = "lblPassengerCap";
            this.lblPassengerCap.Size = new System.Drawing.Size(62, 13);
            this.lblPassengerCap.TabIndex = 85;
            this.lblPassengerCap.Text = "Passengers";
            // 
            // lblNoDoors
            // 
            this.lblNoDoors.AutoSize = true;
            this.lblNoDoors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblNoDoors.ForeColor = System.Drawing.Color.Black;
            this.lblNoDoors.Location = new System.Drawing.Point(207, 256);
            this.lblNoDoors.Name = "lblNoDoors";
            this.lblNoDoors.Size = new System.Drawing.Size(52, 13);
            this.lblNoDoors.TabIndex = 84;
            this.lblNoDoors.Text = "No. Doors";
            // 
            // lblTankCapacity
            // 
            this.lblTankCapacity.AutoSize = true;
            this.lblTankCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTankCapacity.ForeColor = System.Drawing.Color.Black;
            this.lblTankCapacity.Location = new System.Drawing.Point(22, 230);
            this.lblTankCapacity.Name = "lblTankCapacity";
            this.lblTankCapacity.Size = new System.Drawing.Size(78, 13);
            this.lblTankCapacity.TabIndex = 83;
            this.lblTankCapacity.Text = "Tank Capacity";
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblMileage.ForeColor = System.Drawing.Color.Black;
            this.lblMileage.Location = new System.Drawing.Point(166, 283);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(45, 13);
            this.lblMileage.TabIndex = 82;
            this.lblMileage.Text = "Mileage";
            // 
            // lblTrunkSize
            // 
            this.lblTrunkSize.AutoSize = true;
            this.lblTrunkSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTrunkSize.ForeColor = System.Drawing.Color.Black;
            this.lblTrunkSize.Location = new System.Drawing.Point(168, 230);
            this.lblTrunkSize.Name = "lblTrunkSize";
            this.lblTrunkSize.Size = new System.Drawing.Size(61, 13);
            this.lblTrunkSize.TabIndex = 91;
            this.lblTrunkSize.Text = "Trunk Size";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancel.Location = new System.Drawing.Point(305, 574);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirm.Location = new System.Drawing.Point(224, 574);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 16;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // grpBoxRequiredData
            // 
            this.grpBoxRequiredData.Controls.Add(this.btnImage);
            this.grpBoxRequiredData.Controls.Add(this.cBoxFuelType);
            this.grpBoxRequiredData.Controls.Add(this.textYear);
            this.grpBoxRequiredData.Controls.Add(this.numUpDownTankCapacity);
            this.grpBoxRequiredData.Controls.Add(this.cBoxTrunkSize);
            this.grpBoxRequiredData.Controls.Add(this.lblTankCapacity);
            this.grpBoxRequiredData.Controls.Add(this.numUpDownPassengerCap);
            this.grpBoxRequiredData.Controls.Add(this.numUpDownNoDoors);
            this.grpBoxRequiredData.Controls.Add(this.lblFuelType);
            this.grpBoxRequiredData.Controls.Add(this.lblTrunkSize);
            this.grpBoxRequiredData.Controls.Add(this.cBoxGroup);
            this.grpBoxRequiredData.Controls.Add(this.lblChassis);
            this.grpBoxRequiredData.Controls.Add(this.lblPassengerCap);
            this.grpBoxRequiredData.Controls.Add(this.lblNoDoors);
            this.grpBoxRequiredData.Controls.Add(this.lblMileage);
            this.grpBoxRequiredData.Controls.Add(this.textColor);
            this.grpBoxRequiredData.Controls.Add(this.lblLicensePlate);
            this.grpBoxRequiredData.Controls.Add(this.textMileage);
            this.grpBoxRequiredData.Controls.Add(this.lblColor);
            this.grpBoxRequiredData.Controls.Add(this.lblImage);
            this.grpBoxRequiredData.Controls.Add(this.lblId);
            this.grpBoxRequiredData.Controls.Add(this.textModel);
            this.grpBoxRequiredData.Controls.Add(this.textLicensePlate);
            this.grpBoxRequiredData.Controls.Add(this.lblBrand);
            this.grpBoxRequiredData.Controls.Add(this.lblModel);
            this.grpBoxRequiredData.Controls.Add(this.lblGroup);
            this.grpBoxRequiredData.Controls.Add(this.textChassis);
            this.grpBoxRequiredData.Controls.Add(this.textBrand);
            this.grpBoxRequiredData.Controls.Add(this.textId);
            this.grpBoxRequiredData.Controls.Add(this.lblYear);
            this.grpBoxRequiredData.ForeColor = System.Drawing.Color.Black;
            this.grpBoxRequiredData.Location = new System.Drawing.Point(12, 72);
            this.grpBoxRequiredData.Name = "grpBoxRequiredData";
            this.grpBoxRequiredData.Size = new System.Drawing.Size(367, 318);
            this.grpBoxRequiredData.TabIndex = 94;
            this.grpBoxRequiredData.TabStop = false;
            this.grpBoxRequiredData.Text = "Required Data";
            // 
            // btnImage
            // 
            this.btnImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnImage.Location = new System.Drawing.Point(97, 199);
            this.btnImage.Name = "btnImage";
            this.btnImage.Size = new System.Drawing.Size(216, 23);
            this.btnImage.TabIndex = 8;
            this.btnImage.Text = "Insert Image";
            this.btnImage.UseVisualStyleBackColor = true;
            this.btnImage.Click += new System.EventHandler(this.btnImage_Click);
            // 
            // cBoxFuelType
            // 
            this.cBoxFuelType.FormattingEnabled = true;
            this.cBoxFuelType.ItemHeight = 13;
            this.cBoxFuelType.Items.AddRange(new object[] {
            "Gasoline",
            "Ethanol",
            "Flex (Gasoline and Ethanol)",
            "Diesel"});
            this.cBoxFuelType.Location = new System.Drawing.Point(97, 253);
            this.cBoxFuelType.Name = "cBoxFuelType";
            this.cBoxFuelType.Size = new System.Drawing.Size(92, 21);
            this.cBoxFuelType.TabIndex = 10;
            this.cBoxFuelType.Text = "Select";
            // 
            // textYear
            // 
            this.textYear.Location = new System.Drawing.Point(97, 148);
            this.textYear.MaxLength = 4;
            this.textYear.Name = "textYear";
            this.textYear.Size = new System.Drawing.Size(51, 20);
            this.textYear.TabIndex = 5;
            this.textYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textYear_KeyPress);
            // 
            // numUpDownTankCapacity
            // 
            this.numUpDownTankCapacity.Location = new System.Drawing.Point(97, 227);
            this.numUpDownTankCapacity.Name = "numUpDownTankCapacity";
            this.numUpDownTankCapacity.Size = new System.Drawing.Size(51, 20);
            this.numUpDownTankCapacity.TabIndex = 9;
            // 
            // cBoxTrunkSize
            // 
            this.cBoxTrunkSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxTrunkSize.FormattingEnabled = true;
            this.cBoxTrunkSize.Items.AddRange(new object[] {
            "Large",
            "Medium",
            "Small"});
            this.cBoxTrunkSize.Location = new System.Drawing.Point(264, 227);
            this.cBoxTrunkSize.Name = "cBoxTrunkSize";
            this.cBoxTrunkSize.Size = new System.Drawing.Size(49, 21);
            this.cBoxTrunkSize.TabIndex = 14;
            // 
            // numUpDownPassengerCap
            // 
            this.numUpDownPassengerCap.Location = new System.Drawing.Point(97, 280);
            this.numUpDownPassengerCap.Name = "numUpDownPassengerCap";
            this.numUpDownPassengerCap.Size = new System.Drawing.Size(48, 20);
            this.numUpDownPassengerCap.TabIndex = 12;
            // 
            // numUpDownNoDoors
            // 
            this.numUpDownNoDoors.Location = new System.Drawing.Point(265, 254);
            this.numUpDownNoDoors.Name = "numUpDownNoDoors";
            this.numUpDownNoDoors.Size = new System.Drawing.Size(48, 20);
            this.numUpDownNoDoors.TabIndex = 11;
            // 
            // cBoxGroup
            // 
            this.cBoxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxGroup.FormattingEnabled = true;
            this.cBoxGroup.Location = new System.Drawing.Point(97, 174);
            this.cBoxGroup.Name = "cBoxGroup";
            this.cBoxGroup.Size = new System.Drawing.Size(217, 21);
            this.cBoxGroup.TabIndex = 7;
            // 
            // lblLicensePlate
            // 
            this.lblLicensePlate.AutoSize = true;
            this.lblLicensePlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblLicensePlate.ForeColor = System.Drawing.Color.Black;
            this.lblLicensePlate.Location = new System.Drawing.Point(57, 47);
            this.lblLicensePlate.Name = "lblLicensePlate";
            this.lblLicensePlate.Size = new System.Drawing.Size(74, 13);
            this.lblLicensePlate.TabIndex = 66;
            this.lblLicensePlate.Text = "License Plate";
            // 
            // grpBoxOptionals
            // 
            this.grpBoxOptionals.Controls.Add(this.checkedListBoxOptionals);
            this.grpBoxOptionals.ForeColor = System.Drawing.Color.Black;
            this.grpBoxOptionals.Location = new System.Drawing.Point(12, 409);
            this.grpBoxOptionals.Name = "grpBoxOptionals";
            this.grpBoxOptionals.Size = new System.Drawing.Size(367, 159);
            this.grpBoxOptionals.TabIndex = 95;
            this.grpBoxOptionals.TabStop = false;
            this.grpBoxOptionals.Text = "Optionals";
            // 
            // checkedListBoxOptionals
            // 
            this.checkedListBoxOptionals.FormattingEnabled = true;
            this.checkedListBoxOptionals.Items.AddRange(new object[] {
            "Air Conditioning",
            "Power Steering",
            "ABS Brakes"});
            this.checkedListBoxOptionals.Location = new System.Drawing.Point(6, 19);
            this.checkedListBoxOptionals.Name = "checkedListBoxOptionals";
            this.checkedListBoxOptionals.Size = new System.Drawing.Size(355, 124);
            this.checkedListBoxOptionals.TabIndex = 15;
            // 
            // VehicleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(392, 609);
            this.Controls.Add(this.grpBoxOptionals);
            this.Controls.Add(this.grpBoxRequiredData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VehicleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Rental";
            this.grpBoxRequiredData.ResumeLayout(false);
            this.grpBoxRequiredData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownTankCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownPassengerCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNoDoors)).EndInit();
            this.grpBoxOptionals.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textLicensePlate;
        private System.Windows.Forms.TextBox textChassis;
        private System.Windows.Forms.TextBox textBrand;
        private System.Windows.Forms.TextBox textModel;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblImage;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblChassis;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox textColor;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblFuelType;
        private System.Windows.Forms.TextBox textMileage;
        private System.Windows.Forms.Label lblPassengerCap;
        private System.Windows.Forms.Label lblNoDoors;
        private System.Windows.Forms.Label lblTankCapacity;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblTrunkSize;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox grpBoxRequiredData;
        private System.Windows.Forms.ComboBox cBoxGroup;
        private System.Windows.Forms.NumericUpDown numUpDownTankCapacity;
        private System.Windows.Forms.ComboBox cBoxTrunkSize;
        private System.Windows.Forms.NumericUpDown numUpDownPassengerCap;
        private System.Windows.Forms.NumericUpDown numUpDownNoDoors;
        private System.Windows.Forms.GroupBox grpBoxOptionals;
        private System.Windows.Forms.CheckedListBox checkedListBoxOptionals;
        private System.Windows.Forms.TextBox textYear;
        private System.Windows.Forms.ComboBox cBoxFuelType;
        private System.Windows.Forms.Label lblLicensePlate;
        private System.Windows.Forms.Button btnImage;
    }
}
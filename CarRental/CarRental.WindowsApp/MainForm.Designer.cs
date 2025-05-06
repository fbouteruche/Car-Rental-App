namespace CarRental.WindowsApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelTitle = new System.Windows.Forms.Label();
            this.recordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rentalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxActions = new System.Windows.Forms.ToolStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEdit = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.labelRecordType = new System.Windows.Forms.ToolStripLabel();
            this.recordsPanel = new System.Windows.Forms.Panel();
            this.statusStripFooter = new System.Windows.Forms.StatusStrip();
            this.labelFooter = new System.Windows.Forms.ToolStripStatusLabel();
            this.discountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.couponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.partnersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.toolBoxActions.SuspendLayout();
            this.statusStripFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.Black;
            this.labelTitle.Location = new System.Drawing.Point(309, 3);
            this.labelTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(98, 20);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "Car Rental";
            // 
            // recordsToolStripMenuItem
            // 
            this.recordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesToolStripMenuItem,
            this.customersToolStripMenuItem,
            this.servicesToolStripMenuItem,
            this.vehiclesToolStripMenuItem,
            this.vehicleGroupsToolStripMenuItem});
            this.recordsToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.recordsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            this.recordsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.recordsToolStripMenuItem.Text = "Records";
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.employeesToolStripMenuItem.Text = "Employees";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // customersToolStripMenuItem
            // 
            this.customersToolStripMenuItem.Name = "customersToolStripMenuItem";
            this.customersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customersToolStripMenuItem.Text = "Customers";
            this.customersToolStripMenuItem.Click += new System.EventHandler(this.customersToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.servicesToolStripMenuItem.Text = "Services";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // vehiclesToolStripMenuItem
            // 
            this.vehiclesToolStripMenuItem.Name = "vehiclesToolStripMenuItem";
            this.vehiclesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vehiclesToolStripMenuItem.Text = "Vehicles";
            this.vehiclesToolStripMenuItem.Click += new System.EventHandler(this.vehiclesToolStripMenuItem_Click);
            // 
            // vehicleGroupsToolStripMenuItem
            // 
            this.vehicleGroupsToolStripMenuItem.Name = "vehicleGroupsToolStripMenuItem";
            this.vehicleGroupsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.vehicleGroupsToolStripMenuItem.Text = "Vehicle Groups";
            this.vehicleGroupsToolStripMenuItem.Click += new System.EventHandler(this.vehicleGroupsToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.recordsToolStripMenuItem,
            this.rentalToolStripMenuItem,
            this.discountsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(795, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // rentalToolStripMenuItem
            // 
            this.rentalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rentalsToolStripMenuItem,
            this.returnsToolStripMenuItem});
            this.rentalToolStripMenuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.rentalToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.rentalToolStripMenuItem.Name = "rentalToolStripMenuItem";
            this.rentalToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.rentalToolStripMenuItem.Text = "Rental";
            // 
            // rentalsToolStripMenuItem
            // 
            this.rentalsToolStripMenuItem.Name = "rentalsToolStripMenuItem";
            this.rentalsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.rentalsToolStripMenuItem.Text = "Rentals";
            this.rentalsToolStripMenuItem.Click += new System.EventHandler(this.rentalsToolStripMenuItem_Click);
            // 
            // returnsToolStripMenuItem
            // 
            this.returnsToolStripMenuItem.Name = "returnsToolStripMenuItem";
            this.returnsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.returnsToolStripMenuItem.Text = "Returns";
            this.returnsToolStripMenuItem.Click += new System.EventHandler(this.returnsToolStripMenuItem_Click);
            // 
            // toolBoxActions
            // 
            this.toolBoxActions.AutoSize = false;
            this.toolBoxActions.BackColor = System.Drawing.SystemColors.Control;
            this.toolBoxActions.Enabled = false;
            this.toolBoxActions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolBoxActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete,
            this.btnFilter,
            this.toolStripSeparator,
            this.labelRecordType});
            this.toolBoxActions.Location = new System.Drawing.Point(0, 24);
            this.toolBoxActions.Name = "toolBoxActions";
            this.toolBoxActions.Size = new System.Drawing.Size(795, 45);
            this.toolBoxActions.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdd.Image = global::CarRental.WindowsApp.Properties.Resources._36x1;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(40, 42);
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(40, 42);
            this.btnEdit.Text = "Edit";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(40, 42);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFilter.Image = global::CarRental.WindowsApp.Properties.Resources.outline_filter_alt_black_36dp;
            this.btnFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(40, 42);
            this.btnFilter.Text = "Filter";
            this.btnFilter.ToolTipText = "Filter element";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 45);
            // 
            // labelRecordType
            // 
            this.labelRecordType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelRecordType.Name = "labelRecordType";
            this.labelRecordType.Size = new System.Drawing.Size(157, 42);
            this.labelRecordType.Text = "Selected Record: None";
            // 
            // recordsPanel
            // 
            this.recordsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsPanel.Location = new System.Drawing.Point(0, 70);
            this.recordsPanel.Margin = new System.Windows.Forms.Padding(2);
            this.recordsPanel.Name = "recordsPanel";
            this.recordsPanel.Size = new System.Drawing.Size(795, 491);
            this.recordsPanel.TabIndex = 6;
            // 
            // statusStripFooter
            // 
            this.statusStripFooter.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStripFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelFooter});
            this.statusStripFooter.Location = new System.Drawing.Point(0, 563);
            this.statusStripFooter.Name = "statusStripFooter";
            this.statusStripFooter.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStripFooter.Size = new System.Drawing.Size(795, 22);
            this.statusStripFooter.TabIndex = 7;
            this.statusStripFooter.Text = "statusStrip";
            // 
            // labelFooter
            // 
            this.labelFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(73, 17);
            this.labelFooter.Text = "All good :D";
            // 
            // discountsToolStripMenuItem
            // 
            this.discountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.couponsToolStripMenuItem,
            this.partnersToolStripMenuItem});
            this.discountsToolStripMenuItem.Name = "discountsToolStripMenuItem";
            this.discountsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.discountsToolStripMenuItem.Text = "Discounts";
            // 
            // couponsToolStripMenuItem
            // 
            this.couponsToolStripMenuItem.Name = "couponsToolStripMenuItem";
            this.couponsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.couponsToolStripMenuItem.Text = "Coupons";
            this.couponsToolStripMenuItem.Click += new System.EventHandler(this.couponsToolStripMenuItem_Click);
            // 
            // partnersToolStripMenuItem
            // 
            this.partnersToolStripMenuItem.Name = "partnersToolStripMenuItem";
            this.partnersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.partnersToolStripMenuItem.Text = "Partners";
            this.partnersToolStripMenuItem.Click += new System.EventHandler(this.partnersToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(795, 585);
            this.Controls.Add(this.statusStripFooter);
            this.Controls.Add(this.recordsPanel);
            this.Controls.Add(this.toolBoxActions);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Car Rental";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolBoxActions.ResumeLayout(false);
            this.toolBoxActions.PerformLayout();
            this.statusStripFooter.ResumeLayout(false);
            this.statusStripFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.ToolStripMenuItem recordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customersToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolBoxActions;
        private System.Windows.Forms.ToolStripButton btnAdd;
        private System.Windows.Forms.ToolStripButton btnEdit;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripMenuItem rentalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleGroupsToolStripMenuItem;
        private System.Windows.Forms.Panel recordsPanel;
        private System.Windows.Forms.StatusStrip statusStripFooter;
        private System.Windows.Forms.ToolStripStatusLabel labelFooter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripLabel labelRecordType;
        private System.Windows.Forms.ToolStripMenuItem rentalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discountsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem couponsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem partnersToolStripMenuItem;
    }
}


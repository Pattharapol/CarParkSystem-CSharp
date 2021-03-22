namespace CarParkSystem
{
    partial class HomeForm
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
            this.components = new System.ComponentModel.Container();
            this.hometoolstrip = new System.Windows.Forms.ToolStrip();
            this.tsbtnDriverType = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAllVehicle = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsbtnCheckIn = new System.Windows.Forms.ToolStripButton();
            this.tsbtnCheckOut = new System.Windows.Forms.ToolStripButton();
            this.tsbtnHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.panelParent = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.hometoolstrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // hometoolstrip
            // 
            this.hometoolstrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.hometoolstrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.hometoolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnDriverType,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripButton2,
            this.tsbtnAllVehicle,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.tsbtnCheckIn,
            this.tsbtnCheckOut,
            this.tsbtnHistory,
            this.toolStripLabel2,
            this.toolStripButton3});
            this.hometoolstrip.Location = new System.Drawing.Point(0, 0);
            this.hometoolstrip.Name = "hometoolstrip";
            this.hometoolstrip.Size = new System.Drawing.Size(139, 844);
            this.hometoolstrip.TabIndex = 0;
            this.hometoolstrip.Text = "toolStrip1";
            // 
            // tsbtnDriverType
            // 
            this.tsbtnDriverType.Image = global::CarParkSystem.Properties.Resources.png_clipart_human_illustration_computer_icons_driving_chauffeur_icon_library_bus_driver_miscellaneous_logo_thumbnail;
            this.tsbtnDriverType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDriverType.Name = "tsbtnDriverType";
            this.tsbtnDriverType.Size = new System.Drawing.Size(136, 56);
            this.tsbtnDriverType.Text = "Driver Type";
            this.tsbtnDriverType.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDriverType.Click += new System.EventHandler(this.TsbtnDriverType_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::CarParkSystem.Properties.Resources.images;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(136, 56);
            this.toolStripButton1.Text = "AutoCar Type";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(126, 28);
            this.toolStripLabel1.Text = "Registration";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::CarParkSystem.Properties.Resources.png_clipart_computer_icons_share_icon_register_icon_black_silhouette;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(136, 56);
            this.toolStripButton2.Text = "Registration";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // tsbtnAllVehicle
            // 
            this.tsbtnAllVehicle.Image = global::CarParkSystem.Properties.Resources.images2;
            this.tsbtnAllVehicle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAllVehicle.Name = "tsbtnAllVehicle";
            this.tsbtnAllVehicle.Size = new System.Drawing.Size(136, 56);
            this.tsbtnAllVehicle.Text = "All Vehicle";
            this.tsbtnAllVehicle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnAllVehicle.Click += new System.EventHandler(this.TsbtnAllVehicle_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(136, 6);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(126, 28);
            this.toolStripLabel3.Text = "Parking";
            // 
            // tsbtnCheckIn
            // 
            this.tsbtnCheckIn.Image = global::CarParkSystem.Properties.Resources._38_384151_clipart_resolution_980912_online_check_in_icon_png;
            this.tsbtnCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheckIn.Name = "tsbtnCheckIn";
            this.tsbtnCheckIn.Size = new System.Drawing.Size(136, 56);
            this.tsbtnCheckIn.Text = "Check In";
            this.tsbtnCheckIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCheckIn.Click += new System.EventHandler(this.TsbtnCheckIn_Click);
            // 
            // tsbtnCheckOut
            // 
            this.tsbtnCheckOut.Image = global::CarParkSystem.Properties.Resources.check_out_512;
            this.tsbtnCheckOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCheckOut.Name = "tsbtnCheckOut";
            this.tsbtnCheckOut.Size = new System.Drawing.Size(136, 56);
            this.tsbtnCheckOut.Text = "Check Out";
            this.tsbtnCheckOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnCheckOut.Click += new System.EventHandler(this.TsbtnCheckOut_Click);
            // 
            // tsbtnHistory
            // 
            this.tsbtnHistory.Image = global::CarParkSystem.Properties.Resources._301_3019347_purchase_history_icon_transaction_history_icon_png;
            this.tsbtnHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnHistory.Name = "tsbtnHistory";
            this.tsbtnHistory.Size = new System.Drawing.Size(136, 56);
            this.tsbtnHistory.Text = "Parking History";
            this.tsbtnHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnHistory.Click += new System.EventHandler(this.TsbtnHistory_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(126, 28);
            this.toolStripLabel2.Text = "SMS Setting";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::CarParkSystem.Properties.Resources._301_3019347_purchase_history_icon_transaction_history_icon_png;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(136, 56);
            this.toolStripButton3.Text = "GSM Connection";
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton3.Click += new System.EventHandler(this.ToolStripButton3_Click);
            // 
            // panelParent
            // 
            this.panelParent.BackgroundImage = global::CarParkSystem.Properties.Resources.bg;
            this.panelParent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelParent.Location = new System.Drawing.Point(139, 0);
            this.panelParent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelParent.Name = "panelParent";
            this.panelParent.Size = new System.Drawing.Size(1654, 844);
            this.panelParent.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1793, 844);
            this.Controls.Add(this.panelParent);
            this.Controls.Add(this.hometoolstrip);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auto Car Parking System";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.hometoolstrip.ResumeLayout(false);
            this.hometoolstrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripButton tsbtnAllVehicle;
        private System.Windows.Forms.Panel panelParent;
        private System.Windows.Forms.ToolStripButton tsbtnDriverType;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripButton tsbtnCheckIn;
        private System.Windows.Forms.ToolStripButton tsbtnCheckOut;
        private System.Windows.Forms.ToolStripButton tsbtnHistory;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStrip hometoolstrip;
    }
}


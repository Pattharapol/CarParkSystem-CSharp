namespace CarParkSystem.Forms.ParkingForm
{
    partial class frmAllVehicle
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
            this.dgvAllVehicle = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllVehicle)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAllVehicle
            // 
            this.dgvAllVehicle.AllowUserToAddRows = false;
            this.dgvAllVehicle.AllowUserToDeleteRows = false;
            this.dgvAllVehicle.AllowUserToResizeColumns = false;
            this.dgvAllVehicle.AllowUserToResizeRows = false;
            this.dgvAllVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAllVehicle.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAllVehicle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllVehicle.Location = new System.Drawing.Point(8, 34);
            this.dgvAllVehicle.MultiSelect = false;
            this.dgvAllVehicle.Name = "dgvAllVehicle";
            this.dgvAllVehicle.ReadOnly = true;
            this.dgvAllVehicle.RowHeadersVisible = false;
            this.dgvAllVehicle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllVehicle.Size = new System.Drawing.Size(984, 548);
            this.dgvAllVehicle.TabIndex = 12;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(63, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(410, 20);
            this.txtSearch.TabIndex = 11;
            this.txtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Search : ";
            // 
            // frmAllVehicle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 594);
            this.Controls.Add(this.dgvAllVehicle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label3);
            this.Name = "frmAllVehicle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Vehicle";
            this.Load += new System.EventHandler(this.FrmAllVehicle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllVehicle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAllVehicle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
    }
}
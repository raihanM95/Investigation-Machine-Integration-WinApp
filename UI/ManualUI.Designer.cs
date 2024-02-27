namespace MachineIntegrationWinApp.UI
{
    partial class ManualUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnMicrosES60Analyzer = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHospitalSync = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnMicrosES60Analyzer);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 63);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Machines";
            // 
            // BtnMicrosES60Analyzer
            // 
            this.BtnMicrosES60Analyzer.Location = new System.Drawing.Point(7, 19);
            this.BtnMicrosES60Analyzer.Name = "BtnMicrosES60Analyzer";
            this.BtnMicrosES60Analyzer.Size = new System.Drawing.Size(508, 37);
            this.BtnMicrosES60Analyzer.TabIndex = 0;
            this.BtnMicrosES60Analyzer.Text = "Micros ES 60 Analyzer";
            this.BtnMicrosES60Analyzer.UseVisualStyleBackColor = true;
            this.BtnMicrosES60Analyzer.Click += new System.EventHandler(this.BtnMicrosES60Analyzer_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 82);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(522, 243);
            this.dataGridView.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHospitalSync);
            this.groupBox2.Location = new System.Drawing.Point(13, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(521, 63);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hospital";
            // 
            // btnHospitalSync
            // 
            this.btnHospitalSync.Location = new System.Drawing.Point(7, 19);
            this.btnHospitalSync.Name = "btnHospitalSync";
            this.btnHospitalSync.Size = new System.Drawing.Size(508, 37);
            this.btnHospitalSync.TabIndex = 0;
            this.btnHospitalSync.Text = "Sync";
            this.btnHospitalSync.UseVisualStyleBackColor = true;
            this.btnHospitalSync.Click += new System.EventHandler(this.btnHospitalSync_Click);
            // 
            // ManualUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 404);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ManualUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manually";
            this.Load += new System.EventHandler(this.ManualUI_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnMicrosES60Analyzer;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnHospitalSync;
    }
}
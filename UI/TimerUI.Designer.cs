namespace MachineIntegrationWinApp.UI
{
    partial class TimerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimerUI));
            this.timerMicrosES60Analyzer = new System.Windows.Forms.Timer(this.components);
            this.timerMachineHospital = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timerMicrosES60Analyzer
            // 
            this.timerMicrosES60Analyzer.Interval = 20000;
            this.timerMicrosES60Analyzer.Tick += new System.EventHandler(this.timerMicrosES60Analyzer_Tick);
            // 
            // timerMachineHospital
            // 
            this.timerMachineHospital.Interval = 20000;
            this.timerMachineHospital.Tick += new System.EventHandler(this.timerMachineHospital_Tick);
            // 
            // TimerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 184);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TimerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Timer";
            this.Load += new System.EventHandler(this.TimerUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerMicrosES60Analyzer;
        private System.Windows.Forms.Timer timerMachineHospital;
    }
}
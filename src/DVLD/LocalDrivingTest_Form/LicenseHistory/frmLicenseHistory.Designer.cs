namespace DVLD.LocalDrivingTest_Form.LicenseHistory
{
    partial class frmLicenseHistory
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
            this.ctrlLicenseHistory1 = new DVLD.ControlApplicationsTest_LocalDriving.LicenseHistory.ctrlLicenseHistory();
            this.SuspendLayout();
            // 
            // ctrlLicenseHistory1
            // 
            this.ctrlLicenseHistory1.Location = new System.Drawing.Point(-1, 0);
            this.ctrlLicenseHistory1.Name = "ctrlLicenseHistory1";
            this.ctrlLicenseHistory1.Size = new System.Drawing.Size(2527, 1626);
            this.ctrlLicenseHistory1.TabIndex = 0;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(2530, 1631);
            this.Controls.Add(this.ctrlLicenseHistory1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmLicenseHistory";
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest_LocalDriving.LicenseHistory.ctrlLicenseHistory ctrlLicenseHistory1;
    }
}
namespace DVLD.LocalDrivingTest_Form.DriverLicenseInfo
{
    partial class FrmDriverLicenseInfo
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
            this.ctrlDriverLicenseInfo1 = new DVLD.ControlApplicationsTest_LocalDriving.ShowLicense.ctrlDriverLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrlDriverLicenseInfo1
            // 
            this.ctrlDriverLicenseInfo1.Location = new System.Drawing.Point(1, 4);
            this.ctrlDriverLicenseInfo1.Name = "ctrlDriverLicenseInfo1";
            this.ctrlDriverLicenseInfo1.Size = new System.Drawing.Size(2065, 1284);
            this.ctrlDriverLicenseInfo1.TabIndex = 0;
            // 
            // FrmDriverLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2069, 1291);
            this.Controls.Add(this.ctrlDriverLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmDriverLicenseInfo";
            this.Text = "Driver License Info";
            this.Load += new System.EventHandler(this.FrmDriverLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest_LocalDriving.ShowLicense.ctrlDriverLicenseInfo ctrlDriverLicenseInfo1;
    }
}
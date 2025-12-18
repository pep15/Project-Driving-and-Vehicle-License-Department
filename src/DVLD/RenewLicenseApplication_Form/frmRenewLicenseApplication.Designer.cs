namespace DVLD.RenewLicenseApplication_Form
{
    partial class frmRenewLicenseApplication
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
            this.ctrlRenewLicenseApplication1 = new DVLD.RenewLicenseApplication.ctrlRenewLicenseApplication();
            this.SuspendLayout();
            // 
            // ctrlRenewLicenseApplication1
            // 
            this.ctrlRenewLicenseApplication1.Location = new System.Drawing.Point(3, -1);
            this.ctrlRenewLicenseApplication1.Name = "ctrlRenewLicenseApplication1";
            this.ctrlRenewLicenseApplication1.Size = new System.Drawing.Size(2124, 1755);
            this.ctrlRenewLicenseApplication1.TabIndex = 0;
            // 
            // frmRenewLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2133, 1757);
            this.Controls.Add(this.ctrlRenewLicenseApplication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmRenewLicenseApplication";
            this.Text = "Renew License Application";
            this.ResumeLayout(false);

        }

        #endregion

        private RenewLicenseApplication.ctrlRenewLicenseApplication ctrlRenewLicenseApplication1;
    }
}
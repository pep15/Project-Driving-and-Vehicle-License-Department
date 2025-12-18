namespace DVLD.InternationalLicenseApplication_Form
{
    partial class frmInternationLicenseApplication
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
            this.ctrlShowInternationLicenseApplication1 = new DVLD.InternationalLicenseApplication_Control.ctrlShowInternationLicenseApplication();
            this.SuspendLayout();
            // 
            // ctrlShowInternationLicenseApplication1
            // 
            this.ctrlShowInternationLicenseApplication1.Location = new System.Drawing.Point(1, 1);
            this.ctrlShowInternationLicenseApplication1.Name = "ctrlShowInternationLicenseApplication1";
            this.ctrlShowInternationLicenseApplication1.Size = new System.Drawing.Size(2037, 1184);
            this.ctrlShowInternationLicenseApplication1.TabIndex = 0;
            // 
            // frmInternationLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2039, 1189);
            this.Controls.Add(this.ctrlShowInternationLicenseApplication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInternationLicenseApplication";
            this.Text = "Internation License Application";
            this.Load += new System.EventHandler(this.frmInternationLicenseApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicenseApplication_Control.ctrlShowInternationLicenseApplication ctrlShowInternationLicenseApplication1;
    }
}
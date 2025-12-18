namespace DVLD.InternationalLicenseApplication_Form
{
    partial class frmInternationlLicenseApplication
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
            this.ctrlInternationalLicense1 = new DVLD.InternationalLicenseApplication_Control.ctrlInternationalLicense();
            this.SuspendLayout();
            // 
            // ctrlInternationalLicense1
            // 
            this.ctrlInternationalLicense1.Location = new System.Drawing.Point(1, 0);
            this.ctrlInternationalLicense1.Name = "ctrlInternationalLicense1";
            this.ctrlInternationalLicense1.Size = new System.Drawing.Size(2047, 1495);
            this.ctrlInternationalLicense1.TabIndex = 0;
            // 
            // frmInternationlLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2055, 1497);
            this.Controls.Add(this.ctrlInternationalLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmInternationlLicenseApplication";
            this.Text = "Internationl License Applications";
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicenseApplication_Control.ctrlInternationalLicense ctrlInternationalLicense1;
    }
}
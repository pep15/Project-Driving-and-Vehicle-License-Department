namespace DVLD.InternationalLicenseApplication_Form
{
    partial class FrmInternationlLicenseList
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
            this.ctrlInternationalLicenseApplications1 = new DVLD.InternationalLicenseApplication_Control.ctrlInternationalLicenseApplications();
            this.SuspendLayout();
            // 
            // ctrlInternationalLicenseApplications1
            // 
            this.ctrlInternationalLicenseApplications1.Location = new System.Drawing.Point(2, -3);
            this.ctrlInternationalLicenseApplications1.Name = "ctrlInternationalLicenseApplications1";
            this.ctrlInternationalLicenseApplications1.Size = new System.Drawing.Size(2347, 1267);
            this.ctrlInternationalLicenseApplications1.TabIndex = 0;
            // 
            // FrmInternationlLicenseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2347, 1270);
            this.Controls.Add(this.ctrlInternationalLicenseApplications1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmInternationlLicenseList";
            this.Text = "Internationl License List";
            this.Load += new System.EventHandler(this.FrmInternationlLicenseList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private InternationalLicenseApplication_Control.ctrlInternationalLicenseApplications ctrlInternationalLicenseApplications1;
    }
}
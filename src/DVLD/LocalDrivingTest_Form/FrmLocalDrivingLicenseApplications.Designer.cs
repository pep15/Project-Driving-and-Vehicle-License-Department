namespace DVLD.LocalDriving_Form
{
    partial class FrmLocalDrivingLicenseApplications
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
            this.ctrlLocalDrivingLicenseApllication1 = new DVLD.Control_LocalDriving.ctrlLocalDrivingLicenseApllication();
            this.SuspendLayout();
            // 
            // ctrlLocalDrivingLicenseApllication1
            // 
            this.ctrlLocalDrivingLicenseApllication1.Location = new System.Drawing.Point(-2, 3);
            this.ctrlLocalDrivingLicenseApllication1.Name = "ctrlLocalDrivingLicenseApllication1";
            this.ctrlLocalDrivingLicenseApllication1.Size = new System.Drawing.Size(2309, 1163);
            this.ctrlLocalDrivingLicenseApllication1.TabIndex = 0;
            // 
            // FrmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2303, 1175);
            this.Controls.Add(this.ctrlLocalDrivingLicenseApllication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmLocalDrivingLicenseApplications";
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.FrmLocalDrivingLicenseApplications_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_LocalDriving.ctrlLocalDrivingLicenseApllication ctrlLocalDrivingLicenseApllication1;
    }
}
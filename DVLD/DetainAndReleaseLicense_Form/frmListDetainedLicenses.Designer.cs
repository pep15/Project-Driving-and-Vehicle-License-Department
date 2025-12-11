namespace DVLD.RenewLicenseApplication_From
{
    partial class frmListDetainedLicenses
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
            this.ctrlmanageDetainedandReleaseLicenses1 = new DVLD.DetainAndReleaseLicense_Control.ctrlmanageDetainedandReleaseLicenses();
            this.SuspendLayout();
            // 
            // ctrlmanageDetainedandReleaseLicenses1
            // 
            this.ctrlmanageDetainedandReleaseLicenses1.Location = new System.Drawing.Point(2, 2);
            this.ctrlmanageDetainedandReleaseLicenses1.Name = "ctrlmanageDetainedandReleaseLicenses1";
            this.ctrlmanageDetainedandReleaseLicenses1.Size = new System.Drawing.Size(2303, 1124);
            this.ctrlmanageDetainedandReleaseLicenses1.TabIndex = 0;
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2313, 1136);
            this.Controls.Add(this.ctrlmanageDetainedandReleaseLicenses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.Text = "List Detained Licenses";
            this.ResumeLayout(false);

        }

        #endregion

        private DetainAndReleaseLicense_Control.ctrlmanageDetainedandReleaseLicenses ctrlmanageDetainedandReleaseLicenses1;
    }
}
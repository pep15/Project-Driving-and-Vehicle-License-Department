namespace DVLD.LocalDriving_Form
{
    partial class FrmNewLocalDrivingLicenseApplication
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
            this.ctrlLocalDeriving1 = new DVLD.Control_LocalDriving.ctrlLocalDeriving();
            this.SuspendLayout();
            // 
            // ctrlLocalDeriving1
            // 
            this.ctrlLocalDeriving1.Location = new System.Drawing.Point(12, 12);
            this.ctrlLocalDeriving1.Name = "ctrlLocalDeriving1";
            this.ctrlLocalDeriving1.Size = new System.Drawing.Size(2035, 1465);
            this.ctrlLocalDeriving1.TabIndex = 0;
            // 
            // FrmNewLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2061, 1489);
            this.Controls.Add(this.ctrlLocalDeriving1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmNewLocalDrivingLicenseApplication";
            this.Text = "New Local Driving License Application";
            this.Load += new System.EventHandler(this.FrmNewLocalDrivingLicenseApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_LocalDriving.ctrlLocalDeriving ctrlLocalDeriving1;
    }
}
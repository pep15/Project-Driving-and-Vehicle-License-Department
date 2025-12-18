namespace DVLD.DetainAndReleaseLicense_Form
{
    partial class frmReleaseLicense
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
            this.ctrlReleaseLicense1 = new DVLD.DetainAndReleaseLicense_Control.ctrlReleaseLicense();
            this.SuspendLayout();
            // 
            // ctrlReleaseLicense1
            // 
            this.ctrlReleaseLicense1.Location = new System.Drawing.Point(-2, 3);
            this.ctrlReleaseLicense1.Name = "ctrlReleaseLicense1";
            this.ctrlReleaseLicense1.Size = new System.Drawing.Size(1802, 1521);
            this.ctrlReleaseLicense1.TabIndex = 0;
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1805, 1531);
            this.Controls.Add(this.ctrlReleaseLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmReleaseLicense";
            this.Text = "Release License";
            this.ResumeLayout(false);

        }

        #endregion

        private DetainAndReleaseLicense_Control.ctrlReleaseLicense ctrlReleaseLicense1;
    }
}
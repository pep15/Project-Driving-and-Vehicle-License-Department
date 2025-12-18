namespace DVLD.DetainLicense_Form
{
    partial class frmDetainLicense
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
            this.ctrlDetainLicense1 = new DVLD.DetainLicense_Control.ctrlDetainLicense();
            this.SuspendLayout();
            // 
            // ctrlDetainLicense1
            // 
            this.ctrlDetainLicense1.Location = new System.Drawing.Point(-2, -3);
            this.ctrlDetainLicense1.Name = "ctrlDetainLicense1";
            this.ctrlDetainLicense1.Size = new System.Drawing.Size(1783, 1491);
            this.ctrlDetainLicense1.TabIndex = 0;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1789, 1492);
            this.Controls.Add(this.ctrlDetainLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmDetainLicense";
            this.Text = "Detain License";
            this.ResumeLayout(false);

        }

        #endregion

        private DetainLicense_Control.ctrlDetainLicense ctrlDetainLicense1;
    }
}
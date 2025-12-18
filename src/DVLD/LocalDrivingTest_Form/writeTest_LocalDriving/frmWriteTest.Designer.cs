namespace DVLD.LocalDriving_Form.writeTest
{
    partial class frmWriteTest
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
            this.ctrlWritenTest1 = new DVLD.ControlApplicationsTest.ctrlWritenTest();
            this.SuspendLayout();
            // 
            // ctrlWritenTest1
            // 
            this.ctrlWritenTest1.AutoSize = true;
            this.ctrlWritenTest1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlWritenTest1.Location = new System.Drawing.Point(12, 12);
            this.ctrlWritenTest1.Name = "ctrlWritenTest1";
            this.ctrlWritenTest1.Size = new System.Drawing.Size(1790, 1850);
            this.ctrlWritenTest1.TabIndex = 0;
            // 
            // frmWriteTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1818, 1868);
            this.Controls.Add(this.ctrlWritenTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmWriteTest";
            this.Text = "WriteTest";
            this.Load += new System.EventHandler(this.frmWriteTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ControlApplicationsTest.ctrlWritenTest ctrlWritenTest1;
    }
}
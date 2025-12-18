namespace DVLD.LocalDriving_Form.VisionTest
{
    partial class frmPassFaillTestVision
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
            this.ctrlVisiontestPassFaill1 = new DVLD.ControlApplicationsTest.ScheduleTestVision.ctrlVisiontestPassFaill();
            this.SuspendLayout();
            // 
            // ctrlVisiontestPassFaill1
            // 
            this.ctrlVisiontestPassFaill1.Location = new System.Drawing.Point(12, 12);
            this.ctrlVisiontestPassFaill1.Name = "ctrlVisiontestPassFaill1";
            this.ctrlVisiontestPassFaill1.Size = new System.Drawing.Size(973, 1549);
            this.ctrlVisiontestPassFaill1.TabIndex = 0;
            // 
            // frmPassFaillTestVision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(977, 1573);
            this.Controls.Add(this.ctrlVisiontestPassFaill1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPassFaillTestVision";
            this.Text = "Test Vision";
            this.Load += new System.EventHandler(this.frmPassFaillTestVision_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestVision.ctrlVisiontestPassFaill ctrlVisiontestPassFaill1;
    }
}
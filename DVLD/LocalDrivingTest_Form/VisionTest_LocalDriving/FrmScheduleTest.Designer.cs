namespace DVLD.LocalDriving_Form.VisionTest
{
    partial class FrmScheduleTest
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
            this.ctrlscheduleTestVision1 = new DVLD.ControlApplicationsTest.ScheduleTestVision.ctrlscheduleTestVision();
            this.SuspendLayout();
            // 
            // ctrlscheduleTestVision1
            // 
            this.ctrlscheduleTestVision1.Location = new System.Drawing.Point(12, 42);
            this.ctrlscheduleTestVision1.Name = "ctrlscheduleTestVision1";
            this.ctrlscheduleTestVision1.Size = new System.Drawing.Size(1059, 1460);
            this.ctrlscheduleTestVision1.TabIndex = 0;
            // 
            // FrmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1083, 1509);
            this.Controls.Add(this.ctrlscheduleTestVision1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmScheduleTest";
            this.Text = "ScheduleTest Vision";
            this.Load += new System.EventHandler(this.FrmScheduleTest_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestVision.ctrlscheduleTestVision ctrlscheduleTestVision1;
    }
}
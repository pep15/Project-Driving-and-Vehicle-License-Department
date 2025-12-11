namespace DVLD.LocalDriving_Form.VisionTest
{
    partial class frmScheduleRetakeTest
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
            this.ctrlScheduleRetakeTest1 = new DVLD.ControlApplicationsTest.ScheduleTestVision.ctrlScheduleRetakeTest();
            this.SuspendLayout();
            // 
            // ctrlScheduleRetakeTest1
            // 
            this.ctrlScheduleRetakeTest1.Location = new System.Drawing.Point(12, 89);
            this.ctrlScheduleRetakeTest1.Name = "ctrlScheduleRetakeTest1";
            this.ctrlScheduleRetakeTest1.Size = new System.Drawing.Size(1097, 1462);
            this.ctrlScheduleRetakeTest1.TabIndex = 0;
            // 
            // frmScheduleRetakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1145, 1563);
            this.Controls.Add(this.ctrlScheduleRetakeTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleRetakeTest";
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.frmScheduleRetakeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestVision.ctrlScheduleRetakeTest ctrlScheduleRetakeTest1;
    }
}
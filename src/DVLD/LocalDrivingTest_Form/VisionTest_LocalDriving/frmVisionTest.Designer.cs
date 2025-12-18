namespace DVLD.LocalDriving_Form.VisionTest
{
    partial class frmVisionTest
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
            this.ctrlVisionTestAppointments1 = new DVLD.ControlApplicationsTest.ScheduleTestWritten.ctrlVisionTestAppointments();
            this.SuspendLayout();
            // 
            // ctrlVisionTestAppointments1
            // 
            this.ctrlVisionTestAppointments1.Location = new System.Drawing.Point(2, -1);
            this.ctrlVisionTestAppointments1.Name = "ctrlVisionTestAppointments1";
            this.ctrlVisionTestAppointments1.Size = new System.Drawing.Size(1836, 1803);
            this.ctrlVisionTestAppointments1.TabIndex = 0;
            // 
            // frmVisionTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1834, 1813);
            this.Controls.Add(this.ctrlVisionTestAppointments1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmVisionTest";
            this.Text = "VisionTest";
            this.Load += new System.EventHandler(this.frmVisionTest_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestWritten.ctrlVisionTestAppointments ctrlVisionTestAppointments1;
    }
}
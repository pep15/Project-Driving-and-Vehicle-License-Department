namespace DVLD.LocalDriving_Form.StreetTest
{
    partial class frmScheduleRetakeTestStreet
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
            this.ctrlScheduleRetakeTestStreet1 = new DVLD.ControlApplicationsTest.ScheduleTestStreet.ctrlScheduleRetakeTestStreet();
            this.SuspendLayout();
            // 
            // ctrlScheduleRetakeTestStreet1
            // 
            this.ctrlScheduleRetakeTestStreet1.Location = new System.Drawing.Point(1, 0);
            this.ctrlScheduleRetakeTestStreet1.Name = "ctrlScheduleRetakeTestStreet1";
            this.ctrlScheduleRetakeTestStreet1.Size = new System.Drawing.Size(1083, 1463);
            this.ctrlScheduleRetakeTestStreet1.TabIndex = 0;
            // 
            // frmScheduleRetakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1084, 1471);
            this.Controls.Add(this.ctrlScheduleRetakeTestStreet1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmScheduleRetakeTest";
            this.Text = "Schedule Retake Test";
            this.Load += new System.EventHandler(this.frmScheduleRetakeTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestStreet.ctrlScheduleRetakeTestStreet ctrlScheduleRetakeTestStreet1;
    }
}
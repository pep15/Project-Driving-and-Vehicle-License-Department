namespace DVLD.LocalDriving_Form.StreetTest
{
    partial class FrmScheduleTestStreet
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
            this.ctrlScheduleTestStreet1 = new DVLD.ControlApplicationsTest.ScheduleTestStreet.ctrlScheduleTestStreet();
            this.SuspendLayout();
            // 
            // ctrlScheduleTestStreet1
            // 
            this.ctrlScheduleTestStreet1.Location = new System.Drawing.Point(2, 1);
            this.ctrlScheduleTestStreet1.Name = "ctrlScheduleTestStreet1";
            this.ctrlScheduleTestStreet1.Size = new System.Drawing.Size(1060, 1470);
            this.ctrlScheduleTestStreet1.TabIndex = 0;
            // 
            // FrmScheduleTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1062, 1481);
            this.Controls.Add(this.ctrlScheduleTestStreet1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmScheduleTest";
            this.Text = "Schedule Test";
            this.Load += new System.EventHandler(this.FrmScheduleTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestStreet.ctrlScheduleTestStreet ctrlScheduleTestStreet1;
    }
}
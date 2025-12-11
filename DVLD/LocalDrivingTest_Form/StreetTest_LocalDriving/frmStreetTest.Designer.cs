namespace DVLD.LocalDriving_Form.StreetTest
{
    partial class frmStreetTest
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
            this.ctrlstreetTest1 = new DVLD.ControlApplicationsTest.ScheduleTestStreet.ctrlstreetTest();
            this.SuspendLayout();
            // 
            // ctrlstreetTesk1
            // 
            this.ctrlstreetTest1.Location = new System.Drawing.Point(0, 1);
            this.ctrlstreetTest1.Name = "ctrlstreetTesk1";
            this.ctrlstreetTest1.Size = new System.Drawing.Size(1827, 1837);
            this.ctrlstreetTest1.TabIndex = 0;
            // 
            // frmStreetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1830, 1841);
            this.Controls.Add(this.ctrlstreetTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmStreetTest";
            this.Text = "Street Test";
            this.Load += new System.EventHandler(this.frmStreetTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestStreet.ctrlstreetTest ctrlstreetTest1;
    }
}
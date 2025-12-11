namespace DVLD.LocalDriving_Form.StreetTest
{
    partial class frmPassFaillTestStreet
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
            this.ctrlStreetTestPassFaill1 = new DVLD.ControlApplicationsTest.ScheduleTestStreet.ctrlStreetTestPassFaill();
            this.SuspendLayout();
            // 
            // ctrlStreetTestPassFaill1
            // 
            this.ctrlStreetTestPassFaill1.Location = new System.Drawing.Point(3, 1);
            this.ctrlStreetTestPassFaill1.Name = "ctrlStreetTestPassFaill1";
            this.ctrlStreetTestPassFaill1.Size = new System.Drawing.Size(949, 1514);
            this.ctrlStreetTestPassFaill1.TabIndex = 0;
            // 
            // frmPassFaillTestStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(960, 1523);
            this.Controls.Add(this.ctrlStreetTestPassFaill1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmPassFaillTestStreet";
            this.Text = "Pass Fail lTest Street";
            this.Load += new System.EventHandler(this.frmPassFaillTestStreet_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestStreet.ctrlStreetTestPassFaill ctrlStreetTestPassFaill1;
    }
}
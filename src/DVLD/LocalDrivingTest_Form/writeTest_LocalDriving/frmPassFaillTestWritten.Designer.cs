namespace DVLD.LocalDriving_Form.writeTest
{
    partial class frmPassFaillTestWritten
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
            this.ctrlWrittenTestPassFaill1 = new DVLD.ControlApplicationsTest.ScheduleTestWritten.ctrlWrittenTestPassFaill();
            this.SuspendLayout();
            // 
            // ctrlWrittenTestPassFaill1
            // 
            this.ctrlWrittenTestPassFaill1.Location = new System.Drawing.Point(12, 12);
            this.ctrlWrittenTestPassFaill1.Name = "ctrlWrittenTestPassFaill1";
            this.ctrlWrittenTestPassFaill1.Size = new System.Drawing.Size(962, 1512);
            this.ctrlWrittenTestPassFaill1.TabIndex = 0;
            // 
            // frmPassFaillTestWritten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(986, 1536);
            this.Controls.Add(this.ctrlWrittenTestPassFaill1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPassFaillTestWritten";
            this.Text = "Pass Faill Test Written";
            this.Load += new System.EventHandler(this.frmPassFaillTestWritten_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestWritten.ctrlWrittenTestPassFaill ctrlWrittenTestPassFaill1;
    }
}
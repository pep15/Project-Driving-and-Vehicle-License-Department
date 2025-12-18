namespace DVLD.LocalDriving_Form.writeTest
{
    partial class FrmScheduleTestWritten
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
            this.ctrlScheduleTestWritten1 = new DVLD.ControlApplicationsTest.ScheduleTestWritten.ctrlScheduleTestWritten();
            this.SuspendLayout();
            // 
            // ctrlScheduleTestWritten1
            // 
            this.ctrlScheduleTestWritten1.Location = new System.Drawing.Point(3, 3);
            this.ctrlScheduleTestWritten1.Name = "ctrlScheduleTestWritten1";
            this.ctrlScheduleTestWritten1.Size = new System.Drawing.Size(1051, 1451);
            this.ctrlScheduleTestWritten1.TabIndex = 0;
            // 
            // FrmScheduleTestWritten
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1066, 1466);
            this.Controls.Add(this.ctrlScheduleTestWritten1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmScheduleTestWritten";
            this.Text = "ScheduleTestWritten";
            this.Load += new System.EventHandler(this.FrmScheduleTestWritten_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlApplicationsTest.ScheduleTestWritten.ctrlScheduleTestWritten ctrlScheduleTestWritten1;
    }
}
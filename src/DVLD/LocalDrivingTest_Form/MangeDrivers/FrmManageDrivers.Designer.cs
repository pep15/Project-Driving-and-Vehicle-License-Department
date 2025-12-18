namespace DVLD.LocalDrivingTest_Form.MangeDrivers
{
    partial class FrmManageDrivers
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
            this.ctrlDrivers1 = new DVLD.Drivers.ctrlDrivers();
            this.SuspendLayout();
            // 
            // ctrlDrivers1
            // 
            this.ctrlDrivers1.Location = new System.Drawing.Point(-1, 2);
            this.ctrlDrivers1.Name = "ctrlDrivers1";
            this.ctrlDrivers1.Size = new System.Drawing.Size(2279, 1365);
            this.ctrlDrivers1.TabIndex = 0;
            // 
            // FrmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2284, 1369);
            this.Controls.Add(this.ctrlDrivers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmManageDrivers";
            this.Text = "Manage Drivers";
            this.Load += new System.EventHandler(this.FrmManageDrivers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Drivers.ctrlDrivers ctrlDrivers1;
    }
}
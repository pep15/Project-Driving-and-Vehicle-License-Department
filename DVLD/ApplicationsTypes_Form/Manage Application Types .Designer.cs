namespace DVLD.ApplicationsTypes_Form
{
    partial class Manage_Application_Types
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
            this.ctrlApplications_Types1 = new DVLD.Applications_Types.CtrlApplications_Types();
            this.SuspendLayout();
            // 
            // ctrlApplications_Types1
            // 
            this.ctrlApplications_Types1.Location = new System.Drawing.Point(0, 0);
            this.ctrlApplications_Types1.Name = "ctrlApplications_Types1";
            this.ctrlApplications_Types1.Size = new System.Drawing.Size(1099, 1298);
            this.ctrlApplications_Types1.TabIndex = 0;
            // 
            // Manage_Application_Types
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1105, 1305);
            this.Controls.Add(this.ctrlApplications_Types1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Manage_Application_Types";
            this.Text = "Manage Application Types";
            this.ResumeLayout(false);

        }

        #endregion

        private Applications_Types.CtrlApplications_Types ctrlApplications_Types1;
    }
}
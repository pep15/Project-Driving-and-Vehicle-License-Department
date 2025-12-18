namespace DVLD.ApplicationsTypes_Form
{
    partial class Update_Application_Type
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
            this.ctrlUpdateApplication1 = new DVLD.Applications_Types.ctrlUpdateApplication();
            this.SuspendLayout();
            // 
            // ctrlUpdateApplication1
            // 
            this.ctrlUpdateApplication1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUpdateApplication1.Name = "ctrlUpdateApplication1";
            this.ctrlUpdateApplication1.Size = new System.Drawing.Size(729, 434);
            this.ctrlUpdateApplication1.TabIndex = 0;
            // 
            // Update_Application_Type
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 458);
            this.Controls.Add(this.ctrlUpdateApplication1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Update_Application_Type";
            this.Text = "Update_Application_Type";
            this.Load += new System.EventHandler(this.Update_Application_Type_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Applications_Types.ctrlUpdateApplication ctrlUpdateApplication1;
    }
}
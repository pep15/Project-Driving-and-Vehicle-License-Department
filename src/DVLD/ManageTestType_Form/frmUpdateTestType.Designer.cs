namespace DVLD.ManageTestType_Form
{
    partial class frmUpdateTestType
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
            this.ctrlUpdateManageTestType1 = new DVLD.ManageTestType.ctrlUpdateManageTestType();
            this.SuspendLayout();
            // 
            // ctrlUpdateManageTestType1
            // 
            this.ctrlUpdateManageTestType1.Location = new System.Drawing.Point(12, 12);
            this.ctrlUpdateManageTestType1.Name = "ctrlUpdateManageTestType1";
            this.ctrlUpdateManageTestType1.Size = new System.Drawing.Size(879, 609);
            this.ctrlUpdateManageTestType1.TabIndex = 0;
            // 
            // frmUpdateTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 622);
            this.Controls.Add(this.ctrlUpdateManageTestType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmUpdateTestType";
            this.Text = "Update Test Type";
            this.Load += new System.EventHandler(this.frmUpdateTestType_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ManageTestType.ctrlUpdateManageTestType ctrlUpdateManageTestType1;
    }
}
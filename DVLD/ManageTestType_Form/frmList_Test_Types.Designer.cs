namespace DVLD.ManageTestType_Form
{
    partial class frmList_Test_Types
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
            this.ctrlManageTestType1 = new DVLD.ManageTestType.ctrlManageTestType();
            this.SuspendLayout();
            // 
            // ctrlManageTestType1
            // 
            this.ctrlManageTestType1.Location = new System.Drawing.Point(12, 1);
            this.ctrlManageTestType1.Name = "ctrlManageTestType1";
            this.ctrlManageTestType1.Size = new System.Drawing.Size(1099, 1282);
            this.ctrlManageTestType1.TabIndex = 0;
            // 
            // frmList_Test_Types
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1106, 1281);
            this.Controls.Add(this.ctrlManageTestType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmList_Test_Types";
            this.Text = "List Test Types";
            this.Load += new System.EventHandler(this.frmList_Test_Types_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ManageTestType.ctrlManageTestType ctrlManageTestType1;
    }
}
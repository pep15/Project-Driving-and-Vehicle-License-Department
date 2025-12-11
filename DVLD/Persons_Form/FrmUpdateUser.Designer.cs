namespace DVLD.Persons_Form
{
    partial class FrmUpdateUser
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
            this.ctrlAddNewPerson1 = new DVLD.ControlerPerson.ctrlAddNewPerson();
            this.SuspendLayout();
            // 
            // ctrlAddNewPerson1
            // 
            this.ctrlAddNewPerson1.Location = new System.Drawing.Point(3, 2);
            this.ctrlAddNewPerson1.Margin = new System.Windows.Forms.Padding(6);
            this.ctrlAddNewPerson1.Name = "ctrlAddNewPerson1";
            this.ctrlAddNewPerson1.Size = new System.Drawing.Size(2023, 1213);
            this.ctrlAddNewPerson1.TabIndex = 0;
            this.ctrlAddNewPerson1.Load += new System.EventHandler(this.ctrlAddNewPerson1_Load);
            // 
            // FrmUpdateUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2028, 1217);
            this.Controls.Add(this.ctrlAddNewPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmUpdateUser";
            this.Text = "Update User";
            this.ResumeLayout(false);

        }

        #endregion

        private ControlerPerson.ctrlAddNewPerson ctrlAddNewPerson1;
    }
}
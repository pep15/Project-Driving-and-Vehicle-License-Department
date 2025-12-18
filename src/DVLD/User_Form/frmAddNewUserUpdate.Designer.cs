namespace DVLD.User_Form
{
    partial class frmAddNewUserUpdate
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
            this.ctrlAddNewUser1 = new DVLD.Control_Users.ctrlAddNewUser();
            this.SuspendLayout();
            // 
            // ctrlAddNewUser1
            // 
            this.ctrlAddNewUser1.Location = new System.Drawing.Point(12, 12);
            this.ctrlAddNewUser1.Name = "ctrlAddNewUser1";
            this.ctrlAddNewUser1.Size = new System.Drawing.Size(2149, 1523);
            this.ctrlAddNewUser1.TabIndex = 0;
            // 
            // frmAddNewUserUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2360, 1616);
            this.Controls.Add(this.ctrlAddNewUser1);
            this.Name = "frmAddNewUserUpdate";
            this.Text = "AddNewUser";
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Users.ctrlAddNewUser ctrlAddNewUser1;
    }
}
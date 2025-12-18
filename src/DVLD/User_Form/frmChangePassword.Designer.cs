namespace DVLD.User_Form
{
    partial class frmChangePassword
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
            this.ctrlChangePassword1 = new DVLD.Control_Users.ctrlChangePassword();
            this.SuspendLayout();
            // 
            // ctrlChangePassword1
            // 
            this.ctrlChangePassword1.Location = new System.Drawing.Point(21, 12);
            this.ctrlChangePassword1.Name = "ctrlChangePassword1";
            this.ctrlChangePassword1.Size = new System.Drawing.Size(1611, 1253);
            this.ctrlChangePassword1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 1259);
            this.Controls.Add(this.ctrlChangePassword1);
            this.Name = "frmChangePassword";
            this.Text = "ChangePassword";
            this.Load += new System.EventHandler(this.frmChangePassword_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Users.ctrlChangePassword ctrlChangePassword1;
    }
}
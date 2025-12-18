namespace DVLD.User_Form
{
    partial class FrmUsers
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
            this.ctrlUsers1 = new DVLD.Control_Users.ctrlUsers();
            this.SuspendLayout();
            // 
            // ctrlUsers1
            // 
            this.ctrlUsers1.Location = new System.Drawing.Point(117, 112);
            this.ctrlUsers1.Name = "ctrlUsers1";
            this.ctrlUsers1.Size = new System.Drawing.Size(2153, 1393);
            this.ctrlUsers1.TabIndex = 0;
            // 
            // FrmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1823, 1458);
            this.Controls.Add(this.ctrlUsers1);
            this.Name = "FrmUsers";
            this.Text = "FrmUsers";
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Users.ctrlUsers ctrlUsers1;
    }
}
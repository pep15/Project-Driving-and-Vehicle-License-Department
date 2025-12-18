namespace DVLD.User_Form
{
    partial class FrmShowDetails
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
            this.ctrlShowPeople1 = new DVLD.Control_Users.ctrlShowPeople();
            this.SuspendLayout();
            // 
            // ctrlShowPeople1
            // 
            this.ctrlShowPeople1.Location = new System.Drawing.Point(26, 24);
            this.ctrlShowPeople1.Name = "ctrlShowPeople1";
            this.ctrlShowPeople1.Size = new System.Drawing.Size(1546, 920);
            this.ctrlShowPeople1.TabIndex = 0;
            // 
            // FrmShowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 961);
            this.Controls.Add(this.ctrlShowPeople1);
            this.Name = "FrmShowDetails";
            this.Text = "FrmShowDetails";
            this.Load += new System.EventHandler(this.FrmShowDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Control_Users.ctrlShowPeople ctrlShowPeople1;
    }
}
namespace DVLD
{
    partial class frmPersons
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
            this.ctrlPeople1 = new DVLD.ControlerPerson.ctrlPeople();
            this.SuspendLayout();
            // 
            // ctrlPeople1
            // 
            this.ctrlPeople1.AllowDrop = true;
            this.ctrlPeople1.Location = new System.Drawing.Point(-2, 0);
            this.ctrlPeople1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlPeople1.Name = "ctrlPeople1";
            this.ctrlPeople1.Size = new System.Drawing.Size(2658, 1469);
            this.ctrlPeople1.TabIndex = 0;
            this.ctrlPeople1.Load += new System.EventHandler(this.ctrlPeople1_Load);
            // 
            // frmPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(2667, 1480);
            this.Controls.Add(this.ctrlPeople1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPersons";
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmPersons_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ControlerPerson.ctrlPeople ctrlPeople1;
    }
}
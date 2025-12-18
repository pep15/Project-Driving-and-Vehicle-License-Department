using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        public static Form1 FrmStartApp;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
      [STAThread]
        static void Main()
        {
          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
           
            while (true)
            {
                Form frmLogin = new Login();
                

                if (frmLogin.ShowDialog()== DialogResult.OK)
                {
                     frmLogin.ShowDialog();
                }
               else
                {
                    break;
                }
            }
            
        }
    }
}

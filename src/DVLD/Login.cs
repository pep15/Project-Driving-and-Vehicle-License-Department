using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusineesLayer;
using System.IO;
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Diagnostics.Contracts;
namespace DVLD
{

    public partial class Login : Form
    {
        
        //clsUser _UserNameAndPassword;
        
       static public string FileName = "DVLD_UserData.txt";
       static public string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private string _FilePath;
        public Login()
        {
            InitializeComponent();
            _FilePath = Path.Combine(AppData, FileName);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            string ReadContact = "";
            

            if (File.Exists(_FilePath))
            {
                ReadContact = File.ReadAllText(_FilePath);
                string[] ArrayUserAndPassword = ReadContact.Split('#');
                string GetPaasword = DecodPassword(ArrayUserAndPassword[1]);
                txUserName.Text = ArrayUserAndPassword[0].ToString();
                txPaasword.Text = GetPaasword;
                chrememberMe.Checked = true;
            }
            else
            {
                txUserName.Text = string.Empty;
                txPaasword.Text = string.Empty;
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
             string _userName = txUserName.Text;
              string _password = txPaasword.Text;
            string SavedEncryptedPassword;
            
            clsGlobal._Contact =clsUser.UserNameAndPasswordExsits(_userName, _password);
            

            if (clsGlobal._Contact == null )
            {
                MessageBox.Show("The User name or password you entered is incorrect, try again");
                txUserName.Clear();
                txPaasword.Clear();
                txUserName.Focus();
            }
            else if (clsGlobal._Contact.IsActive == false )
            {
                MessageBox.Show("The account is inactive ", "Inform", MessageBoxButtons.OK);
                txUserName.Clear();
                txPaasword.Clear();
                txUserName.Focus();
            }
            else
            {

                this.Hide();
                
                if (chrememberMe.Checked == true)
                {
                    EncryptionPasswrod(_password, out SavedEncryptedPassword);
                    string Contact = $"{_userName}#{SavedEncryptedPassword}";
                    File.WriteAllText(_FilePath, Contact);
                    
                }
                else 
                {
                    File.Delete(_FilePath);
                    chrememberMe.Checked = false;
                }

                this.DialogResult = DialogResult.OK;
                Form frmShowApplication = new Form1();
                    frmShowApplication.ShowDialog();
                    this.Close();
            }
          
        }
        private void EncryptionPasswrod(string inputPassword, out string encryptedPassword)
        {
            byte[] PasswordEncryption = Encoding.UTF8.GetBytes(inputPassword);
            encryptedPassword =  Convert.ToBase64String(PasswordEncryption);
        }
        private string DecodPassword (string inputPassword)
        {
            byte[] PasswordDecod =  Convert.FromBase64String(inputPassword);
             return Encoding.UTF8.GetString(PasswordDecod);

        }
        private void Lable2_Click(object sender, EventArgs e)
        {
            txUserName.Clear();
            txPaasword.Clear();
            txUserName.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}

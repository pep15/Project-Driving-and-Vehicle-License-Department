using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.User_Form
{
    public partial class frmChangePassword : Form
    {
        private int _PersonID;
        private int _UserID;
        public frmChangePassword(int PersonID , int UserID)
        {
            InitializeComponent();

            this._PersonID = PersonID;
            this._UserID = UserID;

        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlChangePassword1.FindPerson(clsGlobal._Contact.PersonID);
            ctrlChangePassword1.FindUser(clsGlobal._Contact.UserID);
        }
    }
}

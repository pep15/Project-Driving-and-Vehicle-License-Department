using DVLD.Control_Users;
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
    public partial class frmAddNewUserUpdate : Form
    {
        private int _PersonID;
        
        
        public frmAddNewUserUpdate()
        {
            InitializeComponent();
        }
        public frmAddNewUserUpdate(int PersonsID)
        {
            InitializeComponent();
            
            _PersonID = PersonsID;
            ctrlAddNewUser1.LoadPersonInfo(_PersonID);
            
        }

       
    }
}

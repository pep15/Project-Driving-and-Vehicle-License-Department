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
    public partial class FrmShowDetails : Form
    {
        private int _PersonID;
        private int _UserID;
        public FrmShowDetails(int PersonID , int UserID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            this._UserID = UserID;
        }

        private void FrmShowDetails_Load(object sender, EventArgs e)
        {
            ctrlShowPeople1.FindPerson(_PersonID);
            ctrlShowPeople1.FindUser(_UserID);
        }

     
    }
}

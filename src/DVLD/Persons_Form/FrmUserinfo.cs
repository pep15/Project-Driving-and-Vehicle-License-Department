using DVLD.ControlerPerson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Persons_Form
{
    public partial class FrmUserinfo : Form
    {
        private int _PersonID;
        private int _UserID;
        public FrmUserinfo(int Person , int User)
        {
            InitializeComponent();
            this._PersonID = Person;
            this._UserID = User;
        }

        private void FrmUserinfo_Load(object sender, EventArgs e)
        {
            ctrlShowPeople1.FindPerson(_PersonID);
            ctrlShowPeople1.FindUser(_UserID);
        }
    }
}

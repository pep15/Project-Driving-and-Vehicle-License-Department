using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.ControlerPerson;

namespace DVLD.Persons_Form
{
   
    public partial class FrmUpdateUser : Form
    {

        private int _PersonID;

        
        public FrmUpdateUser(int PersonID)
        {
            InitializeComponent();
           
            _PersonID = PersonID;

        }
        private void ctrlAddNewPerson1_Load(object sender, EventArgs e)
        {
            ctrlAddNewPerson1.LoadPersonInfo(_PersonID);
        }
    }
}

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
    public partial class frmAdd_EditPepole : Form
    {
        private int _PersonID;
  
        public frmAdd_EditPepole()
        {
            InitializeComponent();
            ctrlAddNewPerson1.AddPersons();
        }

        public frmAdd_EditPepole(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            if (_PersonID == -1)
                ctrlAddNewPerson1.AddPersons();
            else
                this.Close();
        }
      
      
    }
}

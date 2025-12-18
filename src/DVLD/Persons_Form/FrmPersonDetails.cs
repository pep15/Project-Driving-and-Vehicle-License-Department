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
    public partial class FrmPersonDetails : Form
    {
        private int _PersonID;
       public enum enMode { Add = 0 , Update = 1 }
        private enMode _EnMode;
        public FrmPersonDetails()
        {
            InitializeComponent();
            
        }
        public FrmPersonDetails(int PersonID)
        {
            InitializeComponent();
          
            this._PersonID = PersonID;
        }

        private void FrmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.FindPerson(_PersonID);
        }
    }
}

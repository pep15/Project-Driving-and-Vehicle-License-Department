using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ManageTestType_Form
{
    public partial class frmUpdateTestType : Form
    {
        private int _TypeTestID;
        public frmUpdateTestType(int TypeTestID)
        {
            InitializeComponent();
            _TypeTestID = TypeTestID;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            ctrlUpdateManageTestType1.FindTypesID(_TypeTestID);
        }
    }
}

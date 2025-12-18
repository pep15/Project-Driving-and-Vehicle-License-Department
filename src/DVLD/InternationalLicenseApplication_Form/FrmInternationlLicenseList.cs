using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.InternationalLicenseApplication_Form
{
    public partial class FrmInternationlLicenseList : Form
    {
        public FrmInternationlLicenseList()
        {
            InitializeComponent();
        }

        private void FrmInternationlLicenseList_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseApplications1.ListLicenses();
        }
    }
}

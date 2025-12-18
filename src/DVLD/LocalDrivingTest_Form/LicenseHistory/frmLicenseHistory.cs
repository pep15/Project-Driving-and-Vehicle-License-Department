using DVLD.ControlApplicationsTest_LocalDriving.LicenseHistory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingTest_Form.LicenseHistory
{
    public partial class frmLicenseHistory : Form
    {
        public enum enModeLicense { Local = 0, international = 1 }
        private enModeLicense _Mode;
        
        private int _PersonID;

        public frmLicenseHistory()
        {
            InitializeComponent();
        }

        public frmLicenseHistory(enModeLicense Mode,  int PersonID )
        {
            InitializeComponent();
            this._Mode = Mode;
            this._PersonID = PersonID;
        }

        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_Mode == enModeLicense.Local)
            {
                ctrlLicenseHistory1.FindPersonLocalLicens(_PersonID);
            }
            else if(_Mode == enModeLicense.international)
            {
                ctrlLicenseHistory1.FindPersoninternationalLicens(_PersonID);
            }
            
        }
    }
}

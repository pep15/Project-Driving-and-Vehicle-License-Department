using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingTest_Form.IssueDrivinglicense
{
    public partial class frmIssueDrivingLicense : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public frmIssueDrivingLicense()
        {
            InitializeComponent();
        }

        public frmIssueDrivingLicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmIssueDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlissueDrivinglicense1.LoadData(_LocalDrivingLicenseApplicationID );
        }
    }
}

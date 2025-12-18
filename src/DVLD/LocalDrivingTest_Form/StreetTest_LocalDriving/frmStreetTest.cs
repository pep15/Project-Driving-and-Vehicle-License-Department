using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.StreetTest
{

    public partial class frmStreetTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmStreetTest()
        {
            InitializeComponent();
        }
        public frmStreetTest(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmStreetTest_Load(object sender, EventArgs e)
        {
            ctrlstreetTest1.Load_ctrlstreetTestAppointments(_LocalDrivingLicenseApplicationID);
        }
    }
}

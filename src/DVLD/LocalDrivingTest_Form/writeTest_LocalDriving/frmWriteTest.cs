using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.writeTest
{
    public partial class frmWriteTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;

        public frmWriteTest()
        {
            InitializeComponent();
        }
        public frmWriteTest(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
        }

        private void frmWriteTest_Load(object sender, EventArgs e)
        {
            ctrlWritenTest1.Load_ctrlWriteTestAppointments(_LocalDrivingLicenseApplicationID);
        }
    }
}

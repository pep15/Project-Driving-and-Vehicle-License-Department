using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.VisionTest
{
    
    public partial class frmVisionTest : Form
    {
      
        private int _LocalDrivingLicenseApplicationID = -1;
        
        public frmVisionTest()
        {
            InitializeComponent();
        }

        public frmVisionTest(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            
        }
        private void frmVisionTest_Load_1(object sender, EventArgs e)
        {
            ctrlVisionTestAppointments1.Load_ctrlVisionTestAppointments(_LocalDrivingLicenseApplicationID);
        }
    }
}

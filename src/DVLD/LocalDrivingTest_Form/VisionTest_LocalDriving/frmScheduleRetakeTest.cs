using DVLD_BusineesLayer;
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
    public partial class frmScheduleRetakeTest : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public frmScheduleRetakeTest()
        {
            InitializeComponent();
        }
        public frmScheduleRetakeTest(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID  = LocalDrivingLicenseApplicationID;
        }
        
        private void frmScheduleRetakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleRetakeTest1.AddNewSchedultVision(_LocalDrivingLicenseApplicationID);
        }
    }
}

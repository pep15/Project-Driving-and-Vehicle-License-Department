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
    public partial class FrmScheduleTest : Form
    {
        public enum enMode { Add = 0, Update = 1, RetakeExam = 2 }
        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _ApplicationID = -1;
        private clsScheduleRetakeTest _ScheduleRetakeTest;
        public FrmScheduleTest()
        {
            InitializeComponent();
        }

        public FrmScheduleTest(enMode Mode, int LocalDrivingLicenseApplicationID, int ApplicationID)
        {
            InitializeComponent();
            this._Mode = Mode;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._ApplicationID = ApplicationID;

        }
        private void FrmScheduleTest_Load_1(object sender, EventArgs e)
        {
            if (_Mode == enMode.Add)
            {
                ctrlscheduleTestVision1.AddNewSchedultVision(_LocalDrivingLicenseApplicationID);
            }
            else if (_Mode == enMode.Update)
            {
                ctrlscheduleTestVision1.UpdateAppointments(_ApplicationID);
            }
            else if (_Mode == enMode.RetakeExam)
            {
                ctrlscheduleTestVision1.LoadRetakeExam(_LocalDrivingLicenseApplicationID, _ApplicationID);
            }
        }
    }
}

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

namespace DVLD.ControlApplicationsTest.ScheduleTestVision
{
    public partial class ctrlScheduleRetakeTest : UserControl
    {
        
        private clsViewPersonSchedultTest _Shedule;
        private clsTestType _TestType;
        private clsScheduleRetakeTest _ScheduleRetakeTest;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _ApplicationID = -1;
        private clsLocalDrivingLicenseApplication _Info;
        private clsApplicationTypes _ApplicationsFees;
        public ctrlScheduleRetakeTest()
        {
            InitializeComponent();

        }

        private void _FullControl(clsViewPersonSchedultTest shedule)
        {
            _TestType = clsTestType.FindTypeFees(1);
            lbDApp.Text = _Shedule.LocalDrivingLicenseApplicationID.ToString();
            lbClass.Text = _Shedule.ClassName;
            lbName.Text = _Shedule.FullName();
            lbTrial.Text = _Shedule.TestResult.ToString();
            lbFess.Text = _TestType.TestTypeFees.ToString("0");
        }
        private void _FullRetakeTestInfo(clsScheduleRetakeTest ScheduleRetakeTest)
        {
            _ApplicationsFees = clsApplicationTypes.FindID(8);
            decimal Num1 = _ApplicationsFees.Fees;
            decimal Num2 = Convert.ToDecimal(lbFess.Text);
            decimal Result  = Num1 + Num2;
            LbRAppFees.Text = _ApplicationsFees.Fees.ToString("0");
            lbTotalFees.Text = Result.ToString("0");
            lbTestID.Text = _ScheduleRetakeTest.NewAppointments.ToString();
        }
        private void _FullScheduleRetakeTest(clsLocalDrivingLicenseApplication info )
        {
            _ScheduleRetakeTest.ApplicantPersonID = info.ApplicantPersonID;
            _ScheduleRetakeTest.LicenseClassID = info.LicenseClassID;
        }
        private void _FindUserSheduleTest(int LocalDrivingLicenseApplicationID)
        {
            _Shedule = clsViewPersonSchedultTest.FindPersonSchedultTest(LocalDrivingLicenseApplicationID );
            _Info = clsLocalDrivingLicenseApplication.FindApplictionsByID(LocalDrivingLicenseApplicationID);
            if (_Shedule != null && _Info != null)
            {
                _FullControl(_Shedule);
                _FullScheduleRetakeTest(_Info);
            }
            else
            {
                MessageBox.Show("Could not find driving license Application Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddNewSchedultVision(int LocalDrivingLicenseApplicationID)
        {
            _ScheduleRetakeTest = new clsScheduleRetakeTest();
            _FindUserSheduleTest(LocalDrivingLicenseApplicationID);
            _FullRetakeTestInfo(_ScheduleRetakeTest);

            _ScheduleRetakeTest.LocalDrivingLicenseApplicationID = Convert.ToInt16(lbDApp.Text);
            _ScheduleRetakeTest.NewApplicationID = Convert.ToInt16(lbTestID.Text);
            _ScheduleRetakeTest.ApplicationDate = DTime.Value;
            _ScheduleRetakeTest.TestFees = Convert.ToDecimal(lbFess.Text);
            _ScheduleRetakeTest.CreatedByUserID = clsGlobal._Contact.UserID;
            _ScheduleRetakeTest.TestTypeID = _TestType.TestTypeID;
            _ScheduleRetakeTest.IsLocked = false;
            _ScheduleRetakeTest.RetakPaidFees = Convert.ToDecimal(LbRAppFees.Text);
            _ScheduleRetakeTest.LastStatusDate = DTime.Value;
            _ScheduleRetakeTest.ApplicationStatus = 1;
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _ScheduleRetakeTest.ApplicationDate = DTime.Value;
            if (_ScheduleRetakeTest.RetakeExam())
            {
                MessageBox.Show("Data Save Successfully.");

            }
            else
                MessageBox.Show("Error: Data Is not Save Successfully.");


            _FullRetakeTestInfo(_ScheduleRetakeTest);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnClose.FindForm().Close();
        }
    }
}

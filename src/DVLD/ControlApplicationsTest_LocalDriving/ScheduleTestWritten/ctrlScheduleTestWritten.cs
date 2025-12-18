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

namespace DVLD.ControlApplicationsTest.ScheduleTestWritten
{
    public partial class ctrlScheduleTestWritten : UserControl
    {
        public enum eMode { Add = 0, update = 1 };
        private eMode _Mode;
        private clsViewPersonSchedultTest _Shedule;
        private clsTestType _TestType;
        private clsAppointments _AddAppointments;
        private clsScheduleRetakeTest _ScheduleRetakeTest;
        private int _LocalDrivingLicenseApplicationID = -1;
        clsApplicationTypes _ApplicationsFees;
        private int _ApplicationID = -1;
        public ctrlScheduleTestWritten()
        {
            InitializeComponent();
        }
        public ctrlScheduleTestWritten(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;

            if (_LocalDrivingLicenseApplicationID == -1)
                _Mode = eMode.Add;
            else
                _Mode = eMode.update;
        }
        private void _FullControl(clsViewPersonSchedultTest shedule , int LocalDrivingLicenseApplicationID)
        {
            _TestType = clsTestType.FindTypeFees(2);
            //_Shedule = clsViewPersonSchedultTest.FindPersonSchedultTest(LocalDrivingLicenseApplicationID, 2);
            lbDApp.Text = _Shedule.LocalDrivingLicenseApplicationID.ToString();
            lbClass.Text = _Shedule.ClassName;
            lbName.Text = _Shedule.FullName();
            lbTrial.Text = _Shedule.TestResult.ToString();
            lbFess.Text = _TestType.TestTypeFees.ToString("0");
            LbTotalFees.Text = _TestType.TestTypeFees.ToString("0");
        }
        private void _FullRetakeTestInfo()
        {

            _ApplicationsFees = clsApplicationTypes.FindID(8);
            decimal Num1 = _ApplicationsFees.Fees;
            decimal Num2 = Convert.ToDecimal(lbFess.Text);
            decimal Result = Num1 + Num2;
            lbRAppFees.Text = _ApplicationsFees.Fees.ToString("0");
            LbTotalFees.Text = Result.ToString("0");
            LbTestID.Text = _ApplicationID.ToString();
            grtestInfo.ForeColor = Color.Black;
            lbSubject.Text = "Schedule Retake Exam";
            _Mode = eMode.update;
            UpdateAppointment();

        }
        public void UpdateAppointment()
        {
            if (_Mode == eMode.update)
            {
                _AddAppointments = clsAppointments.FindAppointments(_ApplicationID, 2);

                if (_AddAppointments.IsLocked == true)
                {
                    DTime.Enabled = false;
                    LbSatTest.Text = "Person already sat for the test, appointment loacked.";
                    btnSave.Enabled = false;
                    grtestInfo.ForeColor = Color.Black;
                }
                else
                {
                    DTime.Enabled = true;
                    if (_AddAppointments == null)
                    {

                        MessageBox.Show("This Appointments does not exist.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    grtestInfo.Enabled = false;
                }


                _FindUserSheduleTest(_AddAppointments.LocalDrivingLicenseApplicationID);
            }

        }
        public void AddNewSchedultWritten(int LocalDrivingLicenseApplicationID)
        {
            if (_Mode == eMode.Add)
            {
                _FindUserSheduleTest(LocalDrivingLicenseApplicationID);

                _AddAppointments = new clsAppointments();

                return;
            }

        }
        private void _FindUserSheduleTest(int LocalDrivingLicenseApplicationID)
        {
            _Shedule = clsViewPersonSchedultTest.FindPersonSchedultTest(LocalDrivingLicenseApplicationID);
            if (_Shedule != null)
            {
                _FullControl(_Shedule , LocalDrivingLicenseApplicationID);
            }
            else
            {
                MessageBox.Show("Could not find driving license Application Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Load_scheduleTestVision(int LocalDrivingLicenseApplicationID)
        {
            Load_scheduleTestVision(_LocalDrivingLicenseApplicationID);
        }
        public void ctrlscheduleTestVision_Load(object sender, EventArgs e)
        {
            btnSave_Click_1(sender, e);
        }
        public void UpdateAppointments(int ApplicationID)
        {
            _ApplicationID = ApplicationID;
            _Mode = eMode.update;
            UpdateAppointment();
        }
        public void LoadRetakeExam(int LocalDrivingLicenseApplicationID, int ApplicationID)
        {
            this._ApplicationID = ApplicationID;
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _FindUserSheduleTest(_LocalDrivingLicenseApplicationID);
            _ScheduleRetakeTest = new clsScheduleRetakeTest();
            _FullRetakeTestInfo();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            _AddAppointments.LocalDrivingLicenseApplicationID = Convert.ToInt16(lbDApp.Text);
            _AddAppointments.AppointmentDate = DTime.Value;
            _AddAppointments.PaidFees = Convert.ToDecimal(lbFess.Text);
            _AddAppointments.CreatedByUserID = clsGlobal._Contact.UserID;
            _AddAppointments.TestTypeID = _TestType.TestTypeID;
            _AddAppointments.IsLocked = false;
            grtestInfo.Enabled = false;
            if (_AddAppointments.save())
            {
                MessageBox.Show("Data Save Successfully.");
            }
            else
                MessageBox.Show("Error: Data Is not Save Successfully.");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

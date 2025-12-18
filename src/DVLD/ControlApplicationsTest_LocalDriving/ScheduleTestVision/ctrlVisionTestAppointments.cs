using DVLD.LocalDriving_Form.VisionTest;
using DVLD.Persons_Form;
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
    public partial class ctrlVisionTestAppointments : UserControl
    {
        public enum enMode { Add = 0, Update = 1, RetakeExam = 2 };
        private enMode _Mode;
        private clsVisionTest _VisionTestAppointments;
        private int _LocalDrivingLicenseApplicationID;
        private clsAppointments _HasAppointments;
        static public DataTable dtAppointmentsTest;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _PersonID;
        private clsApplicationTypes _ApplicationsFees;
        private clsScheduleRetakeTest _ScheduleRetakeTest;
        public ctrlVisionTestAppointments()
        {
            InitializeComponent();
        }
        public ctrlVisionTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void _RefrechContactList(bool RefreshDataFromDB = true)
        {
            if (RefreshDataFromDB)
            {
                dtAppointmentsTest = clsAppointments.GetAllAppointment(1);
                dgvAppointment.DataSource = dtAppointmentsTest;

                lbRecord.Text = dgvAppointment.Rows.Count.ToString();
            }
        }
        private void _FullDrivingLicenseApplicationInfo(clsVisionTest _VisionTestAppointments)
        {
            LbDLAppID.Text = _VisionTestAppointments.LocalDrivingLicenseApplicationID.ToString();
            LbAppliedLicenses.Text = _VisionTestAppointments.ClassName;
            LbPassed.Text = _VisionTestAppointments.TestResult.ToString() + "" + "/3";
        }
        private string ApplicationStatusOfConvertning(byte ApplicationStatus)
        {
            switch (ApplicationStatus)
            {
                case 1:
                    return "New";
                case 2:
                    return "Cancelled";
                case 3:
                    return "Completed";
            }

            return null;
        }
        private void _FullApplicationBasicInfo(clsVisionTest _VisionTestAppointments)
        {
            _ApplicationsFees = clsApplicationTypes.FindID(1);
            LbID.Text = _VisionTestAppointments.ApplicationID.ToString();
            lbStatusOrder.Text = ApplicationStatusOfConvertning(_VisionTestAppointments.ApplicationStatus);
            LbFees.Text = _ApplicationsFees.Fees.ToString("0");
            lbType.Text = _VisionTestAppointments.ApplicationTypeTitle;
            LbApplicant.Text = _VisionTestAppointments.FullName();
            LbDate.Text = DateTime.Now.ToString("d");
            LbStatusDate.Text = _VisionTestAppointments.ApplicationDate.ToString("d");
            lbCreateBy.Text = _VisionTestAppointments.UserName;
        }
        public void Load_ctrlVisionTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            Load_DrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            Load_ApplicationBasicInfo(LocalDrivingLicenseApplicationID);
            _RefrechContactList(true);
        }
        private void Load_DrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            _VisionTestAppointments = clsVisionTest.DrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);

            if (_VisionTestAppointments != null)
            {
                _FullDrivingLicenseApplicationInfo(_VisionTestAppointments);
            }
            else
            {
                MessageBox.Show("Could not find driving license Application Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefrechContactList(true);
        }
        private void Load_ApplicationBasicInfo(int LocalDrivingLicenseApplicationID)
        {
            _VisionTestAppointments = clsVisionTest.ApplicationBasicInfo(LocalDrivingLicenseApplicationID);

            if (_VisionTestAppointments != null)
            {
                _FullApplicationBasicInfo(_VisionTestAppointments);
            }
            else
            {
                MessageBox.Show("Could not find Application Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _RefrechContactList(true);


        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
            {
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_LocalDrivingLicenseApplicationID);
                _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
                Form frmViewPerson = new FrmPersonDetails(_PersonID.PersonID);
                frmViewPerson.ShowDialog();
            }
            _RefrechContactList(true);
        }
        private void btnAddLocalApplications_Click(object sender, EventArgs e)
        {
            int ApplicationID = -1;
            bool shouldOpenRetakeScreen = false;
            if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
            {
                if (clsAppointments.HasActiveAppointment(_VisionTestAppointments.LocalDrivingLicenseApplicationID, 2, false))
                {
                    MessageBox.Show("Person Already have an active appointment for this test, you cannot add new appointment", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    clsVisionTest lastTestResult = clsVisionTest.GetLastTestAppointmentResult(_LocalDrivingLicenseApplicationID, 2, true);
                    if (lastTestResult != null && lastTestResult.TestResult == 1 && lastTestResult.IsLocked == true)
                    {
                        MessageBox.Show("This person already passed this test, you can only retake failed tests.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (lastTestResult != null && lastTestResult.TestResult == 0)
                    {
                        shouldOpenRetakeScreen = true;
                    }
                }

            }
            if (shouldOpenRetakeScreen)
            {
                if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
                {
                    Form scheduleRetakeTest = new frmScheduleRetakeTest(_LocalDrivingLicenseApplicationID);
                    scheduleRetakeTest.ShowDialog();
                    _RefrechContactList(true);
                }
            }
            else
            {

                if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
                {

                    Form FrmscheduleTestVision = new FrmScheduleTest(FrmScheduleTest.enMode.Add, _LocalDrivingLicenseApplicationID, ApplicationID);
                    FrmscheduleTestVision.ShowDialog();
                    _RefrechContactList(true);
                }
                else
                {
                    MessageBox.Show("Local Driving License Application ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ApplicationID = (int)dgvAppointment.CurrentRow.Cells["TestAppointmentID"].Value;
            _ScheduleRetakeTest = clsScheduleRetakeTest.ScheduleRetakeFind(ApplicationID, 1);
            if (_ScheduleRetakeTest != null)
            {
                if (_ScheduleRetakeTest.ApplicationTypeID == 8)
                {
                    if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
                    {
                        Form FrmscheduleTestVision = new FrmScheduleTest(FrmScheduleTest.enMode.RetakeExam, _LocalDrivingLicenseApplicationID, ApplicationID);
                        FrmscheduleTestVision.ShowDialog();
                        _RefrechContactList(true);
                    }

                }
                else
                {
                    if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
                    {
                        Form FrmscheduleTestVision = new FrmScheduleTest(FrmScheduleTest.enMode.Update, _LocalDrivingLicenseApplicationID, ApplicationID);
                        FrmscheduleTestVision.ShowDialog();
                        _RefrechContactList(true);
                    }
                }
            }
            else
            {
                MessageBox.Show("Local Driving License Application ID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dgvAppointment.CurrentRow.Cells["TestAppointmentID"].Value;
            if (int.TryParse(LbDLAppID.Text, out _LocalDrivingLicenseApplicationID))
            {
                Form TakeTest = new frmPassFaillTestVision(_LocalDrivingLicenseApplicationID);
                TakeTest.ShowDialog();
            }
            _RefrechContactList(true);
        }
    }
}

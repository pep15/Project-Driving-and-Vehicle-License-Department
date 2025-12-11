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

namespace DVLD.ControlApplicationsTest.ScheduleTestStreet
{
    public partial class ctrlStreetTestPassFaill : UserControl
    {
        private clsAppointments _AddAppointments;
        private clsViewPersonSchedultTest _Shedule;
        private clsTestType _TestType;
        public clsTakeTestVisionTest _TakeTestVisionTest;
        private int _LocalDrivingLicenseApplicationID;
        public ctrlStreetTestPassFaill()
        {
            InitializeComponent();
        }
        public ctrlStreetTestPassFaill(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void _FullControl(clsViewPersonSchedultTest Shedule, clsAppointments AddAppointments, int LocalDrivingLicenseApplicationID)
        {
            _TestType = clsTestType.FindTypeFees(3);
            _Shedule = clsViewPersonSchedultTest.FindPersonSchedultTest(LocalDrivingLicenseApplicationID, 3);
            lbDApp.Text = _Shedule.LocalDrivingLicenseApplicationID.ToString();
            lbClass.Text = _Shedule.ClassName;
            lbName.Text = _Shedule.FullName();
            lbTrial.Text = _Shedule.TestResult.ToString();
            lbDate.Text = AddAppointments.AppointmentDate.ToString("dd/MMM/yyyy");
            lbFess.Text = _TestType.TestTypeFees.ToString("0");
        }
        private void _FullControlPassAndFaill()
        {
            _AddAppointments.LocalDrivingLicenseApplicationID = Convert.ToInt16(lbDApp.Text);
            _AddAppointments.AppointmentDate = Convert.ToDateTime(lbDate.Text);
            _AddAppointments.PaidFees = Convert.ToDecimal(lbFess.Text);
            _AddAppointments.TestTypeID = _TestType.TestTypeID;
            _AddAppointments.CreatedByUserID = clsGlobal._Contact.UserID;
        }
        public void _FindUserSheduleTest(int LocalDrivingLicenseApplicationID)
        {
            _Shedule = clsViewPersonSchedultTest.FindPersonSchedultTest(LocalDrivingLicenseApplicationID);
            _AddAppointments = clsAppointments.FindLastClosedAppointment(LocalDrivingLicenseApplicationID, false);
            if (_Shedule != null && _AddAppointments != null)
            {
                _FullControl(_Shedule, _AddAppointments, LocalDrivingLicenseApplicationID);
            }
            else
            {
                MessageBox.Show("Could not find driving license Application Info.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.FindForm().Close();
            }
        }
        private void AddTakeWrittenTest()
        {

            _FullControlPassAndFaill();
            _TakeTestVisionTest = new clsTakeTestVisionTest();
            _TakeTestVisionTest.CreatedByUserID = clsGlobal._Contact.UserID;
            _TakeTestVisionTest.TestAppointmentID = _AddAppointments.AppointmentID;
            _TakeTestVisionTest.Notes = tbNote.Text;
            if (radfail.Checked)
            {
                _TakeTestVisionTest.TestResult = 0;
            }
            else
            {
                _TakeTestVisionTest.TestResult = 1;

            }
            _AddAppointments.IsLocked = true;

            if (_TakeTestVisionTest.AddNewTest() && _AddAppointments.UpdateIsLockedAppointment())
            {
                MessageBox.Show("Data Save Successfully.");
            }
            else
                MessageBox.Show("Error: Data Is not Save Successfully.");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            AddTakeWrittenTest();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

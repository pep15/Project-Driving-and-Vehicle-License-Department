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

namespace DVLD.ControlApplicationsTest.Issue_Driving_license
{
    public partial class ctrlissueDrivinglicense : UserControl
    {
        private clsApplicationTypes _ApplicationsFees;
        private clsVisionTest _VisionTestAppointments;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _PersonID;
        private int _LocalDrivingLicenseApplicationID;
        private clsLicenses _Licenses;
        private clsDriving _Driving;
        private byte _ApplicationStatus;
        public ctrlissueDrivinglicense()
        {
            InitializeComponent();
        }

        public ctrlissueDrivinglicense(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
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
            tbNote.Text = null;
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
        private void _FullDrivingLicenseApplicationInfo(clsVisionTest _VisionTestAppointments)
        {
            LbDLAppID.Text = _VisionTestAppointments.LocalDrivingLicenseApplicationID.ToString();
            LbAppliedLicenses.Text = _VisionTestAppointments.ClassName;
            LbPassed.Text = _VisionTestAppointments.TestResult.ToString() + "" + "/3";
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(int.TryParse(LbDLAppID.Text,out _LocalDrivingLicenseApplicationID))
            {
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_LocalDrivingLicenseApplicationID);
                _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
                Form frmViewPerson = new FrmPersonDetails(_PersonID.PersonID);
                frmViewPerson.ShowDialog();
            }
            
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
        }
        private void NewDriver()
        {
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_LocalDrivingLicenseApplicationID);
            _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            _Driving.PersonID = _PersonID.PersonID;
            _Driving.CreatedByUserID = clsGlobal._Contact.UserID;
            _Driving.CreatedDate = DateTime.Now;
            if(_Driving.AddNewDriver())
            {
                _Licenses.ApplicationID = _VisionTestAppointments.ApplicationID;
                _Licenses.DriverID = _Driving.DriverID;
                _Licenses.LicenseClass = _LocalDrivingLicenseApplication.LicenseClassID;
                _Licenses.IssueDate = DateTime.Now;
                _Licenses.ExpirationDate = DateTime.Now.AddYears(5);
                _Licenses.Notes = tbNote.Text;
                _Licenses.PaidFees = 20;
                _Licenses.IsActive = true;
                _Licenses.IssueReason = 1;
                _Licenses.CreatedByUserID = clsGlobal._Contact.UserID;
            }

        }
        public void LoadData(int LocalDrivingLicenseApplicationID)
        {
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this._ApplicationStatus = 3;
            Load_DrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID);
            Load_ApplicationBasicInfo(LocalDrivingLicenseApplicationID);
           
            _Driving = new clsDriving();
            _Licenses = new clsLicenses();
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            NewDriver();
            if(_Licenses.AddNewLicenses())
            {
                MessageBox.Show($"License Issued Successfully with License ID = {_Driving.DriverID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Person Not Added !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           clsLocalDrivingLicenseApplication.UpdateApplicationSatus(_LocalDrivingLicenseApplicationID , _ApplicationStatus);
            ApplicationStatusOfConvertning(_ApplicationStatus);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

using DVLD.InternationalLicenseApplication_Form;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
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

namespace DVLD.InternationalLicenseApplication_Control
{
    public partial class ctrlInternationalLicense : UserControl
    {
        private clsShowLicense _License;
        private int _LicenseID;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _PersonID;
        private clsApplicationTypes _ApplicationsFees;
        private clsLicenses _InternationalLicenseApplications;
        private clsDriving _Driving;
        private clsInterantionalLicenseApp _InterantionalLicenseApp;
        public ctrlInternationalLicense()
        {
            InitializeComponent();
        }
        private void _LoadData(clsShowLicense License )
        {
            lbClass.Text = _License.ClassName;
            lbName.Text = _License.FullName;
            LbLicenseID.Text = _License.LicenseID.ToString();
            lbNational.Text = _License.NationalNo;
            if (_License.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;
            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }
            lbIssueDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lbIssueReason.Text = _License.IssueReason.ToString("First Time");
            if (string.IsNullOrEmpty(_License.Notes))
            {
                lbNote.Text = "No Notes";
            }
            if (_License.IsActive == true)
            {
                lbActive.Text = "Yes";
            }
            else
            {
                lbActive.Text = "No";
            }
            lbBirth.Text = _License.DateOfBirth.ToString("dd/MMM/yyyy");
            LbDriverID.Text = _License.DriverID.ToString();
            LbExpiration.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            lbDatained.Text = "No";
            if (!string.IsNullOrEmpty(_License.ImagePath))
            {
                PicBoPersonalImage.Load(_License.ImagePath);
            }
            else
            {
                PicBoPersonalImage.Visible = false;
            }
        }
        private void FindLicensebyLicenseID(int LicenseID)
        {
            _License = clsShowLicense.FindLicensebyLicenseID(LicenseID);
            if (_License != null)
            {
                _LoadData(_License);
                lblShowLicensesHistory.Enabled = true;


                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_License.LocalDrivingLicenseApplicationID);

                if(_LocalDrivingLicenseApplication != null)
                {
                    _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
                }
                
            }
            else
            {
                MessageBox.Show("Could not found the LicensID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
          if (CheckHasLicense())
          {
             MessageBox.Show("Note! Person Already have an active Iinternationl License , you cannot add new License", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnSave.Enabled = false;
                lblShowLicensesinfo.Enabled = true;
                LbApplicationID.Text = "N/A";
                lbLicense.Text = "N/A";

          }
            _LicenseID = Convert.ToInt16(txinput.Text.Trim());
            FindLicensebyLicenseID(_LicenseID);
            ApplicationInfo();
        }
        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _LicenseID = Convert.ToInt16(txinput.Text.Trim());
            _License = clsShowLicense.FindLicensebyLicenseID(_LicenseID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_License.LocalDrivingLicenseApplicationID);
            _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            Form LicenseHistory = new frmLicenseHistory(frmLicenseHistory.enModeLicense.international, _PersonID.PersonID);
            LicenseHistory.ShowDialog();

        }
        private void ApplicationInfo()
        {
            _ApplicationsFees = clsApplicationTypes.FindID(6);
            lbApplicationDate.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lbIssueDa.Text = _License.IssueDate.ToString("dd/MMM/yyyy");
            lbExpirationDate.Text = _License.ExpirationDate.ToString("dd/MMM/yyyy");
            lbLocalLicenseID.Text = _License.LicenseID.ToString();
            LbFees.Text = _ApplicationsFees.Fees.ToString("0");
            lbCreateBy.Text = clsGlobal._Contact.UserName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void _FullInternationData()
        {

            _InterantionalLicenseApp = new clsInterantionalLicenseApp();
            _InterantionalLicenseApp.ApplicantPersonID = _PersonID.PersonID;
            _InterantionalLicenseApp.ApplicationDate = DateTime.Now;
            _InterantionalLicenseApp.ApplicationTypeID = 6;
            _InterantionalLicenseApp.ApplicationStatus = 3;
            _InterantionalLicenseApp.LastStatusDate = DateTime.Now;
            _InterantionalLicenseApp.PaidFees = Convert.ToDecimal(LbFees.Text);
            _InterantionalLicenseApp.DriverID = _License.DriverID;
            _InterantionalLicenseApp.IssuedUsingLocalLicenseID = _License.LicenseID;
            _InterantionalLicenseApp.IssueDate  = _License.IssueDate;
            _InterantionalLicenseApp.ExpirationDate = DateTime.Now.AddYears(1);
            _InterantionalLicenseApp.IsActive = true;
            _InterantionalLicenseApp.CreatedByUserID = clsGlobal._Contact.UserID;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (_License.IsActive != true || _License.LicenseClass != 3 || _License.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show($"Please Check the card License = {_License.IsActive} or Lisense Class={_License.LicenseClass} " +
                    $"or the date ofcard License is Expiration Date = {_License.ExpirationDate} ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Result = MessageBox.Show("Are you sure you want to issue the license?",
                                      "Confirm",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    _FullInternationData();
                    if(_InterantionalLicenseApp.AddnewInterantionalLicense())
                    {
                        MessageBox.Show($"International license issued Successfully with ID = {_InterantionalLicenseApp.LicensesID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LbApplicationID.Text = _InterantionalLicenseApp.ApplicationID.ToString();
                        lbLicense.Text = _InterantionalLicenseApp.LicensesID.ToString();
                        lblShowLicensesinfo.Enabled = true;
                        btnSave.Enabled = false;

                    }
                   
                }
                else
                {
                    MessageBox.Show("Error: License was not issued.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                
            }


        }
        private bool CheckHasLicense()
        {
            _InterantionalLicenseApp = new clsInterantionalLicenseApp();
            _LicenseID = Convert.ToInt16(txinput.Text.Trim());
            _License = clsShowLicense.FindLicensebyLicenseID(_LicenseID);
            return (_License != null) ? _InterantionalLicenseApp.HasInternationLicense(_License.DriverID, 6) : false;
        }
        private void lblShowLicensesinfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LbDriverID.Text = _License.DriverID.ToString();
            _InterantionalLicenseApp = clsInterantionalLicenseApp.FindDriverAndApplicationID(Convert.ToInt16(LbDriverID.Text));
            Form ShowInternationApplications = new frmInternationLicenseApplication(_InterantionalLicenseApp.InternationalLicenseID);
            ShowInternationApplications.ShowDialog();
        }
    }
}

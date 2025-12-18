using DVLD.InternationalLicenseApplication_Form;
using DVLD.LocalDrivingTest_Form.DriverLicenseInfo;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
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

namespace DVLD.RenewLicenseApplication
{
    public partial class ctrlRenewLicenseApplication : UserControl
    {
        private int _LicenseID;
        private clsLicenses _Licenses;
        private clsShowLicense _ShowLicense;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _PersonID;
        private clsApplicationTypes _ApplicationsFees;
        private clsInterantionalLicenseApp _InterantionalLicenseApp;
        private clsDetainLicense _DetainLicense;
        public ctrlRenewLicenseApplication()
        {
            InitializeComponent();
        }

        private void _LoadData(clsLicenses Licenses)
        {
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(Licenses.LicensesID);
            lbClass.Text = Licenses.ClassName;
            lbName.Text = Licenses.FullName;
            LbLicenseID.Text = Licenses.LicensesID.ToString();
            lbNational.Text = Licenses.NationalNo;
            if (Licenses.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;
            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }
            lbIssueDate.Text = Licenses.IssueDate.ToString("dd/MMM/yyyy");
            lbIssueReason.Text = Licenses.IssueReason.ToString("First Time");
            if (string.IsNullOrEmpty(Licenses.Notes))
            {
                lbNote.Text = "No Notes";
            }
            if (Licenses.IsActive == true)
            {
                lbActive.Text = "Yes";
            }
            else
            {
                lbActive.Text = "No";
            }
            lbBirth.Text = Licenses.DateOfBirth.ToString("dd/MMM/yyyy");
            LbDriverID.Text = Licenses.DriverID.ToString();
            LbExpiration.Text = Licenses.ExpirationDate.ToString("dd/MMM/yyyy");
            if (_DetainLicense == null)
            {
                lbDatained.Text = "No";
            }
            else
            {
                if (_DetainLicense.IsReleased == false)
                {
                    lbDatained.Text = "yes";
                }
                else
                {
                    lbDatained.Text = "No";
                }
            }

            if (!string.IsNullOrEmpty(Licenses.ImagePath))
            {
                PicBoPersonalImage.Load(Licenses.ImagePath);
            }
            else
            {
                PicBoPersonalImage.Visible = false;
            }
        }
        private void ApplicationInfo()
        {
            _ApplicationsFees = clsApplicationTypes.FindID(2);
            lbApplicationDate.Text = _Licenses.IssueDate.ToString("dd/MMM/yyyy");
            lbIssueDa.Text = _Licenses.IssueDate.ToString("dd/MMM/yyyy");
            lbExpirationDate.Text = _Licenses.ExpirationDate.ToString("dd/MMM/yyyy");
            lbOldLocalLicenseID.Text = _Licenses.LicensesID.ToString();
            LbFees.Text = _ApplicationsFees.Fees.ToString("0");
            lbLicenseFess.Text = _Licenses.ClassFees.ToString("0");
            lbCreateBy.Text = clsGlobal._Contact.UserName;
            int Result = Convert.ToInt16(lbLicenseFess.Text) + Convert.ToInt16(LbFees.Text);
            lbTotalFees.Text = Result.ToString();
        }
        private void FindLicensebyLicenseID(int LicenseID)
        {
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);
            if (_Licenses.ExpirationDate > DateTime.Now)
            {

               MessageBox.Show($"Selectd Licens is not yet expiared, it will expire on: {_Licenses.ExpirationDate.ToShortDateString()} and your Licens is not Active", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);

               if (_Licenses != null)
               {
                   _LoadData(_Licenses);
                   lblShowLicensesHistory.Enabled = true;
               
                   _PersonID = clsPerson.FindByID(_Licenses.ApplicantPersonID);
               }
               else
               {
                   MessageBox.Show("Could not found the LicensID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
               btnSave.Enabled = false;
            }
            else
            {
                if (_DetainLicense != null && _DetainLicense.IsReleased == false)
                {
                    MessageBox.Show($"This License is Detained, Cannot proceed. Fees: {_DetainLicense.FineFees}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;

                    return;
                }

                if (_Licenses.IsActive == false)
                {
                    _LoadData(_Licenses);
                    MessageBox.Show($"Your Licens is not  Active", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    grboxDriverLicenseInfo.Enabled = false;
                    grboxApplicationNewLicenseInfo.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    if (_Licenses != null)
                    {
                        _LoadData(_Licenses);
                        lblShowLicensesHistory.Enabled = true;

                        _PersonID = clsPerson.FindByID(_Licenses.ApplicantPersonID);
                    }
                    else
                    {
                        MessageBox.Show("Could not found the LicensID", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }


                btnSave.Enabled = true;
                



            }
            
            
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {

            _LicenseID = Convert.ToInt16(txinput.Text.Trim());
            FindLicensebyLicenseID(_LicenseID);
            ApplicationInfo();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            if (_Licenses == null)
            {
                MessageBox.Show("Selected License Info Not Found", "Error", MessageBoxButtons.OK , MessageBoxIcon.Error);

                return;
            }
            
            if (MessageBox.Show("Are you sure you want to Renew the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _Licenses.AddNewRenewLicenses(lbNote.Text, Convert.ToDecimal(lbTotalFees.Text), clsGlobal._Contact.UserID);
                lbRenewedLicenseID.Text = _Licenses.LicensesID.ToString();
                lbReApplicationID.Text = _Licenses.ApplicationID.ToString();
                MessageBox.Show($"Licensed Renewed Successfully with ID= {_Licenses.LicensesID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblShowLicensesinfo.Enabled = true;
                btnSave.Enabled = false;
            }
        }

        private void lblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            _PersonID = clsPerson.FindByID(_Licenses.ApplicantPersonID);
            Form LicenseHistory = new frmLicenseHistory(frmLicenseHistory.enModeLicense.Local, _PersonID.PersonID);
            LicenseHistory.ShowDialog();
        }

        private void lblShowLicensesinfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbReApplicationID.Text = _Licenses.ApplicationID.ToString();
            Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.Renewal, Convert.ToInt16(lbRenewedLicenseID.Text) );
            ShowLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

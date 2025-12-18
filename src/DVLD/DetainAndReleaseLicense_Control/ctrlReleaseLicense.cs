using DVLD.LocalDrivingTest_Form.DriverLicenseInfo;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DetainAndReleaseLicense_Control
{
    public partial class ctrlReleaseLicense : UserControl
    {
        private clsPerson _PersonID;
        private clsLicenses _Licenses;
        private clsDetainLicense _DetainLicense;
        private clsApplicationTypes _ApplicationTypes;
        private int _LicenseID;
        public ctrlReleaseLicense()
        {
            InitializeComponent();
        }
        private int TotalFess(int ApplicationFees , int FineFees)
        {
            return ApplicationFees + FineFees;
        }
        private void ApplicationInfo()
        {
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);
            _ApplicationTypes = clsApplicationTypes.FindID(5);
            lbDetainDate.Text = _DetainLicense.DetainDate.ToString("dd/MMM/yyyy");
            lbCreateBy.Text = clsGlobal._Contact.UserName;
            lbDetainLicense.Text = _LicenseID.ToString();
            LbApplicationFees.Text = _ApplicationTypes.Fees.ToString("0");
            lbFineFees.Text = _DetainLicense.FineFees.ToString("0");
            lbTotalFees.Text = TotalFess(Convert.ToInt16(_ApplicationTypes.Fees), Convert.ToInt16(_DetainLicense.FineFees)).ToString("0");
           
        }
        private void _LoadData(clsLicenses Licenses)
        {
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);
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
            {
                lbNote.Text = _Licenses.Notes;
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
                    lbDatained.Text = "No";
                }
                else
                {
                    lbDatained.Text = "Yes";
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
        private void FindLicensebyLicenseID(int LicenseID)
        {
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);
            if (_Licenses == null)
            {
                MessageBox.Show("License Info Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            else
            {
                _LoadData(_Licenses);
                if (_DetainLicense == null)
                {
                    
                    MessageBox.Show($"Selectd License is not Detained,choose another one.", "Inform", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
               
                _PersonID = clsPerson.FindByID(_Licenses.ApplicantPersonID);
                _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);

                if (_Licenses.IsActive == false)
                {
                    MessageBox.Show($"Selectd Licens is not Active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    grbFilter.Enabled = false;
                    return;
                }
                else
                {
                    

                }
            }

            lblShowLicensesHistory.Enabled = true;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _LicenseID = Convert.ToInt16(txinput.Text.Trim());
            FindLicensebyLicenseID(_LicenseID);

            if(_DetainLicense == null)
            {
                return;
            }
            else
            {
                ApplicationInfo();
            }
            
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            

            DialogResult Result = MessageBox.Show("Are you sure you want to Release the license?",
                                      "Confirm",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                
                _DetainLicense.AddReleaseDetainLicense(clsGlobal._Contact.UserID, _PersonID.PersonID  ,  Convert.ToDecimal(lbTotalFees.Text));
                MessageBox.Show("Detain license release Successfully", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbApplicationID.Text = _DetainLicense.ReleaseApplicationID.ToString();
                grbFilter.Enabled = false;
                btnSave.Enabled = false;
                lblShowLicensesinfo.Enabled = true;
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
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
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.Detain, _Licenses.ApplicationID);
            ShowLicenseInfo.ShowDialog();
        }

        public void FindPersonLocalLicens(int LicenseID)
        {
            this._LicenseID = LicenseID;
            txinput.Text = _LicenseID.ToString();
            if (txinput.Text == _LicenseID.ToString())
            {
                grbFilter.Enabled = false;
                FindLicensebyLicenseID(_LicenseID);
            }
        }
    }
}

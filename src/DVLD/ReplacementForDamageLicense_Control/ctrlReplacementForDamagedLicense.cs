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

namespace DVLD
{
    public partial class ctrlReplacementForDamagedLicense : UserControl
    {

        private clsShowLicense _License;
      private clsDetainLicense _DetainLicense;
        private clsLicenses _Licenses;
        private clsPerson _PersonID;
        private int _LicenseID;
        public ctrlReplacementForDamagedLicense()
        {
            InitializeComponent();
            rdbDamagedLicense.Checked = true;
        }

        private void _LoadData(clsLicenses Licenses)
        {
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
                    lbDatained.Text = "yes";
                }
                else
                {
                    lbDatained.Text = "no";
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
            int LostLicense = 10;
            int DamagedLicense = 5;
            lbApplicationDate.Text = _Licenses.IssueDate.ToString("dd/MMM/yyyy");
            lbLocalLicenseID.Text = _Licenses.LicensesID.ToString();
            if(rdbDamagedLicense.Checked)
            {
                LbApplicationFees.Text = DamagedLicense.ToString("0");
            }
            else if (rdbLostLicense.Checked)
            {
                LbApplicationFees.Text = LostLicense.ToString("0");
            }
            
            lbCreateBy.Text = clsGlobal._Contact.UserName;
        }
        private int GetIssueReason()
        {
            int IssueReason = 0;
            if (rdbDamagedLicense.Checked)
            {
                 IssueReason = 4;
            }
            else if (rdbLostLicense.Checked)
            {
                IssueReason = 3;
            }
            return IssueReason;


        }
        private void FindLicensebyLicenseID(int LicenseID)
        {
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(_LicenseID);
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_Licenses.LicensesID);

            if (_Licenses == null)
            {
                MessageBox.Show("License Info Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            else
            {
                _LoadData(_Licenses);

                if (_DetainLicense != null && _DetainLicense.IsReleased == false)
                {
                    MessageBox.Show($"This License is Detained, Cannot proceed. Fees: {"$" + _DetainLicense.FineFees.ToString("0.00")}", "Error", MessageBoxButtons.OK , MessageBoxIcon.Information);
                    btnSave.Enabled = false;

                    return; 
                }
                

                _PersonID = clsPerson.FindByID(_Licenses.ApplicantPersonID);
                

                if (_Licenses.IsActive == false)
                {
                    MessageBox.Show($"Selectd Licens is not Active.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnSave.Enabled = false;
                    return;
                }
                else
                {
                    lblShowLicensesHistory.Enabled = true;
                    btnSave.Enabled = true;
                }
                
                
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
                MessageBox.Show("Selected License Info Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show("Are you sure you want to Renew the License?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int ReasonID = GetIssueReason();
                int ApplicationTypeID = ReasonID;
                _Licenses.ReplecementDamage(lbNote.Text, Convert.ToDecimal(LbApplicationFees.Text), ReasonID, ApplicationTypeID, Convert.ToDateTime( LbExpiration.Text),clsGlobal._Contact.UserID);
                lbReplacedLicense.Text = _Licenses.LicensesID.ToString();
                LbApplicationID.Text = _Licenses.ApplicationID.ToString();
                MessageBox.Show($"Licensed Replaced  Successfully with ID= {_Licenses.LicensesID}", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            LbApplicationID.Text = _Licenses.ApplicationID.ToString();
            Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.Replacement, Convert.ToInt16(LbApplicationID.Text));
            ShowLicenseInfo.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

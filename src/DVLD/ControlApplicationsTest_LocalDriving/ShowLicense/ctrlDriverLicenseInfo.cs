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

namespace DVLD.ControlApplicationsTest_LocalDriving.ShowLicense
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public enum enIssueReason {  Renew = 0, ReplacementForDamage = 2, Detain = 3 }
        private enIssueReason _Mode;
        private clsShowLicense _License;
        private clsDetainLicense _DetainLicense;
        private clsLicenses _Licenses;
        private int _ApplicationID;
        private int _LicenseID;
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        private void IssueReasonWithIsDetain(enIssueReason Mode= enIssueReason.Renew)
        {
            _Licenses = clsLicenses.GetLicenseInfoByApplicationID(_ApplicationID);
            _LicenseID = _Licenses.LicensesID;
            _DetainLicense = clsDetainLicense.GetDetainLicensesID(_LicenseID);
            switch (Mode)
            {
                case enIssueReason.Renew:
                    if (_DetainLicense.IsReleased == true)
                    {
                        lbDatained.Text = "No";
                        lbIssueReason.Text = _Licenses.IssueReason.ToString("Renew");
                    }
                    else
                    {
                        lbDatained.Text = "Yes";
                        lbIssueReason.Text = _Licenses.IssueReason.ToString("Renew");
                    }
                    break;
                case enIssueReason.ReplacementForDamage:
                    if (_DetainLicense.IsReleased == true)
                    {
                        lbDatained.Text = "No";
                        lbIssueReason.Text = _Licenses.IssueReason.ToString("Replacement for Damage");
                    }
                    else
                    {
                        lbDatained.Text = "Yes";
                        lbIssueReason.Text = _Licenses.IssueReason.ToString("Replacement for Damage");
                    }

                    break;
                case enIssueReason.Detain:
                    if (_DetainLicense.IsReleased == true)
                    {
                        lbDatained.Text = "No";
                        lbIssueReason.Text = "Detained License";
                    }
                    else
                    {
                        lbDatained.Text = "Yes";
                        lbIssueReason.Text = "Detained License";
                    }
                    break;
            }
        }
        private void _LoadDataNew(clsShowLicense License)
        {
            lbClass.Text = _License.ClassName;
            lbName.Text = _License.FullName;
            LbLicenseID.Text = _License.LicenseID.ToString();
            lbNational.Text = _License.NationalNo;
            if(_License.Gendor == 0)
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
            
            if(string.IsNullOrEmpty(_License.Notes))
            {
                lbNote.Text = "No Notes";
            }
            if(_License.IsActive == true)
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
            if(!string.IsNullOrEmpty (_License.ImagePath))
            {
                PicBoPersonalImage.Load(_License.ImagePath);
            }
            else
            {
                PicBoPersonalImage.Visible =false;
            }
        }
        private void _LoadDataRenew(clsLicenses Licenses)
        {
            lbClass.Text = _Licenses.ClassName;
            lbName.Text = _Licenses.FullName;
            LbLicenseID.Text = _Licenses.LicensesID.ToString();
            lbNational.Text = _Licenses.NationalNo;
            if (_Licenses.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;
            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }
            lbIssueDate.Text = _Licenses.IssueDate.ToString("dd/MMM/yyyy");

            if (string.IsNullOrEmpty(_Licenses.Notes))
            {
                lbNote.Text = "No Notes";
            }
            else
            {
                lbNote.Text = _Licenses.Notes;
            }
            if (_Licenses.IsActive == true)
            {
                lbActive.Text = "Yes";
            }
            else
            {
                lbActive.Text = "No";
            }
            lbBirth.Text = _Licenses.DateOfBirth.ToString("dd/MMM/yyyy");
            LbDriverID.Text = _Licenses.DriverID.ToString();
            LbExpiration.Text = _Licenses.ExpirationDate.ToString("dd/MMM/yyyy");
            lbDatained.Text = "No";
            if (!string.IsNullOrEmpty(_Licenses.ImagePath))
            {
                PicBoPersonalImage.Load(_Licenses.ImagePath);
            }
            else
            {
                PicBoPersonalImage.Visible = false;
            }
        }
        public void NewLicense(int ApplicationID)
        {
            this._ApplicationID = ApplicationID;
            
            _License = clsShowLicense.FindLicensebyApplicationID(ApplicationID);
            _LoadDataNew(_License);
            lbIssueReason.Text = _License.IssueReason.ToString("First Time");
        }
        public void RenewLicense(int ApplicationID)
        {
            this._ApplicationID = ApplicationID;
            _Licenses = clsLicenses.GetLicenseInfoByApplicationID(ApplicationID);
            _LoadDataRenew(_Licenses);
            IssueReasonWithIsDetain(_Mode = enIssueReason.Renew);

        }
        public void ReplacementLicense(int ApplicationID)
        {
            this._ApplicationID = ApplicationID;
            _Licenses = clsLicenses.GetLicenseInfoByApplicationID(ApplicationID);

            _LoadDataRenew(_Licenses);
            IssueReasonWithIsDetain(_Mode = enIssueReason.ReplacementForDamage);

        }
        public void DetainLicense(int ApplicationID)
        {
            this._ApplicationID = ApplicationID;
            _Licenses = clsLicenses.GetLicenseInfoByApplicationID(ApplicationID);
            _LoadDataRenew(_Licenses);
            IssueReasonWithIsDetain(_Mode = enIssueReason.Detain);

        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

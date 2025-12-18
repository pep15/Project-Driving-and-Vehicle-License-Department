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
    public partial class ctrlShowInternationLicenseApplication : UserControl
    {
        
        private int _InternationLicesnseID;
        private clsInterantionalLicenseApp _InternationalLicenseApp;
        private clsShowLicense _License;
        public ctrlShowInternationLicenseApplication()
        {
            InitializeComponent();
        }

        private void _LoadData(clsInterantionalLicenseApp InternationalLicenseApp )
        {
            
            lbName.Text = _InternationalLicenseApp.FullName;
            LbLicenseID.Text = _InternationalLicenseApp.IssuedUsingLocalLicenseID.ToString();
            lbNational.Text = _InternationalLicenseApp.NationalNo;
            Lbintlicense.Text = _InternationalLicenseApp.InternationalLicenseID.ToString();
            lbApplicationiD.Text = _InternationalLicenseApp.ApplicationID.ToString();
            if (_InternationalLicenseApp.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;
            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }
           
   
            if (_InternationalLicenseApp.IsActive == true)
            {
                lbActive.Text = "Yes";
            }
            else
            {
                lbActive.Text = "No";
            }
            lbBirth.Text = _InternationalLicenseApp.DateOfBirth.ToString("dd/MMM/yyyy");
            LbDriverID.Text = _InternationalLicenseApp.DriverID.ToString();
            lbIssueDate.Text = _InternationalLicenseApp.IssueDate.ToString("dd/MMM/yyyy");
            LbExpiration.Text = _InternationalLicenseApp.ExpirationDate.ToString("dd/MMM/yyyy");
            if (!string.IsNullOrEmpty(_InternationalLicenseApp.ImagePath))
            {
                PicBoPersonalImage.Load(_InternationalLicenseApp.ImagePath);
            }
            else
            {
                PicBoPersonalImage.Visible = false;
            }
        }

        public void FindLicense(int InternationLicesnseID)
        {
            this._InternationLicesnseID = InternationLicesnseID;
            _InternationalLicenseApp = clsInterantionalLicenseApp.FindLicenseAndApplicationID(InternationLicesnseID);
            
            _LoadData(_InternationalLicenseApp);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

using DVLD.ControlApplicationsTest_LocalDriving.ShowLicense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingTest_Form.DriverLicenseInfo
{
    public partial class FrmDriverLicenseInfo : Form
    {
        public enum enTries { FirstTime = 0, Renewal = 1, Replacement = 2  , Detain=3}
        private enTries _Tries;
        private int _ApplicationID;
      
        public FrmDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public FrmDriverLicenseInfo(enTries Tries, int ApplicationID)
        {
            InitializeComponent();

            this._Tries = Tries;
            this._ApplicationID = ApplicationID;
        }

        private void FrmDriverLicenseInfo_Load(object sender, EventArgs e)
        {
            if(_Tries == enTries.FirstTime)
            {
                ctrlDriverLicenseInfo1.NewLicense(_ApplicationID);
            }
            else if(_Tries == enTries.Renewal)
            {
                ctrlDriverLicenseInfo1.RenewLicense(_ApplicationID);
            }
            else if (_Tries == enTries.Replacement)
            {
                ctrlDriverLicenseInfo1.ReplacementLicense(_ApplicationID);
            }
            else if (_Tries == enTries.Detain)
            {
               ctrlDriverLicenseInfo1.DetainLicense(_ApplicationID);
            }

        }
    }
}

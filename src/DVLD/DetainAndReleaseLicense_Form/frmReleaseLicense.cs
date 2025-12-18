using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.DetainAndReleaseLicense_Form
{
    public partial class frmReleaseLicense : Form
    {
        private int _LicenseID;
        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        public frmReleaseLicense(int LicenseID)
        {
            InitializeComponent();
            this._LicenseID = LicenseID;
            ctrlReleaseLicense1.FindPersonLocalLicens(_LicenseID);
        }
    }
}

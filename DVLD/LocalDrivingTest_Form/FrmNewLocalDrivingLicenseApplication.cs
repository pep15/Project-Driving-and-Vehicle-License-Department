using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form
{
    public partial class FrmNewLocalDrivingLicenseApplication : Form
    {
        private int _PersonID;
        private int _LicenseClass;
        public FrmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }


        public FrmNewLocalDrivingLicenseApplication(int PersonID)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            
        }
        public FrmNewLocalDrivingLicenseApplication(int PersonID , int LicenseClass)
        {
            InitializeComponent();
            this._PersonID = PersonID;
            this._LicenseClass = LicenseClass;

        }
        private void FrmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.InternationalLicenseApplication_Form
{
    public partial class frmInternationLicenseApplication : Form
    {

        private int _InternationLicesnseID = -1;
       
        public frmInternationLicenseApplication()
        {
            InitializeComponent();
        }
        public frmInternationLicenseApplication( int InternationLicesnseID )
        {
            InitializeComponent();
            
            this._InternationLicesnseID = InternationLicesnseID;

        }

        private void frmInternationLicenseApplication_Load(object sender, EventArgs e)
        {
            ctrlShowInternationLicenseApplication1.FindLicense(_InternationLicesnseID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.writeTest
{
    public partial class frmScheduleRetakeTestWritten : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public frmScheduleRetakeTestWritten()
        {
            InitializeComponent();
        }
        public frmScheduleRetakeTestWritten(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
  

        private void frmScheduleRetakeTestWritten_Load(object sender, EventArgs e)
        {
            ctrlScheduleRetakeTestWritten1.AddNewSchedultWritten(_LocalDrivingLicenseApplicationID);
        }
    }
}

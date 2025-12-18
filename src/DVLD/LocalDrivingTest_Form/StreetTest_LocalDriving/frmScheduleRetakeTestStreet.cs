using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.StreetTest
{
    public partial class frmScheduleRetakeTestStreet : Form
    {
        private int _LocalDrivingLicenseApplicationID;
        public frmScheduleRetakeTestStreet()
        {
            InitializeComponent();
        }

        public frmScheduleRetakeTestStreet(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmScheduleRetakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleRetakeTestStreet1.AddNewSchedultStreet(_LocalDrivingLicenseApplicationID);
        }
    }
}

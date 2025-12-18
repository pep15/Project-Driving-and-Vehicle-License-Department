using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDriving_Form.VisionTest
{
    public partial class frmPassFaillTestVision : Form
    {
        private int _LocalDrivingApplicationID;
        public frmPassFaillTestVision()
        {
            InitializeComponent();
        }
        public frmPassFaillTestVision(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingApplicationID = LocalDrivingApplicationID;
        }

        private void frmPassFaillTestVision_Load(object sender, EventArgs e)
        {
           ctrlVisiontestPassFaill1._FindUserSheduleTest(_LocalDrivingApplicationID);
        }
    }
}

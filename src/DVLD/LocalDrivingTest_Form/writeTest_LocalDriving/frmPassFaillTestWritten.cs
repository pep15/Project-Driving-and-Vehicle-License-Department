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
    public partial class frmPassFaillTestWritten : Form
    {
        private int _LocalDrivingApplicationID;

        public frmPassFaillTestWritten()
        {
            InitializeComponent();
        }
        public frmPassFaillTestWritten(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingApplicationID = LocalDrivingApplicationID;
        }

        private void frmPassFaillTestWritten_Load(object sender, EventArgs e)
        {
            ctrlWrittenTestPassFaill1._FindUserSheduleTest(_LocalDrivingApplicationID);
        }
    }
}

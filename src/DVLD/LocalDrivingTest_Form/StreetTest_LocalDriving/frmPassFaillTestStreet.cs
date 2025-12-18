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
    public partial class frmPassFaillTestStreet : Form
    {
        private int _LocalDrivingApplicationID;
        public frmPassFaillTestStreet()
        {
            InitializeComponent();
        }

        public frmPassFaillTestStreet(int LocalDrivingApplicationID)
        {
            InitializeComponent();
            this._LocalDrivingApplicationID = LocalDrivingApplicationID;
        }
        private void frmPassFaillTestStreet_Load(object sender, EventArgs e)
        {
            ctrlStreetTestPassFaill1._FindUserSheduleTest(_LocalDrivingApplicationID);
        }

      
    }
}

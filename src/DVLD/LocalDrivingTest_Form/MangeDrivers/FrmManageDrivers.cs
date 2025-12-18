using DVLD.Drivers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.LocalDrivingTest_Form.MangeDrivers
{
    public partial class FrmManageDrivers : Form
    {
        public FrmManageDrivers()
        {
            InitializeComponent();
        }

        private void FrmManageDrivers_Load(object sender, EventArgs e)
        {
            ctrlDrivers1.GetData();
        }
    }
}

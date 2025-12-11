using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ApplicationsTypes_Form
{
    public partial class Update_Application_Type : Form
    {
        private int _AppID;
        public Update_Application_Type(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
        }

        private void Update_Application_Type_Load(object sender, EventArgs e)
        {
            ctrlUpdateApplication1.FindApplicationID(_AppID);
        }
    }
}

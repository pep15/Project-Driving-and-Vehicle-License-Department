using DVLD.ApplicationsTypes_Form;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications_Types
{
    public partial class CtrlApplications_Types : UserControl
    {
        static public DataTable dtApplications;
        public CtrlApplications_Types()
        {
            InitializeComponent();
            dtApplications = clsApplicationTypes.getApps();
        }
        private void _RefrechContactList(bool RefreshDataFroomDB = false)
        {
            if(RefreshDataFroomDB)
            {
                dtApplications = clsApplicationTypes.getApps();
                dvgApplicationTypes.DataSource = dtApplications;
                lbRecords.Text = dvgApplicationTypes.RowCount.ToString();
            }
            dvgApplicationTypes.Columns["ApplicationTypeID"].HeaderText = "ID";
            dvgApplicationTypes.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dvgApplicationTypes.Columns["ApplicationFees"].HeaderText = "Fees";
        }
        private void CtrlApplications_Types_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = (int)dvgApplicationTypes.CurrentRow.Cells["ApplicationTypeID"].Value;
            Form frmUpdateApplications = new Update_Application_Type(AppID);
            frmUpdateApplications.ShowDialog();
            _RefrechContactList(true);
        }
    }
}

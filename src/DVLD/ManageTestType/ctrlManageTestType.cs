using DVLD.ManageTestType_Form;
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

namespace DVLD.ManageTestType
{
    public partial class ctrlManageTestType : UserControl
    {
        static public DataTable dtManageTestType;
        public ctrlManageTestType()
        {
            InitializeComponent();
            dtManageTestType = clsManageTestType.GetAllTestType();
        }
        private void _RefrechContactList(bool RefreshDataFroomDB = false)
        {
            if(RefreshDataFroomDB)
            {
                dtManageTestType = clsManageTestType.GetAllTestType();
                dvgManageTestType.DataSource = dtManageTestType;
                lbRecords.Text = dtManageTestType.Rows.Count.ToString();
            }

            dvgManageTestType.Columns["TestTypeID"].HeaderText = "ID";
            dvgManageTestType.Columns["TestTypeTitle"].HeaderText = "Title";
            dvgManageTestType.Columns["TestTypeDescription"].HeaderText = "Description";
            dvgManageTestType.Columns["TestTypeFees"].HeaderText = "Fees";
        }
        private void ctrlManageTestType_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestTypeID = (int)dvgManageTestType.CurrentRow.Cells["TestTypeID"].Value;
            Form FrmUpdateTestType = new frmUpdateTestType(TestTypeID);
            FrmUpdateTestType.ShowDialog();
            _RefrechContactList(true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

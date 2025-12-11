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

namespace DVLD.Drivers
{
    public partial class ctrlDrivers : UserControl
    {
        static public DataTable dtDriversLists;
        private clsDriving _Driver;
        public ctrlDrivers()
        {
            InitializeComponent();
        }
        private void _RefrechContactList(bool RefreshDataFromDB = false)
        {
            if (RefreshDataFromDB)
            {
                dtDriversLists = clsDriving.ListLicensesDriverPerson();
                dgvLocal.DataSource = dtDriversLists;

                lbRecord.Text = dtDriversLists.Rows.Count.ToString();
                dgvLocal.Columns["DriverID"].FillWeight = 50;
                dgvLocal.Columns["PersonID"].FillWeight = 50;
                dgvLocal.Columns["NationalNo"].FillWeight = 50;
                dgvLocal.Columns["FullName"].FillWeight = 300;
                cbFilter.SelectedIndex = 0;
            }
        }
        public void GetData()
        {
            _RefrechContactList(true);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFilter.Visible = (cbFilter.Text != "None");
        }
        private void txFilter_TextChanged(object sender, EventArgs e)
        {
           
            if (string.IsNullOrEmpty(txFilter.Text))
            {
                
                dtDriversLists.DefaultView.RowFilter = "";
            }
            else
            {
                switch (cbFilter.Text.ToString())
                {
                    case "Driver ID":
                        int DriverID;
                        if (int.TryParse(txFilter.Text, out DriverID))
                        {
                            dtDriversLists.DefaultView.RowFilter = "DriverID = " + DriverID;
                        }
                        break;
                    case "Person ID":
                        int PersonID;
                        if (int.TryParse(txFilter.Text, out PersonID))
                        {
                            dtDriversLists.DefaultView.RowFilter = "PersonID = " + PersonID;
                        }
                        break;
                    case "National No.":
                        dtDriversLists.DefaultView.RowFilter = "NationalNo Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Full Name":
                        dtDriversLists.DefaultView.RowFilter = "FullName Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}

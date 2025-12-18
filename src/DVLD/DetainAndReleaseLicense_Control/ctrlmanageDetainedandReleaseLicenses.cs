using DVLD.DetainAndReleaseLicense_Form;
using DVLD.DetainLicense_Form;
using DVLD.LocalDrivingTest_Form.DriverLicenseInfo;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
using DVLD.Persons_Form;
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

namespace DVLD.DetainAndReleaseLicense_Control
{
    public partial class ctrlmanageDetainedandReleaseLicenses : UserControl
    {

        private clsDetainLicense _DetainLicense;
        static DataTable _DTDetainLicense;
        private clsLicenses _Licenses;
        public ctrlmanageDetainedandReleaseLicenses()
        {
            InitializeComponent();
            _DetainLicense = new clsDetainLicense();
            _Licenses = new clsLicenses();
            
        }

       private void _RefrechContactList(bool RefreshDataFromDB = false)
       {
            if(RefreshDataFromDB)
            {

                _DTDetainLicense = clsDetainLicense.GetDetainLicenses();
                dgvListDetainedLicenses.DataSource = _DTDetainLicense;
                dgvListDetainedLicenses.Columns["D.ID"].FillWeight = 90;
                dgvListDetainedLicenses.Columns["L.ID"].FillWeight = 90;
                dgvListDetainedLicenses.Columns["Is Released"].FillWeight = 110; 
                dgvListDetainedLicenses.Columns["Fine Fees"].FillWeight = 110;
                dgvListDetainedLicenses.Columns["D.Date"].FillWeight = 160;
                dgvListDetainedLicenses.Columns["Release Date"].FillWeight = 160;
                dgvListDetainedLicenses.Columns["N.No"].FillWeight = 110;
                dgvListDetainedLicenses.Columns["Full Name"].FillWeight = 350;
                dgvListDetainedLicenses.Columns["Rlease App.ID"].FillWeight = 130;
                dgvListDetainedLicenses.RowHeadersVisible = false;
                lbRecord.Text = dgvListDetainedLicenses.RowCount.ToString();
                cbFilter.SelectedIndex = 0;

            }

       }
       private void ctrlmanageDetainedandReleaseLicenses_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
        }
       private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
       private void txFilter_TextChanged(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txFilter.Text))
            {
                _DTDetainLicense.DefaultView.RowFilter = null;
            }
            else
            {
                switch (cbFilter.Text)
                {
                    case "Detain ID":
                        int DetainLicense;
                        if (int.TryParse(txFilter.Text, out DetainLicense))
                        {
                            _DTDetainLicense.DefaultView.RowFilter = "[D.ID] = " + DetainLicense;
                        }
                        break;

                    case "Is Released":
                        bool IsReleased;
                        if (bool.TryParse(txFilter.Text, out IsReleased))
                        {
                            _DTDetainLicense.DefaultView.RowFilter = "[Is Released] = " + IsReleased;
                        }
                        break;

                    case "National No.":
                        _DTDetainLicense.DefaultView.RowFilter = "N.No Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Full Name":
                        _DTDetainLicense.DefaultView.RowFilter = "Full Name Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Rlease App.ID":
                        int RleaseAppID;
                        if (int.TryParse(txFilter.Text, out RleaseAppID))
                        {
                            _DTDetainLicense.DefaultView.RowFilter = "[Rlease App.ID] = " + RleaseAppID;
                        }
                        break;

                }
            }
        }
       private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFilter.Visible = (cbFilter.Text != "None");
        }
       private void button1_Click(object sender, EventArgs e)
        {
            Form frmreleaseLicenses = new frmReleaseLicense();
            frmreleaseLicenses.Show();
        }
       private void btnAddLocalApplications_Click(object sender, EventArgs e)
        {
            Form frmDetainLicenses = new frmDetainLicense();
            frmDetainLicenses.Show();
        }
       private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
       {
            int LocalLicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells["L.ID"].Value;
            _DetainLicense = clsDetainLicense.GetPersonDetails(LocalLicenseID);
            Form frmViewPerson = new FrmPersonDetails(_DetainLicense.PersonID);
            frmViewPerson.ShowDialog();
       }

        
       private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
       {
            int LocalLicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells["L.ID"].Value;
            _Licenses = clsLicenses.GetLicenseInfoByLicensesID(LocalLicenseID);
            Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.Detain, _Licenses.ApplicationID);
            ShowLicenseInfo.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells["L.ID"].Value;
            _DetainLicense = clsDetainLicense.GetPersonDetails(LocalLicenseID);
            Form LicenseHistory = new frmLicenseHistory(frmLicenseHistory.enModeLicense.Local, _DetainLicense.PersonID);
            LicenseHistory.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells["L.ID"].Value;
            _DetainLicense = clsDetainLicense.GetPersonDetails(LocalLicenseID);
            Form frmReleaseLicense = new frmReleaseLicense(LocalLicenseID);
            frmReleaseLicense.Show();
            
            
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int DetainsID = (int)dgvListDetainedLicenses.CurrentRow.Cells["D.ID"].Value;
            _DetainLicense = clsDetainLicense.GetDetainsID(DetainsID);
            if (_DetainLicense.IsReleased == false)
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = true;
            }
            else
            {
                releaseDetainedLicenseToolStripMenuItem.Enabled = false;
            }
        }
    }
}

using DVLD.LocalDriving_Form;
using DVLD.LocalDriving_Form.StreetTest;
using DVLD.LocalDriving_Form.VisionTest;
using DVLD.LocalDriving_Form.writeTest;
using DVLD.LocalDrivingTest_Form.DriverLicenseInfo;
using DVLD.LocalDrivingTest_Form.IssueDrivinglicense;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DVLD.Control_LocalDriving
{
    public partial class ctrlLocalDrivingLicenseApllication : UserControl
    {
        static  public DataTable dtLocalApplications;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _PersonID;
        private clsShowLicense _License;
        public ctrlLocalDrivingLicenseApllication()
        {
            InitializeComponent();
            this.dgvListLocalApplications.AutoGenerateColumns = false;
        }
        private void _RefrechContactList(bool RefreshDataFromDB = false)
        {
            if (RefreshDataFromDB)
            {
                dtLocalApplications = clsLocalDrivingLicenseApplication.GetLocalLicenseApplications();
                dgvListLocalApplications.DataSource = dtLocalApplications;
              
                lbRecord.Text = dgvListLocalApplications.Rows.Count.ToString();
                cbFilter.SelectedIndex = 0;
            }
        }
        private void ctrlLocalDrivingLicenseApllication_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
        }
        private void dgvListLocalApplications_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvListLocalApplications.Columns[e.ColumnIndex].Name == "colStatus")
            {

                if (e.Value != null && e.Value != DBNull.Value)
                {
                    if (e.Value is string)
                    {
                        return;
                    }

                    byte statusValue = Convert.ToByte(e.Value);
                    switch (statusValue)
                    {
                        case 1:
                            e.Value = "New";
                            break;
                        case 2:
                            e.Value = "Cancelled";
                            break;
                        case 3:
                            e.Value = "Completed";
                            break;
                    }
                    e.FormattingApplied = true;
                    return;
                }
            }
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFilter.Visible = (cbFilter.Text != "None");
        }
        private void txFilter_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txFilter.Text))
            {
                dtLocalApplications.DefaultView.RowFilter = null;
            }
            else
            {
                switch (cbFilter.Text)
                {
                    case "L.DL.AppID":
                        int Value;
                        if (int.TryParse(txFilter.Text, out Value))
                        {
                            dtLocalApplications.DefaultView.RowFilter = "LocalDrivingLicenseApplicationID = " + Value;
                        }
                        break;
                    case "National No":
                        dtLocalApplications.DefaultView.RowFilter = "NationalNo Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;
                    case "Full Name":
                        dtLocalApplications.DefaultView.RowFilter = "FullName like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;
                    case "Status":
                        string FilterText = txFilter.Text.Trim().ToLower();
                        if ("new".StartsWith(FilterText))
                        {
                            dtLocalApplications.DefaultView.RowFilter = "Status = 1";
                        }
                        else if ("cancelled".StartsWith(FilterText))
                        {
                            dtLocalApplications.DefaultView.RowFilter = "Status = 2";
                        }
                        else if ("completed".StartsWith(FilterText))
                        {
                            dtLocalApplications.DefaultView.RowFilter = "Status = 3";
                        }
                        else
                        {
                            dtLocalApplications.DefaultView.RowFilter = "Status = 0";
                        }

                        break;

                }

            }

        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            
            clsLocalDrivingLicenseApplication.UpdateApplicationSatus(LocalDrivingLicenseApplicationID , 2);
            _RefrechContactList(true);
        }
        private void btnAddLocalApplications_Click(object sender, EventArgs e)
        {
            Form FrmAddLocalDrivingLicenseApplication = new FrmNewLocalDrivingLicenseApplication();
            FrmAddLocalDrivingLicenseApplication.ShowDialog();
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            Form VisionTest = new frmVisionTest(LocalDrivingLicenseApplicationID);
            VisionTest.Show();
            _RefrechContactList(true) ;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            Form WrittenTest = new frmWriteTest(LocalDrivingLicenseApplicationID);
            WrittenTest.Show();
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            Form StreetTest = new frmStreetTest(LocalDrivingLicenseApplicationID);
            StreetTest.Show();
        }
        private bool CheckContectMenu(byte ApplicationStatus)
        {
            if (ApplicationStatus == 3)
            {
                issueDrivinvLicenseFirstTimeToolStripMenuItem.Enabled = false;
                sechduleTestToolStripMenuItem.Enabled = false;
                cancelApplicationToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                return false;
            }
           else
           {
                return true;
           }

            
        }
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int PassedTest = (int)dgvListLocalApplications.CurrentRow.Cells["colPassedTests"].Value;
            byte ApplicationStatus = (byte)dgvListLocalApplications.CurrentRow.Cells["colStatus"].Value;
            if(CheckContectMenu(ApplicationStatus))
            {
                switch (PassedTest)
                {
                    case 0:
                        if (PassedTest == 0)
                        {
                            scheduleVisionTestToolStripMenuItem.Enabled = true;
                            scheduleWrittenTestToolStripMenuItem.Enabled = false;
                            scheduleStreetTestToolStripMenuItem.Enabled = false;
                            showLicenseToolStripMenuItem.Enabled = false;
                            showPersonLicenseHistoryToolStripMenuItem.Enabled=false;
                            issueDrivinvLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        }
                        break;
                    case 1:
                        if (PassedTest == 1)
                        {
                            scheduleWrittenTestToolStripMenuItem.Enabled = true;
                            scheduleVisionTestToolStripMenuItem.Enabled = false;
                            scheduleStreetTestToolStripMenuItem.Enabled = false;
                            showLicenseToolStripMenuItem.Enabled = false;
                            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;
                            issueDrivinvLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        }
                        break;
                    case 2:
                        if (PassedTest == 2)
                        {
                            scheduleStreetTestToolStripMenuItem.Enabled = true;
                            scheduleVisionTestToolStripMenuItem.Enabled = false;
                            scheduleWrittenTestToolStripMenuItem.Enabled = false;
                            showLicenseToolStripMenuItem.Enabled=false;
                            showPersonLicenseHistoryToolStripMenuItem.Enabled = false;  
                            issueDrivinvLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        }
                        break;
                    case 3:
                        if (PassedTest == 3)
                        {

                            scheduleVisionTestToolStripMenuItem.Enabled = false;
                            scheduleWrittenTestToolStripMenuItem.Enabled = false;
                            scheduleStreetTestToolStripMenuItem.Enabled = false;
                            issueDrivinvLicenseFirstTimeToolStripMenuItem.Enabled = true;
                            
                        }
                        break;
                }
            }
            
        }
        private void issueDrivinvLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            byte ApplicationStatus = (byte)dgvListLocalApplications.CurrentRow.Cells["colStatus"].Value;
            Form IssueDriving = new frmIssueDrivingLicense(LocalDrivingLicenseApplicationID);
            IssueDriving.ShowDialog();
        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            byte ApplicationStatus = (byte)dgvListLocalApplications.CurrentRow.Cells["colStatus"].Value;
            DialogResult Result = MessageBox.Show("Are you sure you want to delete this application?",
                                      "Confirm",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            if (Result == DialogResult.Yes)
            {
                switch (ApplicationStatus)
                {

                    case 1:
                        clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicense(LocalDrivingLicenseApplicationID);
                        break;
                    case 2:
                        clsLocalDrivingLicenseApplication.DeleteLocalDrivingLicense(LocalDrivingLicenseApplicationID);
                        break;

                  

                }

                MessageBox.Show("Application Delete Successfully", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                return;
            }
           

            _RefrechContactList(true);
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            _License = clsShowLicense.FindLicensebyLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.FirstTime, _License.ApplicationID);
            ShowLicenseInfo.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)dgvListLocalApplications.CurrentRow.Cells["colLDLApplicationID"].Value;
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(LocalDrivingLicenseApplicationID);
            _PersonID = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            Form LicenseHistory = new frmLicenseHistory(frmLicenseHistory.enModeLicense.Local, _PersonID.PersonID);
            LicenseHistory.ShowDialog();

        }
    }
}

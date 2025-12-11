using DVLD.InternationalLicenseApplication_Form;
using DVLD.LocalDrivingTest_Form.LicenseHistory;
using DVLD.Persons_Form;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.InternationalLicenseApplication_Control
{
    public partial class ctrlInternationalLicenseApplications : UserControl
    {
        private clsInterantionalLicenseApp _InternationLicenseApp;
        static DataTable dtInternationLicenseList;
        private clsShowLicense _ShowLicense;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private clsPerson _InfoPerson;
        public ctrlInternationalLicenseApplications()
        {
            InitializeComponent();
        }
        private void _RefrechContactList(bool RefreshDataFromDB = false)
        {
            if(RefreshDataFromDB)
            {
                dtInternationLicenseList = clsInterantionalLicenseApp.GetListInternationlicense();
                dgvListinternationalApplications.DataSource = dtInternationLicenseList;
                lbRecord.Text = dtInternationLicenseList.Rows.Count.ToString();
                dgvListinternationalApplications.Columns["Int.License ID"].FillWeight = 120;
                dgvListinternationalApplications.Columns["Application ID"].FillWeight = 120;
                dgvListinternationalApplications.Columns["L.License ID"].FillWeight = 120;
                dgvListinternationalApplications.Columns["Issue Date"].FillWeight = 180;
                dgvListinternationalApplications.Columns["Expiration Date"].FillWeight = 180;
                dgvListinternationalApplications.Columns["Is Active"].FillWeight = 180;
                cbFilter.SelectedIndex = 0;

            }

        }
        public void ListLicenses()
        {
            _RefrechContactList(true);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFilter.Visible = (cbFilter.Text != "None");
        }
        private void txFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txFilter.Text))
            {
                dtInternationLicenseList.DefaultView.RowFilter = null;
            }
            else
            {
                switch (cbFilter.Text)
                {
                    case "Int.License ID":
                        int Value;
                        if (int.TryParse(txFilter.Text, out Value))
                        {
                            dtInternationLicenseList.DefaultView.RowFilter = "[Int.License ID] = " + Value;
                        }
                        break;
                }
            }
        }
        private void showPersonLicenseHistroryToolStripMenuItem_Click(object sender, EventArgs e)
        {
           int LocalLicenseID = (int)dgvListinternationalApplications.CurrentRow.Cells["L.License ID"].Value;
            _ShowLicense = clsShowLicense.FindLicensebyLicenseID(LocalLicenseID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_ShowLicense.LocalDrivingLicenseApplicationID);
            _InfoPerson = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            Form LicenseHistory = new frmLicenseHistory(frmLicenseHistory.enModeLicense.international, _InfoPerson.PersonID);
            LicenseHistory.ShowDialog();
        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalLicenseID = (int)dgvListinternationalApplications.CurrentRow.Cells["L.License ID"].Value;
            _ShowLicense = clsShowLicense.FindLicensebyLicenseID(LocalLicenseID);
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindApplictionsByID(_ShowLicense.LocalDrivingLicenseApplicationID);
            _InfoPerson = clsPerson.FindByID(_LocalDrivingLicenseApplication.ApplicantPersonID);
            Form frmViewPerson = new FrmPersonDetails(_InfoPerson.PersonID);
            frmViewPerson.ShowDialog();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = (int)dgvListinternationalApplications.CurrentRow.Cells["Driver ID"].Value;
            _InternationLicenseApp = clsInterantionalLicenseApp.FindDriverAndApplicationID(DriverID);
            Form ShowInternationApplications = new frmInternationLicenseApplication(_InternationLicenseApp.InternationalLicenseID);
            ShowInternationApplications.ShowDialog();
        }
    }
}

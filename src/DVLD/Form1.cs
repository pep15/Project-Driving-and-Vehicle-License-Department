using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusineesLayer;
using DVLD.ControlerPerson;
using DVLD.User_Form;
using DVLD.Persons_Form;
using DVLD.ApplicationsTypes_Form;
using DVLD.ManageTestType_Form;
using DVLD.LocalDriving_Form;
using DVLD.LocalDrivingTest_Form.MangeDrivers;
using DVLD.InternationalLicenseApplication_Form;
using DVLD.RenewLicenseApplication_Form;
using DVLD.ReplacementForDamageLicense_Form;
using DVLD.DetainLicense_Form;
using DVLD.DetainAndReleaseLicense_Form;
using DVLD.RenewLicenseApplication_From;

namespace DVLD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPeople = new frmPersons();
            frmPeople.Show();

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUser = new FrmUsers();
            frmUser.Show();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmShowCardUsers = new FrmUserinfo(clsGlobal._Contact.PersonID , clsGlobal._Contact.UserID);
            frmShowCardUsers.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frmChangePaasword = new frmChangePassword(clsGlobal._Contact.PersonID , clsGlobal._Contact.UserID);
            frmChangePaasword.Show();

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmApplicationsType = new Manage_Application_Types();
            FrmApplicationsType.Show();
        }

        private void manageTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form FrmManageTestTypes = new frmList_Test_Types();
            FrmManageTestTypes.Show();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmNewLincenseLocal = new FrmNewLocalDrivingLicenseApplication();
            frmNewLincenseLocal.Show();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLocalLiecenseApplications = new FrmLocalDrivingLicenseApplications();
            frmLocalLiecenseApplications.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frmManageDrivers = new FrmManageDrivers();
            frmManageDrivers.Show();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmInternaionlLicencesApp = new frmInternationlLicenseApplication();
            frmInternaionlLicencesApp.Show();
        }

        private void internationlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmInternationalLicencesList = new FrmInternationlLicenseList();
            frmInternationalLicencesList.Show();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmRenewLicense = new frmRenewLicenseApplication();
            frmRenewLicense.Show();
        }

        private void damagedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDamagedLicense = new frmReplacementForDamageLicense();
            frmDamagedLicense.Show();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmDetainLicenses = new frmDetainLicense();
            frmDetainLicenses.Show();
        }

        private void relaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.Show();

        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmListDetainedLicense = new frmListDetainedLicenses();
            frmListDetainedLicense.Show();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmReleaseLicense = new frmReleaseLicense();
            frmReleaseLicense.Show();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmLocalLiecenseApplications = new FrmLocalDrivingLicenseApplications();
            frmLocalLiecenseApplications.Show();
        }
    }
}

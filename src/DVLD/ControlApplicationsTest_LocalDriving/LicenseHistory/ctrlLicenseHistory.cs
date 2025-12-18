using DVLD.LocalDrivingTest_Form.DriverLicenseInfo;
using DVLD.Persons_Form;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.ControlApplicationsTest_LocalDriving.LicenseHistory
{
    public partial class ctrlLicenseHistory : UserControl
    {
       
     
        private clsPerson _Contact;
        private int _ContnetID;
        static  DataTable dtDriver;
        static DataTable dtInternational;
        private clsDriving _Drivers;
        private clsLicenses _Licenses;
        
        public ctrlLicenseHistory()
        {
            InitializeComponent();
        }
        public ctrlLicenseHistory(int personID)
        {
            InitializeComponent();
            this._ContnetID = personID;
        }
        private void _RefrechContactList(bool RefreshDataFromDB = false)
        {
            if (RefreshDataFromDB)
            {
                dtDriver = clsDriving.ListLicensesDriver(_ContnetID);
                dtInternational = clsInterantionalLicenseApp.GetInternationLicenses(_ContnetID);
                dgvLocal.DataSource = dtDriver;
                dvgInternational.DataSource = dtInternational;

                lbRecord.Text = dtDriver.Rows.Count.ToString();
                lbRecordInternation.Text = dtInternational.Rows.Count.ToString();
                
            }
        }
        private void _FullDataLable(clsPerson _Contacts)
        {
            LbPersonID.Text = _Contacts.PersonID.ToString();
            LbName.Text = _Contacts.FullName();
            lbNational.Text = _Contacts.NationalNo;
            if (_Contacts.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;

            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }

            lbEmail.Text = _Contacts.Email;
            lbAddress.Text = _Contacts.Address;
            lbDateOfBirthDay.Text = _Contacts.DateOfBirth.ToString("d");
            LbPhone.Text = _Contacts.Phone;
            LbCountry.Text = clsCountry.GetCountryName(_Contacts.NationalityCountryID);

            if (_Contacts.ImagePath != "")
            {
                PicImages.Load(_Contacts.ImagePath);
            }
            else
            {
                PicImages.Visible = (_Contacts.ImagePath != null);
            }

        }
        private void frmAddUser_DataBack(object sender, int PersonID)
        {
            txinput.Text = PersonID.ToString();

            cbFilter.SelectedIndex = 0;
            _Contact = clsPerson.FindByID(PersonID);
            if (_Contact != null)
            {
                grbFilter.Enabled = false;
                _FullDataLable(_Contact);
                
            }
            else
            {
                MessageBox.Show("This person does not exist.", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FindPersonLocalLicens(int personID)
        {
            this._ContnetID = personID;
            txinput.Text = personID.ToString();
            cbFilter.SelectedIndex = 0;
            if (txinput.Text == personID.ToString())
            {
                grbFilter.Enabled = false;
                _Contact = clsPerson.FindByID(personID);
                _FullDataLable(_Contact);
                _RefrechContactList(true);
                tacontrol1.SelectedIndex = 0;
            }
        }
        public void FindPersoninternationalLicens(int personID)
        {
            this._ContnetID = personID;
            txinput.Text = personID.ToString();
            cbFilter.SelectedIndex = 0;
            if (txinput.Text == personID.ToString())
            {
                grbFilter.Enabled = false;
                _Contact = clsPerson.FindByID(personID);
                _FullDataLable(_Contact);
                _RefrechContactList(true);
                tacontrol1.SelectedIndex = 1;
            }
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAdd_EditPepole frmAddUser = new frmAdd_EditPepole(_ContnetID);
            frmAddUser.ctrlAddNewPerson1.DataBack += frmAddUser_DataBack;
            frmAddUser.ShowDialog();
        }
        private void ResetControls()
        {
            LbPersonID.Text = "[????]";
            LbName.Text = "[????]";
            lbNational.Text = "[????]";
            lbGendor.Text = "[????]";
            lbEmail.Text = "[????]";
            lbAddress.Text = "[????]";
            lbDateOfBirthDay.Text = "[????]";
            LbPhone.Text = "[????]";
            LbCountry.Text = "[????]";
            PicImages.Image = Properties.Resources.man;

        }
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string NationalNO = "";

            switch (cbFilter.Text)
            {
                case "National No":
                    NationalNO = txinput.Text.Trim();

                    if (string.IsNullOrEmpty(NationalNO))
                    {
                        MessageBox.Show("Please enter a National No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _Contact = clsPerson.FindByNationalID(NationalNO);

                    if (_Contact != null)
                    {
                        _FullDataLable(_Contact);
                        MessageBox.Show($"Person Found: {_Contact.NationalNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txinput.Clear();
                       
                    }
                    else
                    {
                        MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetControls();
                    }
                    break;
                case "PersonID":
                    int Value;
                    if (int.TryParse(txinput.Text, out Value))
                    {
                        _ContnetID = Value;
                    }
                    _Contact = clsPerson.FindByID(_ContnetID);
                    if (_Contact != null)
                    {
                        _FullDataLable(_Contact);
                        MessageBox.Show($"Person Found: {_Contact.PersonID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txinput.Clear();
                       
                    }
                    else
                    {
                        MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetControls();
                    }
                    break;
            }
        }
        private void _FullControlWithDatePersons(clsPerson _Contacts)
        {
            LbPersonID.Text = _Contacts.PersonID.ToString();
            LbName.Text = _Contacts.FullName();
            lbNational.Text = _Contacts.NationalNo;
            if (_Contacts.Gendor == 0)
            {
                lbGendor.Text = "Male";
                PicGendor.Image = Properties.Resources.man;

            }
            else
            {
                lbGendor.Text = "Female";
                PicGendor.Image = Properties.Resources.person_woman;
            }

            lbEmail.Text = _Contacts.Email;
            lbAddress.Text = _Contacts.Address;
            lbDateOfBirthDay.Text = _Contacts.DateOfBirth.ToString("d");
            LbPhone.Text = _Contacts.Phone;
            LbCountry.Text = clsCountry.GetCountryName(_Contacts.NationalityCountryID);

            if (_Contacts.ImagePath != "")
            {
                PicImages.Load(_Contacts.ImagePath);
            }
            else
            {
                PicImages.Visible = (_Contacts.ImagePath != null);
            }
        }
        private void ditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Contact == null)
            {
                MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Form frmUpdate = new FrmUpdateUser(_Contact.PersonID);
                frmUpdate.ShowDialog();

                _Contact = clsPerson.FindByID(_Contact.PersonID);

                _FullControlWithDatePersons(_Contact);
            }
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dgvLocal.CurrentRow.Cells["ApplicationID"].Value;
            _Licenses = clsLicenses.GetLicenseInfoByApplicationID(ApplicationID);

            if(_Licenses.IsActive == false)
            {
                Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.FirstTime, ApplicationID);
                ShowLicenseInfo.ShowDialog();
            }
            else
            {
                Form ShowLicenseInfo = new FrmDriverLicenseInfo(FrmDriverLicenseInfo.enTries.Renewal, ApplicationID);
                ShowLicenseInfo.ShowDialog();
            }
        }
    }
}

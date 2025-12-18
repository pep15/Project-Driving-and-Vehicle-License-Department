using DVLD.Persons_Form;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Control_LocalDriving
{
    public partial class ctrlLocalDeriving : UserControl
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _Mode;
        private int _ContnetID = -1;
        
        private clsPerson _ContactPerson;
        private  DataTable _dtClasseLincenss;
        private clsApplicationTypes _ApplicationsFees;
        private clsLocalDrivingLicenseApplication _DrivingLicenseApplication;
        
        public ctrlLocalDeriving()
        {
            InitializeComponent();
            
        }
        public ctrlLocalDeriving(int PersonID)
        {
            InitializeComponent();
            _ContnetID = PersonID;

            if (_ContnetID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;

        }
        private void AddUser()
        {
            if (_Mode == enMode.Add)
            {

                _ContactPerson = new clsPerson();
                return;
            }
            _FullControlApplicationInfoWithDateUsers();
        }
        private void AddNewLocalApplicatin()
        {
            if (_Mode == enMode.Add)
            {
                _DrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                return;
            }
        }
        private void ctrlLocalDeriving_Load(object sender, EventArgs e)
        {
            
            if (_ContnetID == -1)
            {
                _Mode = enMode.Add;
                cbFilter.SelectedIndex = 1;
                btnNext.Enabled = false;
                tbApplicationInfo.Enabled = false;
                LinkEditPerson.Enabled = false;
                _FullControlApplicationInfoWithDateUsers(); 
                cbClassLincesc.SelectedIndex = 0;
                AddUser();
                AddNewLocalApplicatin();
            }
            else
            {
                _Mode = enMode.Update;
                LoadPersonInfo(_ContnetID);
            }
            


        }
        private void _FullControlApplicationInfoWithDateUsers()
        {
            _ApplicationsFees = clsApplicationTypes.FindID(1);
            cbClassLincesc_SelectedIndexChanged();
            lbDate.Text = DateTime.Now.ToString("d");
            lbfees.Text = _ApplicationsFees.Fees.ToString("0");
            LbcreateBy.Text = clsGlobal._Contact.UserName;
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
        public bool FoundUserForNext()
        {

            clsPerson TempPerson = clsPerson.FindByID(_ContactPerson.PersonID);

            if (TempPerson == null)
            {

                return false;
            }
            else
            {
                if (TempPerson.PersonID == _ContactPerson.PersonID)
                {
                    return true;
                }

            }

            return true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();

        }
        private bool CheckStatusOfLicense(int PersonID)
        {
            return clsLocalDrivingLicenseApplication.checkStatus(_ContactPerson.PersonID, (int)cbClassLincesc.SelectedValue);
        }
        private void LinkEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_ContactPerson == null)
            {
                MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Form frmUpdate = new FrmUpdateUser(_ContactPerson.PersonID);
                frmUpdate.ShowDialog();

                _ContactPerson = clsPerson.FindByID(_ContactPerson.PersonID);

                _FullControlWithDatePersons(_ContactPerson);
            }
        }
        private void UpdatePersonInof()
        {
            if (_Mode == enMode.Update)
            {
                _ContactPerson = clsPerson.FindByID(_ContnetID);

                if (_ContactPerson == null)
                {
                    MessageBox.Show("This person does not exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lbTitle.Text = "Update Users";
                btnNext.Visible = false;
            }

          

            _FullControlWithDatePersons(_ContactPerson);
            cbFilter.SelectedIndex = 0;
            txinput.Text = _ContactPerson.PersonID.ToString();
            grbFilter.Enabled = false;

            _FullControlApplicationInfoWithDateUsers();

        }
        public void LoadPersonInfo(int Person)
        {
            _ContnetID = Person;
            _Mode = enMode.Update;
            UpdatePersonInof();
        }
        private void frmAddUser_DataBack(object sender, int PersonID)
        {
            txinput.Text = PersonID.ToString();

            cbFilter.SelectedIndex = 0;
            _ContactPerson = clsPerson.FindByID(PersonID);
            if (_ContactPerson != null)
            {
                grbFilter.Enabled = false;
                _FullControlWithDatePersons(_ContactPerson);
                btnNext.Enabled = true;
                LinkEditPerson.Enabled = true;
            }
            else
            {
                MessageBox.Show("This person does not exist.", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string NationalNO = "";
            int PersonID = 0;

            switch (cbFilter.Text)
            {
                case "National No":
                    NationalNO = txinput.Text.Trim();

                    if (string.IsNullOrEmpty(NationalNO))
                    {
                        MessageBox.Show("Please enter a National No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    _ContactPerson = clsPerson.FindByNationalID(NationalNO);

                    if (_ContactPerson != null)
                    {
                        _FullControlWithDatePersons(_ContactPerson);
                        MessageBox.Show($"Person Found: {_ContactPerson.NationalNo}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txinput.Clear();
                        btnNext.Enabled = true;
                        LinkEditPerson.Enabled = true;
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
                        PersonID = Value;
                    }
                    _ContactPerson = clsPerson.FindByID(PersonID);
                    if (_ContactPerson != null)
                    {
                        _FullControlWithDatePersons(_ContactPerson);
                        MessageBox.Show($"Person Found: {_ContactPerson.PersonID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txinput.Clear();
                        btnNext.Enabled = true;
                        LinkEditPerson.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Person Not Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ResetControls();
                    }
                    break;
            }
        }
        private void btnAddNewUser_Click_1(object sender, EventArgs e)
        {
            frmAdd_EditPepole frmAddUser = new frmAdd_EditPepole(_ContnetID);
            frmAddUser.ctrlAddNewPerson1.DataBack += frmAddUser_DataBack;
            frmAddUser.ShowDialog();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (FoundUserForNext())
            {
                tabControl1.SelectedIndex = 1;
                tbApplicationInfo.Enabled = true;
            }
        }
        private void cbClassLincesc_SelectedIndexChanged()
        {
            _dtClasseLincenss = clsLocalDriving.GetAllLicenseClassID();
            cbClassLincesc.DataSource = _dtClasseLincenss;
            cbClassLincesc.ValueMember = "LicenseClassID";
            cbClassLincesc.DisplayMember = "ClassName";
        }
        private void _FullObject()
        {
            _DrivingLicenseApplication.ApplicantPersonID = _ContactPerson.PersonID;
            _DrivingLicenseApplication.LicenseClassID = (int)cbClassLincesc.SelectedValue;
            _DrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _DrivingLicenseApplication.ApplicationTypeID = 1; 
            _DrivingLicenseApplication.ApplicationStatus = 1;
            _DrivingLicenseApplication.CreatedByUserID = clsGlobal._Contact.UserID;
            _DrivingLicenseApplication.PaidFees = Convert.ToDecimal(lbfees.Text);
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (CheckHasLicense())
            {
                MessageBox.Show("Person already has a license with the same applied driving class. Choose a different class.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cbClassLincesc.SelectedIndex != -1)
                {
                    if (CheckStatusOfLicense(_ContactPerson.PersonID))
                    {
                        MessageBox.Show($"Choose another License Class, the selected Person Already " +
                            $"have an active application for the selected  with id ={_ContactPerson.PersonID}");
                    }
                    else
                    {
                        _FullObject();
                        if (_DrivingLicenseApplication.AddLocalLicenseApplications())
                        {
                            MessageBox.Show("Data Save Successfully.");
                            lbApplicationsID.Text = _DrivingLicenseApplication.LocalDrivingApplicationID.ToString();
                        }
                        else
                            MessageBox.Show("Error: Data Is not Save Successfully.");
                    }
                }
            }
           
       
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private bool CheckHasLicense()
        {
           return clsDriving.HasLicenses(_ContactPerson.PersonID, (int)cbClassLincesc.SelectedValue);
        }
    }
}

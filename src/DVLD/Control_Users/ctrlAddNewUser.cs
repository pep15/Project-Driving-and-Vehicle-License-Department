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
using DVLD.ControlerPerson;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Messaging;
using System.Drawing.Text;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics.Contracts;
using DVLD.Persons_Form;

namespace DVLD.Control_Users
{
    public partial class ctrlAddNewUser : UserControl
    {
        public enum enMode { Add = 0, Update = 1 };
        private enMode _Mode;
        private int _ContnetID = -1;
        private clsPerson _ContactPerson;
        private clsUser _ContactUser;
        public ctrlAddNewUser()
        {
            InitializeComponent();

        }
        public ctrlAddNewUser(int PersonID)
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

                _ContactUser = new clsUser();
                return;
            }
            _FullControlWithDateUsers(_ContactUser);
        }
        private void _FullControlWithDateUsers(clsUser Contact)
        {
            lbUserID.Text = Contact.UserID.ToString();
            Contact.PersonID = _ContactPerson.PersonID;
            txUserName.Text = Contact.UserName;
            txPassword.Text = Contact.Password;
            txConfirmPass.Text = Contact.Password;
            ChActive.Checked = Contact.IsActive;
        }
        private void ctrlAddNewUser_Load(object sender, EventArgs e)
        {            
            if(_ContnetID == -1)
            {
                _Mode = enMode.Add;
                cbFilter.SelectedIndex = 1;
                btnNext.Enabled = false;
                tbLogininfo.Enabled = false;
                LinkEditPerson.Enabled = false;
                AddUser();
            }
            else 
            {
                _Mode = enMode.Update;
                LoadPersonInfo(_ContnetID);
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
        public bool FoundUserForNext()
        {

            clsUser TempPerson = clsUser.FindByPersonID(_ContactPerson.PersonID);

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
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (FoundUserForNext())
            {
                MessageBox.Show("Selected Person already has a user, choose another one. ", "Select another Person", MessageBoxButtons.OK);
            }
            else
            {
                tabControl1.SelectedIndex = 1;
                tbLogininfo.Enabled = true;

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _ContactUser.UserName = txUserName.Text;
            _ContactUser.Password = txPassword.Text;
            _ContactUser.PersonID = _ContactPerson.PersonID;
            _ContactUser.IsActive = ChActive.Checked;
            if(this.FindForm().ValidateChildren())
            {
                if (_ContactUser.save())
                {
                    MessageBox.Show("Data Save Successfully.");
                    lbUserID.Text = _ContactUser.UserID.ToString();
                }
                else
                    MessageBox.Show("Error: Data Is not Save Successfully.");
            }
        }
        private bool IsMatchesPaasword(string Password)
        {
            Password = txPassword.Text;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=[\]{};':""\\|,.<>/?]).{8,16}$";
            Regex FormatPassword = new Regex(pattern, RegexOptions.IgnoreCase);

            bool IsMatches = FormatPassword.IsMatch(Password);

            return IsMatches;
        }
        private void txConfirmPass_Validating(object sender, CancelEventArgs e)
        {
            string Password = txPassword.Text;
           string ConfirmPassword = txConfirmPass.Text;

            if (string.IsNullOrEmpty(ConfirmPassword))
            {
                e.Cancel = true;
                errorProviderConfirmPasswoerd.SetError(txConfirmPass, "Please enter confirm Password !!");
            }
            else if (Password != ConfirmPassword)
            {
                e.Cancel = true;
                errorProviderConfirmPasswoerd.SetError(txConfirmPass, "Please the password not matches !!");
                errorProviderConfirmPasswoerd.SetError(txPassword, "Please the password not matches !!");
            }
            else
            {
                e.Cancel = false;
                errorProviderConfirmPasswoerd.SetError(txConfirmPass, "");
                errorProviderConfirmPasswoerd.SetError(txPassword, "");
            }
        }
        private void txPassword_Validating(object sender, CancelEventArgs e)
        {
            string Password = txPassword.Text;

            if (string.IsNullOrEmpty(Password))
            {
                e.Cancel = false;
                errorProviderConfirmPasswoerd.SetError(txPassword, "Please enter Password !!");
            }
            else if (!IsMatchesPaasword(Password))
            {
                e.Cancel = true;
                errorProviderConfirmPasswoerd.SetError(txPassword, "The password is not strong.");
            }
            else
            {
                e.Cancel = false;
                errorProviderConfirmPasswoerd.SetError(txPassword, "");
            }

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
            if(_Mode == enMode.Update)
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

            _ContactUser = clsUser.FindByPersonID(_ContactPerson.PersonID);
            
            _FullControlWithDatePersons(_ContactPerson);
            cbFilter.SelectedIndex = 0;
            txinput.Text = _ContactPerson.PersonID.ToString();
            grbFilter.Enabled = false;

            _FullControlWithDateUsers(_ContactUser);

        }
        public void LoadPersonInfo(int Person)
        {
            _ContnetID = Person;
            _Mode = enMode.Update;
            UpdatePersonInof();
        }
        private void frmAddUser_DataBack(object sender , int PersonID)
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
        private void btnSearch_Click(object sender, EventArgs e)
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
                    if(int.TryParse(txinput.Text, out Value))
                    {
                        _ContnetID = Value;
                    }
                    _ContactPerson = clsPerson.FindByID(_ContnetID);
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

       
    }
}

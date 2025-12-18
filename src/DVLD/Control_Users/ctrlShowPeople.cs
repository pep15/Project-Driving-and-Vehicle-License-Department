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

namespace DVLD.Control_Users
{
    public partial class ctrlShowPeople : UserControl
    {
        private clsPerson _Contact;
        private clsUser _User;
        public ctrlShowPeople()
        {
            InitializeComponent();
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
        private void _FullControlWithDateUsers(clsUser _Contact)
        {
            lbUserID.Text = _Contact.UserID.ToString();
            lbUserName.Text = _Contact.UserName;
            if (_Contact.IsActive == true)
            {
                lbActive.Text = "true";
            }
            else
            {
                lbActive.Text = "false";
            }

        }
        public void FindPerson(int personID)
        {
            _Contact = clsPerson.FindByID(personID);
            _FullDataLable(_Contact);
        }
        public void FindUser(int userID)
        {
            _User = clsUser.FindByUserID(userID);
            _FullControlWithDateUsers(_User);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
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

                _FullDataLable(_Contact);
            }
        }

    
    }
}

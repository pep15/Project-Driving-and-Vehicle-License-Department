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

namespace DVLD.ControlerPerson
{
    public partial class ctrlPersonDetails : UserControl
    {
        private clsPerson _persons;
        public ctrlPersonDetails()
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
        public void FindPerson(int personID)
        {
            _persons = clsPerson.FindByID(personID);
            _FullDataLable(_persons);
        }
        private void ditPerson_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frmUpdate = new FrmUpdateUser(_persons.PersonID);
            frmUpdate.ShowDialog();
            FindPerson(_persons.PersonID);
        }
    }
}

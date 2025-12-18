using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Persons_Form;
using DVLD.Properties;
using DVLD_BusineesLayer;
using System.Text.RegularExpressions;
using System.Reflection.Emit;
using System.Drawing.Drawing2D;

namespace DVLD.ControlerPerson
{
    public partial class ctrlAddNewPerson : UserControl
    {

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { Add = 0 , Update=1};
        private enMode _Mode;
        private int _ContactID = -1;
        private clsPerson _Contact;
        public ctrlAddNewPerson()
        {
            InitializeComponent();
        }
        public ctrlAddNewPerson(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if(_ContactID == -1)
                _Mode = enMode.Add;
            else
                _Mode = enMode.Update;

            
        }
        private void _FillCountry()
        {
            DataTable dtContries = clsCountry.GetAllCountry();

            cbCountry.DataSource = dtContries;

            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.SelectedIndex = 149;
        }
        public void FullControlWithDate(clsPerson _Contact)
        {
            lbPersonID.Text = _ContactID.ToString();
            tbFirstName.Text = _Contact.FirstName;
            txSecondName.Text = _Contact.SecondName;
            txThirdName.Text = _Contact.ThirdName;
            txLastName.Text = _Contact.LastName;
            txNationalNo.Text = _Contact.NationalNo;
            if (_Contact.Gendor == 0)
            {
                rdbMale.Checked = true;
               
            }
            else
            {
                rdbFamale.Checked = true;
            }
            rdbFamale.Tag = _Contact.Gendor;
            txEmail.Text = _Contact.Email;
            txAddress.Text = _Contact.Address;
            dtpBirthDay.Value = _Contact.DateOfBirth;
            tbPhone.Text = _Contact.Phone;
            cbCountry.SelectedValue = _Contact.NationalityCountryID;
            
            if (_Contact.ImagePath != "")
            {
                PicBoPersonalImage.Load(_Contact.ImagePath);
            }
            else
            {
                lnkSetImage.Visible = (_Contact.ImagePath != "");
            }
        }
        public void AddPersons()
        {
            _FillCountry();
            cbCountry.SelectedIndex = 149;
            lbRemove.Visible = false;

            if (_Mode == enMode.Add)
            {
                label1.Text = "Add new Person";
                _Contact = new clsPerson();
                return;
            }
            FullControlWithDate(_Contact);
        }
        public void LoadData()
        {
            _FillCountry();
            cbCountry.SelectedIndex = 149;
            
            lbRemove.Visible = true;
             if (_Mode == enMode.Update)
            {
                
                _Contact = clsPerson.FindByID(_ContactID);

                if (_Contact == null)
                {
                    MessageBox.Show("This person does not exist.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                label1.Text = "Update Person Info";
                txNationalNo.Enabled = false;
            }

            FullControlWithDate(_Contact);
            lnkSetImage.Visible = true;

        }
        private void ResetFields()
        {
            lbPersonID.Text = string.Empty;
            tbFirstName.Text = string.Empty;
            txSecondName.Text = string.Empty;
            txThirdName.Text = string .Empty;
            txLastName.Text = string .Empty;
            txNationalNo.Text = string .Empty;
            txEmail.Text = string .Empty;
            txAddress.Text = string .Empty;
            MaxDate();
            cbCountry.SelectedIndex = 149;
            tbPhone.Text = string .Empty;
            rdbMale.Checked = true;
            PicBoPersonalImage.Image = Properties.Resources.man;
            rdbFamale.Checked = false ;
            lbRemove.Visible = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            _Contact.FirstName = tbFirstName.Text;
            _Contact.SecondName = txSecondName.Text;
            _Contact.ThirdName = txThirdName.Text;
            _Contact.LastName = txLastName.Text;
            _Contact.NationalNo = txNationalNo.Text;
            _Contact.Email = txEmail.Text;
            _Contact.Address = txAddress.Text;
            _Contact.DateOfBirth = dtpBirthDay.Value;
            _Contact.Phone = tbPhone.Text;
            _Contact.NationalityCountryID = (int)cbCountry.SelectedValue;
            _Contact.Gendor = Convert.ToInt16( rdbMale.Checked == true);
            _Contact.Gendor = Convert.ToInt16(rdbFamale.Checked == true);
            if (PicBoPersonalImage.ImageLocation != null)
                ManipulateFile();
            else
                _Contact.ImagePath = string.Empty;

            if (this.FindForm().ValidateChildren())
            {
                if (_Contact.save())
                {
                    _ContactID = _Contact.PersonID;
                    MessageBox.Show("Data Save Successfully.");
                    lbPersonID.Text = _Contact.PersonID.ToString();
                   

                    if (_Mode == enMode.Add)
                    {
                        ResetFields();
                    }
                }
                else
                    MessageBox.Show("Error: Data Is not Save Successfully.");
            }
         
        }
        private void MaxDate()
        {
            int Year = -18;
          DateTime DateNow = DateTime.Now.AddYears(Year);
          dtpBirthDay.MaxDate = DateNow;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _ContactID);
            this.FindForm().Close();
        }
        private void ManipulateFile()
        {
            String destinationDir = @"C:\DVLD-Images";
            
            String GuidRnameImage = Guid.NewGuid().ToString() + Path.GetExtension(PicBoPersonalImage.ImageLocation);
            File.Copy( PicBoPersonalImage.ImageLocation,  Path.Combine( destinationDir, GuidRnameImage));
            _Contact.ImagePath = Path.Combine( destinationDir , GuidRnameImage);

        }
        private void lnkSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectdFilePath = openFileDialog1.FileName;
                PicBoPersonalImage.Load(selectdFilePath);
                
            }
        }
        private void lbRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Image tempImage = PicBoPersonalImage.Image;
            tempImage = null;
            PicBoPersonalImage.Dispose();
            PicBoPersonalImage.Image = tempImage;
            File.Delete(_Contact.ImagePath);
            PicBoPersonalImage.ImageLocation = null;
        }
        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            PicBoPersonalImage.Image = Properties.Resources.man;
        }
        private void rdbFamale_CheckedChanged(object sender, EventArgs e)
        {
            PicBoPersonalImage.Image = Properties.Resources.person_woman;
        }
        private void txNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txNationalNo.Text))
            {
                e.Cancel = true;
                txNationalNo.Focus();
                 errorProviderAdd_Edit.SetError(txNationalNo, "Should be insert the Nationality");
                return;
                
            }

            if(_Mode == enMode.Update && txNationalNo.Text.Trim() == _Contact.NationalNo.Trim())
            {
                e.Cancel = false;
                errorProviderAdd_Edit.SetError(txNationalNo, "");
                return; 
            }

            else if (ctrlPeople.isNationalityexisting(txNationalNo.Text))
            {
                e.Cancel = true;
                txNationalNo.Focus();
                errorProviderAdd_Edit.SetError(txNationalNo, "National No is used by another person!");
            }
            else
            {
                e.Cancel = false;
                errorProviderAdd_Edit.SetError(txNationalNo, "");
            }

            
        }
        private bool IsMatches(string Email="Example.@example.com")
        {
          
            string pattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
              + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";
            Regex FormatEmail = new Regex(pattern, RegexOptions.IgnoreCase);

            bool IsMache = FormatEmail.IsMatch(Email);

          return IsMache;

        }
        private void txEmail_Validating(object sender, CancelEventArgs e)
        {

            if(string.IsNullOrEmpty(txEmail.Text) )
            {
                e.Cancel = false ;
                errorProviderAdd_Edit.SetError(txEmail, "");
            }
           else if(!IsMatches(txEmail.Text))
            {
                e.Cancel= true;
                txEmail.Focus();
                errorProviderAdd_Edit.SetError(txEmail, "Invild Email Format");
            }
            else
            {

                e.Cancel = false;
                errorProviderAdd_Edit.SetError(txEmail, "");
               
            }
           
        }
        private void txAddress_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty (txAddress.Text) )
            {
                
                errorProviderAdd_Edit.SetError(txAddress, "Please enter Your Address");
            }
            else
            {
                e.Cancel = false;
                errorProviderAdd_Edit.SetError(txAddress, "");
            }

            
           
        }
        public void LoadPersonInfo(int PersonID)
        {
            _ContactID = PersonID;
            _Mode = enMode.Update;
            LoadData();
           

        }

       
    }
}

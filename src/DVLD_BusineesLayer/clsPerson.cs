using System;
using System.Data;
using System.Runtime.Remoting.Messaging;
using ContactsDataAccessLayer;


namespace DVLD_BusineesLayer
{
   
    public class clsPerson
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }  
        public string LastName { get; set; }
        public string FullName()
        {
           return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public DateTime DateOfBirth { get; set; }
        public short Gendor {  get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }
        
        public clsPerson()
        {
            this.PersonID = -1;
            this.NationalNo = " ";
            this.FirstName = " ";
            this.SecondName = " ";
            this.ThirdName = " ";
            this.LastName = " ";
            this.FullName();
            this.DateOfBirth = DateTime.Now;
           this.Gendor = 0;
            this.Address = " ";
            this.Phone = " ";
            this.Email = " ";
            this.NationalityCountryID = 0;
            this.ImagePath = " ";

            Mode = enMode.AddNew;
        }
        public clsPerson(int PersonID , string NationalNo , string FirstName
            , string SecondName , string ThirdName , string LastName,
           DateTime DateOfBirth , short Gendor , string Address, 
            string Phone , string Email , int NationalityCountryID , string ImagePath)
        {
            this.PersonID = PersonID;
            
           this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.NationalityCountryID = NationalityCountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }
        public static  clsPerson FindByID(int PersonID)
        {
            string NationalNo = "", FirstName = "", SecondName = ""
                , ThirdName = "", LastName = "", Address = "", Phone= "", Email= "", ImagePath = "";

            
            short Gendor = 0;
            int NationalityCountryID = 0;
            DateTime DateOfBirth = DateTime.Now;

            if(ContactsDataAccessLayer.clsDataPerson.GetInfoPersonByID(PersonID,  ref NationalNo, ref FirstName, ref SecondName, ref ThirdName
                , ref LastName, ref DateOfBirth, ref  Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                  return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName
                , LastName, DateOfBirth, Gendor, Address, Phone, Email, NationalityCountryID, ImagePath);
            else
                return null;
        }
        public static clsPerson FindByNationalID(string  NationalNo)
        {
            string  FirstName = "", SecondName = ""
                 , ThirdName = "", LastName = "", Address = "", Phone = "", Email = "", ImagePath = "";
            int PersonID = -1;
            short Gendor = 0;
            int NationalityCountryID = 0; 
            DateTime DateOfBirth = DateTime.Now;

            if (ContactsDataAccessLayer.clsDataPerson.GetInfoPersonByNationalNo(NationalNo, ref PersonID,ref FirstName
                , ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth
                , ref Gendor, ref Address, ref Phone, ref Email, ref NationalityCountryID, ref ImagePath))

                return new clsPerson(PersonID, NationalNo, FirstName
                    , SecondName, ThirdName, LastName, DateOfBirth, Gendor,
                    Address, Phone, Email, NationalityCountryID, ImagePath);

            else return null;
        }
        private bool _AddPerson()
        {
            this.PersonID = ContactsDataAccessLayer.clsDataPerson.AddNewPerson(NationalNo, this.FirstName, this.SecondName, this.ThirdName, 
                this.LastName,this.DateOfBirth, this.Gendor, this.Address, this.Phone, this.Email,this.NationalityCountryID, this.ImagePath);

            return (this.PersonID != -1);
        }
        private bool _UpdatePerson()
        {
            return ContactsDataAccessLayer.clsDataPerson.UpdatePerson(this.PersonID, this.NationalNo
                , this.FirstName, this.SecondName, this.ThirdName, this.LastName, this.DateOfBirth
                , this.Gendor, this.Address, this.Phone, this.Email, this.NationalityCountryID, this.ImagePath);
        }
        public static bool DeletePerson(int PersonID)
        {
            return ContactsDataAccessLayer.clsDataPerson.DeletePerson(PersonID);
        }
        public static DataTable GetAllPersons()
        {
            return ContactsDataAccessLayer.clsDataPerson.GetPersons();
        }
        public static bool IsTherePersonID(int PersonID)
        {
            return ContactsDataAccessLayer.clsDataPerson.PersonIDIsExist(PersonID);
        }
        public static bool IsTherePersonNationalID(string NationalNo)
        {
            return ContactsDataAccessLayer.clsDataPerson.PersonIsExistbyNational(NationalNo);
        }
        public bool save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }

            return false;
        }

        

    }
}

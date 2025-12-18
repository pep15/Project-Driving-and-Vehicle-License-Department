using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using ContactsDataAccessLayer;

namespace DVLD_BusineesLayer
{
    public class clsUser
    {
        public enum enMode { AddNew = 1, Update = 2 };
        public enMode Mode = enMode.AddNew;

        public int UserID {  get; set; }
        public int PersonID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.Password = "";
            this.UserName = "";
            this.IsActive = false;

            Mode = enMode.AddNew;
        }
        public clsUser(int UserID ,  int PersonID , string UserName , string Password,  bool IsActive)
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.UserName = UserName;
            this.Password = Password;
            this.IsActive = IsActive;
            Mode = enMode.Update;
        }
        public static clsUser FindByUserID(int UserID)
        {
            int personID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if(ContactsDataAccessLayer.clsDataUser.GetInfoUsersID(UserID , ref personID , ref UserName ,ref Password, ref IsActive))

                    return new clsUser(UserID, personID, UserName, Password,IsActive);
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "";
            string Password = "";
            bool IsActive = false;

            if (ContactsDataAccessLayer.clsDataUser.GetInfoPersonID(ref UserID , PersonID,  ref UserName, ref Password,ref IsActive))

                return new clsUser(UserID, PersonID,  UserName, Password,IsActive);
            else
                return null;
        }
        public static clsUser FindByUserName(string UserName)
        {
            int personID = -1;
            int UserID = -1;
            string Password = "";
            bool IsActive = false;

            if (ContactsDataAccessLayer.clsDataUser.GetInofUserByUserName(ref UserID, ref personID, UserName, ref Password,ref IsActive))

                return new clsUser(UserID, personID, UserName, Password,IsActive);
            else
                return null;
        }
        static public bool isActive(bool IsActive)
        {
            return (ContactsDataAccessLayer.clsDataUser.IsActive(IsActive));
        }
        private bool _AddNewUser()
        {
            this.UserID = ContactsDataAccessLayer.clsDataUser.AddNewUser(this.PersonID , this.UserName , this.Password , this.IsActive);

            return (this.UserID != -1);
        }
        private bool _UpdateUsers()
        {
            return (ContactsDataAccessLayer.clsDataUser.UpdateUser(this.UserID, this.PersonID, this.UserName, this.Password, this.IsActive));
        }
        static public DataTable GetAllUsers()
        {
            return ContactsDataAccessLayer.clsDataUser.GetAllUser();
        }
        static public bool DeleteUsers(int UserID)
        {
            return (ContactsDataAccessLayer.clsDataUser.DeleteUsers(UserID));
        }
        public static bool IsUserExsist(int UserID)
        {
            return (ContactsDataAccessLayer.clsDataUser.IsUserIDExsit(UserID));
        }
        public static clsUser UserNameAndPasswordExsits(string UserName , string Password)
        {
            
           if(ContactsDataAccessLayer.clsDataUser.IsUserNameAndPasswordExsit(UserName , Password))
            {
                return FindByUserName(UserName);
            }
           else
            {
                return null;
            }
        }
        public bool save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    if(_AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUsers();
            }

            return false;
        }

    }
}

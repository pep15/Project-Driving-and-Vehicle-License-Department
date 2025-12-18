using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsDetainLicense
    {
 
       public int PersonID { get; set; }
       public string NationalNo { get; set; }
       public string FullName { get; set; }
       public DateTime DateOfBirth { get; set; }
        public byte Gendor { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
       public int  ApplicantPersonID { get; set; }
       public DateTime ApplicationDate { get; set; }
       public int ApplicationTypeID { get; set; }
       public int ApplicationStatus { get; set; }
       public DateTime LastStatusDate { get; set; }
       public decimal PaidFees { get; set; }
       public int DetainID { get; set; }
       public int LicenseID { get; set; }
       public DateTime DetainDate { get; set; }
       public decimal FineFees { get; set; }
       public int CreatedByUserID { get; set; }
       public bool IsReleased { get; set; }
       public DateTime ReleaseDate { get; set; }
       public int ReleasedByUserID { get; set; }
       public int ReleaseApplicationID { get; set; }

        public clsDetainLicense ()
       {
            this.PersonID = -1;
            this.NationalNo = "";
            this.FullName = "";
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
            this.Address = "";
            this.Phone = "";
            this.Email = "";
            this.ImagePath = "";
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = -1;
            this.LastStatusDate = DateTime.MinValue;
            this.DetainID = -1;
            this.LicenseID = -1;
            this.DetainDate = DateTime.MinValue;
            this.FineFees = 0;
            this.CreatedByUserID = -1;
            this.IsReleased = false;    
            this.ReleaseDate = DateTime.MinValue;
            this.ReleasedByUserID = -1;
            this.ReleaseApplicationID = -1;
       }
        public clsDetainLicense(int LicenseID, int DetainID,DateTime DetainDate,decimal FineFees,int CreatedByUserID,bool IsReleased,DateTime ReleaseDate,int ReleasedByUserID,int ReleaseApplicationID)
        {
            this.LicenseID = LicenseID;
            this.DetainID = DetainID;
            this.DetainDate = DetainDate;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsReleased = IsReleased;
            this.ReleaseDate = ReleaseDate;
            this.ReleasedByUserID = ReleasedByUserID;
            this.ReleaseApplicationID = ReleaseApplicationID;
        }

        public clsDetainLicense(int LicenseID,  int PersonID,  string NationalNo,
             string FullName,  DateTime DateOfBirth,  byte Gendor
            ,  string Address,  string Phone,  string Email,  string ImagePath)
        {
            this.LicenseID = LicenseID;
            this.PersonID = PersonID;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
        }
        static public clsDetainLicense GetDetainLicensesID(int LicenseID)
        {

            int DetainID = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = -1;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;
            if(clsAccessDetainLicense.GetDetainLicensesID(LicenseID, ref DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
                return new clsDetainLicense(LicenseID, DetainID, DetainDate, FineFees, CreatedByUserID, IsReleased
                , ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }
        static public clsDetainLicense GetDetainsID(int DetainID)
        {

            int LicenseID = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = -1;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime ReleaseDate = DateTime.MinValue;
            int ReleasedByUserID = -1;
            int ReleaseApplicationID = -1;
            if (clsAccessDetainLicense.GetDetainsID(ref LicenseID,  DetainID, ref DetainDate, ref FineFees, ref CreatedByUserID,
                ref IsReleased, ref ReleaseDate, ref ReleasedByUserID, ref ReleaseApplicationID))
                return new clsDetainLicense(LicenseID, DetainID, DetainDate, FineFees, CreatedByUserID, IsReleased
                , ReleaseDate, ReleasedByUserID, ReleaseApplicationID);
            else
                return null;
        }
        public bool AddDetainLicense(int LicenseID, decimal FineFees , int CreatedByUserID)
        {
            this.LicenseID = LicenseID;
            this.FineFees = FineFees;
            this.CreatedByUserID = CreatedByUserID;
            this.DetainDate = DateTime.Now;


            this.DetainID = (clsAccessDetainLicense.AddDetainLicense(this.LicenseID, this.DetainDate, this.FineFees, this.CreatedByUserID,
               this.IsReleased , this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID));

            return (this.DetainID != -1);

        }
        public bool IsFoundDetainLicense(int LicenseID , bool IsReleased)
        {
            return clsAccessDetainLicense.IsFoundDetainLicense(LicenseID , IsReleased);
        }
        public  bool AddReleaseDetainLicense( int CreatedByUserID  , int ApplicantPersonID , decimal PaidFees)
        {
            
            this.ReleasedByUserID = CreatedByUserID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationTypeID = 5;
            this.ApplicationStatus = 3;
            this.PaidFees = PaidFees;
            this.IsReleased = true;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.ReleaseDate = DateTime.Now;



            int ApplicationID = (clsAccessDetainLicense.AddReleaseDetainLicense(this.LicenseID, this.ApplicantPersonID
                , this.ApplicationDate, this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate
                , this.PaidFees, this.CreatedByUserID, this.IsReleased, this.FineFees, this.ReleaseDate, this.ReleasedByUserID, this.ReleaseApplicationID));

            this.ReleaseApplicationID = ApplicationID;

            return (ReleaseApplicationID != -1);
        }
        static public  DataTable GetDetainLicenses()
        {
           return (clsAccessDetainLicense.GetDetainLicenses());
        }

         static public clsDetainLicense GetPersonDetails(int LicenseID)
         {
            int PersonID = -1;
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            string Address = string.Empty;
            string Phone = string.Empty;
            string Email = string.Empty;
            string ImagePath = string.Empty;
            if (clsAccessDetainLicense.GetPersonDetails(LicenseID, ref PersonID
                , ref NationalNo, ref FullName, ref DateOfBirth, ref Gendor, ref Address, ref Phone, ref Email, ref ImagePath))
                return new clsDetainLicense(LicenseID, PersonID, NationalNo, FullName, DateOfBirth, Gendor, Address, Phone, Email, ImagePath);
            else
                return null;
         }
    }
}

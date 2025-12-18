using ContactsDataAccessLayer;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusineesLayer
{
    public class clsLicenses
    {
      
        public int LicensesID {  get; set; }
        public int ApplicantPersonID { get; set;}
        public string NationalNo { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public int IssueReason { get; set; }
        public decimal PaidFees { get; set; }
        public decimal ClassFees { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public byte Gendor { get; set; }
        public int CreatedByUserID { get; set; }
        public string Notes { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ImagePath { get; set; }
        public bool IsActive { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int ApplicationTypeID { get; set;}
        public int ApplicationStatus {get; set;}

        public clsLicenses()
        {
          this.LicensesID = -1;
          this.ApplicantPersonID = -1;
          this.NationalNo = string.Empty;
          this.ApplicationID = -1;
          this.DriverID = -1;
          this.LicenseClass = -1;
          this.IssueReason = 0;
          this.PaidFees = 0;
          this.ClassFees = 0;
          this.ClassName = string.Empty;
          this.FullName= string.Empty;
          this.Gendor = 0;
          this.CreatedByUserID = -1;
          this.Notes= string.Empty;
          this.DateOfBirth = DateTime.MinValue;
          this.IssueDate= DateTime.MinValue;
          this.ExpirationDate= DateTime.MinValue;
          this.ImagePath= string.Empty;
          this.IsActive = false;
          this.LastStatusDate = DateTime.MinValue;
          this.ApplicationDate = DateTime.MinValue;
          this.ApplicationTypeID = -1;

        }
        public clsLicenses(int ApplicantPersonID, int LicensesID, int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate
            , DateTime ExpirationDate, string Notes, decimal PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            this.ApplicantPersonID = ApplicantPersonID;
            this.LicensesID= LicensesID;
            this.ApplicationID= ApplicationID;
            this.DriverID= DriverID;
            this.LicenseClass= LicenseClass;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
        }
        public clsLicenses(int LicenseID,  int ApplicantPersonID,  string NationalNo, int ApplicationID , int DriverID, int LicenseClass,
             int IssueReason,  decimal PaidFees,decimal  ClassFees, string ClassName,
             string FullName,  byte Gendor,  int CreatedByUserID,  string Notes, DateTime DateOfBirth,  DateTime IssueDate,
              DateTime ExpirationDate,  string ImagePath,  bool IsActive)
        {
            
            this.LicensesID = LicenseID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.NationalNo = NationalNo;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.ClassFees = ClassFees;
            this.ClassName = ClassName;
            this.FullName = FullName;
            this.Gendor = Gendor;
            this.CreatedByUserID = CreatedByUserID;
            this.Notes = Notes;
            this.DateOfBirth = DateOfBirth;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.ImagePath = ImagePath;
            this.IsActive = IsActive;
        }
        public clsLicenses(int ApplicationID, int LicenseID, int ApplicantPersonID, string NationalNo,  int DriverID, int LicenseClass,
            int IssueReason, decimal PaidFees, decimal ClassFees, string ClassName,
            string FullName, byte Gendor, int CreatedByUserID, string Notes, DateTime DateOfBirth, DateTime IssueDate,
             DateTime ExpirationDate, string ImagePath, bool IsActive)
        {

            this.LicensesID = LicenseID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.NationalNo = NationalNo;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClass = LicenseClass;
            this.IssueReason = IssueReason;
            this.PaidFees = PaidFees;
            this.ClassFees = ClassFees;
            this.ClassName = ClassName;
            this.FullName = FullName;
            this.Gendor = Gendor;
            this.CreatedByUserID = CreatedByUserID;
            this.Notes = Notes;
            this.DateOfBirth = DateOfBirth;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.ImagePath = ImagePath;
            this.IsActive = IsActive;
        }
        public bool AddNewLicenses()
        {
            this.LicensesID = (clsAccessLicenses.AddNewLicenses(this.ApplicationID, this.DriverID
                , this.LicenseClass, this.IssueDate, this.ExpirationDate, this.Notes
                , this.PaidFees, this.IsActive, this.IssueReason, this.CreatedByUserID));

            return (LicensesID != -1);
        }
        public bool AddNewRenewLicenses(string Notes, decimal PaidFees, int CreatedByUserID)
        {
            this.IssueDate = DateTime.Now;
            this.IssueReason = 2;
            this.ExpirationDate = DateTime.Now.AddYears(10);
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.Notes = Notes;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationTypeID = 2;
            this.IssueReason = 2;
            this.IsActive = true;
            this.ApplicationStatus = 3;

            int AppID = 0;
            int newLicensesID = (clsAccessLicenses.AddNewRenewLicenses(this.LicensesID, out AppID,  this.ApplicantPersonID, this.ApplicationDate, 
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.DriverID, this.LicenseClass, this.IssueDate
            , this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive ? (byte)1 : (byte)0 , this.IssueReason, this.CreatedByUserID));

            this.LicensesID = newLicensesID;
            this.ApplicationID = AppID;
            return (this.LicensesID != -1);
        }
        static public clsLicenses GetLicenseInfoByLicensesID(int LicensesID)
        {


            int ApplicationID = -1;
            int ApplicantPersonID = -1;
            string NationalNo = string.Empty;
            int DriverID = -1;  
            int LicenseClass = -1;
            int IssueReason = 0;
            decimal PaidFees = 0;
            string ClassName = string.Empty;
            string FullName = string.Empty;
            byte Gendor = 0;
            int CreatedByUserID = -1;
            string Notes = string.Empty;
             DateTime DateOfBirth = DateTime.MinValue;
            DateTime IssueDate = DateTime.MinValue;
             DateTime ExpirationDate = DateTime.MinValue;   
             string ImagePath = string.Empty;
             bool IsActive = false;
            decimal ClassFees = 0;

            if (clsAccessLicenses.GetLicenseInfoByLicensesID(LicensesID , ref ApplicantPersonID , ref NationalNo 
                , ref ApplicationID , ref DriverID , ref LicenseClass , ref IssueReason , 
                ref PaidFees , ref ClassFees, ref ClassName , ref FullName , ref Gendor ,
                ref CreatedByUserID , ref Notes , ref DateOfBirth,ref IssueDate , ref ExpirationDate , ref ImagePath , ref IsActive))
                return new clsLicenses(LicensesID , ApplicantPersonID , NationalNo , ApplicationID , DriverID, LicenseClass
                    , IssueReason , PaidFees,ClassFees, ClassName , FullName , Gendor , CreatedByUserID 
                    , Notes , DateOfBirth , IssueDate , ExpirationDate , ImagePath , IsActive);
            else
                return null;
        }
        static public clsLicenses GetLicenseInfoByApplicationID(int ApplicationID)
        {
            int LicensesID = -1;
            int ApplicantPersonID = -1;
            string NationalNo = string.Empty;
            int DriverID = -1;
            int LicenseClass = -1;
            int IssueReason = 0;
            decimal PaidFees = 0;
            string ClassName = string.Empty;
            string FullName = string.Empty;
            byte Gendor = 0;
            int CreatedByUserID = -1;
            string Notes = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string ImagePath = string.Empty;
            bool IsActive = false;
            decimal ClassFees = 0;

            if (clsAccessLicenses.GetLicenseInfoByApplicationID(ApplicationID,ref LicensesID, ref ApplicantPersonID, ref NationalNo
                , ref DriverID, ref LicenseClass, ref IssueReason,
                ref PaidFees, ref ClassFees, ref ClassName, ref FullName, ref Gendor,
                ref CreatedByUserID, ref Notes, ref DateOfBirth, ref IssueDate, ref ExpirationDate, ref ImagePath, ref IsActive))
                return new clsLicenses(ApplicationID, LicensesID, ApplicantPersonID, NationalNo,  DriverID, LicenseClass
                    , IssueReason, PaidFees, ClassFees, ClassName, FullName, Gendor, CreatedByUserID
                    , Notes, DateOfBirth, IssueDate, ExpirationDate, ImagePath, IsActive);
            else
                return null;
        }

        public bool ReplecementDamage(string Notes, decimal PaidFees, int IssueReason, int ApplicationTypeID, DateTime ExpirationDate, int CreatedByUserID)
        {
            this.IssueDate = DateTime.Now;
            this.IssueReason = IssueReason;
            this.ExpirationDate = ExpirationDate;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.IsActive = true;
            this.ApplicationStatus = 3;

            int AppID = 0;
            int newLicensesID = (clsAccessLicenses.AddNewRenewLicenses(this.LicensesID, out AppID, this.ApplicantPersonID, this.ApplicationDate,
                this.ApplicationTypeID, this.ApplicationStatus, this.LastStatusDate, this.DriverID, this.LicenseClass, this.IssueDate
            , this.ExpirationDate, this.Notes, this.PaidFees, this.IsActive ? (byte)1 : (byte)0, this.IssueReason, this.CreatedByUserID));

            this.LicensesID = newLicensesID;
            this.ApplicationID = AppID;
            return (this.LicensesID != -1);

        }
    }
}

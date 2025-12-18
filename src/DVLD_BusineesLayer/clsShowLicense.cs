using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusineesLayer
{
    public class clsShowLicense
    {
        public int ApplicationID { get; set; }
        public  int ApplicantPersonID { get; set; }
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int LicenseID {  get; set; }
        public int DriverID {  get; set; }
        public string NationalNo { get; set; }
        public int LicenseClass {  get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public bool IsActive {  get; set; }
        public byte IssueReason {  get; set; }
        public string ClassName {  get; set; }
        public string ImagePath { get; set; }
        public decimal ClassFees { get; set; }
        public int numberOfClasses { get; set; }
        public clsShowLicense()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.ApplicationID = -1;
            this.LicenseID = -1;
            this.DriverID = -1;
            this.NationalNo = string.Empty;
            this.LicenseClass = -1;
            this.FullName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.Notes = string.Empty;
            this.IsActive = false;
            this.IssueReason = 0;
            this.ClassName = string.Empty;
            this.ImagePath = string.Empty;
            this.ApplicantPersonID = -1;
            this.ClassFees = 0;
            this.numberOfClasses = 0;
        }

        public clsShowLicense(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseID, int DriverID
                , string NationalNo, string FullName, DateTime DateOfBirth, byte Gendor,
                DateTime IssueDate, DateTime ExpirationDate, string Notes, bool IsActive, byte IssueReason, string ClassName, string ImagePath , int numberOfClasses)
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseID= LicenseID;
            this.DriverID= DriverID;
            this.NationalNo= NationalNo;
            this.FullName= FullName;
            this.DateOfBirth= DateOfBirth;
            this.Gendor= Gendor;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.ClassName = ClassName;
            this.ImagePath = ImagePath;
            this.numberOfClasses = numberOfClasses;


        }
        public clsShowLicense(int ApplicationID, int LocalDrivingLicenseApplicationID, int LicenseID
            , int DriverID, string NationalNo, string FullName, DateTime DateOfBirth,
             byte Gendor, DateTime IssueDate, DateTime ExpirationDate,
             string Notes, bool IsActive, byte IssueReason, string ClassName, string ImagePath )
        {
            this.ApplicationID = ApplicationID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.LicenseID = LicenseID;
            this.DriverID = DriverID;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.IsActive = IsActive;
            this.IssueReason = IssueReason;
            this.ClassName = ClassName;
            this.ImagePath = ImagePath;

        }
        public clsShowLicense(int ApplicantPersonID, int LicenseID)
        {
           this.ApplicantPersonID= ApplicantPersonID;
           this.LicenseID = LicenseID;
        }
        public clsShowLicense(int LicenseID,  int LocalDrivingLicenseApplicationID
           ,  int DriverID,  string NationalNo,  int LicenseClass,  byte IssueReason,  string ClassName,  decimal ClassFees,  string FullName,  DateTime DateOfBirth,
            byte Gendor,  DateTime IssueDate,  DateTime ExpirationDate,
            string Notes,  string ImagePath,  bool IsActive)
        {
            this.LicenseID = LicenseID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.DriverID = DriverID;
            this.NationalNo = NationalNo;
            this.LicenseClass = LicenseClass;
            this.IssueReason = IssueReason;
            this.ClassName = ClassName;
            this.ClassFees = ClassFees;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.ImagePath = ImagePath;
            this.IsActive = IsActive;

        }

        static public clsShowLicense FindLicensebyLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID )
        {
            int LicenseID = -1;
            int ApplicationID = -1;
            int DriverID = -1;
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            bool IsActive = false;
            byte IssueReason =  0;
            string ClassName = string.Empty;
            string ImagePath = string.Empty;

            if (clsAccessShowLicense.FindLicensebyLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID, ref ApplicationID,ref LicenseID, ref DriverID
                , ref NationalNo, ref FullName, ref DateOfBirth, ref Gendor,
                ref IssueDate, ref ExpirationDate, ref Notes, ref IsActive, ref IssueReason, ref ClassName, ref ImagePath))
                return new clsShowLicense(LocalDrivingLicenseApplicationID ,ApplicationID, LicenseID , 
                    DriverID , NationalNo , FullName, DateOfBirth,Gendor , IssueDate 
                    , ExpirationDate , Notes , IsActive 
                    , IssueReason , ClassName , ImagePath , 0);
            else
                return null;
        }
      

        static public clsShowLicense FindLicensebyApplicationID(int ApplicationID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int LicenseID = -1;
            int DriverID = -1;
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            bool IsActive = false;
            byte IssueReason = 0;
            string ClassName = string.Empty;
            string ImagePath = string.Empty;

            if (clsAccessShowLicense.FindLicensebyApplicationID(ApplicationID,ref LocalDrivingLicenseApplicationID, ref LicenseID, ref DriverID
                , ref NationalNo, ref FullName, ref DateOfBirth, ref Gendor,
                ref IssueDate, ref ExpirationDate, ref Notes, ref IsActive, ref IssueReason, ref ClassName, ref ImagePath))
                return new clsShowLicense(ApplicationID,LocalDrivingLicenseApplicationID, LicenseID,
                    DriverID, NationalNo, FullName, DateOfBirth, Gendor, IssueDate
                    , ExpirationDate, Notes, IsActive
                    , IssueReason, ClassName, ImagePath);
            else
                return null;
        }


        static public clsShowLicense FindLicensebyLicenseID(int LicenseID)
        {
            int LocalDrivingLicenseApplicationID = -1;
            int DriverID = -1;
            string NationalNo = string.Empty;
            int LicenseClass = -1;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            decimal ClassFees = 0;
            byte Gendor = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            bool IsActive = false;
            byte IssueReason = 0;
            string ClassName = string.Empty;
            string ImagePath = string.Empty;

            if (clsAccessShowLicense.FindLicensebyLicenseID(LicenseID, ref LocalDrivingLicenseApplicationID
           , ref DriverID, ref NationalNo, ref LicenseClass, ref IssueReason, ref ClassName, ref ClassFees, ref FullName, ref DateOfBirth,
             ref Gendor, ref IssueDate, ref ExpirationDate, ref Notes, ref ImagePath, ref IsActive))
                return new clsShowLicense( LicenseID,  LocalDrivingLicenseApplicationID
           ,  DriverID,  NationalNo,  LicenseClass,  IssueReason,  ClassName,  ClassFees,  FullName,  DateOfBirth,
             Gendor,  IssueDate,   ExpirationDate,Notes,  ImagePath,  IsActive);
            else
                return null;
        }
        static public clsShowLicense FindLicensebyPersonID(int ApplicantPersonID)
        {
            int LicenseID = -1;

            if (clsAccessShowLicense.FindLicensebyPersonID(ApplicantPersonID, ref LicenseID))
                return new clsShowLicense(ApplicantPersonID, LicenseID);
            else
                return null;
        }
    }
}

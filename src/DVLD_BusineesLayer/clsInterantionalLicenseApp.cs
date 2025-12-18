using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusineesLayer
{
    public class clsInterantionalLicenseApp
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public byte ApplicationStatus { get; set; }
        public int ApplicationTypeID { get; set; }
        public DateTime LastStatusDate { get; set; }
        public  decimal PaidFees { get; set; }
        public int LicensesID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID {  get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public string NationalNo {  get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte Gendor {  get; set; }
        public int CreatedByUserID { get; set; }
        public string ImagePath { get; set; }
        public clsInterantionalLicenseApp()
        {
            this.InternationalLicenseID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.MinValue;
            this.ApplicationStatus = 0;
            this.ApplicationTypeID = -1;
            this.LastStatusDate = DateTime.MinValue;
            this.PaidFees = 0;
            this.LicensesID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.IssuedUsingLocalLicenseID = -1;
            this.IssueDate = DateTime.MinValue;
            this.ExpirationDate = DateTime.MinValue;
            this.IsActive = false;
            this.CreatedByUserID = -1;
            this.NationalNo = string.Empty;
            this.FullName = string.Empty;
            this.DateOfBirth = DateTime.MinValue;
            this.Gendor = 0;
        }
        public clsInterantionalLicenseApp(int InternationalLicenseID,  int ApplicationID,  int DriverID,  int IssuedUsingLocalLicenseID, int ApplicantPersonID, 
            DateTime IssueDate,  DateTime ExpirationDate,  bool IsActive,  string NationalNo,  string FullName,  DateTime DateOfBirth,
             byte Gendor,  string ImagePath)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID= IssuedUsingLocalLicenseID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive=IsActive;
            this.NationalNo=NationalNo;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.ImagePath = ImagePath;
        }
        public clsInterantionalLicenseApp(int InternationalLicenseID, int ApplicationID, int DriverID,
            int IssuedUsingLocalLicenseID,DateTime IssueDate,DateTime ExpirationDate,bool IsActive, string NationalNo
            , string FullName, DateTime DateOfBirth, byte Gendor , string ImagePath)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.DateOfBirth = DateOfBirth;
            this.Gendor = Gendor;
            this.ImagePath = ImagePath;
        }
         public bool AddnewInterantionalLicense()
         {
            int AppID = -1;
            this.LicensesID = (ClsAccessInterantionalLicenseApp.AddnewInterantionalLicense(out AppID, this.ApplicantPersonID,this.ApplicationDate,this.ApplicationTypeID
            , this.ApplicationStatus, this.LastStatusDate, this.PaidFees,this.DriverID,this.IssuedUsingLocalLicenseID
            , this.IssueDate, this.ExpirationDate, this.IsActive,this.CreatedByUserID));
            this.ApplicationID = AppID;
            return (this.LicensesID != -1);
         }
        static public clsInterantionalLicenseApp FindLicenseAndApplicationID(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            int ApplicantPersonID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            string ImagePath = string.Empty;

            if (ClsAccessInterantionalLicenseApp.FindLicenseAndApplicationID(InternationalLicenseID 
                , ref ApplicationID , ref DriverID , ref IssuedUsingLocalLicenseID 
                , ref ApplicantPersonID , ref IssueDate 
                , ref ExpirationDate , ref IsActive , ref NationalNo
                , ref FullName , ref DateOfBirth , ref Gendor , ref ImagePath))
                return new clsInterantionalLicenseApp(InternationalLicenseID, ApplicationID, DriverID
                    , IssuedUsingLocalLicenseID, ApplicantPersonID, IssueDate, ExpirationDate
                    , IsActive, NationalNo, FullName, DateOfBirth, Gendor , ImagePath);
            else
                return null;

        }
        static public clsInterantionalLicenseApp FindDriverAndApplicationID(int DriverID )
        {
            int ApplicationID = -1;
            int InternationalLicenseID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            string NationalNo = string.Empty;
            string FullName = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gendor = 0;
            string ImagePath = string.Empty;

            if (ClsAccessInterantionalLicenseApp.FindDriverAndApplicationID(DriverID , ref ApplicationID , ref InternationalLicenseID,
               ref IssuedUsingLocalLicenseID , ref IssueDate , ref ExpirationDate , ref IsActive,
               ref NationalNo , ref FullName , ref DateOfBirth , ref Gendor , ref ImagePath))
                return new clsInterantionalLicenseApp(InternationalLicenseID, ApplicationID, DriverID
                    , IssuedUsingLocalLicenseID, IssueDate, ExpirationDate
                    , IsActive, NationalNo, FullName, DateOfBirth, Gendor, ImagePath);
            else
                return null;

        }
        public bool HasInternationLicense(int DriverID, int ApplicationTypeID)
        {
            return (ClsAccessInterantionalLicenseApp.HasInternationLicense(DriverID, ApplicationTypeID));
        }
        static public DataTable GetInternationLicenses(int ApplicantPersonID)
        {
            return (ClsAccessInterantionalLicenseApp.GetInternationLicenses(ApplicantPersonID));
        }
        static public DataTable GetListInternationlicense()
        {
            return (ClsAccessInterantionalLicenseApp.GetListInternationlicense());
        }
    }
}

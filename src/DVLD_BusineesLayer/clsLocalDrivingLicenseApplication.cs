using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusineesLayer
{
    public class clsLocalDrivingLicenseApplication
    {
     
       public int LocalDrivingApplicationID { get; set; }
        public byte ApplicationStatus {  get; set; }
       public int ApplicationID { get; set; }
       public int ApplicantPersonID { get; set; }
       public int ApplicationTypeID { get; set; }
        public int LicenseClassID { get; set; }
        public int CreatedByUserID { get; set; }
        public string ClassName {  get; set; }
        public string NationalNo {  get; set; }
        public string FirstName {  get; set; }
        public string SecondName {  get; set; }
        public string ThirdName {  get; set; }
        public string LastName {  get; set; }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public DateTime ApplicationDate {  get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int TestResult { get; set; }
       
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingApplicationID = 0;
            this.ApplicationID = 0;
            this.ApplicantPersonID = 0;
            this.ApplicationTypeID = 0;
            this.LicenseClassID = 0;
            this.CreatedByUserID = 0;
            this.ClassName = "";
            this.NationalNo = "";
            this.FirstName = "";
            this.SecondName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.FullName();
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.TestResult = 0;
            this.ApplicationStatus = 0;
        }
        public clsLocalDrivingLicenseApplication(int LocalDrivingApplicationID , int ApplicationID, int ApplicantPersonID , int ApplicationTypeID , int LicenseClassID , int CreatedByUserID, string ClassName , string NationalNo 
            , string FirstName , string SecondName , string ThirdName , string LastName , DateTime ApplicationDate , DateTime LastStatusDate,  int TestResult, decimal PaidFees, byte ApplicationStatus)
        {
            this.LocalDrivingApplicationID= LocalDrivingApplicationID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID= ApplicantPersonID;
            this.ApplicationTypeID= ApplicationTypeID;
            this.LicenseClassID= LicenseClassID;
            this.CreatedByUserID= CreatedByUserID;
            this.ClassName = ClassName;
            this.NationalNo = NationalNo;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.ApplicationDate = ApplicationDate;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.TestResult = TestResult;
            this.ApplicationStatus = ApplicationStatus;
            
        }
        public static clsLocalDrivingLicenseApplication FindApplictionsByID(int LocalDrivingApplicationID )
        {
            int ApplicationID = -1;
            int ApplicantPersonID = 0;
            int ApplicationTypeID = 0;
            int LicenseClassID = 0;
            int CreatedByUserID = 0;
            string ClassName = "";
            string NationalNo = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime ApplicationDate = DateTime.Now;
            DateTime LastStatusDate = DateTime.Now;
            decimal PaidFees = 0;
            int TestResult = 0;
            byte ApplicationStatus = 0;


            if (clsDataAccessLocalDrivingLicenseApplication.FindApplicationbyID(LocalDrivingApplicationID, ref ApplicationID,
                ref ApplicantPersonID, ref ApplicationTypeID, ref CreatedByUserID, ref LicenseClassID, ref ClassName
                , ref NationalNo, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref LastStatusDate, ref ApplicationDate, ref PaidFees, ref ApplicationStatus, ref TestResult))
                return new clsLocalDrivingLicenseApplication(LocalDrivingApplicationID , ApplicationID , ApplicantPersonID , ApplicationTypeID  , LicenseClassID,CreatedByUserID , 
                    ClassName , NationalNo , FirstName , SecondName , ThirdName , LastName , ApplicationDate , LastStatusDate , TestResult , PaidFees , ApplicationStatus);
            else
                return null;
                

        }
        public static DataTable GetLocalLicenseApplications()
        {
            return ContactsDataAccessLayer.clsDataAccessLocalDrivingLicenseApplication.GetLocalLicenseApplications();
        }
        public bool AddLocalLicenseApplications()
        {
            this.LocalDrivingApplicationID = (clsDataAccessLocalDrivingLicenseApplication.AddNewLocalDrivingLicense(this.ApplicantPersonID, this.ApplicationTypeID
                , this.LicenseClassID, this.CreatedByUserID, this.ApplicationDate, this.LastStatusDate, this.PaidFees, this.ApplicationStatus ));

            return (this.LocalDrivingApplicationID != -1);
        }
      
        static public bool checkStatus(int ApplicantPersonID , int LicenseClassID)
        {
            return (clsDataAccessLocalDrivingLicenseApplication.checkStatus(ApplicantPersonID,LicenseClassID));
        }
        static public bool UpdateApplicationSatus(int LocalDrivingApplicationID , byte ApplicationStatus)
        {
            return (clsDataAccessLocalDrivingLicenseApplication.UpdateApplicationSatus(LocalDrivingApplicationID , ApplicationStatus));
        }
       static  public bool DeleteLocalDrivingLicense(int LocalDrivingApplicationID)
       {
            return (clsDataAccessLocalDrivingLicenseApplication.DeleteLocalDrivingLicense(LocalDrivingApplicationID));
       }
    }
}

using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsVisionTest
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int ApplicationID { get; set; }
        public int TestTypeID { get; set; }
        public  int CreatedByUserID { get; set; }
        public  string ClassName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
        }
        public DateTime ApplicationDate { get; set; }
        public byte TestResult {  get; set; }
        public byte ApplicationStatus { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal PaidFees { get; set; }
        public string UserName { get; set; }
        public bool IsLocked { get; set; }
        public clsVisionTest()
        {
            
            this.LocalDrivingLicenseApplicationID = 0;
            this.ApplicationID = 0;
            this.ClassName = string.Empty;
            this.FirstName = string.Empty;
            this.SecondName = string.Empty;
             this.ThirdName = string.Empty;
            this.LastName = string.Empty;
            this.FullName();
            this.ApplicationDate = DateTime.Now;
            this.TestResult = 0;
            this.ApplicationStatus = 0;
            this.ApplicationTypeTitle = string.Empty;
            this.PaidFees = 0;
        }
        public clsVisionTest(int ApplicationID,  int TestTypeID,  int LocalDrivingLicenseApplicationID,  DateTime ApplicationDate, 
            decimal PaidFees,  int CreatedByUserID,  bool IsLocked,  byte TestResult)
        {
            this.ApplicationID = ApplicationID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationDate = ApplicationDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
            this.TestResult = TestResult;
            
        }
        public clsVisionTest(int LocalDrivingLicenseApplicationID ,  int ApplicationID  
            , string FirstName , string SecondName, string ThirdName , string LastName , DateTime ApplicationDate
             , byte ApplicationStatus, string ApplicationTypeTitle , decimal PaidFees, string UserName)
        {
            
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
   
            this.ApplicationID = ApplicationID;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.FullName();
            this.ApplicationDate = ApplicationDate;
            this.ApplicationStatus = ApplicationStatus;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.PaidFees= PaidFees;
            this.UserName = UserName;

        }
        public clsVisionTest(int LocalDrivingLicenseApplicationID , string ClassName, byte TestResult)
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ClassName = ClassName;
            this.TestResult = TestResult;
        }
        static public DataTable getAllData()
        {
            return clsAccessVisonTest.getAllDataVision();
        }
        static public clsVisionTest DrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "";
            byte TestResult = 0;
            if (clsAccessVisonTest.DrivingLicenseApplicationInfo(LocalDrivingLicenseApplicationID,  ref ClassName,  ref TestResult))
                return new clsVisionTest(LocalDrivingLicenseApplicationID , ClassName , TestResult);
            else
                return null;
        }
        static public clsVisionTest ApplicationBasicInfo(int LocalDrivingLicenseApplicationID)
        {
            

            int ApplicationID = 0;
            string ApplicationTypeTitle = "";
            DateTime ApplicationDate = DateTime.Now;
            byte ApplicationStatus = 0;
            decimal PaidFees = 0;
             
            string UserName = "";
            string FirstName = "";
            string SecondName = "";
            string ThirdName = "";
            string LastName = "";


            if (clsAccessVisonTest.ApplicationBasicInfo(LocalDrivingLicenseApplicationID, 
                 ref ApplicationID, ref ApplicationTypeTitle, ref ApplicationDate
                , ref ApplicationStatus, ref PaidFees, ref UserName
                , ref FirstName, ref SecondName, ref ThirdName, ref LastName))
                return new clsVisionTest(LocalDrivingLicenseApplicationID,   ApplicationID
            , FirstName, SecondName, ThirdName, LastName, ApplicationDate
            , ApplicationStatus, ApplicationTypeTitle, PaidFees, UserName);
            else
                return null;
        }
        static public clsVisionTest GetLastTestAppointmentResult(int LocalDrivingLicenseApplicationID , int TestTypeID , bool IsLocked)
        {
            int ApplicationID = 0;
            DateTime ApplicationDate = DateTime.Now;
            decimal PaidFees = 0;
            int CreatedByUserID = 0;
         
            byte TestResult = 0;
            if (clsAccessVisonTest.GetLastTestAppointmentResult(LocalDrivingLicenseApplicationID,  TestTypeID, ref ApplicationID
                , ref ApplicationDate, ref PaidFees, ref CreatedByUserID,  IsLocked, ref TestResult))
                return new clsVisionTest(ApplicationID, TestTypeID, LocalDrivingLicenseApplicationID, ApplicationDate, PaidFees, CreatedByUserID, IsLocked, TestResult);
            else
                return null;
        }

    }
}

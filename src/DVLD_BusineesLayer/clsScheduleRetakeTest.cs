using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_BusineesLayer
{
    public class clsScheduleRetakeTest
    {
       public int NewApplicationID { get; set; }
       public int NewAppointments {  get; set; }
       public int TestTypeID { get; set; }
   
        public int LocalDrivingLicenseApplicationID { get; set; }
        public  int ApplicantPersonID { get; set; }
        public  int ApplicationTypeID { get; set; }
        public  int LicenseClassID { get; set; }
        public int CreatedByUserID { get; set; }
        public  DateTime ApplicationDate { get; set; }
       public   DateTime LastStatusDate { get; set; }
       public  decimal RetakPaidFees { get; set; }
       public  decimal TestFees { get; set; }
       public  byte ApplicationStatus { get; set; }
        public bool IsLocked { get; set; }

        public clsScheduleRetakeTest()
        {
            this.NewApplicationID = 0;
            this.NewAppointments = 0;
            this.TestTypeID = 0;
            this.LocalDrivingLicenseApplicationID   = 0;
            this.ApplicantPersonID = 0;
            this.ApplicationTypeID = 0;
            this.LicenseClassID = 0;
            this.CreatedByUserID = 0;
            this.ApplicationDate = DateTime.Now;
            this.LastStatusDate = DateTime.Now;
            this.RetakPaidFees = 0;
            this.TestFees = 0;
            this.ApplicationStatus = 0;
            this.IsLocked = false;
        }
        public clsScheduleRetakeTest(  int NewApplicationID, int NewAppointments , int TestTypeID , int LocalDrivingLicenseApplicationID 
            , int ApplicantPersonID, int ApplicationTypeID,int LicenseClassID,int CreatedByUserID 
            , DateTime ApplicationDate, DateTime LastStatusDate, decimal RetakPaidFees , decimal TestFees , byte ApplicationStatus , bool IsLocked)
        {
            this.NewApplicationID= NewApplicationID;
            this.NewAppointments= NewAppointments;
            this.TestTypeID= TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ApplicantPersonID= ApplicantPersonID;  
            this.ApplicationTypeID= ApplicationTypeID;
            this.LicenseClassID= LicenseClassID;
            this.CreatedByUserID= CreatedByUserID;
            this.ApplicationDate= ApplicationDate;
            this.LastStatusDate= LastStatusDate;
            this.RetakPaidFees= RetakPaidFees;
            this.TestFees = TestFees;
            this.ApplicationStatus= ApplicationStatus;
            this.IsLocked= IsLocked;

        }
        public clsScheduleRetakeTest(int NewAppointments , int ApplicationID , int LocalDrivingLicenseApplicationID ,int  ApplicantPersonID , int TestTypeID ,int ApplicationTypeID, bool IsLocked)
        {
            this.NewAppointments = NewAppointments;
            this.NewApplicationID= NewApplicationID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.TestTypeID = TestTypeID;
            this.ApplicationTypeID = ApplicationTypeID;
            this.IsLocked = IsLocked;
        }
        static public clsScheduleRetakeTest ScheduleRetakeFind(int NewAppointments, int TestTypeID)
        {
            int ApplicationID = 0;
            int ApplicantPersonID = 0;
            int ApplicationTypeID = 0;
            int LocalDrivingLicenseApplicationID = 0;
            bool IsLocked = false;
            if (clsAccessRetakeExam.FindRatakeExam( NewAppointments , ref ApplicationID , ref LocalDrivingLicenseApplicationID ,ref  ApplicantPersonID , TestTypeID ,ref ApplicationTypeID, ref IsLocked))
            {
                return  new clsScheduleRetakeTest(NewAppointments , ApplicationID , LocalDrivingLicenseApplicationID , ApplicantPersonID , TestTypeID,ApplicationTypeID , IsLocked);
            }
            else
                return null;
        }
        public bool RetakeExam()
        {
            this.NewAppointments = (clsAccessRetakeExam.RetakeExam(this.TestTypeID, LocalDrivingLicenseApplicationID
                , ApplicantPersonID, ApplicationTypeID, LicenseClassID, CreatedByUserID, ApplicationDate, LastStatusDate, RetakPaidFees, TestFees, ApplicationStatus , IsLocked));
            return (this.NewAppointments != -1);
        }
         public int findRatakeExam(int TestAppointmentID, int TestTypeID)
        {
           this.NewAppointments =  ( clsAccessRetakeExam.findRatakeExam(TestAppointmentID, TestTypeID));

            return this.NewAppointments;
        }
    }
}

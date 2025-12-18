using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsViewPersonSchedultTest
    {
        public int LocalDrivingLicenseApplicationID {  get; set; }
        public int TestTypeID { get; set; }
        public string ClassName { get; set; }
        public int TestResult {  get; set; }
        public decimal TestTypeFees { get; set; }
        public string FirstName { get; set; }
        public string SecoundName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName()
        {
            return FirstName + " " + SecoundName + " " + ThirdName + " " + LastName;
        }
        public DateTime AppointmentDate { get; set; }
        public clsViewPersonSchedultTest()
        {
            this.LocalDrivingLicenseApplicationID = 0;
            this.TestTypeID = 0;
            this.ClassName = "";
            this.TestResult = 0;
            this.TestTypeFees = 0;
            this.FirstName = "";
            this.SecoundName = "";
            this.ThirdName = "";
            this.LastName = "";
            this.AppointmentDate = DateTime.Now;
        }
        public clsViewPersonSchedultTest(int LocalDrivingLicenseApplicationID ,  string ClassName 
            , int TestResult , decimal TestTypeFees , string FirstName , string SecoundName  , string ThirdName , string LastName , DateTime AppointmentDate )
        {
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.ClassName = ClassName;
            this.TestResult = TestResult;
            this.TestTypeFees = TestTypeFees;
            this.FirstName = FirstName;
            this.SecoundName= SecoundName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.AppointmentDate = AppointmentDate;
        }
        public clsViewPersonSchedultTest(int LocalDrivingLicenseApplicationID, int TestTypeID, string ClassName
          , int TestResult, decimal TestTypeFees, string FirstName, string SecoundName, string ThirdName, string LastName, DateTime AppointmentDate)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.TestTypeID = TestTypeID;
            this.ClassName = ClassName;
            this.TestResult = TestResult;
            this.TestTypeFees = TestTypeFees;
            this.FirstName = FirstName;
            this.SecoundName = SecoundName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.AppointmentDate = AppointmentDate;
        }
        static public clsViewPersonSchedultTest FindPersonSchedultTest(int LocalDrivingLicenseApplicationID)
        {
            string ClassName = "";
            int TestResult = 0;
            decimal TestTypeFees = 0;
            string FirstName = "";
            string SecoundName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime AppointmentDate = DateTime.Now;

            if (clsAccessSchedultTestVision.FindPersonSchedultTest(LocalDrivingLicenseApplicationID,  ref ClassName, ref TestResult, ref TestTypeFees
                , ref FirstName, ref SecoundName, ref ThirdName, ref LastName))

                return new clsViewPersonSchedultTest(LocalDrivingLicenseApplicationID, ClassName, TestResult
                    , TestTypeFees, FirstName, SecoundName, ThirdName, LastName, AppointmentDate);
            else
                return null;
        }
        static public clsViewPersonSchedultTest FindPersonSchedultTest(int LocalDrivingLicenseApplicationID , int TestTypeID)
        {
            string ClassName = "";
            int TestResult = 0;
            decimal TestTypeFees = 0;
            string FirstName = "";
            string SecoundName = "";
            string ThirdName = "";
            string LastName = "";
            DateTime AppointmentDate = DateTime.Now;

            if (clsAccessSchedultTestVision.FindPersonSchedultTest(LocalDrivingLicenseApplicationID, TestTypeID, ref ClassName, ref TestResult, ref TestTypeFees
                , ref FirstName, ref SecoundName, ref ThirdName, ref LastName))

                return new clsViewPersonSchedultTest(LocalDrivingLicenseApplicationID, TestTypeID,ClassName, TestResult
                    , TestTypeFees, FirstName, SecoundName, ThirdName, LastName, AppointmentDate);
            else
                return null;
        }


    }

   
}

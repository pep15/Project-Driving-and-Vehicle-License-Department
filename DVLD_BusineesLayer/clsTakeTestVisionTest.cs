using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsTakeTestVisionTest
    {
       
        public int TestID {  get; set; }
        public int TestAppointmentID { get; set; }
        public byte TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsLocked { get; set; }
        public clsTakeTestVisionTest()
        {
            TestID = 0;
            TestAppointmentID = 0;
            TestResult = 0;
            Notes = string.Empty;
            CreatedByUserID = 0;
            IsLocked = false;
            
        }
   
      
        public clsTakeTestVisionTest(int TestID , int TestAppointmentID , byte TestResult , string Notes , int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            
        }
        public bool AddNewTest()
        {
            this.TestID = (clsAccessTakeTestVisionTest.AddNewTest(this.TestAppointmentID, this.TestResult, this.Notes, this.CreatedByUserID));

            return (this.TestID > 0);
        }
       
    }
}

using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsTestType
    {
        public int TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public decimal TestTypeFees { get; set; }


        public clsTestType()
        {
            this.TestTypeID = 0;
            this.TestTypeTitle = string.Empty;
            this.TestTypeDescription = string.Empty;
            this.TestTypeFees = 0;
        }
        public clsTestType(int testTypeID , string TestTypeTitle , string TestTypeDescription , decimal TestTypeFees)
        {
            this.TestTypeID = testTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;
        }
        static public clsTestType FindTypeFees(int TestTypeID)
        {
            string TestTypeTitle = "";
            string TestTypeDescription = "";
            decimal TestTypeFees = 0;
            if (clsAccessTestType.FindTypeFees(TestTypeID , ref TestTypeTitle , ref TestTypeDescription , ref TestTypeFees))
                return new clsTestType (TestTypeID , TestTypeTitle , TestTypeDescription , TestTypeFees);
            else
                return null;
        }

    }
}

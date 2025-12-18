using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsDriving
    {
       
       public int DriverID { get; set; }
        public int PersonID {  get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsDriving()
        {
            DriverID = -1;
            PersonID = 0;
            CreatedByUserID = 0;
            CreatedDate = DateTime.Now;
        }
        public clsDriving(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
        public bool AddNewDriver()
        {
            this.DriverID = (clsAccessDriver.AddNewDriver(this.PersonID, this.CreatedByUserID, this.CreatedDate));
            return (this.DriverID != -1);
        }
        static public bool HasLicenses(int PersonID  , int LicenseClass)
        {
            return (clsAccessDriver.HasLicenses(PersonID , LicenseClass));
        }
        public static DataTable ListLicensesDriver(int PersonID)
        {
            return (clsAccessDriver.ListLicensesDriver(PersonID));
        }
        public static DataTable ListLicensesDriverPerson()
        {
            return (clsAccessDriver.ListLicensesDriverPerson());    
        }
    }
}

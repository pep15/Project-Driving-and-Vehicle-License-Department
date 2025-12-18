using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;

namespace DVLD_BusineesLayer
{
    public class clsCountry
    {
        public static DataTable GetAllCountry()
        {
            return ContactsDataAccessLayer.clsCountry.GettAllCountry();
        }

        public static string GetCountryName(int nationalityCountryID)
        {
            return ContactsDataAccessLayer.clsCountry.GetCountryName(nationalityCountryID);
        }
    }
}

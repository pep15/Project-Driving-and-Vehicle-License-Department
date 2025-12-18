using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ContactsDataAccessLayer;
namespace DVLD_BusineesLayer
{
    public class clsApplicationTypes
    {
        public int ID { get; set; }
        public string Title { get; set; }

        public decimal Fees { get; set; }

        public clsApplicationTypes()
        {
            this.ID = 0;
            this.Title = "";
            this.Fees = 0;
        }
        public clsApplicationTypes(int ID , string Title , decimal Fees )
        {
            this.ID = ID;
            this.Title = Title;
            this.Fees = Fees;
        }
        public static clsApplicationTypes FindID( int ID )
        {
            string Title = "";
            decimal Fees = 0;
            if(clsDataAccessApplicationTypes.GetInfoID(ID , ref Title , ref Fees))
                return new clsApplicationTypes(ID , Title , Fees);
            else
                 return null;
        }
        public bool UpdateTitleAndfeesOfApplications(int ID , string Title, decimal Fees)
        {
            return (ContactsDataAccessLayer.clsDataAccessApplicationTypes.UpdateApplicationsTypes( this.ID , this.Title, this.Fees));
        }
        public static DataTable getApps()
        {
            return (ContactsDataAccessLayer.clsDataAccessApplicationTypes.GetAllAplicationsTypes());
        }
        public static bool GetFeesLocalDrivers(int ID , string Title , decimal Fees)
        {
            return (ContactsDataAccessLayer.clsDataAccessApplicationTypes.GetFeesOfLocalDrivers(ref ID, ref Title, Fees));
        }
    }
}

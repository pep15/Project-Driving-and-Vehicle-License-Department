using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DVLD_BusineesLayer
{
    public class clsManageTestType
    {
        public int ID {  get; set; }
        public string Titile { get; set; }
        public string Description { get; set; }
        public decimal Fees { get; set; }

        public clsManageTestType()
        {
            this.ID = 0;
            this.Titile = "";
            this.Description = "";
            this.Fees = 0;

        }
        public clsManageTestType(int ID , string Titile , string Description , decimal Fees)
        {
            this.ID= ID;
            this.Titile = Titile;
            this.Description = Description;
            this.Fees = Fees;
        }
        static public clsManageTestType GetInfoID(int  ID)
        {
            string Titile = "";
            string Description = "";
            decimal Fees = 0;

            if(clsDataAccessManageTestType.GetFindID(ID , ref Titile , ref Description , ref Fees))
            {
                return new clsManageTestType(ID , Titile , Description , Fees);
            }
            else
                return null;
        }
        static public DataTable GetAllTestType()
        {
            return (clsDataAccessManageTestType.GetAllTestType());
        }
        public bool updateTestType(int ID, string Titile, string Description, decimal Fees)
        {
            return (clsDataAccessManageTestType.UpdateManageTestType(this.ID , this.Titile , this .Description , this.Fees));
        }
    }
}

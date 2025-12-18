using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsLocalDriving
    {
        public int _LicenseClassID {  get; set; }
        public string _ClassName { get; set; }
        public string _ClassDescription { get; set; }
        public int _MinimumAllowedAge { get; set; }
        public int _DefaultValidityLength { get; set; }

        public decimal _ClassFess {  get; set; }


        public clsLocalDriving()
        {
            this._LicenseClassID = 0;
            this._ClassName = "";
            this._ClassDescription = "";
            this._MinimumAllowedAge = 0;
            this._DefaultValidityLength = 0;
            this._ClassFess = 0;
        }

        public clsLocalDriving(int LicenseClassID , string ClassName , string ClassDescription , int _MinimumAllowedAge , int DefaultValidityLength , decimal ClassFess)
        {
            this._LicenseClassID = LicenseClassID;
            this._ClassName = ClassName;
            this._ClassDescription = ClassDescription;
            this._MinimumAllowedAge = _MinimumAllowedAge;
            this._DefaultValidityLength = DefaultValidityLength;
            this._ClassFess = ClassFess;
        }


        static public DataTable GetAllLicenseClassID()
        {
            return (clsDataAccessLocalDriving.GetLocalDrivingLincess());
        }
    }

}

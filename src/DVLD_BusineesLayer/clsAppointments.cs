using ContactsDataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusineesLayer
{
    public class clsAppointments
    {
        public enum eMode { Add = 0 , Update =  1 }
        private eMode _Mode;
        public int AppointmentID {  get; set; }
         public int TestTypeID {  get; set; }
        public int LocalDrivingLicenseApplicationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public  bool IsLocked { get; set; }
        public clsAppointments()
        {
            this.AppointmentID = -1;
            this.TestTypeID = -1;
            this.LocalDrivingLicenseApplicationID = -1;
            this.AppointmentDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID = 0;
            this.IsLocked = true;
            this._Mode = eMode.Add;
        }
        public clsAppointments(int AppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            this.AppointmentID = AppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID= LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees= PaidFees;
            this.CreatedByUserID = CreatedByUserID;
            this.IsLocked = IsLocked;
        }
        public clsAppointments(int AppointmentID, int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, bool IsLocked)
        {
            this.AppointmentID = AppointmentID;
            this.TestTypeID = TestTypeID;
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.AppointmentDate = AppointmentDate;
            this.PaidFees = PaidFees;
            this.IsLocked = IsLocked;
            _Mode = eMode.Update;
        }
        public static DataTable GetAllAppointment(int TestTypeID)
        {
            return (clsAccessclsAppointments.GetAllAppointment(TestTypeID));
        }
        public static clsAppointments FindAppointments(int AppointmentID, int TestTypeID)
        {
            int LocalDrivingLicenseApplicationID = 0;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0;
            bool IsLocked = false;
            if(clsAccessclsAppointments.FindAppointments(AppointmentID, TestTypeID , ref LocalDrivingLicenseApplicationID, ref AppointmentDate , ref PaidFees , ref IsLocked))
                return new clsAppointments(AppointmentID , TestTypeID , LocalDrivingLicenseApplicationID , AppointmentDate , PaidFees , IsLocked);
            else
                return null;
        }
        public static clsAppointments FindLastClosedAppointment(int LocalDrivingLicenseApplicationID, bool IsLocked)
        {
            int AppointmentID = 0;
            DateTime AppointmentDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int TestTypeID = 0;
         
            if (clsAccessclsAppointments.FindLastClosedAppointment(LocalDrivingLicenseApplicationID, ref AppointmentID, ref   TestTypeID, ref AppointmentDate, ref PaidFees,  IsLocked))
                return new clsAppointments(AppointmentID, TestTypeID, LocalDrivingLicenseApplicationID, AppointmentDate, PaidFees, IsLocked);
            else
                return null;
        }
        private bool _AddNewAppointment()
        {
            this.AppointmentID = (clsAccessclsAppointments.AddNewAppointment(this.TestTypeID, this.LocalDrivingLicenseApplicationID, this.AppointmentDate, this.PaidFees, this.CreatedByUserID, this.IsLocked));

            return (AppointmentID != -1);
        }
         static public bool HasActiveAppointment(int LocalDrivingLicenseApplicationID, int TestTypeID, bool IsLocked)
         {
            return (clsAccessclsAppointments.HasActiveAppointment(LocalDrivingLicenseApplicationID, TestTypeID, IsLocked));
         }
        private bool _UpdateDateAppointment()
        {
            return (clsAccessclsAppointments.updateDateAppointment(this.AppointmentID, this.AppointmentDate));
        }

        public bool UpdateIsLockedAppointment()
        {
            return (clsAccessclsAppointments.UpdateIsLockedAppointment(this.AppointmentID, this.IsLocked));
        }
        public bool save()
        {
            switch (_Mode)
            {
                case eMode.Add:
                    if (_AddNewAppointment())
                    {
                        _Mode = eMode.Add;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case eMode.Update:
                    return _UpdateDateAppointment();
            }

            return false;
        }
    }
}

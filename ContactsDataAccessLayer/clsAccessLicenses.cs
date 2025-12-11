using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;

namespace ContactsDataAccessLayer
{
    public class clsAccessLicenses
    {

        static public int AddNewLicenses(int ApplicationID, int DriverID , int LicenseClass, DateTime IssueDate
            , DateTime ExpirationDate , string Notes , decimal PaidFees , bool IsActive , int IssueReason, int CreatedByUserID)
        {
            int LicensesID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Licenses
                            (ApplicationID
                            ,DriverID
                            ,LicenseClass
                            ,IssueDate
                            ,ExpirationDate
                            ,Notes
                            ,PaidFees
                            ,IsActive
                            ,IssueReason
                            ,CreatedByUserID)
                        VALUES
                            (@ApplicationID 
                            ,@DriverID
                            ,@LicenseClass
                            ,@IssueDate
                            ,@ExpirationDate
                            ,@Notes
                            ,@PaidFees
                            ,@IsActive
                            ,@IssueReason
                            ,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString() , out int InsertedID))
                {
                    LicensesID = InsertedID;
                }
            }
            finally
            {
                Connection.Close();
            }

            return LicensesID;

        }
        static public int AddNewRenewLicenses(int OldLicensesID, out int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate,int ApplicationTypeID, int ApplicationStatus ,DateTime LastStatusDate, int DriverID, int LicenseClass, DateTime IssueDate
            , DateTime ExpirationDate, string Notes, decimal PaidFees, byte IsActive, int IssueReason, int CreatedByUserID)
        {
            int NewLicenseID = 0;
            ApplicationID = 0;
          
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query1 = @"INSERT INTO Applications
                            (ApplicantPersonID
                            ,ApplicationDate
                            ,ApplicationTypeID
                            ,ApplicationStatus
                            ,LastStatusDate
                            ,PaidFees
                            ,CreatedByUserID)
                          VALUES
                            (@ApplicantPersonID
                            ,@ApplicationDate
                            ,@ApplicationTypeID
                            ,@ApplicationStatus
                            ,@LastStatusDate
                            ,@PaidFees
                            ,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";


            string query2 = @"INSERT INTO Licenses
                            (ApplicationID
                            ,DriverID
                            ,LicenseClass
                            ,IssueDate
                            ,ExpirationDate
                            ,Notes
                            ,PaidFees
                            ,IsActive
                            ,IssueReason
                            ,CreatedByUserID)
                        VALUES
                            (@ApplicationID 
                            ,@DriverID
                            ,@LicenseClass
                            ,@IssueDate
                            ,@ExpirationDate
                            ,@Notes
                            ,@PaidFees
                            ,@IsActive
                            ,@IssueReason
                            ,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";


            string query3 = @"UPDATE  Licenses
                             SET IsActive = 0
                             WHERE LicenseID = @OldLicensesID";




            SqlCommand Command1 = new SqlCommand(query1, Connection);
            Command1.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command1.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command1.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command1.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command1.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command1.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command1.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);


            SqlCommand Command2 = new SqlCommand(query2, Connection);

            SqlCommand Command3 = new SqlCommand(query3, Connection);
            Command3.Parameters.AddWithValue("@OldLicensesID", OldLicensesID);

            SqlTransaction transaction = null;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Command1.Transaction = transaction;
                Command2.Transaction = transaction;
                Command3.Transaction = transaction; 
                object Result = Command1.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }
                else
                {
                    transaction.Rollback();
                    return -1;
                }

                
                Command2.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                Command2.Parameters.AddWithValue("@DriverID", DriverID);
                Command2.Parameters.AddWithValue("@LicenseClass", LicenseClass);
                Command2.Parameters.AddWithValue("@IssueDate", IssueDate);
                Command2.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                Command2.Parameters.AddWithValue("@Notes", Notes);
                Command2.Parameters.AddWithValue("@PaidFees", PaidFees);
                Command2.Parameters.AddWithValue("@IsActive", IsActive);
                Command2.Parameters.AddWithValue("@IssueReason", IssueReason);
                Command2.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                object NewResult = Command2.ExecuteScalar();

                if (NewResult != null && int.TryParse(NewResult.ToString(), out int InsertedNewID))
                {
                    NewLicenseID = InsertedNewID;
                }
                else
                {
                    transaction.Rollback();
                    return -1;
                }
                Command3.ExecuteNonQuery();
                transaction.Commit();
            }
            finally
            {
                Connection.Close();
            }
            return  NewLicenseID;
        }
        static public bool GetLicenseInfoByLicensesID(int LicenseID , ref int ApplicantPersonID, ref string NationalNo, 
            ref int ApplicationID, ref int DriverID, ref int LicenseClass, 
            ref int IssueReason, ref decimal PaidFees,ref decimal ClassFees, ref string ClassName, 
            ref string FullName, ref byte Gendor, ref int CreatedByUserID,ref string Notes, 
            ref DateTime DateOfBirth, ref DateTime IssueDate, ref DateTime ExpirationDate,ref string ImagePath , ref bool IsActive)
        {
            bool Isfound = false;
        SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
        string query = @"SELECT Licenses.LicenseID , Applications.ApplicantPersonID,People.NationalNo,Licenses.ApplicationID, Licenses.DriverID, Licenses.LicenseClass,  Licenses.IssueReason,Licenses.PaidFees,LicenseClasses.ClassFees,LicenseClasses.ClassName, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' ' ,People.LastName) As FullName ,People.Gendor, Licenses.CreatedByUserID,Licenses.Notes, People.DateOfBirth,Licenses.IssueDate, Licenses.ExpirationDate,People.ImagePath , Licenses.IsActive
                             FROM  Licenses 
                             INNER JOIN Applications ON Licenses.ApplicationID = Applications.ApplicationID 
                             INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                             INNER JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID 
                             INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID AND People.PersonID = Drivers.PersonID
                             WHERE Licenses.LicenseID = @LicenseID;";
                       SqlCommand Command = new SqlCommand(query, Connection);
                      Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Isfound = true;
                    if (Reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)Reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (Reader["ApplicantPersonID"] != DBNull.Value)
                    {
                        ApplicantPersonID = (int)Reader["ApplicantPersonID"];
    }
                    else
                    {
                        ApplicantPersonID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)Reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = 0;
                    }
                    if (Reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)Reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (Reader["LicenseClass"] != DBNull.Value)
                    {
                        LicenseClass = (int)Reader["LicenseClass"];
                    }
                    else
                    {
                        LicenseClass = -1;
                    }
                    if (Reader["IssueReason"] != DBNull.Value)
                    {
                        IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    }
                    else
                    {
                        IssueReason = 0;
                    }
                    if (Reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)Reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees = 0;
                    }
                    if(Reader["ClassFees"] != DBNull.Value)
                    {
                        ClassFees = (decimal)Reader["ClassFees"];
                    }
                    else
                    {
                        ClassFees = 0;
                    }
                    if (Reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)Reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)Reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID = -1;
                    }
                   
                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }
                    if (Reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (Reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)Reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (Reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                    if (Reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)Reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                }

            }
            catch
            {
                Isfound = false;
            }

            finally
            {
                Connection.Close();
            }

            return (Isfound);
        }

        static public bool GetLicenseInfoByApplicationID(int ApplicationID, ref int LicenseID, ref int ApplicantPersonID, ref string NationalNo,
           ref int DriverID, ref int LicenseClass,
          ref int IssueReason, ref decimal PaidFees, ref decimal ClassFees, ref string ClassName,
          ref string FullName, ref byte Gendor, ref int CreatedByUserID, ref string Notes,
          ref DateTime DateOfBirth, ref DateTime IssueDate, ref DateTime ExpirationDate, ref string ImagePath, ref bool IsActive)
        {
            bool Isfound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Licenses.ApplicationID,Licenses.LicenseID , Applications.ApplicantPersonID,People.NationalNo, Licenses.DriverID, Licenses.LicenseClass,  Licenses.IssueReason,Licenses.PaidFees,LicenseClasses.ClassFees,LicenseClasses.ClassName, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' ' ,People.LastName) As FullName ,People.Gendor, Licenses.CreatedByUserID,Licenses.Notes, People.DateOfBirth,Licenses.IssueDate, Licenses.ExpirationDate,People.ImagePath , Licenses.IsActive
                             FROM  Licenses 
                             INNER JOIN Applications ON Licenses.ApplicationID = Applications.ApplicationID 
                             INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                             INNER JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID 
                             INNER JOIN Drivers ON Licenses.DriverID = Drivers.DriverID AND People.PersonID = Drivers.PersonID
                             WHERE Licenses.ApplicationID = @ApplicationID;";
            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Isfound = true;
                    if (Reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)Reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (Reader["ApplicantPersonID"] != DBNull.Value)
                    {
                        ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    }
                    else
                    {
                        ApplicantPersonID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)Reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = 0;
                    }
                    if (Reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)Reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (Reader["LicenseClass"] != DBNull.Value)
                    {
                        LicenseClass = (int)Reader["LicenseClass"];
                    }
                    else
                    {
                        LicenseClass = -1;
                    }
                    if (Reader["IssueReason"] != DBNull.Value)
                    {
                        IssueReason = Convert.ToInt16(Reader["IssueReason"]);
                    }
                    else
                    {
                        IssueReason = 0;
                    }
                    if (Reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)Reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees = 0;
                    }
                    if (Reader["ClassFees"] != DBNull.Value)
                    {
                        ClassFees = (decimal)Reader["ClassFees"];
                    }
                    else
                    {
                        ClassFees = 0;
                    }
                    if (Reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)Reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)Reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID = -1;
                    }

                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }
                    if (Reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (Reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)Reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (Reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                    if (Reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)Reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                }

            }
            catch
            {
                Isfound = false;
            }

            finally
            {
                Connection.Close();
            }

            return (Isfound);
        }
    }
}

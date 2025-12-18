using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ContactsDataAccessLayer
{
    public class ClsAccessInterantionalLicenseApp
    {
        
        static public int AddnewInterantionalLicense(out int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate ,int ApplicationTypeID
            ,byte ApplicationStatus,DateTime LastStatusDate,decimal PaidFees,int DriverID, int IssuedUsingLocalLicenseID 
            , DateTime IssueDate , DateTime ExpirationDate , bool IsActive , int CreatedByUserID)
        {
             ApplicationID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query1 = @"INSERT INTO Applications
                                    (ApplicantPersonID
                                     ,ApplicationDate
                                     ,ApplicationTypeID
                                     ,ApplicationStatus
                                     ,LastStatusDate
                                     ,PaidFees
                                    ,CreatedByUserID)
                        VALUES
                            (@ApplicantPersonID,
                            @ApplicationDate,
                            @ApplicationTypeID,
                            @ApplicationStatus,
                           @LastStatusDate, 
                           @PaidFees,
                           @CreatedByUserID)
                          SELECT SCOPE_IDENTITY();";
            string Query2 = @"INSERT INTO InternationalLicenses
                             (ApplicationID
                             ,DriverID
                             ,IssuedUsingLocalLicenseID
                             ,IssueDate
                             ,ExpirationDate
                             ,IsActive
                             ,CreatedByUserID)
                         VALUES
                             (@ApplicationID
                             ,@DriverID
                             ,@IssuedUsingLocalLicenseID
                             ,@IssueDate
                             ,@ExpirationDate
                             ,@IsActive
                             ,@CreatedByUserID)
                             SELECT SCOPE_IDENTITY();";

            
            SqlCommand Command = new SqlCommand(Query1, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            SqlCommand Command2 = new SqlCommand(Query2, Connection);

            SqlTransaction transaction = null;
            int LicensesID = -1;
            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command2.Transaction = transaction;
                object Result = Command.ExecuteScalar();
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
                Command2.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);
                Command2.Parameters.AddWithValue("@IssueDate", IssueDate);
                Command2.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
                Command2.Parameters.AddWithValue("@IsActive", IsActive);
                Command2.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

                object NewResult = Command2.ExecuteScalar();

                if (NewResult != null && int.TryParse(NewResult.ToString(), out int InsertedNewID))
                {
                    LicensesID = InsertedNewID;
                }
                else
                {
                    transaction.Rollback();
                    return -1;
                }
                transaction.Commit();

            }
            catch 
            {
                if (transaction != null)
                    transaction.Rollback();

                LicensesID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return LicensesID;


        }
        static public bool FindLicenseAndApplicationID(int InternationalLicenseID  , ref int  ApplicationID , ref int DriverID 
            , ref int IssuedUsingLocalLicenseID,ref int ApplicantPersonID, ref DateTime IssueDate,ref DateTime ExpirationDate , ref bool IsActive , ref string NationalNo 
            , ref string FullName , ref DateTime DateOfBirth , ref byte Gendor , ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, InternationalLicenses.DriverID, InternationalLicenses.IssuedUsingLocalLicenseID, Applications.ApplicantPersonID , InternationalLicenses.IssueDate ,InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive, People.NationalNo,  CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  AS FullName, People.DateOfBirth, People.Gendor, People.ImagePath
                            FROM  InternationalLicenses INNER JOIN
                            Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID
		                     where InternationalLicenses.InternationalLicenseID = @InternationalLicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    if (reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = -1;
                    }
                    if (reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (reader["IssuedUsingLocalLicenseID"] != DBNull.Value)
                    {
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    }
                    else
                    {
                        IssuedUsingLocalLicenseID = -1;
                    }
                    if (reader["ApplicantPersonID"] != DBNull.Value)
                    {
                        ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    }
                    else
                    {
                        ApplicantPersonID = -1;
                    }
                    if (reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                    if (reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["imagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                }
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }
            
            return IsFound;
        }
        static public bool FindDriverAndApplicationID(int DriverID
           , ref int ApplicationID, ref int InternationalLicenseID
           , ref int IssuedUsingLocalLicenseID
           , ref DateTime IssueDate,
           ref DateTime ExpirationDate
           , ref bool IsActive, ref string NationalNo
           , ref string FullName, ref DateTime DateOfBirth, ref byte Gendor, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenses.InternationalLicenseID, InternationalLicenses.ApplicationID, InternationalLicenses.DriverID, InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive, People.NationalNo, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ',People.ThirdName, ' ' ,People.LastName) as FullName, 
                            People.DateOfBirth, People.Gendor , People.ImagePath
                            FROM  InternationalLicenses INNER JOIN
                            Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID
		                    where InternationalLicenses.DriverID = @DriverID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DriverID", DriverID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = -1;
                    }
                    if (reader["InternationalLicenseID"] != DBNull.Value)
                    {
                        InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    }
                    else
                    {
                        InternationalLicenseID = -1;
                    }
                    if (reader["IssuedUsingLocalLicenseID"] != DBNull.Value)
                    {
                        IssuedUsingLocalLicenseID = (int)reader["IssuedUsingLocalLicenseID"];
                    }
                    else
                    {
                        IssuedUsingLocalLicenseID = -1;
                    }
                    if (reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                    if (reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["imagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                }
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        static public bool HasInternationLicense(int DriverID, int ApplicationTypeID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicantPersonID, InternationalLicenses.InternationalLicenseID, Applications.ApplicationTypeID, InternationalLicenses.DriverID
                             FROM  Applications INNER JOIN
                             InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID
                             WHERE (InternationalLicenses.DriverID =@DriverID) AND (Applications.ApplicationTypeID =@ApplicationTypeID)";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        static public DataTable GetInternationLicenses(int ApplicantPersonID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT InternationalLicenses.InternationalLicenseID AS [Lic ID], InternationalLicenses.ApplicationID AS [App ID], InternationalLicenses.IssuedUsingLocalLicenseID AS [Local Lic ID], ApplicationTypes.ApplicationTypeTitle AS [Class Name], InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive
                            FROM  InternationalLicenses INNER JOIN
                            Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                            ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID
                            WHERE ( Applications.ApplicantPersonID =@ApplicantPersonID)";

            SqlCommand Command = new SqlCommand(query , Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();
            }
            finally
            {
                Connection.Close();
            }

            return dt;

        }
        static public DataTable GetListInternationlicense()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);
            string query = @"select InternationalLicenseID [Int.License ID],ApplicationID [Application ID], DriverID[Driver ID], IssuedUsingLocalLicenseID[L.License ID] , IssueDate[Issue Date], ExpirationDate[Expiration Date] , IsActive[Is Active] from InternationalLicenses";

            SqlCommand Command = new SqlCommand(query , Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if(Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                    Reader.Close();
            }
            finally
            {
                Connection.Close();
            }


            return dt;

        }
    }
}

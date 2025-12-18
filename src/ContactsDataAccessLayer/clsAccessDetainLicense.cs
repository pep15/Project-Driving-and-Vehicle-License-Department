using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace ContactsDataAccessLayer
{
    public class clsAccessDetainLicense
    {
      
        static public int AddDetainLicense(int LicenseID, DateTime DetainDate, decimal FineFees, int CreatedByUserID,bool IsReleased, DateTime ReleaseDate, int ReleasedByUserID, int ReleaseApplicationID)
        {
            int DetainLicenseID = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO DetainedLicenses
                             (LicenseID
                             ,DetainDate
                             ,FineFees
                             ,CreatedByUserID
                             ,IsReleased
                             ,ReleaseDate
                             ,ReleasedByUserID
                             ,ReleaseApplicationID)
                            VALUES
                             (@LicenseID
                             ,@DetainDate
                             ,@FineFees
                             ,@CreatedByUserID
                             ,@IsReleased
                             ,@ReleaseDate
                             ,@ReleasedByUserID
                             ,@ReleaseApplicationID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", false);
            Command.Parameters.AddWithValue("@ReleaseDate", DBNull.Value);
            Command.Parameters.AddWithValue("@ReleasedByUserID", DBNull.Value);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", DBNull.Value);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int insertedID))
                {
                    DetainLicenseID = insertedID;
                }
            }
            finally
            {
                Connection.Close();
            }

            return (DetainLicenseID);
        }
        static public bool GetDetainLicensesID(int LicenseID,  ref int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID, 
            ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select DetainID , 
                                    LicenseID , 
                                    DetainDate , 
                                    FineFees , 
                                    CreatedByUserID , 
                                    IsReleased , 
                                    ReleaseDate , 
                                    ReleasedByUserID , 
                                    ReleaseApplicationID 
                                    from DetainedLicenses
                                    where LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    if (reader["DetainID"] != DBNull.Value)
                    {
                        DetainID = (int)reader["DetainID"];
                    }
                    else
                    {
                        DetainID = -1;
                    }
                    if (reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (reader["DetainDate"] != DBNull.Value)
                    {
                        DetainDate = (DateTime)reader["DetainDate"];
                    }
                    else
                    {
                        DetainDate = DateTime.MinValue;
                    }
                    if (reader["FineFees"] != DBNull.Value)
                    {
                        FineFees = (decimal)reader["FineFees"];
                    }
                    else
                    {
                        FineFees = 0;
                    }
                    if (reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID = -1;
                    }
                    if(reader["IsReleased"] != DBNull.Value)
                    {
                        IsReleased = (bool)reader["IsReleased"];
                    }
                    else
                    {
                        IsReleased = false;
                    }
                    if (reader["ReleaseDate"] != DBNull.Value)
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    else
                    {
                        ReleaseDate = DateTime.MinValue;
                    }
                   if(reader["ReleasedByUserID"] != DBNull.Value)
                    {
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }
                    else
                    {
                        ReleasedByUserID = -1;
                    }
                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    }
                    else
                    {
                        ReleaseApplicationID = -1;
                    }

                }

            }
            catch
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();

            }
            return isFound;
        }

        static public bool GetDetainsID(ref int LicenseID,  int DetainID, ref DateTime DetainDate, ref decimal FineFees, ref int CreatedByUserID,
           ref bool IsReleased, ref DateTime ReleaseDate, ref int ReleasedByUserID, ref int ReleaseApplicationID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select DetainID , 
                                    LicenseID , 
                                    DetainDate , 
                                    FineFees , 
                                    CreatedByUserID , 
                                    IsReleased , 
                                    ReleaseDate , 
                                    ReleasedByUserID , 
                                    ReleaseApplicationID 
                                    from DetainedLicenses
                                    where DetainID = @DetainID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@DetainID", DetainID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    if (reader["DetainID"] != DBNull.Value)
                    {
                        DetainID = (int)reader["DetainID"];
                    }
                    else
                    {
                        DetainID = -1;
                    }
                    if (reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (reader["DetainDate"] != DBNull.Value)
                    {
                        DetainDate = (DateTime)reader["DetainDate"];
                    }
                    else
                    {
                        DetainDate = DateTime.MinValue;
                    }
                    if (reader["FineFees"] != DBNull.Value)
                    {
                        FineFees = (decimal)reader["FineFees"];
                    }
                    else
                    {
                        FineFees = 0;
                    }
                    if (reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID = -1;
                    }
                    if (reader["IsReleased"] != DBNull.Value)
                    {
                        IsReleased = (bool)reader["IsReleased"];
                    }
                    else
                    {
                        IsReleased = false;
                    }
                    if (reader["ReleaseDate"] != DBNull.Value)
                    {
                        ReleaseDate = (DateTime)reader["ReleaseDate"];
                    }
                    else
                    {
                        ReleaseDate = DateTime.MinValue;
                    }
                    if (reader["ReleasedByUserID"] != DBNull.Value)
                    {
                        ReleasedByUserID = (int)reader["ReleasedByUserID"];
                    }
                    else
                    {
                        ReleasedByUserID = -1;
                    }
                    if (reader["ReleaseApplicationID"] != DBNull.Value)
                    {
                        ReleaseApplicationID = (int)reader["ReleaseApplicationID"];
                    }
                    else
                    {
                        ReleaseApplicationID = -1;
                    }

                }

            }
            catch
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();

            }
            return isFound;
        }
        static public bool IsFoundDetainLicense(int LicenseID , bool IsReleased)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from DetainedLicenses
                            where LicenseID = LicenseID and IsReleased = 1 ";


            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@IsReleased", IsReleased);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                }
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;

        }
        static public int AddReleaseDetainLicense(int LicenseID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, 
                                               int ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID 
                                             , bool IsReleased , decimal FineFees , DateTime ReleaseDate 
                                             , int ReleasedByUserID , int ReleaseApplicationID)
        {
            int ApplicationID = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Applications
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

            string query1 = @"UPDATE DetainedLicenses
                            SET IsReleased = 1,
                                FineFees = @FineFees,
                                ReleaseDate = @ReleaseDate,
                                ReleasedByUserID = @ReleasedByUserID,
                                ReleaseApplicationID = @ReleaseApplicationID
                                WHERE DetainedLicenses.LicenseID = @LicenseID and IsReleased = 0";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", ReleasedByUserID);

            SqlCommand Command1 = new SqlCommand(query1, Connection);
            Command1.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command1.Parameters.AddWithValue("@FineFees", FineFees);
            Command1.Parameters.AddWithValue("@ReleaseDate", ReleaseDate);
            Command1.Parameters.AddWithValue("@ReleasedByUserID", ReleasedByUserID);
            

            SqlTransaction transction = null;

            try
            {
                Connection.Open();
                transction = Connection.BeginTransaction();
                Command.Transaction = transction;
                Command1.Transaction = transction;
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    ApplicationID = InsertedID;
                }
                else
                {
                    transction.Rollback();
                    return -1;
                }
                Command1.Parameters.AddWithValue("@ReleaseApplicationID", ApplicationID);
                Command1.ExecuteNonQuery();
               
                transction.Commit();
            }
            finally
            {
                Connection.Close();
            }

            return (ApplicationID);
        }
        static public DataTable GetDetainLicenses()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT DetainedLicenses.DetainID [D.ID], DetainedLicenses.LicenseID [L.ID], DetainedLicenses.IsReleased [Is Released] , DetainedLicenses.FineFees [Fine Fees] ,DetainedLicenses.DetainDate [D.Date],   DetainedLicenses.ReleaseDate [Release Date], People.NationalNo [N.No], CONCAT(People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' '  ,People.LastName) As [Full Name],  DetainedLicenses.ReleaseApplicationID [Rlease App.ID]
                             FROM  DetainedLicenses INNER JOIN
                             Licenses ON DetainedLicenses.LicenseID = Licenses.LicenseID INNER JOIN
                             Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                             People ON Drivers.PersonID = People.PersonID ";

            SqlCommand Command = new SqlCommand(query, Connection);

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


        static public bool GetPersonDetails(int LicenseID , ref int PersonID , ref string NationalNo , 
            ref string FullName , ref DateTime DateOfBirth , ref byte Gendor 
            , ref string Address , ref string Phone , ref string Email , ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT People.PersonID, People.NationalNo, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' ' ,People.LastName) as FullName ,  People.DateOfBirth, People.Gendor, People.Address, People.Phone, People.Email, People.ImagePath
                             FROM  Licenses INNER JOIN
                             Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                             People ON Drivers.PersonID = People.PersonID
		                     where Licenses.LicenseID = @LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    isFound = true;
                    if (Reader["PersonID"] != DBNull.Value)
                    {
                        PersonID = (int)Reader["PersonID"];
                    }
                    else
                    {
                        PersonID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName =(string) Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["Address"] != DBNull.Value)
                    {
                        Address = (string)Reader["Address"];
                    }
                    else
                    {
                        Address = string.Empty;
                    }
                    if (Reader["Phone"] != DBNull.Value)
                    {
                        Phone = (string)Reader["Phone"];
                    }
                    else
                    {
                        Phone = string.Empty;
                    }
                    if (Reader["Email"] != DBNull.Value)
                    {
                        Email = (string)Reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                }
                
            }
            catch 
            {
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return (isFound);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace ContactsDataAccessLayer
{
    public class clsDataAccessLocalDrivingLicenseApplication
    {
        //AddInternatiolApplications
        public static DataTable GetLocalLicenseApplications()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.NationalNo, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' ' ,People.LastName) as fullName,  Applications.ApplicationDate, SUM(CASE WHEN Tests.TestResult = 1 THEN 1 ELSE 0 END) as PassedTests, Applications.ApplicationStatus as Status 
                                        FROM  LocalDrivingLicenseApplications 
                                        INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                                        INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
                                        INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                                        LEFT JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                                        LEFT JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                        group by LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID , LicenseClasses.ClassName , People.NationalNo , People.FirstName , People.SecondName , People.ThirdName , People.LastName , Applications.ApplicationDate, Applications.ApplicationStatus";
            SqlCommand cmd = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.HasRows)
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
        public static int AddNewLocalDrivingLicense(int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID,
            int CreatedByUserID, DateTime ApplicationDate, DateTime LastStatusDate, decimal PaidFees, byte ApplicationStatus)
        {
            int ApplicationID = -1;

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

            string Query2 = @"INSERT INTO LocalDrivingLicenseApplications
                                     (ApplicationID
                                   ,LicenseClassID)
                            VALUES
                               (@ApplicationID,
                               @LicenseClassID)
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
            int NewLocalDrivingLicenseApplicationID = -1;
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
                Command2.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

                object NewResult = Command2.ExecuteScalar();

                if (NewResult != null && int.TryParse(NewResult.ToString(), out int InsertedNewID))
                {
                    NewLocalDrivingLicenseApplicationID = InsertedNewID;
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

                NewLocalDrivingLicenseApplicationID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return NewLocalDrivingLicenseApplicationID;
        }
        public static bool FindApplicationbyID(int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int ApplicantPersonID, ref int ApplicationTypeID, ref int CreatedByUserID, ref int LicenseClassID,
             ref string ClassName, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime ApplicationDate,
               ref DateTime LastStatusDate, ref decimal PaidFees, ref byte Status, ref int PassedTests)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LDLA.LocalDrivingLicenseApplicationID,
                                       A.ApplicationID,
                                      A.ApplicantPersonID,
                                     A.ApplicationTypeID,
                                     A.CreatedByUserID,
                                      LC.LicenseClassID,
                                       LC.ClassName,
                                        P.NationalNo,
                                        P.FirstName,
                                        P.SecondName,
                                        P.ThirdName,
                                        P.LastName,
                                        A.ApplicationDate,
                                        A.LastStatusDate,
                                        A.PaidFees,
                                        A.ApplicationStatus AS Status,
                                        SUM(CASE WHEN T.TestResult = 1 THEN 1 ELSE 0 END) AS PassedTests
                                    FROM
                                        LocalDrivingLicenseApplications AS LDLA
                                    INNER JOIN Applications AS A
                                        ON LDLA.ApplicationID = A.ApplicationID
                                    INNER JOIN People AS P
                                        ON A.ApplicantPersonID = P.PersonID
                                    INNER JOIN LicenseClasses AS LC
                                        ON LDLA.LicenseClassID = LC.LicenseClassID
                                    LEFT JOIN TestAppointments AS TA
                                        ON LDLA.LocalDrivingLicenseApplicationID = TA.LocalDrivingLicenseApplicationID
                                    LEFT JOIN Tests AS T
                                        ON TA.TestAppointmentID = T.TestAppointmentID
                                    WHERE
                                        LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                    GROUP BY
                                        LDLA.LocalDrivingLicenseApplicationID,
                                        A.ApplicationID,
                                        A.ApplicantPersonID,
                                        A.ApplicationTypeID,
                                        A.CreatedByUserID,
                                        LC.LicenseClassID,
                                        LC.ClassName,
                                        P.NationalNo,
                                        P.FirstName,
                                        P.SecondName,
                                        P.ThirdName,
                                        P.LastName,
                                        A.ApplicationDate,
                                        A.LastStatusDate,
                                        A.PaidFees,
                                        A.ApplicationStatus;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
                        ApplicationID = 0;
                    }
                    if (reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (reader["ApplicantPersonID"] != DBNull.Value)
                    {
                        ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    }
                    else
                    {
                        ApplicationID = 0;
                    }
                    if (reader["ApplicationTypeID"] != DBNull.Value)
                    {
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    }
                    else
                    {
                        ApplicationTypeID = 0;
                    }
                    if (reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID = 0;
                    }
                    if (reader["LicenseClassID"] != DBNull.Value)
                    {
                        LicenseClassID = (int)reader["LicenseClassID"];
                    }
                    else
                    {
                        LicenseClassID = 0;
                    }
                    if (reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (reader["FirstName"] != DBNull.Value)
                    {
                        FirstName = (string)reader["FirstName"];
                    }
                    else
                    {
                        FirstName = string.Empty;
                    }
                    if (reader["SecondName"] != DBNull.Value)
                    {
                        SecondName = (string)reader["SecondName"];
                    }

                    if (reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                    else
                    {
                        ThirdName = string.Empty;
                    }
                    if (reader["LastName"] != DBNull.Value)
                    {
                        LastName = (string)reader["LastName"];
                    }
                    else
                    {
                        LastName = string.Empty;
                    }
                    if (reader["ApplicationDate"] != DBNull.Value)
                    {
                        ApplicationDate = (DateTime)reader["ApplicationDate"];
                    }
                    else
                    {
                        ApplicationDate = DateTime.MinValue;
                    }
                    if (reader["LastStatusDate"] != DBNull.Value)
                    {
                        LastStatusDate = (DateTime)reader["LastStatusDate"];
                    }
                    else
                    {
                        LastStatusDate = DateTime.MinValue;
                    }
                    if (reader["PassedTests"] != DBNull.Value)
                    {
                        PassedTests = Convert.ToInt32(reader["PassedTests"]);
                    }
                    else
                    {
                        PassedTests = 0;
                    }
                    if (reader["Status"] != DBNull.Value)
                    {
                        Status = (byte)reader["Status"];
                    }
                    else
                    {
                        Status = 0;
                    }
                    if (reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees = 0;
                    }


                }
                else
                {
                    IsFound = false;
                }

            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;


        }
        public static bool checkStatus(int ApplicantPersonID, int LicenseClassID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  Found = 1 
                                    FROM  People INNER JOIN
                                    Applications ON People.PersonID = Applications.ApplicantPersonID INNER JOIN
                                    LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
		                            where Applications.ApplicantPersonID =@ApplicantPersonID and LocalDrivingLicenseApplications.LicenseClassID =@LicenseClassID and Applications.ApplicationStatus = 1;";


            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                IsFound = reader.HasRows;
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
        public static bool UpdateApplicationSatus(int LocalDrivingLicenseApplicationID, byte ApplicationStatus)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE A
                                    SET A.ApplicationStatus = @ApplicationStatus
                                    FROM Applications AS A
                                    INNER JOIN LocalDrivingLicenseApplications AS LDLA ON A.ApplicationID = LDLA.ApplicationID
                                    WHERE LDLA.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);


            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffected > 0);
        }
       static public  bool DeleteLocalDrivingLicense(int LocalDrivingLicenseApplicationID)
       {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string queryFind = @"select ApplicationID from LocalDrivingLicenseApplications
                                 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            string queryDelete_1 = @"delete  from LocalDrivingLicenseApplications
                                    where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            string queryDelete_2 = @"delete from  Applications
                                     where ApplicationID = @ApplicationID";

           
            SqlCommand Command1 = new SqlCommand(queryFind, Connection);
            SqlCommand Command2 = new SqlCommand(queryDelete_1, Connection);
            SqlCommand Command3 = new SqlCommand(queryDelete_2, Connection);


            
            Command1.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command2.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            
            
            SqlTransaction transaction = null;

            int ApplicationID = -1;

            try
            {
                Connection.Open();
                transaction = Connection.BeginTransaction();
                Command1.Transaction = transaction;
                Command2.Transaction = transaction;
                Command3.Transaction = transaction;

                object Result = Command1.ExecuteScalar();
                
                if (Result != null && int.TryParse(Result.ToString() ,out int InsertdID))
                {
                    ApplicationID = InsertdID;
                }
                RowAffected = Command2.ExecuteNonQuery();
                Command3.Parameters.AddWithValue("@ApplicationID", ApplicationID);
                RowAffected += Command3.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            finally
            {
                
                Connection.Close();
            }

            

            return (RowAffected > 0);


        }


    }


   
}

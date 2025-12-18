using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;

namespace ContactsDataAccessLayer
{
    public class clsAccessRetakeExam
    {
        public static int RetakeExam(int TestTypeID, int LocalDrivingLicenseApplicationID, int ApplicantPersonID, int ApplicationTypeID, int LicenseClassID,
          int CreatedByUserID, DateTime ApplicationDate, DateTime LastStatusDate, decimal RetakPaidFees, decimal TestFees, byte ApplicationStatus , bool IsLocked)
        {
            int NewApplicationID = -1;
    

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
                            8,
                            @ApplicationStatus,
                           @LastStatusDate, 
                           5,
                           @CreatedByUserID)
                          SELECT SCOPE_IDENTITY();";

            string Query2 = @"INSERT INTO TestAppointments
                                           (TestTypeID
                                           ,LocalDrivingLicenseApplicationID
                                           ,AppointmentDate
                                           ,PaidFees
                                           ,CreatedByUserID
                                           ,IsLocked)
                                     VALUES
                                           (@TestTypeID
                                           ,@LocalDrivingLicenseApplicationID 
                                           ,@AppointmentDate
                                           ,@PaidFees
                                           ,@CreatedByUserID
                                           ,0)
                                        SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query1, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", RetakPaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            SqlCommand Command2 = new SqlCommand(Query2, Connection);
            Command2.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command2.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command2.Parameters.AddWithValue("@AppointmentDate", ApplicationDate);
            Command2.Parameters.AddWithValue("@PaidFees", TestFees);
            Command2.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command2.Parameters.AddWithValue("@IsLocked", IsLocked);

            SqlTransaction transaction = null;
            int NewAppointments = -1;
            try
            {

                Connection.Open();
                transaction = Connection.BeginTransaction();
                Command.Transaction = transaction;
                Command2.Transaction = transaction;
                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int InsertedID))
                {
                    NewApplicationID = InsertedID;
                }
                else
                {
                    transaction.Rollback();
                    return -1;
                }



                object NewResult = Command2.ExecuteScalar();

                if (NewResult != null && int.TryParse(NewResult.ToString(), out int InsertedNewID))
                {
                    NewAppointments = InsertedNewID;
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

                NewAppointments = -1;
            }
            finally
            {
                Connection.Close();
            }
            return NewAppointments;
        }
        public static bool FindRatakeExam( int TestAppointmentID , ref int ApplicationID , ref int LocalDrivingLicenseApplicationID , ref int ApplicantPersonID , int TestTypeID,ref int ApplicationTypeID, ref bool IsLocked)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                         TestAppointments.TestAppointmentID, Applications.ApplicationID,
                         LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
	                     Applications.ApplicantPersonID,TestAppointments.IsLocked,
	                     case when EXISTS ( select * from Applications AS A_Original
	                     where Applications.ApplicantPersonID = A_Original.ApplicantPersonID 
						 and A_Original.ApplicationTypeID = 8) 
						 then 8
						 else 1
	                     END As ApplicationType
                        FROM  Applications 
                        INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
                        INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                        where TestAppointments.TestAppointmentID =@TestAppointmentID  and TestAppointments.TestTypeID =@TestTypeID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                
                if(Reader.Read())
                {
                    IsFound = true;
                    if (Reader["ApplicantPersonID"] != DBNull.Value)
                    {
                        ApplicantPersonID = (int)Reader["ApplicantPersonID"];
                    }
                    else
                    {
                        ApplicantPersonID = 0;
                    }
                    if (Reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)Reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = 0;
                    }
                    if (Reader["LocalDrivingLicenseApplicationID"] != DBNull.Value)
                    {
                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    }
                    else
                    {
                        LocalDrivingLicenseApplicationID = 0;
                    }
                    if (Reader["ApplicationType"] != DBNull.Value)
                    {
                        ApplicationTypeID = (int)Reader["ApplicationType"];
                    }
                    else
                    {
                        ApplicationTypeID= 0;
                    }
                    if (Reader["IsLocked"] != DBNull.Value)
                    {
                        IsLocked = (bool)Reader["IsLocked"];
                    }
                    else
                    {
                        IsLocked = false;
                    }
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
        static public int findRatakeExam(int TestAppointmentID, int TestTypeID)
        {
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT 
                                        TestAppointments.TestAppointmentID, Applications.ApplicationID,
                                        LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, 
                                        Applications.ApplicantPersonID,TestAppointments.IsLocked,
                                        case when EXISTS ( select * from Applications AS A_Original
                                        where Applications.ApplicantPersonID = A_Original.ApplicantPersonID 
                                        and A_Original.ApplicationTypeID = 8) 
                                        then 8 
                                        else 1
                                        END As ApplicationType
                                        FROM  Applications 
                                        INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
                                        INNER JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                                        where TestAppointments.TestAppointmentID = @TestAppointmentID  and TestAppointments.TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    if (Reader["TestTypeID"] != DBNull.Value)
                    {
                        TestTypeID = (int)Reader["TestTypeID"];
                    }
                    else
                        {
                          TestTypeID = 0;
                        }
                    }
                }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return (TestAppointmentID);
        }

    }

}

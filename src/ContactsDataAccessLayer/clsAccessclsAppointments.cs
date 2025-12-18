using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ContactsDataAccessLayer
{
    public class clsAccessclsAppointments
    {
        static public DataTable GetAllAppointment(int TestTypeID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID , AppointmentDate , PaidFees , IsLocked from TestAppointments
                                       where TestTypeID = @TestTypeID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID" , TestTypeID);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }
        static public int AddNewAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID, DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            int AppointmentID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO TestAppointments
                                       (TestTypeID
                                        ,LocalDrivingLicenseApplicationID
                                       ,AppointmentDate
                                       ,PaidFees
                                       ,CreatedByUserID
                                        ,IsLocked)
                           VALUES
                                      (@TestTypeID,
                                      @LocalDrivingLicenseApplicationID,
                                      @AppointmentDate,
                                      @PaidFees,
                                      @CreatedByUserID,
                                      @IsLocked)
                                     SELECT SCOPE_IDENTITY()";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int insertAppointmentID))
                {
                    AppointmentID = insertAppointmentID;
                }
            }
            finally
            {
                Connection.Close();
            }

            return AppointmentID;
        }
        static public bool HasActiveAppointment(int LocalDrivingLicenseApplicationID , int TestTypeID,    bool IsLocked)
        {
            bool isFound= false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from TestAppointments
                                        where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypeID = @TestTypeID and IsLocked = @IsLocked";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue(@"LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue(@"TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue(@"IsLocked" , IsLocked);
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                
                if(Reader.HasRows)
                {
                    isFound = true;
                }
                else
                {
                    isFound = false;
                }

                Reader.Close();
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
        static public bool updateDateAppointment(int TestAppointmentID, DateTime NewAppointmentDate)
        {
            int RowAffected = 0;
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE TestAppointments
                                    SET AppointmentDate = @NewAppointmentDate
                                    WHERE TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@NewAppointmentDate", NewAppointmentDate);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffected > 0);
        }
        static public bool UpdateIsLockedAppointment(int TestAppointmentID, bool IsLocked)
        {
            int RowAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE TestAppointments
                                    SET IsLocked = @IsLocked
                                    WHERE TestAppointmentID = @TestAppointmentID;";
            SqlCommand Command = new SqlCommand(query , Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffected > 0);
        }
        static public bool FindAppointments( int TestAppointmentID, int TestTypeID , ref int LocalDrivingLicenseApplicationID, ref DateTime AppointmentDate , ref decimal PaidFees , ref bool IsLocked)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID ,TestTypeID,LocalDrivingLicenseApplicationID ,AppointmentDate , PaidFees , IsLocked from TestAppointments
                                            where TestAppointmentID =@TestAppointmentID and TestTypeID =@TestTypeID;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    isFound = true;
                    if (reader["LocalDrivingLicenseApplicationID"] != DBNull.Value)
                    {
                        LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                    }
                    else
                    {
                        TestAppointmentID = -1;
                    }
                    if (reader["AppointmentDate"] != DBNull.Value)
                    {
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                    }
                    else
                    {
                        AppointmentDate = DateTime.MinValue;
                    }
                    if (reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees  = 0;
                    }
                    if (reader["IsLocked"] != DBNull.Value)
                    {
                        IsLocked = (bool)reader["IsLocked"];
                    }
                    else
                    {
                        IsLocked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }


            return isFound;
        }
      static public bool FindLastClosedAppointment(int LocalDrivingLicenseApplicationID, ref int TestAppointmentID, ref int TestTypeID, ref DateTime AppointmentDate, ref decimal PaidFees,  bool IsLocked)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select TestAppointmentID ,TestTypeID ,AppointmentDate , PaidFees , IsLocked from TestAppointments
                                        where LocalDrivingLicenseApplicationID =@LocalDrivingLicenseApplicationID and IsLocked =@IsLocked
                                          ORDER BY AppointmentDate DESC, TestAppointmentID DESC";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    if (reader["TestAppointmentID"] != DBNull.Value)
                    {
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                    }
                    else
                    {
                        TestAppointmentID = -1;
                    }
                    if (reader["TestTypeID"] != DBNull.Value)
                    {
                        TestTypeID = (int)reader["TestTypeID"];
                    }
                    else
                    {
                        TestTypeID = -1;
                    }
                    if (reader["AppointmentDate"] != DBNull.Value)
                    {
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                    }
                    else
                    {
                        AppointmentDate = DateTime.MinValue;
                    }
                    if (reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees = 0;
                    }
                    if (reader["IsLocked"] != DBNull.Value)
                    {
                        IsLocked = (bool)reader["IsLocked"];
                    }
                    else
                    {
                        IsLocked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }


            return isFound;
      }
    }
}

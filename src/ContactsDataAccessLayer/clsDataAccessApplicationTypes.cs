using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsDataAccessApplicationTypes
    {
        static public bool GetInfoID(int ApplicationTypeID, ref string ApplicationTypeTitle, ref decimal ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from ApplicationTypes
                                    where ApplicationTypeID =@ApplicationTypeID;";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    if (reader["ApplicationTypeTitle"] != DBNull.Value)
                    {
                        ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    }
                    else
                    {
                        ApplicationTypeTitle = string.Empty;
                    }

                    if (reader["ApplicationFees"] != DBNull.Value)
                    {
                        ApplicationFees = (decimal)reader["ApplicationFees"];
                    }
                    else
                    {
                        ApplicationFees = -1;
                    }
                }
                else
                {
                    IsFound = false;
                }
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        static public DataTable GetAllAplicationsTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from ApplicationTypes";

            SqlCommand Command = new SqlCommand(query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader read = Command.ExecuteReader();

                if(read.HasRows)
                {
                    dt.Load(read);
                }
                read.Close();
            }
            finally
            {
                Connection.Close();
            }

            return dt;
        }
        static public bool UpdateApplicationsTypes( int ApplicationTypeID,   string ApplicationTypeTitle,   decimal ApplicationFees)
        {
            int RowAffects = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update ApplicationTypes
                                set ApplicationTypeTitle = @ApplicationTypeTitle,
                               ApplicationFees = @ApplicationFees
                                where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationTypeTitle", ApplicationTypeTitle);
            Command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                Connection.Open();
                RowAffects = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffects > 0);   
        }
        static public bool GetFeesOfLocalDrivers(ref int ApplicationTypeID,  ref string ApplicationTypeTitle,   decimal ApplicationFees)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"select * from ApplicationTypes
                        where ApplicationFees = @ApplicationFees;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationFees", ApplicationFees);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["ApplicationTypeID"] != DBNull.Value)
                    {
                        ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    }
                    else
                    {
                        ApplicationTypeID = -1;
                    }

                    if (reader["ApplicationTypeTitle"] != DBNull.Value)
                    {
                        ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    }
                    else
                    {
                        ApplicationTypeTitle = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }
}

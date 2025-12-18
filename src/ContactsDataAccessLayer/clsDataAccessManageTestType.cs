using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.SqlServer.Server;
namespace ContactsDataAccessLayer
{
    public class clsDataAccessManageTestType
    {
        static public DataTable GetAllTestType()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeury = @"select * from TestTypes";

            SqlCommand Command = new SqlCommand(qeury, Connection);

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
        static public bool GetFindID(int TestTypeID , ref string TestTypeTitle , ref string TestTypeDescription ,ref  decimal TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestTypes
                                    where TestTypeID = @TestTypeID;";

            SqlCommand Commend = new SqlCommand(query, Connection);

            Commend.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Commend.ExecuteReader();
                if(Reader.Read())
                {
                    IsFound = true;

                    if (Reader["TestTypeTitle"] != DBNull.Value)
                    {
                        TestTypeTitle = (string)Reader["TestTypeTitle"];
                    }
                    else
                    {
                        TestTypeTitle = string.Empty;
                    }

                    if (Reader["TestTypeDescription"] != DBNull.Value)
                    {
                        TestTypeDescription = (string)Reader["TestTypeDescription"];
                    }
                    else
                    {
                        TestTypeDescription = string.Empty;
                    }

                    if (Reader["TestTypeFees"] != DBNull.Value)
                    {
                        TestTypeFees = (decimal)Reader["TestTypeFees"];
                    }
                    else
                    {
                        TestTypeFees = -1;
                    }
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                IsFound=false;
            }
            finally
            {
                Connection.Close ();
            }

            return IsFound;
        }
        static public bool UpdateManageTestType(int TestTypeID,  string TestTypeTitle,  string TestTypeDescription,  decimal TestTypeFees)
        {
            int RowAffect = 0;

            SqlConnection Connection = new SqlConnection ( clsDataAccessSettings.ConnectionString );
            string query = @"update TestTypes 
                                set TestTypeTitle = @TestTypeTitle,
                                TestTypeDescription = @TestTypeDescription,
                                TestTypeFees = @TestTypeFees
                                where TestTypeID = @TestTypeID;";

            SqlCommand cmd = new SqlCommand ( query, Connection );

            cmd.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            cmd.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            cmd.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            cmd.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                Connection.Open();
                RowAffect = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close ();
            }

            return (RowAffect > 0);
        }

        
    }
}

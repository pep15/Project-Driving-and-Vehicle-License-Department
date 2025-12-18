using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsAccessTestType
    {
        static public bool FindTypeFees(int TestTypeID , ref string TestTypeTitle , ref string TestTypeDescription  , ref decimal TestTypeFees)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from TestTypes
                                    where TestTypeID = @TestTypeID";

           SqlCommand Commend = new SqlCommand(query, Connection);

            Commend.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Commend.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                    if (reader["TestTypeTitle"] != DBNull.Value)
                    {
                        TestTypeTitle = (string)reader["TestTypeTitle"];
                    }
                    else
                    {
                        TestTypeTitle = string.Empty;
                    }
                    if (reader["TestTypeDescription"] != DBNull.Value)
                    {
                        TestTypeDescription = (string)reader["TestTypeDescription"];
                    }
                    else
                    {
                        TestTypeDescription = string.Empty;
                    }
                    if (reader["TestTypeFees"] != DBNull.Value)
                    {
                        TestTypeFees = (decimal)reader["TestTypeFees"];
                    }
                    else
                    {
                        TestTypeFees = 0;
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
    }
}

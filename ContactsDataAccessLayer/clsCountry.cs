using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDataAccessLayer
{
    public class clsCountry
    {
        public static DataTable GettAllCountry()
        {
            DataTable dtCountry = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Queriy = @"select * from Countries ";

            SqlCommand Command  = new SqlCommand(Queriy, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.HasRows)
                {
                    dtCountry.Load(reader);
                }

                reader.Close();
            }
            finally
            {
                Connection.Close();
            }

            return dtCountry;
        }
        public static string GetCountryName(int CountryID)
        {
            string CountryName = "Unkown country";

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select CountryName from Countries where CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            try
            {
                Connection.Open();

                object result = command.ExecuteScalar();

                if(result != null)
                {
                    CountryName = (string)result;
                }

            }
            finally
            {
                Connection.Close();
            }

            return CountryName;

        }
    }
}

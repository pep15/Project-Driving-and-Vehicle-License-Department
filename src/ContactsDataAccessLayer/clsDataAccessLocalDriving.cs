using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsDataAccessLocalDriving
    {
        static public DataTable GetLocalDrivingLincess()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from LicenseClasses;";

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
    }
}

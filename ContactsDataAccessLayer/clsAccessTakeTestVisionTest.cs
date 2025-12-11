using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsAccessTakeTestVisionTest
    {
        static public int AddNewTest(int TestAppointmentID ,  byte TestResult , string Notes , int CreatedByUserID)
        {
            int TestID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Tests
                                (TestAppointmentID, TestResult, Notes, CreatedByUserID) 
		                     VALUES  
		                     (@TestAppointmentID ,@TestResult,@Notes,@CreatedByUserID);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);
            Command.Parameters.AddWithValue("@Notes", Notes);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString() , out int insertedID))
                {
                    TestID = insertedID;
                }
            }
            finally
            {
                Connection.Close();
            }

            return TestID;
        }
    }
}

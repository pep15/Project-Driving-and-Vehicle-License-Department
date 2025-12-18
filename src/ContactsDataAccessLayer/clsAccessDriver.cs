using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ContactsDataAccessLayer
{
    public class clsAccessDriver
    {
        static public int AddNewDriver(int PersonID, int CreatedByUserID , DateTime CreatedDate)
        {
            int DriverID = -1;
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"INSERT INTO Drivers
                            (PersonID
                            ,CreatedByUserID
                            ,CreatedDate)
                        VALUES
                            (@PersonID
                            ,@CreatedByUserID
                            ,@CreatedDate)
                            SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int insteredID))
                {
                    DriverID = insteredID;
                }
            }
            finally
            {
                Connection.Close();
            }


            return DriverID; ;

        }
        static public bool HasLicenses(int PersonID  ,int LicenseClass)
        {
            bool IsFound = false;
             
            
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT  Found = 1 ,People.PersonID , Drivers.DriverID, Licenses.LicenseID, Licenses.IsActive , Licenses.LicenseClass
                             FROM  Drivers INNER JOIN
                             Licenses ON Drivers.DriverID = Licenses.DriverID INNER JOIN
                             People ON Drivers.PersonID = People.PersonID
		                     where  People.PersonID =@PersonID and Licenses.IsActive = 1 and Licenses.LicenseClass = @LicenseClass";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClass);


            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                IsFound = Reader.HasRows;
                Reader.Close();
            }
            catch(Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;
        }
        static public DataTable ListLicensesDriver(int ApplicantPersonID)
        {
            DataTable dt = new DataTable();
            

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive
                             FROM  Licenses 
                             INNER JOIN LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID 
                             INNER JOIN Applications ON Licenses.ApplicationID = Applications.ApplicationID 
                             INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID
                             where Applications.ApplicantPersonID = @ApplicantPersonID";

            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("ApplicantPersonID", ApplicantPersonID);

            try
            {

                Connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
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
        static public DataTable ListLicensesDriverPerson()
        {
            DataTable dt = new DataTable();
            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);
            string query = @"SELECT Drivers.DriverID,Drivers.PersonID, People.NationalNo, CONCAT( People.FirstName, ' ' ,People.SecondName, ' ' ,People.ThirdName, ' ' ,People.LastName) As FullName, People.DateOfBirth as Date, sum(case when Licenses.IsActive = 1 then 1 else 0 end) as [Active Licenses]
                             FROM  Drivers 
                             INNER JOIN People ON Drivers.PersonID = People.PersonID 
                             INNER JOIN Licenses ON Drivers.DriverID = Licenses.DriverID
                             group by Drivers.DriverID,Drivers.PersonID,  People.NationalNo, People.FirstName,People.SecondName,People.ThirdName,People.LastName,People.DateOfBirth";

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
    }
}

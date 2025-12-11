using System;
using System.Data;
using System.Data.SqlClient;

namespace ContactsDataAccessLayer
{
    public class clsDataUser
    {
        public static bool GetInfoUsersID(int UserID , ref int PersonID , ref string UserName  , ref string Password,ref bool isActive )
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select * from Users where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    IsFound = true;
                    PersonID = (int)reader["PersonID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];

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
        public static bool GetInfoPersonID(ref int UserID, int PersonID,  ref string UserName, ref string Password,ref bool isActive)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select * from Users where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    isActive = (bool)reader["isActive"];

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
        public static bool GetInofUserByUserName(ref int UserID , ref int PersonID , string UserName ,ref string Password , ref bool isActive )
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);

            string Query = "select * from Users where UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query,Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.Read())
                {
                    IsFound = true;
                    UserID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    Password =(string)reader["Password"];   
                    isActive = (bool)reader["isActive"];
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
        public static int AddNewUser( int PersonID  , string UserName , string Password,bool isActive)
        {
            int UserID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"INSERT INTO Users ( PersonID , UserName , Password,isActive ) 
                                    VALUES(@PersonID , @UserName,@Password,@isActive );
                                    SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query,Connection);

            
            Command.Parameters.AddWithValue("@PersonID" , PersonID);
            Command.Parameters.AddWithValue("@UserName" , UserName);
            Command.Parameters.AddWithValue("@Password" , Password);
            Command.Parameters.AddWithValue("@isActive" , isActive);

            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString() , out int InsertedID))
                {
                    UserID = InsertedID;
                }

            }
            finally
            {
                Connection.Close();
            }

            return UserID;
        }
        public static bool UpdateUser(int UserID , int PersonID , string UserName , string Password,bool IsActive)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);

             string query = @"UPDATE Users
                   SET PersonID = @PersonID,
                       UserName = @UserName,
                       Password = @Password,
                       IsActive = @IsActive
                   WHERE UserID = @UserID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            
            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();

            }
            finally
            {
                Connection.Close();
            }

            
            return (RowAffected > 0);
        }
        public static bool DeleteUsers(int UserID)
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"DELETE FROM Users
                                        where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query , Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

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
        public static DataTable GetAllUser()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"SELECT Users.UserID, Users.PersonID,  CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  as FullName, Users.UserName , Users.IsActive
                                        FROM  Users INNER JOIN
                                        People ON Users.PersonID = People.PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.HasRows)
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
        public static bool IsActive(bool isActive)
        {
            bool Isactive = false;

            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);

            string query = @"select * from Users
                                        where IsActive = @IsActive;";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@IsActive", isActive);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                isActive = reader.HasRows;

            }
            catch 
            {
                Isactive=false;
            }
            finally
            {
                Connection.Close();
            }

            return Isactive;
        }
        public static bool IsUserIDExsit(int UserID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection( clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query , Connection );
            Command.Parameters.AddWithValue("@UserID", UserID);

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
        public static bool IsUserNameAndPasswordExsit(string UserName , string Password)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select Found=1 from Users where UserName =@UserName and Password =@Password;";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);

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
    }
}

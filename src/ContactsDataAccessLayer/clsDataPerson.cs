using System;
using System.Data;
using System.Data.SqlClient;
namespace ContactsDataAccessLayer
{
    public class clsDataPerson
    {
        public static bool GetInfoPersonByID(int PersonID  ,ref string NationalNo , ref string FirstName , ref string SecondName ,
            ref string ThirdName , ref string LastName , ref DateTime DateOfBirth , ref short Gendor , ref string Address , 
            ref string Phone , ref string Email , ref int NationalityCountryID , ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection  = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from People
                                       where PersonID =@PersonID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if(reader.Read())
                {
                    isFound = true;
                    if (reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)reader["NationalNo"];
                    }   
                    else
                    {
                        NationalNo = string.Empty;
                    }
                  

                    if(reader["FirstName"] != DBNull.Value)
                    {
                        FirstName = (string)reader["FirstName"];
                    }
                   else
                    {
                        FirstName = string.Empty;
                    }

                    if(reader["SecondName"] != DBNull.Value)
                    {
                        SecondName = (string)reader["SecondName"];
                    }
                    else
                    {
                        SecondName= string.Empty;
                    }

                    if(reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)reader["ThirdName"];
                    }
                   else
                    {
                        ThirdName = string.Empty;
                    }

                    if (reader["LastName"] != DBNull.Value)
                    {
                        LastName = (string)reader["LastName"];
                    }
                    else
                    {
                        LastName = string.Empty;
                    }
                    if (reader["Address"] != DBNull.Value)
                    {
                        Address = (string)reader["Address"];
                    }
                    else
                    {
                        Address = string.Empty;
                    }
                    if (reader["Phone"] != DBNull.Value)
                    {
                        Phone = (string)reader["Phone"];
                    }
                    else
                    {
                        Phone = string.Empty;
                    }

                    if (reader["Email"] != DBNull.Value)
                    {
                        Email = (string)reader["Email"];
                    }
                    else
                    {
                        Email = string.Empty;
                    }

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                   
                    if (reader["Gendor"] != DBNull.Value)
                    {
                        Gendor =  Convert.ToInt16( reader["Gendor"]);
                    }
                    else
                    {
                        Gendor = -1;
                    }

                    if (reader["NationalityCountryID"] != DBNull.Value)
                    {
                        NationalityCountryID = (int)reader["NationalityCountryID"];
                    }
                    else
                    {
                        NationalityCountryID = -1;
                    }

                    if (reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }

                }
                else
                {
                    isFound = false;
                }
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }
        public static bool GetInfoPersonByNationalNo(string NationalNo, ref int PersonID, ref string FirstName, ref string secondName,
            ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref short Gendor, ref string Address,
            ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from People where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    PersonID = (int)reader["PersonID"];
                    FirstName = (string)reader["FirstName"];
                    secondName = (string)reader["secondName"];
                    ThirdName = (string)reader["ThirdName"];
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    if (reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = Convert.ToInt16(reader["Gendor"]);
                    }
                    else
                    {
                        Gendor = -1;
                    }
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = (string)reader["Email"];
                    NationalityCountryID = (int)reader["NationalityCountryID"];

                    if (reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }

                }
                else
                {
                    isFound = false;
                }
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }
        public static int AddNewPerson(string NationalNo , string FirstName , string SecondName, string ThirdName , string LastName ,
           DateTime DateOfBirth , short Gendor  , string Address , string Phone , string Email , int NationalityCountryID , string ImagePath)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO People (NationalNo, FirstName, SecondName,
                                     ThirdName, LastName, DateOfBirth,
                                     Gendor, Address, Phone, Email,
                                     NationalityCountryID, ImagePath) VALUES
                                     (@NationalNo, @FirstName, @SecondName,
                                      @ThirdName, @LastName, @DateOfBirth,
                                      @Gendor, @Address, @Phone, @Email,         
                                      @NationalityCountryID, @ImagePath);
                 SELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != null)
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }
            
            try
            {
                Connection.Open();
                object result = Command.ExecuteScalar();
                if(result != null && int.TryParse(result.ToString() , out int insertedID))
                {
                    PersonID = insertedID;
                }
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;
        }                                                                                                                              
        public static bool UpdatePerson(int PersonID, string NationalNo ,  string FirstName , string SecondName,
            string ThirdName , string LastName , DateTime DateOfBirth , short Gendor , string Address , string Phone 
            , string Email, int NationalityCountryID , string ImagePath )
        {
            int RowAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"update People set 
			                            NationalNo = @NationalNo , 
			                            FirstName = @FirstName , 
			                            SecondName = @SecondName,
                                        ThirdName = @ThirdName, 
			                            LastName =@LastName , 
			                            DateOfBirth =@DateOfBirth ,
			                            Gendor = @Gendor,
			                            Address = @Address ,
			                            Phone = @Phone,
			                            Email = @Email , 
			                            NationalityCountryID = @NationalityCountryID, 
			                            ImagePath = @ImagePath
			                            where PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@PersonID" , PersonID);
            Command.Parameters.AddWithValue("@NationalNo" , NationalNo);
            Command.Parameters.AddWithValue("@FirstName" , FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName" , ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@Email", Email);
            Command.Parameters.AddWithValue("@NationalityCountryID" , NationalityCountryID);
            
            if(ImagePath != null )
            {
                Command.Parameters.AddWithValue("@ImagePath" , ImagePath);
            }
            else
            {
                Command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                Connection.Open();
                RowAffected = Command.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffected > 0);
        }
        public static bool DeletePerson(int PersonID)
        {
            int RowAffectes = 0;        

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"DELETE FROM People
                                        where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                RowAffectes = Command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return (RowAffectes > 0);
        }
        public static DataTable GetPersons()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,  Countries.CountryName  , case
	                                     when Gendor = 0  then 'Male'
	                                     else 'Female'
                                       end  As Gendor , People.Address, People.Phone, People.Email, People.ImagePath 
                                      FROM  People INNER JOIN
                                     Countries ON People.NationalityCountryID = Countries.CountryID";

            SqlCommand Command = new SqlCommand(Query , Connection);

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
        public static bool PersonIDIsExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select Found=1 from People where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close() ;
            }

            return IsFound;       
                
        }
        public static bool PersonIsExistbyNational(string NationalNo)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = "select Found=1 from People where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;

        }
    }                                                                                                                                  
}                                                                                                                                      
                                                                                                              
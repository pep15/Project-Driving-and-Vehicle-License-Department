using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;

namespace ContactsDataAccessLayer
{
    static public class clsAccessShowLicense
    {
        static public bool FindLicensebyLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID ,ref int ApplicationID, ref int LicenseID 
            , ref int DriverID , ref string NationalNo , ref string FullName, ref DateTime DateOfBirth,
            ref byte Gendor , ref DateTime IssueDate , ref DateTime ExpirationDate, 
            ref string Notes ,ref bool IsActive , ref byte IssueReason , ref string ClassName , ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Applications.ApplicationID,Licenses.LicenseID, Drivers.DriverID, People.NationalNo, CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  AS FullName, People.DateOfBirth , People.Gendor, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.Notes, Licenses.IsActive, Licenses.IssueReason,  LicenseClasses.ClassName, People.ImagePath
                            FROM  LocalDrivingLicenseApplications INNER JOIN
                            Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                            Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                            LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID AND Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
                            Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID AND Drivers.PersonID = People.PersonID
		                    where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    if(Reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)Reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = -1;
                    }
                    if (Reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)Reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (Reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)Reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)Reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (Reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }
                    if (Reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)Reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                    if (Reader["IssueReason"] != DBNull.Value)
                    {
                        IssueReason = (byte)Reader["IssueReason"];
                    }
                    else
                    {
                        IssueReason = 0;
                    }
                    if (Reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)Reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }

        static public bool FindLicensebyApplicationID(int ApplicationID, ref int LocalDrivingLicenseApplicationID, ref int LicenseID
            , ref int DriverID, ref string NationalNo, ref string FullName, ref DateTime DateOfBirth,
            ref byte Gendor, ref DateTime IssueDate, ref DateTime ExpirationDate,
            ref string Notes, ref bool IsActive, ref byte IssueReason, ref string ClassName, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicationID , LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Licenses.LicenseID, Drivers.DriverID, People.NationalNo, CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  AS FullName, People.DateOfBirth , People.Gendor, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.Notes, Licenses.IsActive, Licenses.IssueReason,  LicenseClasses.ClassName, People.ImagePath
                            FROM  LocalDrivingLicenseApplications INNER JOIN
                            Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                            Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                            LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID AND Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
                            Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID AND Drivers.PersonID = People.PersonID
		                    where Applications.ApplicationID = @ApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    if (Reader["LocalDrivingLicenseApplicationID"] != DBNull.Value)
                    {
                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    }
                    else
                    {
                        LocalDrivingLicenseApplicationID = -1;
                    }
                    if (Reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)Reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }
                    if (Reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)Reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["DateOfBirth"] != DBNull.Value)
                    {
                        DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    }
                    else
                    {
                        DateOfBirth = DateTime.MinValue;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)Reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (Reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }
                    if (Reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)Reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                    if (Reader["IssueReason"] != DBNull.Value)
                    {
                        IssueReason = (byte)Reader["IssueReason"];
                    }
                    else
                    {
                        IssueReason = 0;
                    }
                    if (Reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)Reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }
        static public bool FindLicensebyLicenseID(int LicenseID, ref int LocalDrivingLicenseApplicationID
           , ref int DriverID, ref string NationalNo,ref int LicenseClass, ref byte IssueReason, ref string ClassName,ref decimal ClassFees, ref string FullName, ref DateTime DateOfBirth,
           ref byte Gendor, ref DateTime IssueDate, ref DateTime ExpirationDate,
           ref string Notes,   ref string ImagePath , ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Licenses.LicenseID,LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID ,Drivers.DriverID, People.NationalNo, Licenses.LicenseClass, Licenses.IssueReason, LicenseClasses.ClassName, LicenseClasses.ClassFees ,CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  AS FullName, People.DateOfBirth , People.Gendor, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.Notes, People.ImagePath , Licenses.IsActive
                            FROM  LocalDrivingLicenseApplications INNER JOIN
                            Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                            Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN
                            LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID AND Licenses.LicenseClass = LicenseClasses.LicenseClassID INNER JOIN
                            Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN
                            People ON Applications.ApplicantPersonID = People.PersonID AND Drivers.PersonID = People.PersonID
		                    where Licenses.LicenseID =@LicenseID";

            SqlCommand Command = new SqlCommand(query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    if (Reader["LocalDrivingLicenseApplicationID"] != DBNull.Value)
                    {
                        LocalDrivingLicenseApplicationID = (int)Reader["LocalDrivingLicenseApplicationID"];
                    }
                    else
                    {
                        LocalDrivingLicenseApplicationID = -1;
                    }
                    if (Reader["DriverID"] != DBNull.Value)
                    {
                        DriverID = (int)Reader["DriverID"];
                    }
                    else
                    {
                        DriverID = -1;
                    }
                    if (Reader["NationalNo"] != DBNull.Value)
                    {
                        NationalNo = (string)Reader["NationalNo"];
                    }
                    else
                    {
                        NationalNo = string.Empty;
                    }
                    if (Reader["LicenseClass"] != DBNull.Value)
                    {
                        LicenseClass = (int)Reader["LicenseClass"];
                    }
                    else
                    {
                        LicenseClass = -1;
                    }
                    if (Reader["IssueReason"] != DBNull.Value)
                    {
                        IssueReason = (byte)Reader["IssueReason"];
                    }
                    else
                    {
                        IssueReason = 0;
                    }
                    if (Reader["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)Reader["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (Reader["ClassFees"] != DBNull.Value)
                    {
                        ClassFees = (decimal)Reader["ClassFees"];
                    }
                    else
                    {
                        ClassFees = -1;
                    }
                    if (Reader["FullName"] != DBNull.Value)
                    {
                        FullName = (string)Reader["FullName"];
                    }
                    else
                    {
                        FullName = string.Empty;
                    }
                    if (Reader["Gendor"] != DBNull.Value)
                    {
                        Gendor = (byte)Reader["Gendor"];
                    }
                    else
                    {
                        Gendor = 0;
                    }
                    if (Reader["IssueDate"] != DBNull.Value)
                    {
                        IssueDate = (DateTime)Reader["IssueDate"];
                    }
                    else
                    {
                        IssueDate = DateTime.MinValue;
                    }
                    if (Reader["ExpirationDate"] != DBNull.Value)
                    {
                        ExpirationDate = (DateTime)Reader["ExpirationDate"];
                    }
                    else
                    {
                        ExpirationDate = DateTime.MinValue;
                    }
                    if (Reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)Reader["Notes"];
                    }
                    else
                    {
                        Notes = string.Empty;
                    }
                    if (Reader["ImagePath"] != DBNull.Value)
                    {
                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = string.Empty;
                    }
                    if (Reader["IsActive"] != DBNull.Value)
                    {
                        IsActive = (bool)Reader["IsActive"];
                    }
                    else
                    {
                        IsActive = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }
        static public bool FindLicensebyPersonID(int ApplicantPersonID , ref int LicenseID)
        {
            bool isFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Applications.ApplicantPersonID ,Licenses.LicenseID
                             FROM  LocalDrivingLicenseApplications INNER JOIN
                             Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                              Licenses ON Applications.ApplicationID = Licenses.ApplicationID
		                      where Applications.ApplicantPersonID =@ApplicantPersonID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);



            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    if (Reader["LicenseID"] != DBNull.Value)
                    {
                        LicenseID = (int)Reader["LicenseID"];
                    }
                    else
                    {
                        LicenseID = -1;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return isFound;
        }
    }
}

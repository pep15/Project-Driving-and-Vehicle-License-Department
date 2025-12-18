using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace ContactsDataAccessLayer
{
    public class clsAccessVisonTest
    {
        static public DataTable getAllDataVision()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string Query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, CONCAT(People.FirstName, ' ', People.SecondName, ' ', People.ThirdName, ' ', People.LastName)  AS fullName, Applications.ApplicationID, Applications.ApplicationDate, SUM(CASE WHEN Tests.TestResult = 1 THEN 1 ELSE 0 END) AS PassedTests, 
                                       Applications.ApplicationStatus AS Status, ApplicationTypes.ApplicationTypeTitle, ApplicationTypes.ApplicationFees, Tests.Notes
                                        FROM  LocalDrivingLicenseApplications INNER JOIN
                                          LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID INNER JOIN
                                          Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN
                                          People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN
                                          ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID LEFT OUTER JOIN
                                          TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID LEFT OUTER JOIN
                                          Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                            GROUP BY LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, Applications.ApplicationID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, Applications.ApplicationDate, Applications.ApplicationStatus, ApplicationTypes.ApplicationTypeTitle, ApplicationTypes.ApplicationFees, Tests.Notes";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader read = Command.ExecuteReader();
                if (read.HasRows)
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
        static public bool DrivingLicenseApplicationInfo(int LocalDrivingLicenseApplicationID , ref string ClassName, ref byte TestResult)
        {
            bool Isfound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
          
            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, SUM(case when Tests.TestResult= 1 THEN 1 ELSE 0 END) as PassedTests
                                      FROM  LocalDrivingLicenseApplications 
                                      INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                                      LEFT JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                                      LEFT JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                      where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                      group by LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID , LicenseClasses.ClassName; ";


            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();
                SqlDataReader read = Command.ExecuteReader();
               
                if (read.Read())
                {
                    Isfound = true;
                    if (read["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)read["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }

                    if (read["PassedTests"] != DBNull.Value)
                    {
                        TestResult = Convert.ToByte(read["PassedTests"]);
                    }
                    else
                    {
                        TestResult = 0;
                    }
                }
                else
                {
                    Isfound = false;
                }

            }
            catch (Exception ex)
            {
                Isfound = false;
            }
            finally
            {
                Connection.Close();
            }

            return Isfound;
        }
        static public bool ApplicationBasicInfo(int LocalDrivingLicenseApplicationID , ref int ApplicationID , ref string ApplicationTypeTitle , ref DateTime ApplicationDate , ref byte ApplicationStatus , ref decimal PaidFees , ref string UserName , ref string FirstName , ref string SecondName , ref string ThirdName , ref string LastName )
        {
            bool Isfound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, Applications.ApplicationID, ApplicationTypes.ApplicationTypeTitle, Applications.ApplicationDate, Applications.ApplicationStatus, Applications.PaidFees,  Users.UserName, People.FirstName, People.SecondName, People.ThirdName, People.LastName
                                    FROM  Applications 
                                    INNER JOIN ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID 
                                    INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                                    INNER JOIN Users ON Applications.CreatedByUserID = Users.UserID INNER JOIN
                                    LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
	                            	 where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            try
            {
                Connection.Open();
                SqlDataReader  reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    Isfound = true;
                    if (reader["ApplicationID"] != DBNull.Value)
                    {
                        ApplicationID = (int)reader["ApplicationID"];
                    }
                    else
                    {
                        ApplicationID = 0;
                    }
                    if (reader["ApplicationTypeTitle"] != DBNull.Value)
                    {
                        ApplicationTypeTitle = (string)reader["ApplicationTypeTitle"];
                    }
                    else
                    {
                        ApplicationTypeTitle = string.Empty;
                    }
                    if (reader["ApplicationDate"] != DBNull.Value)
                    {
                        ApplicationDate = (DateTime)reader["ApplicationDate"];
                    }
                    else
                    {
                        ApplicationDate = DateTime.MinValue;
                    }
                    if (reader["ApplicationStatus"] != DBNull.Value)
                    {
                        ApplicationStatus = (byte)reader["ApplicationStatus"];
                    }
                    else
                    {
                        ApplicationStatus = 0;
                    }
                    if (reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees = 0;
                    }
                    if (reader["UserName"] != DBNull.Value)
                    {
                        UserName = (string)reader["UserName"];
                    }
                    else
                    {
                        UserName = string.Empty;
                    }
                    if (reader["FirstName"] != DBNull.Value)
                    {
                        FirstName = (string)reader["FirstName"];
                    }
                    else
                    {
                        FirstName = string.Empty;
                    }
                    if (reader["SecondName"] != DBNull.Value)
                    {
                        SecondName = (string)reader["SecondName"];
                    }
                    else
                    {
                        SecondName = string.Empty;
                    }
                    if (reader["ThirdName"] != DBNull.Value)
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
                    

                }
                
            }
            catch (Exception ex)
            {
                Isfound = false;
            }
            finally
            {
                Connection.Close();
            }

            return Isfound;
        }
        static public bool GetLastTestAppointmentResult(int LocalDrivingLicenseApplicationID , int TestTypeID,ref  int TestAppointmentID ,   ref DateTime AppointmentDate, ref decimal PaidFees , ref int CreatedByUserID ,  bool IsLocked , ref byte PassedTests)
        {
            bool Isfound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT TOP 1
                                        TestAppointments.TestAppointmentID, TestAppointments.TestTypeID, TestAppointments.LocalDrivingLicenseApplicationID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.CreatedByUserID, TestAppointments.IsLocked, SUM(case when Tests.TestResult= 1 THEN 1 ELSE 0 END) as PassedTests
                                        FROM  TestAppointments 
                                        LEFT JOIN  Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                        where TestAppointments.LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID and TestAppointments.TestTypeID=@TestTypeID and TestAppointments.IsLocked = @IsLocked
                                        group by TestAppointments.TestAppointmentID, TestAppointments.TestTypeID, TestAppointments.LocalDrivingLicenseApplicationID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.CreatedByUserID, TestAppointments.IsLocked
                                        order by AppointmentDate desc";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@IsLocked", IsLocked);
            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                if(reader.Read())
                {
                    Isfound = true;
                    if (reader["TestAppointmentID"] != DBNull.Value)
                    {
                        TestAppointmentID = (int)reader["TestAppointmentID"];
                    }
                    else
                    {
                        TestAppointmentID = -1;
                    }
                    if (reader["AppointmentDate"] != DBNull.Value)
                    {
                        AppointmentDate = (DateTime)reader["AppointmentDate"];
                    }
                    else
                    {
                        AppointmentDate = DateTime.MinValue;
                    }
                    if (reader["PaidFees"] != DBNull.Value)
                    {
                        PaidFees = (decimal)reader["PaidFees"];
                    }
                    else
                    {
                        PaidFees   = -1;
                    }
                    if (reader["CreatedByUserID"] != DBNull.Value)
                    {
                        CreatedByUserID = (int)reader["CreatedByUserID"];
                    }
                    else
                    {
                        CreatedByUserID= -1;
                    }
                    if (reader["PassedTests"] != DBNull.Value)
                    {
                        PassedTests = Convert.ToByte(reader["PassedTests"]);
                    }
                    else
                    {
                        PassedTests = 0;
                    }

                }
            }
            catch (Exception ex)
            {
                Isfound = false;
            }
            finally
            {
                Connection.Close();
            }

            return Isfound;
        }

    }
}

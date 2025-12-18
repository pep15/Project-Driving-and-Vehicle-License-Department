using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ContactsDataAccessLayer
{
    public class clsAccessSchedultTestVision
    {

        static public bool FindPersonSchedultTest(int  LocalDrivingLicenseApplicationID,  ref string ClassName, ref int TotalTrials, ref decimal TestTypeFees, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.FirstName, People.SecondName, People.ThirdName, People.LastName,  Count( Tests.TestResult ) AS TotalTrials, TestTypes.TestTypeFees
                                       FROM  LocalDrivingLicenseApplications 
                                       INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                                       INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
                                       INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                                       LEFT JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                                       LEFT JOIN TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID 
                                       LEFT JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                       where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID 
                                       GROUP BY LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,LicenseClasses.ClassName, People.FirstName, People.SecondName, People.ThirdName, People.LastName, TestTypes.TestTypeFees";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            
            

            try
            {
                Connection.Open();
                SqlDataReader readr = Command.ExecuteReader();

                if(readr.Read())
                {
                    IsFound = true;
                    if (readr["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)readr["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (readr["TotalTrials"] != DBNull.Value)
                    {
                        TotalTrials = (int)readr["TotalTrials"];
                    }
                    else
                    {
                        TotalTrials = 0;
                    }
                    if (readr["TestTypeFees"] != DBNull.Value)
                    {
                        TestTypeFees = (decimal)readr["TestTypeFees"];
                    }
                    else
                    {
                        TestTypeFees = 0;
                    }
                    if (readr["FirstName"] != DBNull.Value)
                    {
                        FirstName = (string)readr["FirstName"];
                    }
                    else
                    {
                        FirstName = string.Empty;
                    }
                    if (readr["SecondName"] != DBNull.Value)
                    {
                        SecondName = (string)readr["SecondName"];
                    }
                    else
                    {
                        SecondName = string.Empty;
                    }
                    if (readr["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)readr["ThirdName"];
                    }
                    else
                    {
                        ThirdName = string.Empty;
                    }
                    if (readr["LastName"] != DBNull.Value)
                    {
                        LastName = (string)readr["LastName"];
                    }
                    else
                    {
                        LastName = string.Empty;
                    }
                    


                }
            }
            catch (Exception e)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsFound;

        }
        static public bool FindPersonSchedultTest(int LocalDrivingLicenseApplicationID, int TestTypeID , ref string ClassName, ref int TotalTrials, ref decimal TestTypeFees, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.FirstName, People.SecondName, People.ThirdName, People.LastName,  Count( Tests.TestResult ) AS TotalTrials, TestTypes.TestTypeFees
                                       FROM  LocalDrivingLicenseApplications 
                                       INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
                                       INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID 
                                       INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
                                       LEFT JOIN TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                                       LEFT JOIN TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID 
                                       LEFT JOIN Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                                       where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and TestTypes.TestTypeID = @TestTypeID
                                       GROUP BY LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,LicenseClasses.ClassName, People.FirstName, People.SecondName, People.ThirdName, People.LastName, TestTypes.TestTypeFees";

            SqlCommand Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);



            try
            {
                Connection.Open();
                SqlDataReader readr = Command.ExecuteReader();

                if (readr.Read())
                {
                    IsFound = true;
                    if (readr["ClassName"] != DBNull.Value)
                    {
                        ClassName = (string)readr["ClassName"];
                    }
                    else
                    {
                        ClassName = string.Empty;
                    }
                    if (readr["TotalTrials"] != DBNull.Value)
                    {
                        TotalTrials = (int)readr["TotalTrials"];
                    }
                    else
                    {
                        TotalTrials = 0;
                    }
                    if (readr["TestTypeFees"] != DBNull.Value)
                    {
                        TestTypeFees = (decimal)readr["TestTypeFees"];
                    }
                    else
                    {
                        TestTypeFees = 0;
                    }
                    if (readr["FirstName"] != DBNull.Value)
                    {
                        FirstName = (string)readr["FirstName"];
                    }
                    else
                    {
                        FirstName = string.Empty;
                    }
                    if (readr["SecondName"] != DBNull.Value)
                    {
                        SecondName = (string)readr["SecondName"];
                    }
                    else
                    {
                        SecondName = string.Empty;
                    }
                    if (readr["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)readr["ThirdName"];
                    }
                    else
                    {
                        ThirdName = string.Empty;
                    }
                    if (readr["LastName"] != DBNull.Value)
                    {
                        LastName = (string)readr["LastName"];
                    }
                    else
                    {
                        LastName = string.Empty;
                    }



                }
            }
            catch (Exception e)
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

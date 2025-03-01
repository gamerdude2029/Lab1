using Microsoft.Data.SqlClient;
using Lab1.Pages.DataClasses;

namespace Lab1.Pages.DB
{
    public class DBClass
    {
        public static SqlConnection Lab1DBConnection = new SqlConnection();
        public static readonly string Lab1DBConnString = "Server=Localhost;Database=Lab1;Trusted_Connection=True;TrustServerCertificate=True";



        public static SqlDataReader ProductReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = "SELECT Users.UserID, Users.Name, Users.Email, Users.Password, Users.Role, Grants.GrantID, Grants.Title, Grants.Category, Grants.FundingAgency, Grants.SubmissionDate, Grants.AwardDate, Grants.Amount,Grants.LeadFacultyID, Grants.Status, Project.ProjectID, Project.Title, Project.DueDate, Project.CreatedByAdminID, Project.Status, GrantOrgAdmin.AdminID, GrantOrgAdmin.UserID, GrantOrgAdmin.OrganizationRole, Faculty.FacultyID, Faculty.UserID, Faculty.Department FROM Users, Grants, Project, GrantOrgAdmin, Faculty Where Users.UserID = Grants.GrantID AND Grants.GrantID = Project.ProjectID AND Project.ProjectID = GrantOrgAdmin.UserID AND GrantOrgAdmin.UserID = Faculty.UserID;";
            cmdProductRead.Connection.Open();

            return cmdProductRead.ExecuteReader();
        }

        public static SqlDataReader SingleProductReader(int UserID)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Users WHERE UserID = " + UserID;
            cmdProductRead.Connection.Open();

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();
            return tempReader;
        }

        public static void UpdateUser(Users u)
        {
            string sqlQuery = "UPDATE Users SET ";
            sqlQuery += "Name='" + u.Name + "',";
            sqlQuery += "Email='" + u.Email + "',";
            sqlQuery += "Password='" + u.Password + "',";
            sqlQuery += "Role='" + u.Role + "', WHERE UserID=" + u.UserID;

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();
            cmdProductRead.ExecuteNonQuery();
        }

        public static void InsertUser(Users u)
        {
            String sqlQuery = "INSERT INTO Users (Name, Email, Password, Role) VALUES ('";
            sqlQuery += u.Name + "',";
            sqlQuery += u.Email + "',";
            sqlQuery += u.Password + "',";
            sqlQuery += u.Role + "')";

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = Lab1DBConnection;
            cmdProductRead.Connection.ConnectionString = Lab1DBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open();

            cmdProductRead.ExecuteNonQuery();
        }

        public static void InsertGrant(Grants g)
        {
            String sqlQuery = "INSERT INTO Grants (Category, FundingAgency, SubmissionDate, AwardDate, Amount, LeadFacultyID ('";
            sqlQuery += g.Category + "',";
            sqlQuery += g.FundingAgency + "',";
            sqlQuery += g.SubmissionDate + "',";
            sqlQuery += g.AwardDate + "',";
            sqlQuery += g.Amount + "',";
            sqlQuery += g.LeadFacultyID + "',";
        }



        public static int LoginQuery(string loginQuery)
        {
            SqlCommand cmdLogin = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(Lab1DBConnString))
            {
                cmdLogin.Connection = connection;
                cmdLogin.CommandText = loginQuery;

                connection.Open();

                int rowCount = (int)cmdLogin.ExecuteScalar();

                return rowCount;
            }
        }




        public static bool ValidateUser(string email, string password)
        {
            bool isValid = false;
            string sqlQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Lab1DBConnection;
            cmd.Connection.ConnectionString = Lab1DBConnString;
            cmd.CommandText = sqlQuery;

            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            try
            {
                cmd.Connection.Open();
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                cmd.Connection.Close();
            }


            return isValid;
        }




    }
}
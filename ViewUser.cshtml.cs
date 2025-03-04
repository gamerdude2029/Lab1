using Microsoft.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.CreateUser
{
    public class ViewUsersModel : PageModel
    {
        public List<Users> EmployeeInfo { get; set; }

        public ViewUsersModel()
        {
            EmployeeInfo = new List<Users>();
        }
        public void OnGet()
        {
            SqlDataReader productReader = DBClass.ProductReader();
            while (productReader.Read())
            {
                EmployeeInfo.Add(new Users
                {
                    Name = productReader["Name"].ToString(),
                    Email = productReader["Email"].ToString(),
                    Password = productReader["Password"].ToString(),
                    Role = productReader["Role"].ToString()
                });
            }
        }
    }
}
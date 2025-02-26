using System.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.ProjectView.ProjectAssign
{
    public class IndexModel : PageModel
    {
        [BindProperty] public int SelectedNumber { get; set; }
        public List<Users> EmployeeInfo {  get; set; }
        public IndexModel()
        {
            EmployeeInfo = new List<Users>();
        }
        public void OnGet()
        {
            SqlDataReader productreader = DBClass.ProductReader();
            while (productreader.Read())
            {
                EmployeeInfo.Add(new Users
                {
                    UserID = Int32.Parse(productreader["UserID"].ToString()),
                    Name = productreader["Name"].ToString(),
                    Email = productreader["Email"].ToString(),
                    Password = productreader["Password"].ToString(),
                    Role = productreader["Role"].ToString()
                });
            }
        }
    }
}

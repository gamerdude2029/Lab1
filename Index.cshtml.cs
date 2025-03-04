using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Lab1.Pages.ProjectView
{
    public class IndexModel : PageModel
    {
        public List<Project> ProjectInfo { get; set; }
        public List<Users> EmployeeInfo { get; set; }

        public IndexModel()
        {
            ProjectInfo = new List<Project>();
            EmployeeInfo = new List<Users>();
        }

        public void OnGet()
        {
            SqlDataReader productReader = DBClass.ProductReader();
            while (productReader.Read())
            {
                ProjectInfo.Add(new Project
                {
                    Title = productReader["Title"].ToString(),
                    CreatedByAdminID = Int32.Parse(productReader["CreatedByAdminID"].ToString()),
                    Status = productReader["Status"].ToString()
                });
            }

            DBClass.Lab1DBConnection.Close();
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.CreateUser
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public Users NewUser { get; set; }
        public string FacultyType { get; set; }
        public string SuccessMessage { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBClass.InsertUser(NewUser);
            DBClass.Lab1DBConnection.Close();

            return RedirectToPage("Index");
        }
    }
}

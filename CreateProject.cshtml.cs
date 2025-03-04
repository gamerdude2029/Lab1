using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Lab1.Pages.ProjectView
{
    public class CreateProjectModel : PageModel
    {
        public List<Project> ProjectInfo { get; set; }
        public CreateProjectModel()
        {
            ProjectInfo = new List<Project>();
        }
        [BindProperty]
        public Project NewProject { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            DBClass.CreateProject(NewProject);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("/ProjectView/Index");
        }
    }
}

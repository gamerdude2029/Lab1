using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;

        public string UserName { get; set; }
        public string UserRole { get; set; }

        public DashboardModel(ILogger<DashboardModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            UserName = TempData["UserName"]?.ToString();
            UserRole = TempData["UserRole"]?.ToString();
        }
    }
}

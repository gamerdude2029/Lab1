using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class DashboardModel : PageModel
    {
        public string UserName { get; set; } = string.Empty;
        public string UserRole { get; set; } = string.Empty;
        public string SuccessMessage { get; set; } = string.Empty;

        public void OnGet()
        {
            if (HttpContext != null)
            {
                UserName = HttpContext.Session.GetString("UserName");
                UserRole = HttpContext.Session.GetString("UserRole");
                SuccessMessage = TempData["SuccessMessage"]?.ToString();
            }
        }
    }
}

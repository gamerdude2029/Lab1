using Lab1.Pages.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace Lab1.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                ModelState.AddModelError(string.Empty, "Email or password is required.");
                return Page();
            }

            string query = "SELECT UserID, Name, Email, Role FROM Users WHERE Email = @Email AND Password = @Password";

            using (SqlConnection conn = new SqlConnection(DBClass.Lab1DBConnString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@Password", Password);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        HttpContext.Session.SetString("UserName", reader["Name"].ToString());
                        HttpContext.Session.SetString("UserRole", reader["Role"].ToString());

                        TempData["SuccessMessage"] = "Login successful!";
                        return RedirectToPage("/Dashboard");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid email or password.");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                }
            }

            return Page();
        }
    }
}

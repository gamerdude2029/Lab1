using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.GrantWork
{
    public class GrantModel : PageModel
    {
        public List<Grants> GrantInfo { get; set; }

        public GrantModel()
        {
            GrantInfo = new List<Grants>();
        }
        [BindProperty]
        public Grants NewGrants { get; set; }
        public void OnGet()
        {
            SqlDataReader productReader = DBClass.GrantReader();
            while (productReader.Read())
            {
                GrantInfo.Add(new Grants
                {
                    Title = productReader["Title"].ToString(),
                    Category = productReader["Category"].ToString(),
                    FundingAgency = productReader["FundingAgency"].ToString(),
                    Amount = Convert.ToDouble(productReader["Amount"]),
                });
            }
            DBClass.Lab1DBConnection.Close();
        }
        public IActionResult OnPost()
        {
            DBClass.InsertGrant(NewGrants);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("/GrantWork/Index");
        }
    }
}

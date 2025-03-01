using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages.GrantWork
{
    public class GrantModel : PageModel
    {
        public List<Grants> GrantInfo { get; set; }
        [BindProperty]
        public Grants NewGrant { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please Select One")]
        public int SelectedNumber { get; set; }
        public string SuccessMessage { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Agency or Business Reqeuired")]
        public string AgencyOrBusiness { get; set; }
        [BindProperty]
        [Required]
        public DateTime? SubmissionDate { get; set; }
        [BindProperty]
        [Required]
        public DateTime? AwardDate { get; set; }
        [BindProperty]
        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "Money must be greater than 0.")]
        public int MoneyInvolved { get; set; }

        public List<Grants> GrantData { get; set; }

        public GrantModel()
        {
            GrantData = new List<Grants>();
        }
        public Grants NewGrants { get; set; }
        public void OnGet()
        {
            SqlDataReader productReader = DBClass.ProductReader();
            while (productReader.Read())
            {
                GrantData.Add(new Grants
                {
                    Title = productReader["Title"].ToString(),
                    Category = productReader["Category"].ToString(),
                    FundingAgency = productReader["FundingAgency"].ToString(),
                    SubmissionDate = DateOnly.FromDateTime(Convert.ToDateTime(productReader["SubmissionDate"])),
                    AwardDate = DateOnly.FromDateTime(Convert.ToDateTime(productReader["AwardDate"])),
                    Amount = Convert.ToDouble(productReader["Amount"]),
                });
            }
            DBClass.Lab1DBConnection.Close();
        }
        public IActionResult OnPost()
        {
            DBClass.LogGrant(NewGrant);
            DBClass.Lab1DBConnection.Close();
            return RedirectToPage("/GrantWork/Index");
        }
    }
}

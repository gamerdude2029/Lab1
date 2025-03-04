using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using Lab1.Pages.DataClasses;
using Lab1.Pages.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab1.Pages
{
    public class GrantModel : PageModel
    {
        public List<Grants> GrantInfo { get; set; }
        [BindProperty]
        public Grants NewGrant { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Please Select One")]
        public int SelectedNumber { get; set; }
        public String SuccessMessage { get; set; }
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
        [BindProperty]
        [Required(ErrorMessage = "Lead Faculty Required")]
        public string LeadFaculty { get; set; }

        public GrantModel()
        {
            GrantInfo = new List<Grants>();
        }
        public void OnGet()
        {
            SqlDataReader productReader = DBClass.ProductReader();
            while (productReader.Read())
            {
                GrantInfo.Add(new Grants
                {
                    Category = productReader["Category"].ToString(),
                    FundingAgency = productReader["FundingAgency"].ToString(),

                });
            }
        }
        public IActionResult OnPost()
        {
            DBClass.InsertGrant(NewGrant);
            DBClass.Lab1DBConnection.Close();

            TempData["SuccessMessage"] = "Grant has been created successfully!";
            return RedirectToPage("/dashboard");
        }
    }
}
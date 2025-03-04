

namespace Lab1.Pages.DataClasses
{
    public class Grants
    {
        public int GrantID { get; set; }
        public string? Title { get; set; }
        public string? Category { get; set; }
        public string? FundingAgency { get; set; }
        public DateOnly? SubmissionDate { get; set; }
        public DateOnly? AwardDate { get; set; }
        public double Amount { get; set; }
        public int LeadFacultyID { get; set; }
        public string Status { get; set; }
        public string? GrantNotes { get; set; }
    }
}

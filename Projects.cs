namespace Lab1.Pages.DataClasses

{
    public class Project
    {
        public int ProjectID { get; set; }
        public string? Title { get; set; }
        public DateOnly? DueDate { get; set; }
        public double CreatedByAdminID { get; set; }
        public string? Status { get; set; }
        public string ProjectNotes { get; internal set; }
    }
}
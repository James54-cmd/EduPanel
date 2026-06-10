namespace EduPanel.Components.Pages.Employee.HumanResource.Models
{
    public class CareerOpportunityModel
    {
        public string TransactionNo { get; set; } = "Autonumber";
        public string DateFiled { get; set; } = "";
        public string OpportunityTitle { get; set; } = "";
        public string Amount { get; set; } = ""; // Following the screenshot column
        public string Remarks { get; set; } = "";
        public string ApprovalStatus { get; set; } = "For Review";
        public string ApprovedBy { get; set; } = "";
        public string ApprovedDate { get; set; } = "";
    }
}

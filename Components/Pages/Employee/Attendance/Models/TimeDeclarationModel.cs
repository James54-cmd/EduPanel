namespace EduPanel.Components.Pages.Employee.Attendance.Models
{
    public class TimeDeclarationModel
    {
        public string TransactionNo { get; set; } = "Autonumber";
        public string Date { get; set; } = "";
        public string In1 { get; set; } = "";
        public string Out1 { get; set; } = "";
        public string In2 { get; set; } = "";
        public string Out2 { get; set; } = "";
        public string ChargeTo { get; set; } = "";
        public string DeclarationType { get; set; } = "";
        public string Reason { get; set; } = "";
        
        public string Status { get; set; } = "For Approval";
        public string ApprovedBy { get; set; } = "";
        public string ApprovedDate { get; set; } = "";
        public string DateApplied { get; set; } = "";
        
        public List<TimeDeclarationDetailModel> Details { get; set; } = new();
    }

    public class TimeDeclarationDetailModel
    {
        public int DetailNo { get; set; }
        public string ChargeTo { get; set; } = "";
        public string Activity { get; set; } = "";
        public string Remarks { get; set; } = "";
        public string HoursWorked { get; set; } = "";
    }
}

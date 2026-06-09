namespace EduPanel.Components.Pages.Employee.Attendance.Models
{
    public class ChangeDayOffModel
    {
        public string TransactionNo { get; set; } = "Autonumber";
        public string DateFrom { get; set; } = "";
        public string DateTo { get; set; } = "";
        public string DayOff1 { get; set; } = "";
        public string DayOff2 { get; set; } = "";
        public string DayOff3 { get; set; } = "";
        public string Reason { get; set; } = "";
        public string ApprovalStatus { get; set; } = "For Approval";
        public string ApprovedBy { get; set; } = "";
        public string ApprovedDate { get; set; } = "";
        public string DateApplied { get; set; } = "";
    }
}

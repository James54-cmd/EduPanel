namespace EduPanel.Components.Pages.Employee.Attendance.Models;

public class LeaveOBModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string LeaveType { get; set; } = "";
    public string CoveredDateFrom { get; set; } = "";
    public string CoveredDateTo { get; set; } = "";
    public string FiledHrs { get; set; } = "";
    public string PaidHrs { get; set; } = "";
    public string Reason { get; set; } = "";
    public string ApprovalStatus { get; set; } = "For Approval";
    public string ApprovedDisapprovedBy { get; set; } = "";
    public string ApprovedDisapprovedDate { get; set; } = "";
    public string DateApplied { get; set; } = DateTime.Today.ToString("MM/dd/yyyy");
    public string LeaveDayType { get; set; } = "Whole Day";

    public List<LeaveOBDetailModel> Details { get; set; } = new();
}

public class LeaveOBDetailModel
{
    public string DetailNo { get; set; } = "";
    public string DtrDate { get; set; } = "";
    public string Day { get; set; } = "";
    public string PaidHrs { get; set; } = "";
}

namespace EduPanel.Components.Pages.Employee.Attendance.Models;

public class OvertimeModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string Date { get; set; } = "";
    public string In { get; set; } = "";
    public string Out { get; set; } = "";
    public bool ForCto { get; set; } = false;
    public string FiledHrs { get; set; } = "";
    public string Reason { get; set; } = "";
    public string ApprovalStatus { get; set; } = "For Approval";
    public string ApprovedDisapprovedBy { get; set; } = "";
    public string ApprovedDisapprovedDate { get; set; } = "";
    public string DateApplied { get; set; } = DateTime.Today.ToString("MM/dd/yyyy");
}

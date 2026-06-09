namespace EduPanel.Components.Pages.Employee.Attendance.Models;

public class ShiftRequestModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string CoveredDateFrom { get; set; } = "";
    public string CoveredDateTo { get; set; } = "";
    public string GlobalShift { get; set; } = "";
    public string ShiftMon { get; set; } = "";
    public string ShiftTue { get; set; } = "";
    public string ShiftWed { get; set; } = "";
    public string ShiftThu { get; set; } = "";
    public string ShiftFri { get; set; } = "";
    public string ShiftSat { get; set; } = "";
    public string ShiftSun { get; set; } = "";
    public string ChargeTo { get; set; } = "";
    public string Reason { get; set; } = "";
    public string ApprovalStatus { get; set; } = "For Approval";
    public string ApprovedBy { get; set; } = "";
    public string ApprovedDate { get; set; } = "";
    public string DateApplied { get; set; } = "";
}

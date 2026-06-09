namespace EduPanel.Components.Pages.Employee.Attendance.Models;

public class ShiftRequestModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string CoveredDateFrom { get; set; } = "";
    public string CoveredDateTo { get; set; } = "";
    public string GlobalShift { get; set; } = "-- Select --";
    public string ShiftMon { get; set; } = "-- Select --";
    public string ShiftTue { get; set; } = "-- Select --";
    public string ShiftWed { get; set; } = "-- Select --";
    public string ShiftThu { get; set; } = "-- Select --";
    public string ShiftFri { get; set; } = "-- Select --";
    public string ShiftSat { get; set; } = "-- Select --";
    public string ShiftSun { get; set; } = "-- Select --";
    public string ChargeTo { get; set; } = "-- Select --";
    public string Reason { get; set; } = "";
    public string ApprovalStatus { get; set; } = "For Approval";
    public string ApprovedBy { get; set; } = "";
    public string ApprovedDate { get; set; } = "";
    public string DateApplied { get; set; } = "";
}

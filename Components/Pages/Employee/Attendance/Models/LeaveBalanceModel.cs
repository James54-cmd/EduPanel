namespace EduPanel.Components.Pages.Employee.Attendance.Models;

public class LeaveBalanceModel
{
    public string EmployeeNo { get; set; } = "";
    public string EmployeeName { get; set; } = "";
    public string LeaveType { get; set; } = "";
    public string Earned { get; set; } = "0.00";
    public string CreditA { get; set; } = "0.00";
    public string UsedB { get; set; } = "0.00";
    public string ForfeitedC { get; set; } = "0.00";
    public string BalanceD { get; set; } = "0.00";
    
    public List<LeaveEarnedModel> EarnedHistory { get; set; } = new();
    public List<LeaveUsedModel> UsedHistory { get; set; } = new();
}

public class LeaveEarnedModel
{
    public string TransactionNo { get; set; } = "";
    public string LeaveType { get; set; } = "";
    public string AcquiredDate { get; set; } = "";
    public string ForfeitedDate { get; set; } = "";
    public string LeaveHrs { get; set; } = "0.00";
    public string Remarks { get; set; } = "";
}

public class LeaveUsedModel
{
    public string LeaveApplicationNo { get; set; } = "";
    public string DtrDate { get; set; } = "";
    public string Day { get; set; } = "";
    public string DayType { get; set; } = "";
    public string Shift { get; set; } = "";
    public string LeaveType { get; set; } = "";
    public string PaidHrs { get; set; } = "0.00";
    public string Status { get; set; } = "";
}

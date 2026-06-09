namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class EmployeeRequestModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string DateRequested { get; set; } = "";
    public string RequestType { get; set; } = "";
    public string Reason { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string DateServed { get; set; } = "";
    public string Status { get; set; } = "Open";
}

namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class BenefitEnrollmentModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string DateFiled { get; set; } = "";
    public string BenefitType { get; set; } = "";
    public string Amount { get; set; } = "0.00";
    public string Attachment { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string ApprovalStatus { get; set; } = "IN PROCESS"; 
    public string ApprovedBy { get; set; } = "";
    public string ApprovedDate { get; set; } = "";
}

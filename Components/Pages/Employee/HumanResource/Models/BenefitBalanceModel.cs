namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class BenefitBalanceModel
{
    public string EmployeeNo { get; set; } = "";
    public string EmployeeName { get; set; } = "";
    public string BenefitType { get; set; } = "";
    public string Earned { get; set; } = "0.00";
    public string Used { get; set; } = "0.00";
    public string Balance { get; set; } = "0.00";

    public List<BenefitEarnedModel> EarnedDetails { get; set; } = new();
    public List<BenefitUsedModel> UsedDetails { get; set; } = new();
}

public class BenefitEarnedModel
{
    public string TransactionNo { get; set; } = "";
    public string AcquiredDate { get; set; } = "";
    public string BenefitType { get; set; } = "";
    public string Amount { get; set; } = "0.00";
    public string Remarks { get; set; } = "";
}

public class BenefitUsedModel
{
    public string TransactionNo { get; set; } = "";
    public string DateFiled { get; set; } = "";
    public string BenefitType { get; set; } = "";
    public string Amount { get; set; } = "0.00";
    public string Remarks { get; set; } = "";
}

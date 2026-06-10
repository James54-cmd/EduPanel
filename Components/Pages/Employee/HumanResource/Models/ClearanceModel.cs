namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class ClearanceModel
{
    public string ReferenceNo { get; set; } = "";
    public string Title { get; set; } = "";
    public string DepartmentOffice { get; set; } = "";
    public string Order { get; set; } = "";
    public string DateEncoded { get; set; } = "";
    public int AgingDays { get; set; } = 0;
    public string Signatory { get; set; } = "";
    public string Cleared { get; set; } = "No";
    public string DateCleared { get; set; } = "";
    public string ClearedBy { get; set; } = "";
    public string ModifiedBy { get; set; } = "";
    public string DateLastModified { get; set; } = "";

    public List<AccountabilityModel> Accountabilities { get; set; } = new();
}

public class AccountabilityModel
{
    public string TransactionNo { get; set; } = "";
    public string DepartmentHead { get; set; } = "";
    public string InCharge { get; set; } = "";
    public string ItemAccountability { get; set; } = "";
    public string ItemAmount { get; set; } = "0.00";
    public string Remarks { get; set; } = "";
    public string DateReturned { get; set; } = "";
    public string Cleared { get; set; } = "No";
}

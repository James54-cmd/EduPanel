namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class SALNModel
{
    public string TransactionNo { get; set; } = "Autonumber";
    public string ApplicableYear { get; set; } = "";
    public string Position { get; set; } = "";
    public string Income { get; set; } = "0.00";
    public string DateFiled { get; set; } = "";
    public string PostedBy { get; set; } = "";
    public string DatePosted { get; set; } = "";
    public string Status { get; set; } = "Open";
    
    // Declarant Info
    public string FilingType { get; set; } = "Jointly Filed";
    public string FamilyName { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public string Address { get; set; } = "";
    public string AgencyOffice { get; set; } = "";
    public string OfficeAddress { get; set; } = "";
    public string DateAccomplished { get; set; } = "";
    public string TaxIdNo { get; set; } = "";
    public string CommTaxCertNo { get; set; } = "";
    public string IssuedAt { get; set; } = "";
    public string IssuedOn { get; set; } = "";
    
    // Spouse Info
    public string MaritalStatus { get; set; } = "I am married";
    public string SpouseFamilyName { get; set; } = "";
    public string SpouseFirstName { get; set; } = "";
    public string SpouseMiddleName { get; set; } = "";
    public string SpousePosition { get; set; } = "";
}

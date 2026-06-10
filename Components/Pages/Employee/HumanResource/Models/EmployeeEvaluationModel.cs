namespace EduPanel.Components.Pages.Employee.HumanResource.Models;

public class EmployeeEvaluationModel
{
    public string ReviewNo { get; set; } = "";
    public string Title { get; set; } = "";
    public string FromDate { get; set; } = "";
    public string ToDate { get; set; } = "";
    public string EvaluationType { get; set; } = "";
    public string Remarks { get; set; } = "";
    public string Status { get; set; } = "";
    public string EvaluationForm { get; set; } = "";

    public List<EvaluationRatingModel> Ratings { get; set; } = new();
    public List<EvaluationSignatoryModel> Signatories { get; set; } = new();
}

public class EvaluationRatingModel
{
    public string Category { get; set; } = "";
    public double Score { get; set; } = 0.0;
    public double MaxScore { get; set; } = 5.0;
    public string Comments { get; set; } = "";
}

public class EvaluationSignatoryModel
{
    public string Role { get; set; } = "";
    public string Name { get; set; } = "";
    public string DateSigned { get; set; } = "";
    public string Status { get; set; } = "Pending";
}

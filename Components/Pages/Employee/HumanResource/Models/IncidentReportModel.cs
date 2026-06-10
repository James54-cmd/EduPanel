using System;
using System.Collections.Generic;

namespace EduPanel.Components.Pages.Employee.HumanResource.Models
{
    public class IncidentEmployeeModel
    {
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
    }

    public class IncidentReportModel
    {
        public string CaseNo { get; set; } = "Autonumber";
        public string DateFiled { get; set; } = "";
        public DateTime? DateOfIncident { get; set; }
        public string IncidentDescription { get; set; } = "";
        public string LocationOfIncident { get; set; } = "";
        public string HowItHappened { get; set; } = "";
        public string ApprovalStatus { get; set; } = "Draft";
        
        public List<IncidentEmployeeModel> InvolvedEmployees { get; set; } = new();
    }
}

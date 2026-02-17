using System.ComponentModel.DataAnnotations;

namespace OrganizationalSurveyModificationSystem.DTO;

public class SurveyCheckRequest
{
    [Required]
    public string OrgName { get; set; } = default!;

    [Required]
    public string SurveyName { get; set; } = default!;
}
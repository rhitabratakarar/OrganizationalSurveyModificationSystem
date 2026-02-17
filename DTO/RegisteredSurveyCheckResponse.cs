namespace OrganizationalSurveyModificationSystem.DTO;

public class RegisteredSurveyCheckResponse
{
    public int Id { get; set; } = -1;
    public string OrgSurveyName { get; set; } = default!;
    public string OrgSurveyDesc { get; set; } = default!;
    public string OrgName { get; set; } = default!;
}
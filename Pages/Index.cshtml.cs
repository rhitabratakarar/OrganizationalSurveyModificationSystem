using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrganizationalSurveyModificationSystem.API;
using OrganizationalSurveyModificationSystem.DTO;

namespace OrganizationalSurveyModificationSystem.Pages;

public class IndexModel(OrganizationalSurveyAPIClient apiClient) : PageModel
{
    readonly OrganizationalSurveyAPIClient _apiClient = apiClient ?? throw new Exception("API Client can't be initialized");
    
    public void OnGet()
    {

    }

    [BindProperty]
    public SurveyCheckRequest? SurveyCheckRequest { get; set; } = default;
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        else
        {
            bool checkResult = await _apiClient.CheckRegisteredSurveyResponse(SurveyCheckRequest!);
            HttpContext.Session.SetString("IsSurveyRegistered", checkResult.ToString());
            return RedirectToPage("./Edit");
        }
    }
}

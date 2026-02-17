using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrganizationalSurveyModificationSystem.API;
using OrganizationalSurveyModificationSystem.DTO;

namespace OrganizationalSurveyModificationSystem.Pages;

public class IndexModel(OrganizationalSurveyAPIClient apiClient) : PageModel
{
    readonly OrganizationalSurveyAPIClient _apiClient = apiClient ?? throw new Exception("API Client can't be initialized");
    
    public async Task<IActionResult> OnGetAsync()
    {
        if (Convert.ToBoolean(HttpContext.Session.GetString("IsSurveyRegistered")) == true)
        {
            return RedirectToPage("./Edit");
        }
        else
        {
            return Page();
        }
    }

    [BindProperty]
    public SurveyCheckRequest? SurveyCheckRequest { get; set; } = default;
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        else
        {
            RegisteredSurveyCheckResponse? result = await _apiClient
                                        .CheckRegisteredSurveyResponse(SurveyCheckRequest!);

            if (result != null)
            {
                HttpContext.Session.SetString("IsSurveyRegistered", Convert.ToString(result != null));
                HttpContext.Session.SetString("SurveyId", result!.Id.ToString());
            }
            return RedirectToPage("./Edit");
        }
    }
}

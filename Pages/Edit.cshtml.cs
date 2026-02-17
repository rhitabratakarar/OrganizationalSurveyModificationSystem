using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OrganizationalSurveyModificationSystem.Pages;

public class EditModel : PageModel
{
    public IActionResult OnGet()
    {
        if (Convert.ToBoolean(HttpContext.Session.GetString("IsSurveyRegistered")) == true)
        {
            return Page();
        }
        else
        {
            return RedirectToPage("./Index");
        }
    }
}

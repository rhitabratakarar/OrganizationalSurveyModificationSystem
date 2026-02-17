using System.Text.Json;
using OrganizationalSurveyModificationSystem.DTO;

namespace OrganizationalSurveyModificationSystem.API;

public class OrganizationalSurveyAPIClient(IConfiguration configuration, IHttpClientFactory httpClientFactory)
{
    readonly IConfiguration _configuration = configuration;
    readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    public async Task<bool> CheckRegisteredSurveyResponse(SurveyCheckRequest checkRequest)
    {
        string? registeredSurveyCheckingURL = _configuration["SurveyAPI:urls:checkregisteredsurvey"] ?? throw new InvalidOperationException("'checkregisteredsurvey' key can't be read from appsettings.");

        HttpClient client = _httpClientFactory.CreateClient("checkregisteredsurvey");
       
        var response = await client.PostAsJsonAsync(registeredSurveyCheckingURL, checkRequest);
        return response.IsSuccessStatusCode;
    }
}
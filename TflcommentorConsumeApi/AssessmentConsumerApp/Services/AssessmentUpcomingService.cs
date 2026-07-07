using System.Net.Http.Json;
using AssessmentConsumerApp.Services.Interfaces;

public class AssessmentUpcomingService : IAssessmentUpcomingService
{
    private readonly HttpClient _httpClient;

    public AssessmentUpcomingService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
     public async Task<List<AssessmentUpcomingDto>> GetUpcomingAssessmentsAsync(int studentId)
    {
        // string.Format replaces {0} with actual studentId
        // e.g. studentId = 3 → "api/AssessmentUpcoming/3"
        var url = string.Format(ApiConfig.GetAssessmentsEndpoint, studentId);

        var result = await _httpClient.GetFromJsonAsync<List<AssessmentUpcomingDto>>(url);
        return result ?? new List<AssessmentUpcomingDto>();
    }
    
}
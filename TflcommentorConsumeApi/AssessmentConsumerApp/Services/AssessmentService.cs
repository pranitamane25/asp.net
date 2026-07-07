using System.Net.Http.Json;

public class AssessmentService : IAssessmentService
{
    private readonly HttpClient _httpClient;

    public AssessmentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AssessmentDto>> GetAssessmentsAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<AssessmentDto>>("assessment/all");
        return response ?? new List<AssessmentDto>();
    }
}
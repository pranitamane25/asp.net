public class ResultRepository : IResultRepository
{
    private readonly HttpClient _httpClient;
    public ResultRepository (HttpClient httpClient)
    {
        _httpClient= httpClient;
    }
    
    public async Task<List<ResultDto>>GetAllResultsAsync()
    {
        var response = await _httpClient.GetAsync($"api/result/results");
        response.EnsureSuccessStatusCode();
        var data = await response.Content.ReadFromJsonAsync<List<ResultDto>>(); 
        return data;
    }
}

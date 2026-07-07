public class ResultService : IResultService
{
    private readonly IResultRepository _resultRepository;
    public ResultService (IResultRepository resultRepository)
    {
        _resultRepository = resultRepository;
    }

    public async Task<List<ResultDto>> GetAllResults()
    {
        return await _resultRepository.GetAllResultsAsync();
    }
}
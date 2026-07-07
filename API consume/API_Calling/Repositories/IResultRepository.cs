public interface IResultRepository
{
    Task<List<ResultDto>> GetAllResultsAsync();
}
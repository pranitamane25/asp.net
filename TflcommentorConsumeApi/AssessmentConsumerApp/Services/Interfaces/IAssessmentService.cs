public interface IAssessmentService
{
    Task<List<AssessmentDto>> GetAssessmentsAsync();
}
namespace AssessmentConsumerApp.Services.Interfaces;

public interface IAssessmentUpcomingService
{

    // new method added
    Task<List<AssessmentUpcomingDto>> GetUpcomingAssessmentsAsync(int studentId);
}
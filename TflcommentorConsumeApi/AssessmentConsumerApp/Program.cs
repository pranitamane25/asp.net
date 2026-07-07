
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AssessmentConsumerApp.Services;
using AssessmentConsumerApp.Services.Interfaces;


var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services.AddHttpClient<IAssessmentService, AssessmentService>(client =>
        {
            client.BaseAddress = new Uri(ApiConfig.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddHttpClient<IAssessmentUpcomingService, AssessmentUpcomingService>(client =>
        {
            client.BaseAddress = new Uri(ApiConfig.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });
    })
    .Build();


var assessmentService = host.Services.GetRequiredService<IAssessmentService>();
var upcomingService   = host.Services.GetRequiredService<IAssessmentUpcomingService>();


var service = host.Services.GetRequiredService<IAssessmentService>();

Console.WriteLine("Fetching Assessments...\n");

var assessments = await service.GetAssessmentsAsync();

if (!assessments.Any())
{
    Console.WriteLine("No assessments found.");
}
else
{
    foreach (var a in assessments)
    {
        Console.WriteLine($"ID       : {a.SrNo}");
        Console.WriteLine($"Title    : {a.AssessmentTitle}");
        Console.WriteLine($"Student  : {a.StudentName}");
        Console.WriteLine($"Difficulty: {a.DifficultyLevel}");
        Console.WriteLine($"Status   : {a.Status}");
        Console.WriteLine(new string('-', 40));
    }

}
// ─── Take Student ID from User ────────────────────────
Console.Write("Enter Student ID to see Upcoming Assessments: ");
var input = Console.ReadLine();

// Validate — make sure input is a valid number
if (!int.TryParse(input, out int studentId))
{
    Console.WriteLine("Invalid Student ID. Please enter a valid number.");
    return;
}

Console.WriteLine($"\n=== Upcoming Assessments for Student ID: {studentId} ===\n");

var upcoming = await upcomingService.GetUpcomingAssessmentsAsync(studentId);

if (!upcoming.Any())
{
    Console.WriteLine($"No upcoming assessments found for Student ID: {studentId}");
}
else
{
    foreach (var u in upcoming)
{
    Console.WriteLine($"Sr No      : {u.SrNo}");
    Console.WriteLine($"Title      : {u.AssessmentName}");
    Console.WriteLine($"Scheduled  : {u.ScheduledAt:dd MMM yyyy hh:mm tt}");
    Console.WriteLine($"Duration   : {u.Duration} mins");
    Console.WriteLine($"Status     : {u.Status}");
    Console.WriteLine(new string('-', 40));
}
}
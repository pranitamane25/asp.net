using JsonCrudApi.Repositories;
using jsoncrudapi.Models;
using System.Text.Json;
namespace jsoncrudapi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string FilePath="Data/Employee.json";

    private List<Employee> ReadFile()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Employee>();
        }

        return JsonSerializer.Deserialize<List<Employee>>(json)??new List<Employee>();
    }

    private void WriteFile(List<Employee>employees)
    {
        string json=JsonSerializer.Serialize(employees,
        new JsonSerializerOptions
        {
            WriteIndented=true
        });
        File.WriteAllText(FilePath,json);
    }

    public List<Employee>GetAll()
    {
        return ReadFile(); 
    }
}
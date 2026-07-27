//using JsonCrudApi.Repositories;
using jsoncrudapi.Models;
using System.Text.Json;
using JsonCrudApi.Repositories;

namespace jsoncrudapi.Repositories.Emp;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly string FilePath="Data/Employee.json";

    private List<Employee> ReadFile()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Employee>();
        }
        string json=File.ReadAllText(FilePath);

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
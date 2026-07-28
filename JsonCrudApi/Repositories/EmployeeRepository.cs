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

    public Employee GetById(int id)
    {
        return ReadFile().FirstOrDefault(e=>e.Id==id);
    }

    public void Add(Employee employee)
    {
        List<Employee>employees=ReadFile();
         employee.Id = employees.Any()
                ? employees.Max(e => e.Id) + 1
                : 1; 
                employees.Add(employee);
                WriteFile(employees);          
        }

        public void Delete(int id)
    {
        List<Employee> employees = ReadFile();
        
            Employee employee=employees.FirstOrDefault(e=>e.Id==id);
            if (employee != null)
            {
                employees.Remove(employee);
                WriteFile(employees);
            }
        
    }
    }


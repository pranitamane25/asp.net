namespace jsoncrudapi.Services;
using jsoncrudapi.Models;
using JsonCrudApi.Repositories;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;

    public EmployeeService(IEmployeeRepository repo)
    {
        _repo=repo;
    } 

    public List<Employee> GetAll()
    {
        return _repo.GetAll();
    }
}
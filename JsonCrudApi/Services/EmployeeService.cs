namespace jsoncrudapi.Services;
using jsoncrudapi.Models;
using JsonCrudApi.Repositories;
using Microsoft.AspNetCore.Mvc;

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
  
    public Employee GetById(int id)
    {
        return _repo.GetById(id);
    }
    public void Add(Employee employee)
    {
         _repo.Add(employee);
    }

    public void Delete(int id)
    {
        _repo.Delete(id);
    }
}

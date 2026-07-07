using Microsoft.AspNetCore.Mvc;
using StudentApp.Data;
using StudentApp.Models;

namespace StudentApp.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public StudentsController (AppDbContext Context)
    {
        _context=Context;
    }
    //create
    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return Ok(student);
    }
    //read
    [HttpGet]
    public IActionResult Getstudents()
    {
       var Students = _context.Students.ToList();
       return Ok(Students);  
    }
    [HttpPatch("{id}")] 
    public IActionResult UpdateStudent(int id,[FromBody]Student updatedstudent)
    {
        var student = _context.Students.Find(id);
        if (student == null)
         return NotFound();

         student.name=updatedstudent.name;
         student.age=updatedstudent.age;
         student.City=updatedstudent.City;

         _context.SaveChanges();
         return Ok(student);      
    }
     // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return Ok("Deleted Successfully");
        }   
}
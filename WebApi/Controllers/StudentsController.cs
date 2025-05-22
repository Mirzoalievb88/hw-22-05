using Domain.Entities;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class StudentsController(StudentsService studentsService)
{
    [HttpGet]
    public async Task<Response<List<Students>>> GetAllStudents()
    {
        return await studentsService.GetAllStudents();
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudent(Students students)
    {
        return await studentsService.CreateStudent(students);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudent(Students students)
    {
        return await studentsService.UpdateStudent(students);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentWithId(int Id)
    {
        return await studentsService.DeleteStudentWithId(Id);
    }

    [HttpGet("{Id = int}")]
    public async Task<Response<Students>> GetStudentsById(int Id)
    {
        return await studentsService.GetStudentsById(Id);
    }
}

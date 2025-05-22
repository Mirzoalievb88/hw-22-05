using Domain.Entities;
using Domain.DTOs;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CourseController(CoursesService coursesService)
{
    [HttpGet]
    public async Task<Response<List<Courses>>> GetAllCourses()
    {
        return await coursesService.GetAllCourses();
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourse(Courses courses)
    {
        return await coursesService.CreateCourse(courses);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourse(Courses courses)
    {
        return await coursesService.UpdateCourse(courses);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourseWithId(int Id)
    {
        return await coursesService.DeleteCourseWithId(Id);
    }

    [HttpGet("{Id = int}")]
    public async Task<Response<Courses>> GetCourseById(int Id)
    {
        return await coursesService.GetCourseById(Id);
    }

    [HttpGet("StudentsPerCourse")]
    public async Task<Response<List<StudentsPerCourse>>> GetStudentsPerCourse()
    {
        return await coursesService.GetStudentsPerCourse();
    }

    [HttpGet("PopularCourse")]
    public async Task<Response<List<Courses>>> GetMostPopularCourse()
    {
        return await coursesService.GetMostPopularCourse();
    }

    [HttpGet("Least Popular Course")]
    public async Task<Response<List<Courses>>> GetLeastPopularCourses()
    {
        return await coursesService.GetLeastPopularCourses();
    }

    [HttpGet("TopThreeCourses")]
    public async Task<Response<List<Courses>>> GetTopThreeCourses()
    {
        return await coursesService.GetTopThreeCourses();
    }
}
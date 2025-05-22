using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICoursesService
{
    Task<Response<string>> CreateCourse(Courses courses);
    Task<Response<List<Courses>>> GetAllCourses();
    Task<Response<string>> UpdateCourse(Courses courses);
    Task<Response<string>> DeleteCourseWithId(int Id);
    Task<Response<Courses>> GetCourseById(int Id);
    Task<Response<List<StudentsPerCourse>>> GetStudentsPerCourse();
    Task<Response<List<Courses>>> GetMostPopularCourse();
    Task<Response<List<Courses>>> GetLeastPopularCourses();
    Task<Response<List<Courses>>> GetTopThreeCourses();
}
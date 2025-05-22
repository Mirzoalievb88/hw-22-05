using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IMentorsService
{
    Task<Response<string>> CreateMentors(Mentors mentors);
    Task<Response<List<Mentors>>> GetAllMentors();
    Task<Response<string>> UpdateMentors(Mentors mentors);
    Task<Response<string>> DeleteMentorsWithId(int Id);
    Task<Response<Mentors>> GetMentorsById(int Id);
    Task<Response<Mentors>> GetMentorWithMostStudents();
    Task<Response<Mentors>> GetMentorsWithMultipleCourses();
}
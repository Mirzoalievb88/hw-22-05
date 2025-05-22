using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStatisticsService
{
    Task<Response<int>> GetTotalStudentsCount();
    Task<Response<int>> GetTotalGroupsCount();
    Task<Response<int>> GetTotalCoursesCount();
    Task<Response<int>> GetTotalMentorCount();
    Task<Response<List<StartDate>>> GetAllStartDate();
}

using Domain.Entities;
using Domain.DTOs;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]


public class StatisticsController(StatisticsService statisticsService)
{
    [HttpGet("Student Count")]
    public async Task<Response<int>> GetTotalStudentsCount()
    {
        return await statisticsService.GetTotalStudentsCount();
    }

    [HttpGet("Groups Count")]
    public async Task<Response<int>> GetTotalGroupsCount()
    {
        return await statisticsService.GetTotalGroupsCount();
    }

    [HttpGet("Courses Count")]
    public async Task<Response<int>> GetTotalCoursesCount()
    {
        return await statisticsService.GetTotalCoursesCount();
    }

    [HttpGet("Mentors Count")]
    public async Task<Response<int>> GetTotalMentorsCount()
    {
        return await statisticsService.GetTotalMentorCount();
    }

    [HttpGet("All Start Date")]
    public async Task<Response<List<StartDate>>> GetAllStartDates()
    {
        return await statisticsService.GetAllStartDate();
    }

}
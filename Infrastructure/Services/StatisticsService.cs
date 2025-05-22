using System.Net;
using Dapper;
using Domain.ApiResponse;
using Domain.DTOs;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StatisticsService(DataContext context) : IStatisticsService
{
    public async Task<Response<List<StartDate>>> GetAllStartDate()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select unique(StartDate) from Groups";
            var result = await connection.QueryAsync<StartDate>(cmd);
            if (result == null)
            {
                return new Response<List<StartDate>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<StartDate>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<int>> GetTotalCoursesCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select count(*) from Courses";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            if (result == null)
            {
                return new Response<int>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<int>(result, "All worked");
        }
    }

    public async Task<Response<int>> GetTotalGroupsCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select count(*) from Groups";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            if (result == null)
            {
                return new Response<int>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<int>(result, "All worked");
        }
    }

    public async Task<Response<int>> GetTotalMentorCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select Count(*) from Mentors";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            if (result == null)
            {
                return new Response<int>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<int>(result, "All")
        }
    }

    public async Task<Response<int>> GetTotalStudentsCount()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select count(*) from Students";
            var result = await connection.ExecuteScalarAsync<int>(cmd);
            if (result == null)
            {
                return new Response<int>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<int>(result, "All Worked");
        }
    }
}

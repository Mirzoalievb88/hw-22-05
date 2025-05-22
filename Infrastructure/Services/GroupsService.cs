using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
using Dapper;
using Infrastructure.Interfaces;
using System.Net;
using Domain.DTOs;

namespace Infrastructure.Services;

public class GroupsService(DataContext context) : IGroupsService
{
    public async Task<Response<string>> CreateGroups(Groups groups)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"insert into Groups(GroupName, CourseId, MentorId, StartDate, EndDate)
                                    values(@GroupName, @CourseId, @MentorId, @StartDate, @EndDate)";
            var result = await connection.ExecuteAsync(cmd, groups);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<string>> DeleteGroupsWithId(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"delete from Groups
                                    where GroupId = @Id";
            var result = await connection.ExecuteAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<List<Groups>>> GetAllGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Groups";
            var result = await connection.QueryAsync<Groups>(cmd);
            if (result == null)
            {
                return new Response<List<Groups>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Groups>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<List<Groups>>> GetEmptyGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"Select g.* from StudentGroups sg
                                join Groups g on g.GroupId = sg.GroupId
                                where sg.StudentId = null";
            var result = await connection.QueryAsync<Groups>(cmd);
            if (result == null)
            {
                return new Response<List<Groups>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Groups>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<Groups>> GetGroupsById(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Groups
                                    where GroupId = @Id";
            var result = await connection.QueryFirstOrDefaultAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<Groups>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<Groups>(result, "All Worked");
        }
    }

    public async Task<Response<List<StudentsAndGroup>>> GetStudentPerGroup()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select count(s.*), g.groupName from StudentGroups sg
                                join Students s on s.StudentId = sg.StudentId
                                join Groups g on g.GroupId = sg.GroupId
                                group by g.GroupId";
            var result = await connection.QueryAsync<StudentsAndGroup>(cmd);
            if (result == null)
            {
                return new Response<List<StudentsAndGroup>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<StudentsAndGroup>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<string>> UpdateGroups(Groups groups)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"update Groups
                                    set GroupName = @GroupName, CoursId = @CoursId, MentorId = @MentorId, StartDate = @StartDate, EndDate = @EndDate";
            var result = await connection.ExecuteAsync(cmd, groups);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
}
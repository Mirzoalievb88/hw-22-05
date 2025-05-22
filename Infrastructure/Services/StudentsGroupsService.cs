using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
using Dapper;
using Infrastructure.Interfaces;
using System.Net;

namespace Infrastructure.Services;

public class StudentsGroupsService(DataContext context) : IStudentsGroupsService
{
    public async Task<Response<string>> CreateStudentToGroup(StudentsGroups studentsGroups)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"insert into StudentsGroupsService(StudentId, GroupId, Status)
                                    values(@StudentId, @GroupId, @Status)";
            var result = await connection.ExecuteAsync(cmd);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
    public async Task<Response<string>> DeleteStudentsGroupsById(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"delete from StudentsGroupsService
                                where StudentGroupId = @Id";
            var result = await connection.ExecuteAsync(cmd);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
    public async Task<Response<string>> UpdateStudentsStatus(string Status)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"update StudentsGroupsService
                                set Status = @Status";
            var result = await connection.ExecuteAsync(cmd, new { @Status = Status });
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<List<StudentsGroups>>> GetAllStudentsAndGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from StudentsGroupsService";
            var result = await connection.QueryAsync<StudentsGroups>(cmd);
            if (result == null)
            {
                return new Response<List<StudentsGroups>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<StudentsGroups>>(result.ToList(), "All worked");
        }
    }
}
using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
using Dapper;
using Infrastructure.Interfaces;
using System.Net;

namespace Infrastructure.Services;

public class MentorsService(DataContext context) : IMentorsService
{
    public async Task<Response<string>> CreateMentors(Mentors mentors)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"insert into Mentors(FullName, Email, Phone, Specialization)
                                    values(@FullName, @Email, @Phone, @Specialization)";
            var result = await connection.ExecuteAsync(cmd, mentors);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<string>> DeleteMentorsWithId(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"delete from Mentors
                                    where MentorId = @Id";
            var result = await connection.ExecuteAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<List<Mentors>>> GetAllMentors()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Mentors";
            var result = await connection.QueryAsync<Mentors>(cmd);
            if (result == null)
            {
                return new Response<List<Mentors>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Mentors>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<Mentors>> GetMentorsById(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Mentors
                                    where MentorId = @Id";
            var result = await connection.QueryFirstOrDefaultAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<Mentors>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<Mentors>(result, "All Worked");
        }
    }

    public async Task<Response<Mentors>> GetMentorsWithMultipleCourses()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"";
        }
    }

    public Task<Response<Mentors>> GetMentorWithMostStudents()
    {
        throw new NotImplementedException();
    }

    public async Task<Response<string>> UpdateMentors(Mentors mentors)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"update Mentors
                                    set FullName = @FullName, Email = @Email, Phone = @Phone, Specialization = @Specialization";
            var result = await connection.ExecuteAsync(cmd, mentors);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
}
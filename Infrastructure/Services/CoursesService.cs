using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
using Dapper;
using Infrastructure.Interfaces;
using System.Net;
using Domain.DTOs;

namespace Infrastructure.Services;

public class CoursesService(DataContext context) : ICoursesService
{
    public async Task<Response<string>> CreateCourse(Courses courses)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"insert into Courses(Title, Description, DurationWeeks)
                                    values(@Title, @Description, @DurationWeeks)";
            var result = await connection.ExecuteAsync(cmd, courses);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<string>> DeleteCourseWithId(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"delete from Courses
                                    where CourseId = @Id";
            var result = await connection.ExecuteAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<List<Courses>>> GetAllCourses()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Courses";
            var result = await connection.QueryAsync<Courses>(cmd);
            if (result == null)
            {
                return new Response<List<Courses>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Courses>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<Courses>> GetCourseById(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Courses
                                    where CourseId = @Id";
            var result = await connection.QueryFirstOrDefaultAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<Courses>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<Courses>(result, "All Worked");
        }
    }

    public async Task<Response<List<Courses>>> GetLeastPopularCourses()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"SELECT c.CourseId, c.Title, COUNT(sg.StudentId) AS StudentCount
                                    FROM Courses c
                                    JOIN Groups g ON g.CourseId = c.CourseId
                                    JOIN StudentGroups sg ON sg.GroupId = g.GroupId
                                    WHERE sg.Status IN ('Активен', 'Завершил')
                                    GROUP BY c.CourseId, c.Title
                                    ORDER BY StudentCount ASC
                                    LIMIT 3";
            var result = await connection.QueryAsync<Courses>(cmd);
            if (result == null)
            {
                return new Response<List<Courses>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Courses>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<List<Courses>>> GetMostPopularCourse()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"SELECT c.CourseId, c.Title, COUNT(sg.StudentId) AS StudentCount
                                    FROM Courses c
                                    JOIN Groups g ON g.CourseId = c.CourseId
                                    JOIN StudentGroups sg ON sg.GroupId = g.GroupId
                                    WHERE sg.Status IN ('Активен', 'Завершил')
                                    group by c.CourseId, c.Title
                                    ORDER BY StudentCount DESC
                                    limit 1";
            var result = await connection.QueryAsync<Courses>(cmd);
            if (result == null)
            {
                return new Response<List<Courses>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Courses>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<List<StudentsPerCourse>>> GetStudentsPerCourse()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"SELECT c.CourseId, c.Title, COUNT(sg.StudentId) AS StudentCount
                                    FROM Courses c
                                    JOIN Groups g ON g.CourseId = c.CourseId
                                    JOIN StudentGroups sg ON sg.GroupId = g.GroupId
                                    where sg.Status IN ('Активен', 'Завершил')
                                    GROUP BY c.CourseId, c.Title
                                    order by c.Title";
            var result = await connection.QueryAsync<StudentsPerCourse>(cmd);
            if (result == null)
            {
                return new Response<List<StudentsPerCourse>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<StudentsPerCourse>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<List<Courses>>> GetTopThreeCourses()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"SELECT c.CourseId, c.Title, COUNT(sg.StudentId) AS StudentCount
                                FROM Courses c
                                JOIN Groups g ON g.CourseId = c.CourseId
                                JOIN StudentGroups sg ON sg.GroupId = g.GroupId
                                WHERE sg.Status IN ('Активен', 'Завершил')
                                GROUP BY c.CourseId, c.Title
                                ORDER BY StudentCount DESC
                                LIMIT 3";
            var result = await connection.QueryAsync<Courses>(cmd);
            if (result == null)
            {
                return new Response<List<Courses>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Courses>>(result.ToList(), "All worked");
        }
    }

    public async Task<Response<string>> UpdateCourse(Courses courses)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"update Courses
                                    set Title = @Title, Description = @Description, DurationWeeks = @DurationWeeks";
            var result = await connection.ExecuteAsync(cmd, courses);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
}
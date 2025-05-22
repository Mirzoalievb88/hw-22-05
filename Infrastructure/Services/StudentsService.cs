using Domain.ApiResponse;
using Domain.Entities;
using Infrastructure.Data;
using Npgsql;
using Dapper;
using Infrastructure.Interfaces;
using System.Net;
using Domain.DTOs;

namespace Infrastructure.Services;

public class StudentsService(DataContext context) : IStudentsService
{
    public async Task<Response<string>> CreateStudent(Students students)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"insert into Students(FullName, Email, Phone, EnrollmentDate)
                                    values(@FullName, @Email, @Phone, @EnrollmentDate)";
            var result = await connection.ExecuteAsync(cmd, students);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }
    public async Task<Response<List<Students>>> GetAllStudents()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Students";
            var result = await connection.QueryAsync<Students>(cmd);
            if (result == null)
            {
                return new Response<List<Students>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Students>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<string>> DeleteStudentWithId(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"delete from Students
                                    where StudentId = @Id";
            var result = await connection.ExecuteAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }


    public async Task<Response<Students>> GetStudentsById(int Id)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select * from Students
                                    where StudentId = @Id";
            var result = await connection.QueryFirstOrDefaultAsync(cmd, new { @Id = Id });
            if (result == null)
            {
                return new Response<Students>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<Students>(result, "All Worked");
        }
    }

    public async Task<Response<string>> UpdateStudent(Students students)
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"update Students
                                    set FullName = @FullName, Email = @Email, Phone = @Phone, EnrollmentDate = @EnrollmentDate";
            var result = await connection.ExecuteAsync(cmd, students);
            if (result == null)
            {
                return new Response<string>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<string>(default, "All worked");
        }
    }

    public async Task<Response<List<StudentAndGroup>>> GetStudentsWithGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select s.*, g.GroupName from StudentGroups sg
                                join Students s on s.StudentId = sg.StudentId
                                join Groups g on g.GroupId = sg.GroupId";
            var result = await connection.QueryAsync<StudentAndGroup>(cmd);
            if (result == null)
            {
                return new Response<List<StudentAndGroup>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<StudentAndGroup>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<List<StudentAndGroup>>> GetStudentsWithoutGroups()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select s.*, g.GroupName from StudentGroups sg
                                join Students s on s.StudentId = sg.StudentId
                                join Groups g on g.GroupId = sg.GroupId";
            var result = await connection.QueryAsync<StudentAndGroup>(cmd);
            if (result == null)
            {
                return new Response<List<StudentAndGroup>>("Result is nunll", HttpStatusCode.NotFound);
            }
            return new Response<List<StudentAndGroup>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<List<GetDroppedStudents>>> GetDroppedOutStudents()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select s.* from StudentGroups sg
                                    join Students s on StudentId = sg.StudentId
                                    where Status = Отчислен";
            var result = await connection.QueryAsync<GetDroppedStudents>(cmd);
            if (result == null)
            {
                return new Response<List<GetDroppedStudents>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<GetDroppedStudents>>(result.ToList(), "All Worked");
        }
    }

    public async Task<Response<List<Students>>> GetGraduatedStudents()
    {
        using (var connection = await context.GetConnectionAsync())
        {
            connection.Open();
            var cmd = @$"select s.* from StudentGroups sg
                                join Students s on s.StudentId = sg.StudentId
                                join Groups g on g.GroupId = sg.GroupId
                                where EndDate Notnull";
            var result = await connection.QueryAsync<Students>(cmd);
            if (result == null)
            {
                return new Response<List<Students>>("Result is null", HttpStatusCode.NotFound);
            }
            return new Response<List<Students>>(result.ToList(), "All worked");
        }
    }
}
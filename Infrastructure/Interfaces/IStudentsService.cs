using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentsService
{
    Task<Response<string>> CreateStudent(Students students);
    Task<Response<List<Students>>> GetAllStudents();
    Task<Response<string>> UpdateStudent(Students students);
    Task<Response<string>> DeleteStudentWithId(int Id);
    Task<Response<Students>> GetStudentsById(int Id);
    Task<Response<List<StudentsAndGroup>>> GetStudentsWithGroups();
    Task<Response<List<StudentsAndGroup>>> GetStudentsWithoutGroups();
    Task<Response<List<GetDroppedStudents>>> GetDroppedOutStudents();
    Task<Response<List<Students>>> GetGraduatedStudents();
}   
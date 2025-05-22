using Domain.ApiResponse;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentsGroupsService
{
    Task<Response<string>> CreateStudentToGroup(StudentsGroups studentsGroups);
    Task<Response<List<StudentsGroups>>> GetAllStudentsAndGroups();
    Task<Response<string>> UpdateStudentsStatus(string Status);
    Task<Response<string>> DeleteStudentsGroupsById(int Id);
}
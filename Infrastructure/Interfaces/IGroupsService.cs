using Domain.ApiResponse;
using Domain.Entities;
using Domain.DTOs;

namespace Infrastructure.Interfaces;

public interface IGroupsService
{
    Task<Response<string>> CreateGroups(Groups groups);
    Task<Response<List<Groups>>> GetAllGroups();
    Task<Response<string>> UpdateGroups(Groups groups);
    Task<Response<string>> DeleteGroupsWithId(int Id);
    Task<Response<Groups>> GetGroupsById(int Id);
    Task<Response<List<StudentsAndGroup>>> GetStudentPerGroup();
    Task<Response<List<Groups>>> GetEmptyGroups();
}
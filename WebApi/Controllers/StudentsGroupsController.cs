using Domain.Entities;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]


public class StudentsGroupsController(StudentsGroupsService studentsGroupsService)
{
    [HttpGet]
    public async Task<Response<List<StudentsGroups>>> GetAllStudentsAndGroups()
    {
        return await studentsGroupsService.GetAllStudentsAndGroups();
    }

    [HttpPost]
    public async Task<Response<string>> CreateStudentToGroup(StudentsGroups studentsGroups)
    {
        return await studentsGroupsService.CreateStudentToGroup(studentsGroups);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateStudentsStatus(string Status)
    {
        return await studentsGroupsService.UpdateStudentsStatus(Status);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteStudentsGroupsById(int Id)
    {
        return await studentsGroupsService.DeleteStudentsGroupsById(Id);
    }
}
using Domain.Entities;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;
using Domain.DTOs;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GroupsController(GroupsService groupsService)
{
    [HttpGet]
    public async Task<Response<List<Groups>>> GetAllGroups()
    {
        return await groupsService.GetAllGroups();
    }

    [HttpPost]
    public async Task<Response<string>> CreateGroups(Groups groups)
    {
        return await groupsService.CreateGroups(groups);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateGroups(Groups groups)
    {
        return await groupsService.UpdateGroups(groups);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteGroupsWithId(int Id)
    {
        return await groupsService.DeleteGroupsWithId(Id);
    }

    [HttpGet("{Id = int}")]
    public async Task<Response<Groups>> GetGroupsById(int Id)
    {
        return await groupsService.GetGroupsById(Id);
    }

    [HttpGet("Student Per Group")]
    public async Task<Response<List<StudentsAndGroup>>> GetStudentPerGroup()
    {
        return await groupsService.GetStudentPerGroup();
    }

    [HttpGet("Empty Groups")]
    public async Task<Response<List<Groups>>> GetEmptyGroups()
    {
        return await groupsService.GetEmptyGroups();
    }
}
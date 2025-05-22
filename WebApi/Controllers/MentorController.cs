using Domain.Entities;
using Infrastructure.Services;
using Domain.ApiResponse;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]

public class MentorController(MentorsService mentorsService)
{
    [HttpGet]
    public async Task<Response<List<Mentors>>> GetAllMentors()
    {
        return await mentorsService.GetAllMentors();
    }

    [HttpPost]
    public async Task<Response<string>> CreateMentors(Mentors mentors)
    {
        return await mentorsService.CreateMentors(mentors);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateMentors(Mentors mentors)
    {
        return await mentorsService.UpdateMentors(mentors);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteMentorsWithId(int Id)
    {
        return await mentorsService.DeleteMentorsWithId(Id);
    }

    [HttpGet("{Id = int}")]
    public async Task<Response<Mentors>> GetMentorsById(int Id)
    {
        return await mentorsService.GetMentorsById(Id);
    }
}
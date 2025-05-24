using Microsoft.AspNetCore.Http;

namespace Domain.Entities;

public class Students
{
    public int StudetnId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public IFormFile? Photo { get; set; }
}
namespace Domain.Entities;

public class Groups
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }
    public int CourseId { get; set; }
    public int MentorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
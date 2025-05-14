using data.Model;
using System.ComponentModel.DataAnnotations;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Da { get; set; }

    public List<Request> Requests { get; set; }
    public List<Availability> Availabilities { get; set; } 

    public List<Meeting> Meetings { get; set; }
}

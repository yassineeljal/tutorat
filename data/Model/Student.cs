using data.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Da { get; set; }
    public bool IsLinked { get; set; } = false;

    public List<Request> Requests { get; set; }
    public List<Availability> Availabilities { get; set; } 
    public List<Meeting> Meetings { get; set; }
    public int? TutorId { get; set; }

    [ForeignKey(nameof(TutorId))]
    public Tutor Tutor { get; set; }
}

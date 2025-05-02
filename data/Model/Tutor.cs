using System.ComponentModel.DataAnnotations;
using data.Model;

public class Tutor
{
    [Key]
    public int Id { get; set; }
    public int Da { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Availability> Availabilities { get; set; } 
}

using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime DateMeeting { get; set; }

        public Tutor Tutor { get; set; }
        public Student Student { get; set; }
    }
}

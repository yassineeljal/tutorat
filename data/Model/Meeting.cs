using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace data.Model
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime DateMeeting { get; set; }

        [ForeignKey(nameof(Tutor))]

        public int TutorId { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }
}

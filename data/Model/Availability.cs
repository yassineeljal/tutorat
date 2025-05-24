using System;
using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Availability
    {
        [Key]
        public int Id { get; set; }

        public DayOfWeek DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Clés étrangères rendues optionnelles
        public int? StudentId { get; set; }
        public Student Student { get; set; }

        public int? TutorId { get; set; }
        public Tutor Tutor { get; set; }
    }
}

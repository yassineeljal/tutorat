using System.ComponentModel.DataAnnotations.Schema;

namespace data.Model
{
    public class Availability
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; } // Exemple d'utilisation d'un type enum
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }
}

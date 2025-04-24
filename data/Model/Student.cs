using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int Da { get; set; }
        public bool IsTutor { get; set; }
    }
}

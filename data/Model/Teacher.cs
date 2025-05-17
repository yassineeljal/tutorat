using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
    }
}

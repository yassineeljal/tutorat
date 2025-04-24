using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Tutor
    {
        [Key]
        public int Id { get; set; }
        public int Da { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

    }
}

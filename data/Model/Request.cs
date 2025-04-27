using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public String Subject { get; set; }
        public String Category { get; set; }
        public int Note { get; set; }
        public Student Student { get; set; }
    }
}

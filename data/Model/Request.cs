using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace data.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public String Subject { get; set; }
        public String Category { get; set; }
        public int Note { get; set; }

        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
    }
}

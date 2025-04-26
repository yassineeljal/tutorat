using System.ComponentModel.DataAnnotations;

namespace data.Model
{
    public class Rencontre
    {
        [Key]
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Description { get; set; }
        public DateTime DateRencontre { get; set; }

        public Tutor Tutor { get; set; }
        public Student Student { get; set; }
    }
}

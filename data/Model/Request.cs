using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Model
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public String Subject { get; set; }
        public String Category { get; set; }
        public String Note { get; set; }
        public Student Student { get; set; }
    }
}

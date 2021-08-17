using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("RegistrationTeacher")]
    public class RegistrationTeach
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(10)]
        public string Login { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        public virtual Subject Subject { get; set; }
        public RegistrationTeach()
        {
        }
    }
}

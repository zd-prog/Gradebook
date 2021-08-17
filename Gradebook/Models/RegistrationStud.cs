using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("RegistrationStudent")]
    public class RegistrationStud
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(10)]
        public string Login { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        public Group Group { get; set; }
        Context Context = new Context();
        public RegistrationStud()
        {
            Group = Context.groups.Local.Where(g => g.Group_ID == Group_ID).FirstOrDefault();
        }
    }
}

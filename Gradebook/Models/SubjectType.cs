using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("SubjectType")]
    public class SubjectType
    {
        [Key]
        public int ID_Subject_Type { get; set; }
        [Required]
        [StringLength(50)]
        public string Subject_Type { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public SubjectType()
        {
            Subjects = new List<Subject>();
        }
    }
}

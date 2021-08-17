using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Lab")]
    public class Lab
    {
        [Key]
        public int Lab_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }
        [Required]
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int Subject_ID { get; set; }

        public virtual Group Group { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
        Context Context = new Context();
        public Lab()
        {
            LabResults = new List<LabResult>();
            Group = Context.groups.Local.Where(g => g.Group_ID == Group_ID).FirstOrDefault();
            Subject = Context.subjects.Local.Where(s => s.Subject_ID == Subject_ID).FirstOrDefault();
            Teacher = Context.teachers.Local.Where(t => t.Teacher_ID == Teacher_ID).FirstOrDefault();
        }
    }
}

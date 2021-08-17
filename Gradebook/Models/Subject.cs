using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public int Subject_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [ForeignKey("SubjectType")]
        public int ID_Subject_Type { get; set; }
        public virtual SubjectType SubjectType { get; set; }
        [Required]
        public int Amount_Hours { get; set; }
        public virtual ICollection<Lab> Labs { get; set; }
        public virtual ICollection<Missing> Missings { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        Context Context = new Context();
        public Subject()
        {
            Labs = new List<Lab>();
            Missings = new List<Missing>();
            Schedules = new List<Schedule>();
            Tests = new List<Test>();
            Groups = new List<Group>();
            Teachers = new List<Teacher>();
        }
    }
}

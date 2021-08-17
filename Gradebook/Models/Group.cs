using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Group")]
    public class Group
    {
        [Key]
        public int Group_ID { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Lab> Labs { get; set; }
        public ICollection<Missing> Missings { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public Group()
        {
            Exams = new List<Exam>();
            Labs = new List<Lab>();
            Missings = new List<Missing>();
            Schedules = new List<Schedule>();
            Tests = new List<Test>();
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }
}

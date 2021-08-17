using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook
{
    [Table("Teacher")]
    public partial class Teacher
    {
        [Key]
        public int Teacher_ID { get; set; }
        public bool Admin { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        [StringLength(10)]
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Lab> Labs { get; set; }
        public virtual ICollection<Missing> Missings { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public virtual ICollection<Test> Tests { get; set; }


        public Teacher()
        {
            Subjects = new List<Subject>();
            Exams = new List<Exam>();
            Labs = new List<Lab>();
            Missings = new List<Missing>();
            Schedules = new List<Schedule>();
            Tests = new List<Test>();
        }
    }
}

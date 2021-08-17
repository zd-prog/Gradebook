using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Missing")]
    public class Missing
    {
        [Key]
        public int Missing_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [ForeignKey("Student")]
        public int Student_ID { get; set; }
        [ForeignKey("Subject")]
        public int Subject_ID { get; set; }
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }
        public Group Group { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }

        public Teacher Teacher { get; set; }
        Context Context = new Context();
        public Missing()
        {
            Group = Context.groups.Local.Where(g => g.Group_ID == Group_ID).FirstOrDefault();
            Student = Context.students.Local.Where(s => s.Student_ID == Student_ID).FirstOrDefault();
            Subject = Context.subjects.Local.Where(s => s.Subject_ID == Subject_ID).FirstOrDefault();
            Teacher = Context.teachers.Local.Where(t => t.Teacher_ID == Teacher_ID).FirstOrDefault();
        }
    }
}

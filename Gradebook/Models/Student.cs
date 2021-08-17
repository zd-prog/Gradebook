using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Student_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }
        public virtual Group Group { get; set; }
        [StringLength(50)]
        public string Login { get; set; }

        public string Password { get; set; }
        public ICollection<Missing> Missings { get; set; }
        public ICollection<LabResult> LabResults { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
        Context Context = new Context();
        public Student()
        {
            Missings = new List<Missing>();
            LabResults = new List<LabResult>();
            TestResults = new List<TestResult>();
            ExamResults = new List<ExamResult>();
        }
    }
}

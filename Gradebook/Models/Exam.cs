using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Exam")]
    public class Exam
    {
        [Key]
        public int Exam_ID { get; set; }
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        [ForeignKey("Subject")]
        public int Subject_ID { get; set; }
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }
        public virtual Group Group { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ExamResult> ExamResults { get; set; }
        public Exam()
        {
            ExamResults = new List<ExamResult>();
        }
        
    }
}

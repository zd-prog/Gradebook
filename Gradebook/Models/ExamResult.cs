using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("ExamResult")]
    public class ExamResult
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Student")]
        public int Student_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Exam")]
        public int Exam_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExamDate { get; set; }

        public int ExamMark { get; set; }
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }
    }
}

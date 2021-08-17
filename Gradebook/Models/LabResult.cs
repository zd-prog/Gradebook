using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("LabResult")]
    public class LabResult
    {
        [Key]
        public int LabResult_ID { get; set; }
        [ForeignKey("Student")]
        public int Student_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        public int Mark { get; set; }
        public virtual Lab Lab { get; set; }
        public virtual Student Student { get; set; }
        Context Context = new Context();
        public LabResult()
        {
            Student = Context.students.Local.Where(s => s.Student_ID == Student_ID).FirstOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Schedule")]
    public class Schedule
    {
        [Key]
        public int Schedule_ID { get; set; }
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        [ForeignKey("Subject")]
        public int Subject_ID { get; set; }
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }
        [ForeignKey("Class")]
        public int Class_ID { get; set; }
        public string Auditorium { get; set; }
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Weekday Weekday { get; set; }
        public virtual Class Class { get; set; }
    }
}

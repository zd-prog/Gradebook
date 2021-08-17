using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("TestResult")]
    public class TestResult
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Test")]
        public int Test_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Student")]
        public int Student_ID { get; set; }

        public int TestMark { get; set; }

        public virtual Student Student { get; set; }

        public virtual Test Test { get; set; }
    }
}

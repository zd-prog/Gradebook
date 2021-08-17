using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int Test_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [ForeignKey("Group")]
        public int Group_ID { get; set; }
        [ForeignKey("TestType")]
        public int TestType_ID { get; set; }
        [ForeignKey("Teacher")]
        public int Teacher_ID { get; set; }
        [ForeignKey("Subject")]
        public int Subject_ID { get; set; }
        [Column(TypeName = "date")]
        public DateTime TestDate { get; set; }
        public Group Group { get; set; }
        public TestType TestType { get; set; }
        public Teacher Teacher { get; set; }
        public Subject Subject { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
        Context Context = new Context();
        public Test()
        {
            TestResults = new List<TestResult>();
        }
    }
}

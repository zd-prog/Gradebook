using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("TestType")]
    public class TestType
    {
        [Key]
        public int TestType_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Test_Type { get; set; }
        public ICollection<Test> Tests { get; set; }
        public TestType()
        {
            Tests = new List<Test>();
        }
    }
}

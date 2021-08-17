using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Class")]
    public class Class
    {
        [Key]
        public int Class_ID { get; set; }
        public int ClassNumber { get; set; }
        public string Time { get; set; }
        public int WeekNumber { get; set; }
        [NotMapped]
        public ICollection<Schedule> Schedules { get; set; }
        public Class()
        {
            Schedules = new List<Schedule>();
        }
    }
}

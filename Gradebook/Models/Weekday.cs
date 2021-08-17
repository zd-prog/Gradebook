using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Models
{
    [Table("Weekday")]
    public class Weekday
    {
        [Key]
        public int Weekday_ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
        public Weekday()
        {
            Schedules = new List<Schedule>();
        }
    }
}

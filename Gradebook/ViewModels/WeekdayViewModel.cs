using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    class WeekdayViewModel : ViewModelBase
    {
        public Weekday Weekday;
        public WeekdayViewModel(Weekday weekday)
        {
            this.Weekday = weekday;
        }
        public string Name
        {
            get { return Weekday.Name; }
            set
            {
                Weekday.Name = value;
                OnPropertyChanged("Weekday");
            }
        }
        public ICollection<Schedule> Schedules
        {
            get { return Weekday.Schedules; }
            set
            {
                Weekday.Schedules = value;
                OnPropertyChanged("Schedules");
            }
        }
    }
}

using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    class ClassViewModel : ViewModelBase
    {
        public Class Class;
        public ClassViewModel(Class Class)
        {
            this.Class = Class;
        }
        public int ClassNumber
        {
            get { return Class.ClassNumber; }
            set
            {
                Class.ClassNumber = value;
                OnPropertyChanged("ClassNumber");
            }
        }
        public string Time
        {
            get { return Class.Time; }
            set
            {
                Class.Time = value;
                OnPropertyChanged("Time");
            }
        }
        public int WeekNumber 
        {
            get { return Class.WeekNumber; }
            set
            {
                Class.WeekNumber = value;
                OnPropertyChanged("WeekNumber");
            }
        }
        public ICollection<Schedule> Schedules
        {
            get { return Class.Schedules; }
            set
            {
                Class.Schedules = value;
                OnPropertyChanged("Schedules");
            }
        }
    }
}

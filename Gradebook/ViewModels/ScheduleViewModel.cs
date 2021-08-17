using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        public Schedule Schedule;
        public ScheduleViewModel(Schedule schedule)
        {
            this.Schedule = schedule;
        }
        public Group Group
        {
            get { return Schedule.Group; }
            set
            {
                Schedule.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public Subject Subject
        {
            get { return Schedule.Subject; }
            set
            {
                Schedule.Subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public Teacher Teacher
        {
            get { return Schedule.Teacher; }
            set
            {
                Schedule.Teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
        public Weekday Weekday
        {
            get { return Schedule.Weekday; }
            set
            {
                Schedule.Weekday = value;
                OnPropertyChanged("Weekday");
            }
        }
        public Class Class
        {
            get { return Schedule.Class; }
            set
            {
                Schedule.Class = value;
                OnPropertyChanged("Time");
            }
        }
        public string Auditorium
        {
            get { return Schedule.Auditorium; }
            set
            {
                Schedule.Auditorium = value;
                OnPropertyChanged("Auditorium");
            }
        }
    }
}

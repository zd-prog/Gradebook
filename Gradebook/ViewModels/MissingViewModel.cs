using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class MissingViewModel : ViewModelBase
    {
        public Missing Missing;
        public MissingViewModel(Missing missing)
        {
            this.Missing = missing;
        }
        public DateTime Date
        {
            get { return Missing.Date; }
            set
            {
                Missing.Date = value;
                OnPropertyChanged("Date");
            }
        }
        public Student Student
        {
            get { return Missing.Student; }
            set
            {
                Missing.Student = value;
                OnPropertyChanged("Student");
            }
        }
        public Subject Subject
        {
            get { return Missing.Subject; }
            set
            {
                Missing.Subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public Group Group
        {
            get { return Missing.Group; }
            set
            {
                Missing.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public Teacher Teacher
        {
            get { return Missing.Teacher; }
            set
            {
                Missing.Teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
    }
}

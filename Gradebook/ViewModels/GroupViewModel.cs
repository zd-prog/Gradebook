using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class GroupViewModel : ViewModelBase
    {
        public Group Group;
        public string Name
        {
            get { return Group.Name; }
            set
            {
                Group.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public ICollection<Exam> Exams
        {
            get { return Group.Exams; }
            set
            {
                Group.Exams = new List<Exam>();
                OnPropertyChanged("Exams");
            }
        }
        public ICollection<Lab> Labs
        {
            get { return Group.Labs; }
            set
            {
                Group.Labs = new List<Lab>();
                OnPropertyChanged("Labs");
            }
        }
        public ICollection<Missing> Missings
        {
            get { return Group.Missings; }
            set
            {
                Group.Missings = new List<Missing>();
                OnPropertyChanged("Missings");
            }
        }
        public ICollection<Schedule> Schedules
        {
            get { return Group.Schedules; }
            set
            {
                Group.Schedules = new List<Schedule>();
                OnPropertyChanged("Schedules");
            }
        }
        public ICollection<Student> Students
        {
            get { return Group.Students; }
            set
            {
                Group.Students = new List<Student>();
                OnPropertyChanged("Students");
            }
        }
        public GroupViewModel(Group group)
        {
            this.Group = group;
        }
    }
}

using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class SubjectViewModel : ViewModelBase
    {
        public Subject Subject;
        public string Name 
        {
            get { return Subject.Name; }
            set
            {
                Subject.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public SubjectType SubjectType 
        { 
            get { return Subject.SubjectType; } 
            set
            {
                Subject.SubjectType = value;
                OnPropertyChanged("SubjectType");
            }
        }
        public int Amount_Hours 
        { 
            get { return Subject.Amount_Hours; }
            set
            {
                Subject.Amount_Hours = value;
                OnPropertyChanged("Amount_Hours");
            }
        }
        public ICollection<Missing> Missings
        {
            get { return Subject.Missings; }
            set
            {
                Subject.Missings = value;
                OnPropertyChanged("Missings");
            }
        }
        public ICollection<Lab> Labs
        {
            get { return Subject.Labs; }
            set
            {
                Subject.Labs = value;
                OnPropertyChanged("Labs");
            }
        }
        public ICollection<Schedule> Schedules
        {
            get { return Subject.Schedules; }
            set
            {
                Subject.Schedules = value;
                OnPropertyChanged("Schedules");
            }
        }
        public ICollection<Test> Tests
        {
            get { return Subject.Tests; }
            set
            {
                Subject.Tests = value;
                OnPropertyChanged("Tests");
            }
        }
        public ICollection<Group> Groups
        {
            get { return Subject.Groups; }
            set
            {
                Subject.Groups = value;
                OnPropertyChanged("Groups");
            }
        }
        public ICollection<Teacher> Teachers
        {
            get { return Subject.Teachers; }
            set
            {
                Subject.Teachers = value;
                OnPropertyChanged("Teachers");
            }
        }
        public SubjectViewModel(Subject subject)
        {
            this.Subject = subject;
        }
    }
}

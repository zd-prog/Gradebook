using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class TeacherViewModel : ViewModelBase
    {
        public Teacher Teacher;
        public string Surname
        {
            get { return Teacher.Surname; }
            set
            {
                Teacher.Surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public bool Admin
        {
            get { return Teacher.Admin; }
            set
            {
                Teacher.Admin = value;
            }
        }
        public string Login
        {
            get { return Teacher.Login; }
            set
            {
                Teacher.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return Teacher.Password; }
            set
            {
                Teacher.Password = value;
                OnPropertyChanged("Password");
            }
        }
        public ICollection<Subject> Subjects
        {
            get { return Teacher.Subjects; }
            set
            {
                Teacher.Subjects = value;
                OnPropertyChanged("Subjects");
            }
        }
        public ICollection<Exam> Exams
        {
            get { return Teacher.Exams; }
            set
            {
                Teacher.Exams = value;
                OnPropertyChanged("Exams");
            }
        }
        public ICollection<Lab> Labs
        {
            get { return Teacher.Labs; }
            set
            {
                Teacher.Labs = value;
                OnPropertyChanged("Labs");
            }
        }
        public ICollection<Missing> Missings
        {
            get { return Teacher.Missings; }
            set
            {
                Teacher.Missings = value;
                OnPropertyChanged("Missings");
            }
        }
        public ICollection<Schedule> Schedules
        {
            get { return Teacher.Schedules; }
            set
            {
                Teacher.Schedules = value;
                OnPropertyChanged("Schedules");
            }
        }
        public ICollection<Test> Tests
        {
            get { return Teacher.Tests; }
            set
            {
                Teacher.Tests = value;
                OnPropertyChanged("Tests");
            }
        }
        private Teacher SelectedTeacher { get; set; }
        public void Add(Teacher teacher)
        {
            SelectedTeacher = teacher;
            using (Context context = new Context())
            {
                context.teachers.Add(SelectedTeacher);
                context.SaveChanges();
            }
        }
        public TeacherViewModel(Teacher teacher)
        {
            this.Teacher = teacher;
        }
    }
}

using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        public Student Student;
        public string Surname
        {
            get { return Student.Surname; }
            set
            {
                Student.Surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Login
        {
            get { return Student.Login; }
            set
            {
                Student.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return Student.Password; }
            set
            {
                Student.Password = value;
                OnPropertyChanged("Password");
            }
        }
        public Group Group
        {
            get { return Student.Group; }
            set
            {
                Student.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public ICollection<Missing> Missings
        {
            get { return Student.Missings; }
            set
            {
                Student.Missings = value;
                OnPropertyChanged("Missings");
            }
        }
        public ICollection<LabResult> LabResults
        {
            get { return Student.LabResults; }
            set
            {
                Student.LabResults = value;
                OnPropertyChanged("LabResults");
            }
        }
        public ICollection<TestResult> TestResults
        {
            get { return Student.TestResults; }
            set
            {
                Student.TestResults = value;
                OnPropertyChanged("TestResults");
            }
        }
        public ICollection<ExamResult> ExamResults
        {
            get { return Student.ExamResults; }
            set
            {
                Student.ExamResults = value;
                OnPropertyChanged("ExamResults");
            }
        }

        public StudentViewModel(Student student)
        {
            this.Student = student;
        }
    }
}

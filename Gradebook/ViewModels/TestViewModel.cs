using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        public Test Test;
        public TestViewModel(Test test)
        {
            this.Test = test;
        }
        public string Name
        {
            get { return Test.Name; }
            set
            {
                Test.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Group Group
        {
            get { return Test.Group; }
            set
            {
                Test.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public TestType TestType
        {
            get { return Test.TestType; }
            set
            {
                Test.TestType = value;
                OnPropertyChanged("TestType");
            }
        }
        public Teacher Teacher
        {
            get { return Test.Teacher; }
            set
            {
                Test.Teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
        public DateTime Date
        {
            get { return Test.TestDate; }
            set
            {
                Test.TestDate = value;
                OnPropertyChanged("Date");
            }
        }
        public Subject Subject
        {
            get { return Test.Subject; }
            set
            {
                Test.Subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public ICollection<TestResult> TestResults
        {
            get { return Test.TestResults; }
            set
            {
                Test.TestResults = value;
                OnPropertyChanged("TestResults");
            }
        }
    }
}

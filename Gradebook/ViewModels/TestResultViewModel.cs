using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class TestResultViewModel : ViewModelBase
    {
        public TestResult TestResult;
        public TestResultViewModel(TestResult testResult)
        {
            this.TestResult = testResult;
        }
        public Test Test
        {
            get { return TestResult.Test; }
            set
            {
                TestResult.Test = value;
                OnPropertyChanged("Test");
            }
        }
        public Student Student
        {
            get { return TestResult.Student; }
            set
            {
                TestResult.Student = value;
                OnPropertyChanged("Student");
            }
        }

        public int Mark
        {
            get { return TestResult.TestMark; }
            set
            {
                TestResult.TestMark = value;
                OnPropertyChanged("Mark");
            }
        }
    }
}

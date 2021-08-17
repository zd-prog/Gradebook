using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class WelcomePageStudentViewModel
    {
        Context context = new Context();
        public Student Student { get; set; }
        public string SubjectTest { get; set; }
        public ObservableCollection<TestViewModel> ControlsGrid { get; set; }
        public WelcomePageStudentViewModel(Student student)
        {
            Student = student;
            ControlsGrid = new ObservableCollection<TestViewModel>(context.tests.ToList().Where(t => t.Group_ID == Student.Group.Group_ID).Where(t => (t.TestDate - DateTime.Now).TotalDays < 12 && 
            (t.TestDate - DateTime.Now).TotalDays > 0).Select(t => new TestViewModel(t)));
        }
    }
}

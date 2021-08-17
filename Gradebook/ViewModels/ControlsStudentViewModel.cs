using Gradebook.Commands;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class ControlsStudentViewModel : ViewModelBase
    {
        Context Context { get; set; }
        public Student Student { get; set; }
        public List<string> ControlSubject { get; set; }
        private string selectedSubject;
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                this.selectedSubject = value;
                OnPropertyChanged(nameof(selectedSubject));
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        public ObservableCollection<TestResult> testResults { get; set; }
        public ObservableCollection<TestResultViewModel> testResultsList
        {
            get { return new ObservableCollection<TestResultViewModel>(testResults.Where(t => t.Test.Subject.Name == SelectedSubject && 
            t.Student.Surname == Student.Surname).Select(t => new TestResultViewModel(t))); }
            set
            {
                testResultsList = value;
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        public ControlsStudentViewModel(Student student, Context context)
        {
            SelectedSubject = "";
            Context = context;
            Context.groups.Load();
            Context.subjects.Load();
            Context.testResults.Load();
            testResults = Context.testResults.Local;
            Student = student;
            ControlSubject = new List<string>();
            foreach (var s in Context.subjects.Local.ToList())
            {
                foreach (var g in s.Groups)
                {
                    if (g.Name == Student.Group.Name)
                    {
                        ControlSubject.Add(s.Name);
                    }
                }
            }
        }
    }
}

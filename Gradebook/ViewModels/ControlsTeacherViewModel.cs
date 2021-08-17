using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
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
    public class ControlsTeacherViewModel : ViewModelBase
    {
        Context Context { get; set; }
        public Teacher Teacher { get; set; }
        private List<string> subjectsRes;
        public List<string> SubjectsRes
        {
            get
            {
                subjectsRes = new List<string>();
                foreach (var s in Context.subjects.Local)
                {
                    foreach (var t in s.Teachers)
                    {
                        if (t.Surname == Teacher.Surname && !subjectsRes.Contains(Context.subjects.Where(subj => subj.Name == s.Name).Select(subj => subj.Name).FirstOrDefault()))
                        {
                            subjectsRes.Add(s.Name);
                        }
                    }
                }
                return subjectsRes;
            }
        }
        private string selectedSubject;
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                this.selectedSubject = value;
                OnPropertyChanged(nameof(selectedSubject));
                OnPropertyChanged(nameof(GroupsLabs));
                OnPropertyChanged(nameof(TestsTeacher));
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        private string selectedSubjectAdd;
        public string SelectedSubjectAdd
        {
            get { return selectedSubjectAdd; }
            set
            {
                this.selectedSubjectAdd = value;
                OnPropertyChanged(nameof(selectedSubjectAdd));
                OnPropertyChanged(nameof(GroupsAdd));
                OnPropertyChanged(nameof(TestsAdd));
            }
        }
        private List<string> groupsLabs;
        public List<string> GroupsLabs
        {
            get
            {
                foreach (var s in Context.subjects.Local.Where(s => s.Name == SelectedSubject))
                {
                    foreach (var g in s.Groups)
                    {
                        groupsLabs.Add(g.Name);
                    }
                }
                return groupsLabs;
            }
        }
        private List<string> groupsAdd;
        public List<string> GroupsAdd
        {
            get
            {
                groupsAdd = new List<string>();
                foreach (var s in Context.subjects.Local.Where(s => s.Name == SelectedSubjectAdd))
                {
                    foreach (var g in s.Groups)
                    {
                        groupsAdd.Add(g.Name);
                    }
                }
                return groupsAdd;
            }
        }
        private string selectedGroup;
        public string SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                this.selectedGroup = value;
                OnPropertyChanged(nameof(SelectedGroup));
                OnPropertyChanged(nameof(TestsTeacher));
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        private string selectedGroupAdd;
        public string SelectedGroupAdd
        {
            get { return selectedGroupAdd; }
            set
            {
                this.selectedGroupAdd = value;
                OnPropertyChanged(nameof(SelectedGroupAdd));
                OnPropertyChanged(nameof(StudentsAdd));
                OnPropertyChanged(nameof(TestsAdd));
            }
        }
        public List<string> TestsTeacher
        {
            get
            {
                return Context.tests.Local.Where(l => l.Subject.Name == SelectedSubject && l.Group.Name == SelectedGroup).Select(l => l.Name).ToList();
            }
        }
        public List<string> TestsAdd
        {
            get
            {
                return Context.tests.Local.Where(l => l.Subject.Name == SelectedSubjectAdd && l.Group.Name == SelectedGroupAdd).Select(l => l.Name).ToList();
            }
        }
        private string selectedTest;
        public string SelectedTest
        {
            get { return selectedTest; }
            set
            {
                this.selectedTest = value;
                OnPropertyChanged(nameof(SelectedTest));
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        private string selectedTestAdd;
        public string SelectedTestAdd
        {
            get { return selectedTestAdd; }
            set
            {
                this.selectedTestAdd = value;
                OnPropertyChanged(nameof(SelectedTestAdd));
            }
        }
        public List<string> StudentsAdd
        {
            get
            {
                return Context.students.Local.Where(s => s.Group.Name == SelectedGroupAdd).Select(s => s.Surname).ToList();
            }
        }
        private string selectedStudentAdd;
        public string SelectedStudentAdd
        {
            get { return selectedStudentAdd; }
            set
            {
                this.selectedStudentAdd = value;
                OnPropertyChanged(nameof(SelectedStudentAdd));
            }
        }
        public List<int> MarksAdd
        {
            get
            {
                return new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            }
        }
        private int selectedMarkAdd;
        public int SelectedMarkAdd
        {
            get { return selectedMarkAdd; }
            set
            {
                this.selectedMarkAdd = value;
                OnPropertyChanged(nameof(SelectedMarkAdd));
            }
        }
        public ObservableCollection<TestResultViewModel> testResultsList
        {
            get { return new ObservableCollection<TestResultViewModel>(Context.testResults.Local.Where(t => t.Test.Subject.Name == SelectedSubject && t.Student.Group.Name == SelectedGroup && 
            t.Test.Name == SelectedTest).Select(t => new TestResultViewModel(t))); }
            set
            {
                testResultsList = value;
                OnPropertyChanged(nameof(testResultsList));
            }
        }
        public ControlsTeacherViewModel(Teacher teacher, Context context)
        {
            Teacher = teacher;
            Context = context;
            SelectedSubject = "";
            SelectedGroup = "";
            SelectedTest = "";
            SelectedSubjectAdd = null;
            SelectedGroupAdd = "";
            SelectedTestAdd = "";
            SelectedStudentAdd = "";
            SelectedMarkAdd = new int();
            Context.subjects.Load();
            Context.groups.Load();
            Context.tests.Load();
            Context.testResults.Load();
            Context.students.Load();
            subjectsRes = new List<string>();
            groupsLabs = new List<string>();
        }
        private DelegateCommand saveCommand;
        private DelegateCommand addCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (saveCommand == null)
                    saveCommand = new DelegateCommand(Save);
                return saveCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                    addCommand = new DelegateCommand(Add, canAdd);
                return addCommand;
            }
        }
        private void Add()
        {
            Student student = Context.students.Local.Where(s => s.Surname == SelectedStudentAdd).FirstOrDefault();
            Test test = Context.tests.Local.Where(l => l.Name == SelectedTestAdd).FirstOrDefault();
            TestResult testResult = new TestResult() { Student = student, Test = test, TestMark = SelectedMarkAdd };
            Context.testResults.Local.Add(testResult);
            Context.SaveChanges();
            SelectedSubjectAdd = "";
            SelectedGroupAdd = "";
            SelectedTestAdd = "";
            SelectedStudentAdd = "";
        }
        private bool canAdd()
        {
            if (SelectedTestAdd != "" && SelectedStudentAdd != "" && !Context.testResults.Local.Contains(Context.testResults.Where(l => l.Test.Name == SelectedTestAdd && 
            l.Student.Surname == SelectedStudentAdd).FirstOrDefault()))
            {
                return true;
            }
            else
                return false;
        }
        private void Save()
        {
            Context.SaveChanges();
        }   
    }
}

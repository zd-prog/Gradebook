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
    public class LabsTeacherViewModel : ViewModelBase
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
                        if (t.Surname == Teacher.Surname)
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
                OnPropertyChanged(nameof(SelectedSubject));
                OnPropertyChanged(nameof(GroupsLabs));
                OnPropertyChanged(nameof(LabsTeacher));
                OnPropertyChanged(nameof(labResultsList));
            }
        }
        private string selectedSubjectAdd;
        public string SelectedSubjectAdd
        {
            get { return selectedSubjectAdd; }
            set
            {
                this.selectedSubjectAdd = value;
                OnPropertyChanged(nameof(SelectedSubjectAdd));
                OnPropertyChanged(nameof(GroupsAdd));
                OnPropertyChanged(nameof(LabsAdd));
            }
        }
        private List<string> groupsLabs;
        public List<string> GroupsLabs
        {
            get
            {
                groupsLabs = new List<string>();
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
                OnPropertyChanged(nameof(LabsTeacher));
                OnPropertyChanged(nameof(labResultsList));
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
                OnPropertyChanged(nameof(LabsAdd));
            }
        }
        public List<string> LabsTeacher
        {
            get
            {
                return Context.labs.Local.Where(l => l.Subject.Name == SelectedSubject && l.Group.Name == SelectedGroup).Select(l => l.Name).ToList();
            }
        }
        public List<string> LabsAdd
        {
            get
            {
                return Context.labs.Local.Where(l => l.Subject.Name == SelectedSubjectAdd && l.Group.Name == SelectedGroupAdd).Select(l => l.Name).ToList();
            }
        }
        private string selectedLab;
        public string SelectedLab
        {
            get { return selectedLab; }
            set
            {
                this.selectedLab = value;
                OnPropertyChanged(nameof(SelectedLab));
                OnPropertyChanged(nameof(labResultsList));
            }
        }
        private string selectedLabAdd;
        public string SelectedLabAdd
        {
            get { return selectedLabAdd; }
            set
            {
                this.selectedLabAdd = value;
                OnPropertyChanged(nameof(SelectedLabAdd));
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
        private DateTime selectedDateAdd;
        public DateTime SelectedDateAdd
        {
            get { return selectedDateAdd; }
            set 
            {
                this.selectedDateAdd = value;
                OnPropertyChanged(nameof(SelectedDateAdd)); 
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
        public ObservableCollection<LabResultViewModel> labResultsList
        {
            get { return new ObservableCollection<LabResultViewModel>(Context.labResults.Local.Where(t => t.Lab.Subject.Name == SelectedSubject && t.Student.Group.Name == SelectedGroup && t.Lab.Name == SelectedLab).Select(t => new LabResultViewModel(t))); }
            set
            {
                labResultsList = value;
                OnPropertyChanged(nameof(labResultsList));
            }
        }
        public LabsTeacherViewModel(Teacher teacher, Context context)
        {
            Teacher = teacher;
            Context = context;
            SelectedSubject = "";
            SelectedGroup = "";
            SelectedLab = "";
            SelectedSubjectAdd = "";
            SelectedGroupAdd = "";
            SelectedLabAdd = null;
            SelectedStudentAdd = "";
            SelectedDateAdd = DateTime.Now;
            SelectedMarkAdd = new int();
            Context.subjects.Load();
            Context.groups.Load();
            Context.labs.Load();
            Context.labResults.Load();
            Context.students.Load();
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
            Lab lab = Context.labs.Local.Where(l => l.Name == SelectedLabAdd).FirstOrDefault();
            LabResult labResult = new LabResult() { Student = student, Date = SelectedDateAdd, Lab = lab, Mark = SelectedMarkAdd };
            Context.labResults.Local.Add(labResult);
            Context.SaveChanges();
            SelectedSubjectAdd = "";
            SelectedGroupAdd = "";
            SelectedLabAdd = "";
            SelectedStudentAdd = "";
        }
        private bool canAdd()
        {
            if (SelectedLabAdd != "" && SelectedStudentAdd != "" && !Context.labResults.Local.Contains(Context.labResults.Where(l => l.Lab.Name == SelectedLabAdd && l.Student.Surname == SelectedStudentAdd).FirstOrDefault()))
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

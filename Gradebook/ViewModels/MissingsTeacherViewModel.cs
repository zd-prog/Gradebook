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
    public class MissingsTeacherViewModel : ViewModelBase
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
                OnPropertyChanged(nameof(GroupsMissings));
                OnPropertyChanged(nameof(MissingsList));
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
            }
        }
        private List<string> groupsMissings;
        public List<string> GroupsMissings
        {
            get
            {
                groupsMissings = new List<string>();
                foreach (var s in Context.subjects.Local.Where(s => s.Name == SelectedSubject))
                {
                    foreach (var g in s.Groups)
                    {
                        groupsMissings.Add(g.Name);
                    }
                }
                return groupsMissings;
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
                OnPropertyChanged(nameof(selectedGroup));
                OnPropertyChanged(nameof(StudentsTeacher));
                OnPropertyChanged(nameof(MissingsList));
            }
        }
        private string selectedGroupAdd;
        public string SelectedGroupAdd
        {
            get { return selectedGroupAdd; }
            set
            {
                this.selectedGroupAdd = value;
                OnPropertyChanged(nameof(selectedGroupAdd));
                OnPropertyChanged(nameof(StudentsAdd));
            }
        }
        public List<string> StudentsTeacher
        {
            get
            {
                return Context.students.Local.Where(s => s.Group.Name == SelectedGroup).Select(s => s.Surname).ToList();
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
        private string selectedStudent;
        public string SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                this.selectedStudent = value;
                OnPropertyChanged(nameof(MissingsList));
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
        public ObservableCollection<MissingViewModel> MissingsList
        {
            get { return new ObservableCollection<MissingViewModel>(Context.missings.Local.Where(m => m.Group.Name == SelectedGroup && m.Student.Surname == SelectedStudent && 
            m.Subject.Name == SelectedSubject).Select(m => new MissingViewModel(m))); }
            set
            {
                MissingsList = value;
                OnPropertyChanged(nameof(MissingsList));
            }
        }
        public MissingsTeacherViewModel(Teacher teacher, Context context)
        {
            Teacher = teacher;
            Context = context;
            SelectedSubject = "";
            SelectedGroup = "";
            SelectedStudent = "";
            SelectedSubjectAdd = null;
            SelectedGroupAdd = "";
            SelectedStudentAdd = "";
            SelectedDateAdd = DateTime.Now;
            Context.subjects.Load();
            Context.groups.Load();
            Context.students.Load();
            Context.missings.Load();
        }

        private DelegateCommand addCommand;
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
            Group group = Context.groups.Local.Where(g => g.Name == SelectedGroupAdd).FirstOrDefault();
            Student student = Context.students.Local.Where(s => s.Surname == SelectedStudentAdd).FirstOrDefault();
            Subject subject = Context.subjects.Local.Where(s => s.Name == SelectedSubjectAdd).FirstOrDefault();
            Teacher teacher = Context.teachers.Local.Where(t => t.Surname == Teacher.Surname).FirstOrDefault();
            Missing missing = new Missing() { Date = SelectedDateAdd, Group = group, Student = student, Subject = subject, Teacher = teacher };
            Context.missings.Local.Add(missing);
            Context.SaveChanges();
            SelectedSubjectAdd = "";
            SelectedGroupAdd = "";
            SelectedStudentAdd = "";
        }
        private bool canAdd()
        {
            if (SelectedSubjectAdd != "" && SelectedStudentAdd != "" && !Context.missings.Local.Contains(Context.missings.Local.Where(m => m.Subject.Name == SelectedSubjectAdd && 
            m.Student.Surname == SelectedStudentAdd && m.Group.Name == SelectedGroupAdd && m.Date == SelectedDateAdd).FirstOrDefault()))
            {
                return true;
            }
            else
                return false;
        }
    }
}

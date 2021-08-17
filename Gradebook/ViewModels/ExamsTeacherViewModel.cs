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
    public class ExamsTeacherViewModel : ViewModelBase
    {
        Context Context { get; set; }
        public Teacher Teacher { get; set; }
        public List<string> ExamsTeacher
        {
            get
            {
                return Context.exams.Local.Where(e => e.Teacher.Surname == Teacher.Surname).Select(e => e.Subject.Name).ToList();
            }
        }
        private string selectedExam;
        public string SelectedExam
        {
            get { return selectedExam; }
            set
            {
                this.selectedExam = value;
                OnPropertyChanged(nameof(SelectedExam));
                OnPropertyChanged(nameof(GroupsExams));
                OnPropertyChanged(nameof(examResultsList));
            }
        }
        private string selectedExamAdd;
        public string SelectedExamAdd
        {
            get { return selectedExamAdd; }
            set
            {
                this.selectedExamAdd = value;
                OnPropertyChanged(nameof(SelectedExamAdd));
                OnPropertyChanged(nameof(GroupsAdd));
            }
        }
        private List<string> groupsExams;
        public List<string> GroupsExams
        {
            get
            {
                groupsExams = new List<string>();
                foreach (var e in Context.exams.Local.Where(e => e.Subject.Name == SelectedExam))
                {
                    groupsExams.Add(e.Group.Name);
                }
                return groupsExams;
            }
        }
        private List<string> groupsAdd;
        public List<string> GroupsAdd
        {
            get
            {
                groupsAdd = new List<string>();
                foreach (var e in Context.exams.Local.Where(e => e.Subject.Name == SelectedExamAdd))
                {
                    groupsAdd.Add(e.Group.Name);
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
                OnPropertyChanged(nameof(examResultsList));
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
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                this.startDate = value;
                OnPropertyChanged(nameof(StartDate));
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
        public ObservableCollection<ExamResultViewModel> examResultsList
        {
            get { return new ObservableCollection<ExamResultViewModel>(Context.examResults.Local.Where(e => e.Exam.Subject.Name == SelectedExam && 
            e.Exam.Group.Name == SelectedGroup).Select(e => new ExamResultViewModel(e))); }
            set
            {
                examResultsList = value;
                OnPropertyChanged(nameof(examResultsList));
            }
        }
        public ExamsTeacherViewModel(Teacher teacher, Context context)
        {
            Teacher = teacher;
            Context = context;
            SelectedExam = "";
            SelectedGroup = "";
            SelectedExamAdd = null;
            SelectedGroupAdd = "";
            SelectedStudentAdd = "";
            SelectedDateAdd = DateTime.Now;
            SelectedMarkAdd = new int();
            Context.examResults.Load();
            Context.exams.Load();
            Context.groups.Load();
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
        private void Save()
        {
            Context.SaveChanges();
        }
        private void Add()
        {
            Student student = Context.students.Local.Where(s => s.Surname == SelectedStudentAdd).FirstOrDefault();
            Exam exam = Context.exams.Local.Where(e => e.Subject.Name == SelectedExamAdd && e.Group.Name == SelectedGroupAdd).FirstOrDefault();
            ExamResult examResult = new ExamResult() { Exam = exam, Student = student, ExamDate = SelectedDateAdd, ExamMark = SelectedMarkAdd };
            Context.examResults.Local.Add(examResult);
            Context.SaveChanges();
            SelectedExamAdd = null;
            SelectedGroupAdd = "";
            SelectedStudentAdd = "";
        }
        private bool canAdd()
        {
            if (SelectedExamAdd != "" && SelectedStudentAdd != "" && SelectedDateAdd >= Context.exams.Local.Where(e => e.Subject.Name == SelectedExamAdd).Select(e => e.ExamDate).First() && 
                !Context.examResults.Local.Contains(Context.examResults.Where(e => e.Exam.Subject.Name == SelectedExamAdd && e.Student.Surname == SelectedStudentAdd && 
                e.Student.Group.Name == SelectedGroupAdd).FirstOrDefault()))
            {
                return true;
            }
            else
                return false;
        }
    }
}

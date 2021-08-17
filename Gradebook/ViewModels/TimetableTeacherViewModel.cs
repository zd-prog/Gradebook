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
    public class TimetableTeacherViewModel : ViewModelBase
    {
        Context Context { get; set; }
        Teacher Teacher { get; set; }
        public List<string> WeekNumbers { get; set; }
        private string weekNumber;
        public string WeekNumber
        {
            get { return weekNumber; }
            set
            {
                this.weekNumber = value;
                OnPropertyChanged(nameof(MondayClasses));
                OnPropertyChanged(nameof(TuesdayClasses));
                OnPropertyChanged(nameof(WednesdayClasses));
                OnPropertyChanged(nameof(ThursdayClasses));
                OnPropertyChanged(nameof(FridayClasses));
                OnPropertyChanged(nameof(SaturdayClasses));
            }
        }
        private string selectedWeekNumber;
        public string SelectedWeekNumberAdd
        {
            get { return selectedWeekNumber; }
            set
            {
                this.selectedWeekNumber = value;
                OnPropertyChanged(nameof(SelectedWeekNumberAdd));
                OnPropertyChanged(nameof(ClassesAdd));
            }
        }
        public List<string> Weekdays
        {
            get
            {
                return new List<string>() { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота" };
            }
        }
        private string selectedWeekdayAdd;
        public string SelectedWeekdayAdd
        {
            get { return selectedWeekdayAdd; }
            set
            {
                this.selectedWeekdayAdd = value;
                OnPropertyChanged(nameof(SelectedWeekdayAdd));
            }
        }
        private List<string> classesAdd;
        public List<string> ClassesAdd
        {
            get
            {
                classesAdd = new List<string>();
                foreach (var c in Context.classes.Local.Where(c => c.WeekNumber == int.Parse(SelectedWeekNumberAdd)))
                {
                    classesAdd.Add(c.Time);
                }
                return classesAdd;
            }
        }
        private string selectedClassAdd;
        public string SelectedClassAdd
        {
            get { return selectedClassAdd; }
            set
            {
                this.selectedClassAdd = value;
                OnPropertyChanged(nameof(SelectedClassAdd));
            }
        }
        private List<string> subjectsAdd;
        public List<string> SubjectsAdd
        {
            get
            {
                subjectsAdd = new List<string>();
                foreach (var s in Context.subjects.Local)
                {
                    foreach (var t in s.Teachers)
                    {
                        if (t.Surname == Teacher.Surname)
                        {
                            subjectsAdd.Add(s.Name);
                        }
                    }
                }
                return subjectsAdd;
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
        private string selectedGroupAdd;
        public string SelectedGroupAdd
        {
            get { return selectedGroupAdd; }
            set
            {
                this.selectedGroupAdd = value;
                OnPropertyChanged(nameof(SelectedGroupAdd));
            }
        }
        public List<string> AuditoriumsAdd
        {
            get
            {
                return new List<string>() { "200-3a", "100-3a", "322-1", "110a-1" };
            }
        }
        private string selectedAuditoriumAdd;
        public string SelectedAuditoriumAdd
        {
            get { return selectedAuditoriumAdd; }
            set
            {
                this.selectedAuditoriumAdd = value;
                OnPropertyChanged(nameof(SelectedAuditoriumAdd));
            }
        }
        public ObservableCollection<ScheduleViewModel> MondayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Понедельник" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                MondayClasses = value;
                OnPropertyChanged(nameof(MondayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> TuesdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Вторник" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                TuesdayClasses = value;
                OnPropertyChanged(nameof(TuesdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> WednesdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Среда" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                WednesdayClasses = value;
                OnPropertyChanged(nameof(WednesdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> ThursdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Четверг" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                ThursdayClasses = value;
                OnPropertyChanged(nameof(ThursdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> FridayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Пятница" 
            && s.Class.WeekNumber == int.Parse(WeekNumber) && s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                FridayClasses = value;
                OnPropertyChanged(nameof(FridayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> SaturdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Суббота" && s.Class.WeekNumber == int.Parse(WeekNumber) &&
            s.Teacher.Surname == Teacher.Surname).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                SaturdayClasses = value;
                OnPropertyChanged(nameof(SaturdayClasses));
            }
        }
        public TimetableTeacherViewModel(Teacher teacher, Context context)
        {
            Teacher = teacher;
            Context = context;
            WeekNumber = "1";
            WeekNumbers = new List<string>() { "1", "2" };
            Context.schedules.Load();
            Context.classes.Load();
            Context.groups.Load();
            Context.subjects.Load();
            Context.weekdays.Load();
            SelectedWeekNumberAdd = "0";
            SelectedClassAdd = "";
            SelectedSubjectAdd = "";
            SelectedGroupAdd = "";
            SelectedAuditoriumAdd = "";
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
            Class @class = Context.classes.Local.Where(c => c.Time == SelectedClassAdd && c.WeekNumber == int.Parse(SelectedWeekNumberAdd)).FirstOrDefault();
            Group group = Context.groups.Local.Where(g => g.Name == SelectedGroupAdd).FirstOrDefault();
            Subject subject = Context.subjects.Local.Where(s => s.Name == SelectedSubjectAdd).FirstOrDefault();
            Teacher teacher = Context.teachers.Local.Where(t => t.Surname == Teacher.Surname).FirstOrDefault();
            Weekday weekday = Context.weekdays.Local.Where(w => w.Name == SelectedWeekdayAdd).FirstOrDefault();
            Schedule schedule = new Schedule() { Class = @class, Group = group, Subject = subject, Teacher = teacher, Weekday = weekday, Auditorium = SelectedAuditoriumAdd };
            Context.schedules.Local.Add(schedule);
            Context.SaveChanges();
            SelectedAuditoriumAdd = "";
            SelectedClassAdd = "";
            SelectedGroupAdd = "";
            SelectedSubjectAdd = "";
            SelectedWeekdayAdd = "";
        }
        private bool canAdd()
        {
            if (SelectedWeekdayAdd != "" && SelectedClassAdd != "" && SelectedGroupAdd != "" && SelectedAuditoriumAdd != "" && 
                !Context.schedules.Local.Contains(Context.schedules.Local.Where(s => s.Class.WeekNumber == int.Parse(SelectedWeekNumberAdd) && s.Weekday.Name == SelectedWeekdayAdd && 
                s.Class.Time == SelectedClassAdd && s.Subject.Name == SelectedSubjectAdd && s.Group.Name == SelectedGroupAdd && s.Auditorium == SelectedAuditoriumAdd).FirstOrDefault()) &&
                !Context.schedules.Local.Contains(Context.schedules.Local.Where(s => s.Class.WeekNumber == int.Parse(SelectedWeekNumberAdd) && s.Weekday.Name == SelectedWeekdayAdd &&
                s.Class.Time == SelectedClassAdd && s.Group.Name == SelectedGroupAdd).FirstOrDefault()))
                return true;
            else
                return false;
        }
    }
}

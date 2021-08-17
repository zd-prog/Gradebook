using Gradebook.Commands;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class TimetableViewModel : ViewModelBase
    {
        Context Context { get; set; } 
        public Group Group { get; set; }
        public List<string> WeekNumbers { get; set; }

        public ObservableCollection<ScheduleViewModel> MondayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Понедельник" && s.Class.WeekNumber == int.Parse(WeekNumber) && 
            s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                MondayClasses = value;
                OnPropertyChanged(nameof(MondayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> TuesdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Вторник" && s.Class.WeekNumber == int.Parse(WeekNumber) && 
            s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                TuesdayClasses = value;
                OnPropertyChanged(nameof(TuesdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> WednesdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Среда" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                WednesdayClasses = value;
                OnPropertyChanged(nameof(WednesdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> ThursdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Четверг" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                ThursdayClasses = value;
                OnPropertyChanged(nameof(ThursdayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> FridayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Пятница" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                FridayClasses = value;
                OnPropertyChanged(nameof(FridayClasses));
            }
        }
        public ObservableCollection<ScheduleViewModel> SaturdayClasses
        {
            get { return new ObservableCollection<ScheduleViewModel>(Context.schedules.Local.Where(s => s.Weekday.Name == "Суббота" && s.Class.WeekNumber == int.Parse(WeekNumber) 
            && s.Group.Name == Group.Name).OrderBy(c => c.Class_ID).Select(s => new ScheduleViewModel(s))); }
            set
            {
                SaturdayClasses = value;
                OnPropertyChanged(nameof(SaturdayClasses));
            }
        }
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
        public TimetableViewModel(Group group, Context context)
        {
            Context = context;
            WeekNumber = "1";
            Group = group;
            WeekNumbers = new List<string>() { "1", "2" };
            Context.schedules.Load();
        }
    }
}

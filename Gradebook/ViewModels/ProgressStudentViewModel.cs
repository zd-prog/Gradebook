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
using System.Windows;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class ProgressStudentViewModel : ViewModelBase
    {
        Context Context { get; set; }
        public Student Student { get; set; }
        public List<string> SubjectsRes { get; set; }
        private string selectedSubject;
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                this.selectedSubject = value;
                OnPropertyChanged(nameof(selectedSubject));
                OnPropertyChanged(nameof(labResultsList));
            }
        }
        public ObservableCollection<LabResult> labResults { get; set; }
        public ObservableCollection<LabResultViewModel> labResultsList
        {
            get { return new ObservableCollection<LabResultViewModel>(labResults.Where(t => t.Lab.Subject.Name == SelectedSubject && 
            t.Student.Surname == Student.Surname).Select(t => new LabResultViewModel(t))); }
            set
            {
                labResultsList = value;
                OnPropertyChanged(nameof(labResultsList));
            }
        }
        public ProgressStudentViewModel(Student student, Context context)
        {
            SelectedSubject = "";
            Context = context;
            SubjectsRes = new List<string>();
            Student = student;
            Context.groups.Load();
            Context.subjects.Load();
            Context.labResults.Load();
            SubjectType type = new SubjectType() { Subject_Type = "ЛР" }; 
            foreach (var s in Context.subjects.Local.Where(s => s.SubjectType.Subject_Type == type.Subject_Type))
            {
                foreach (var g in s.Groups)
                {
                    if (g.Name == Student.Group.Name)
                    {
                        SubjectsRes.Add(s.Name);
                    }
                }
            }
            labResults = Context.labResults.Local;

        }
    }
}

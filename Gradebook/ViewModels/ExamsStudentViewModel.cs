using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gradebook.ViewModels
{
    public class ExamsStudentViewModel
    {
        Context Context = new Context();
        public Student Student { get; set; }
        public ObservableCollection<ExamResultViewModel> examResultsList { get; set; }
        public ExamsStudentViewModel(Student student)
        {
            Context.groups.Load();
            Context.subjects.Load();
            Context.examResults.Load();
            Student = student;
            examResultsList = new ObservableCollection<ExamResultViewModel>();
            foreach (var e in Context.examResults.Local.Where(e => e.Student.Surname == Student.Surname).Select(e => new ExamResultViewModel(e)))
            {
                examResultsList.Add(e);
            }
        }
    }
}

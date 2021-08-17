using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class ExamResultViewModel : ViewModelBase
    {
        public ExamResult ExamResult;
        public ExamResultViewModel(ExamResult examResult)
        {
            this.ExamResult = examResult;
        }
        public Student Student
        {
            get { return ExamResult.Student; }
            set
            {
                ExamResult.Student = value;
                OnPropertyChanged("Student");
            }
        }
        public Exam Exam
        {
            get { return ExamResult.Exam; }
            set
            {
                ExamResult.Exam = value;
                OnPropertyChanged("Exam");
            }
        }
        public DateTime Date
        {
            get { return ExamResult.ExamDate; }
            set
            {
                ExamResult.ExamDate = value;
                OnPropertyChanged("Date");
            }
        }
        public int Mark
        {
            get { return ExamResult.ExamMark; }
            set
            {
                ExamResult.ExamMark = value;
                OnPropertyChanged("Mark");
            }
        }
    }
}

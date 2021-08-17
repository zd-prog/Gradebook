using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    class ExamViewModel : ViewModelBase
    {
        public Exam Exam;
        public ExamViewModel(Exam exam)
        {
            this.Exam = exam;
        }
        public Subject Subject
        {
            get { return Exam.Subject; }
            set
            {
                Exam.Subject = value;
                OnPropertyChanged("Exam");
            }
        }
        public Group Group
        {
            get { return Exam.Group; }
            set
            {
                Exam.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public Teacher Teacher
        {
            get { return Exam.Teacher; }
            set
            {
                Exam.Teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
        public DateTime Date
        {
            get { return Exam.ExamDate; }
            set
            {
                Exam.ExamDate = value;
                OnPropertyChanged("Date");
            }
        }
        public ICollection<ExamResult> ExamResults
        {
            get { return Exam.ExamResults; }
            set
            {
                Exam.ExamResults = value;
                OnPropertyChanged("ExamResults");
            }
        }
    }
}

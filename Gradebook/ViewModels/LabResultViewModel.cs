using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class LabResultViewModel : ViewModelBase
    {
        public LabResult LabResult;
        public LabResultViewModel(LabResult labResult)
        {
            this.LabResult = labResult;
        }
        public Student Student
        {
            get { return LabResult.Student; }
            set
            {
                LabResult.Student = value;
                OnPropertyChanged("Student");
            }
        }
        public Lab Lab
        {
            get { return LabResult.Lab; }
            set
            {
                LabResult.Lab = value;
                OnPropertyChanged("Lab");
            }
        }
        public DateTime Date
        {
            get { return LabResult.Date; }
            set
            {
                LabResult.Date = value;
                OnPropertyChanged("Date");
            }
        }
        public int Mark
        {
            get { return LabResult.Mark; }
            set
            {
                LabResult.Mark = value;
                OnPropertyChanged("Mark");
            }
        }
    }
}

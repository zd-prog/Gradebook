using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    class LabViewModel : ViewModelBase
    {
        public Lab Lab;
        public LabViewModel(Lab lab)
        {
            this.Lab = lab;
        }
        public string Name
        {
            get { return Lab.Name; }
            set
            {
                Lab.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public Teacher Teacher
        {
            get { return Lab.Teacher; }
            set 
            {
                Lab.Teacher = value;
                OnPropertyChanged("Teacher");
            }
        }
        public Group Group
        {
            get { return Lab.Group; }
            set
            {
                Lab.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public Subject Subject
        {
            get { return Lab.Subject; }
            set
            {
                Lab.Subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public ICollection<LabResult> LabResults
        {
            get { return Lab.LabResults; }
            set
            {
                Lab.LabResults = value;
                OnPropertyChanged("LabResults");
            }
        }
    }
}

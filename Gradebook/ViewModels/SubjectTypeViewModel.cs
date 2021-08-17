using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class SubjectTypeViewModel : ViewModelBase
    {
        public SubjectType SubjectType;
        public string Subject_Type
        {
            get { return SubjectType.Subject_Type; }
            set 
            {
                SubjectType.Subject_Type = value;
                OnPropertyChanged("Subject_Type");
            }
        }
        public SubjectTypeViewModel(SubjectType subjectType)
        {
            this.SubjectType = subjectType;
        }

    }
}

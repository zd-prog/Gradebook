using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class RegistrationTeachViewModel : ViewModelBase
    {
        public RegistrationTeach Registration;
        public string Surname
        {
            get { return Registration.Surname; }
            set
            {
                Registration.Surname = value;
                OnPropertyChanged("Surname");
            }
        }
        public string Login
        {
            get { return Registration.Login; }
            set
            {
                Registration.Login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return Registration.Password; }
            set
            {
                Registration.Password = value;
                OnPropertyChanged("Password");
            }
        }
        public Subject Subject
        {
            get { return Registration.Subject; }
            set
            {
                Registration.Subject = value;
                OnPropertyChanged("Subject");
            }
        }
        public RegistrationTeachViewModel(RegistrationTeach registration)
        {
            this.Registration = registration;
        }
    }
}

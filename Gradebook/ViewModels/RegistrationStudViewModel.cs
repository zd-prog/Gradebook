using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.ViewModels
{
    public class RegistrationStudViewModel : ViewModelBase
    {
        public RegistrationStud Registration;
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
        public Group Group
        {
            get { return Registration.Group; }
            set
            {
                Registration.Group = value;
                OnPropertyChanged("Group");
            }
        }
        public RegistrationStudViewModel(RegistrationStud registration)
        {
            this.Registration = registration;
        }
    }
}

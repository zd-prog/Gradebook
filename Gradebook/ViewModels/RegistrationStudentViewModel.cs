using Gradebook.Commands;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;
using Group = Gradebook.Models.Group;

namespace Gradebook.ViewModels
{
    public class RegistrationStudentViewModel : ViewModelBase
    {
        Context Context { get; set; }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                this.surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        private string group;
        public string Group
        {
            get { return group; }
            set
            {
                this.group = value;
                OnPropertyChanged(nameof(Group));
            }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                this.login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public UnityContainer Container { get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier passwordSupplier = Container.Resolve<IPasswordSupplier>();
                return passwordSupplier.GetPassword();
            }
        }
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                this.errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public ObservableCollection<GroupViewModel> GroupsList { get; set; }
        public ObservableCollection<StudentViewModel> StudentsList { get; set; }
        public ObservableCollection<string> GroupsNames
        {
            get
            {
                return new ObservableCollection<string>(Context.groups.Local.Select(g => g.Name));
            }
        }
        public ObservableCollection<RegistrationStudViewModel> RegistrationsList { get; set; }

        public RegistrationStudentViewModel(List<Group> groups, List<Student> students, List<RegistrationStud> registrations, Context context, IUnityContainer container)
        {
            GroupsList = new ObservableCollection<GroupViewModel>(groups.Select(g => new GroupViewModel(g)));
            StudentsList = new ObservableCollection<StudentViewModel>(students.Select(s => new StudentViewModel(s)));
            RegistrationsList = new ObservableCollection<RegistrationStudViewModel>(registrations.Select(r => new RegistrationStudViewModel(r)));
            Context = context;
            Surname = "";
            Login = "";
            Group = "";
            Container = (UnityContainer)container;
        }
        private DelegateCommand addStudentCommand;
        public ICommand AddStudentCommand
        {
            get
            {
                if (addStudentCommand == null)
                    addStudentCommand = new DelegateCommand(AddStudent);
                return addStudentCommand;
            }
        }
        private void AddStudent()
        {
            Regex regex = new Regex("[А-Я][а-я]+\\s[А-Я][а-я]+");
            Regex regex1 = new Regex("^(?=.{1,15}$)[a-zA-Z0-9]*[^$%^&*;:,<>?()\"']*$");
            if (Surname == "" || Login == "" || Password == "" || Group == "")
            {
                ErrorMessage = "Не все поля формы заполнены";
            }
            else
            {
                if (regex.IsMatch(Surname) == false)
                {
                    ErrorMessage = "Неправильный формат фамилии";
                }
                else
                {
                    if (regex1.IsMatch(Login) == false)
                    {
                        ErrorMessage = "Неправильный формат логина: не более 15 символов.";
                    }
                    else
                    {
                        if (Context.teachers.Local.Contains(Context.teachers.Local.Where(t => t.Login == Login).FirstOrDefault()) || 
                            Context.students.Local.Contains(Context.students.Local.Where(s => s.Login == Login).FirstOrDefault()))
                        {
                            ErrorMessage = "Пользователь с таким логином уже существует";
                        }
                        else
                        {
                            if (Context.registrationUsers.Local.Contains(Context.registrationUsers.Local.Where(u => u.Login == Login).FirstOrDefault()) ||
                                Context.registrationStudents.Local.Contains(Context.registrationStudents.Local.Where(u => u.Login == Login).FirstOrDefault()))
                            {
                                ErrorMessage = "Вы уже подали заявку, ожидайте добавления в систему.";
                            }
                            else
                            {
                                Models.Group groupStud = Context.groups.Local.Where(g => g.Name == Group).FirstOrDefault();
                                RegistrationStud registration = new RegistrationStud() { Surname = Surname, Login = Login, Password = Password, Group = groupStud };
                                RegistrationsList.Add(new RegistrationStudViewModel(registration));
                                Context.registrationStudents.Load();
                                Context.registrationStudents.Add(registration);
                                Context.SaveChanges();
                                ErrorMessage = "Ваша заявка принята и в ближайшее время будет \nобработана администратором журнала.";
                            }

                        }
                    }
                    
                }
                
            }
            
        }
    }
}

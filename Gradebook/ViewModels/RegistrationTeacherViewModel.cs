using Gradebook.Commands;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace Gradebook.ViewModels
{
    public class RegistrationTeacherViewModel : ViewModelBase
    {
        Context Context { get; set; }
        private string surname;
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
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
            set
            {
                Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string selectedSubject;
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                this.selectedSubject = value;
                OnPropertyChanged(nameof(SelectedSubject));
            }
        }
        public ObservableCollection<SubjectViewModel> SubjectsList { get; set; }
        public ObservableCollection<SubjectTypeViewModel> SubjectTypesList { get; set; }
        public ObservableCollection<TeacherViewModel> TeachersList { get; set; }
        public ObservableCollection<RegistrationTeachViewModel> RegistrationsList { get; set; }
        public ObservableCollection<string> Subjects
        {
            get
            {
                return new ObservableCollection<string>(Context.subjects.Local.Select(s => s.Name));
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
        public RegistrationTeacherViewModel(List<Subject> subjects, List<SubjectType> subjectTypes, List<Teacher> teachers, List<RegistrationTeach> registrations, Context context, 
            IUnityContainer container)
        {
            SubjectsList = new ObservableCollection<SubjectViewModel>(subjects.Select(sub => new SubjectViewModel(sub)));
            SubjectTypesList = new ObservableCollection<SubjectTypeViewModel>(subjectTypes.Select(su => new SubjectTypeViewModel(su)));
            TeachersList = new ObservableCollection<TeacherViewModel>(teachers.Select(t => new TeacherViewModel(t)));
            RegistrationsList = new ObservableCollection<RegistrationTeachViewModel>(registrations.Select(r => new RegistrationTeachViewModel(r)));
            Context = context;
            Surname = "";
            Login = "";
            Container = (UnityContainer)container;
        }


        private DelegateCommand addTeacherCommand;
        public ICommand AddTeacherCommand
        {
            get
            {
                if (addTeacherCommand == null)
                    addTeacherCommand = new DelegateCommand(AddTeacher);
                return addTeacherCommand;
            }
        }
        private void AddTeacher()
        {
            Regex regex = new Regex("[А-Я][а-я]+\\s[А-Я][а-я]+");
            Regex regex1 = new Regex("^(?=.{1,15}$)[a-zA-Z0-9]*[^$%^&*;:,<>?()\"']*$");
            if (Surname == "" || Login == "" || Password == "" || SelectedSubject == "")
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
                                Subject subject = Context.subjects.Local.Where(s => s.Name == SelectedSubject).FirstOrDefault();
                                RegistrationTeach registration = new RegistrationTeach { Surname = Surname, Login = Login, Password = Password, Subject = subject };
                                RegistrationTeachViewModel viewModel = new RegistrationTeachViewModel(registration);
                                RegistrationsList.Add(viewModel);
                                Context.registrationUsers.Load();
                                Context.registrationUsers.Add(registration);
                                Context.SaveChanges();
                                ErrorMessage = "Ваша заявка принята и в ближайшее время будет \nобработанa администратором журнала.";
                                Surname = "";
                                SelectedSubject = "";
                                Login = "";
                                Password = "";
                            }
                        }
                    }
                    
                }
                

            }
            
        }
    }
}

using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace Gradebook.ViewModels
{
    class AuthorizationViewModel : ViewModelBase
    {
        Authorization window { get; set; }
        Context Context { get; set; }
        public ObservableCollection<StudentViewModel> StudentsList { get; set; }
        public ObservableCollection<TeacherViewModel> TeachersList { get; set; }
        public UnityContainer Container { get; set; }
        public string Login { get; set; }
        public string Password
        {
            get
            {
                IPasswordSupplier passwordSupplier = Container.Resolve<IPasswordSupplier>();
                return passwordSupplier.GetPassword();
            }
        }
        private string message;
        public string Message 
        {
            get { return message; }
            set
            {
                this.message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
        public AuthorizationViewModel(List<Student> students, List<Teacher> teachers, IUnityContainer container, Context context, Authorization authorization)
        {
            StudentsList = new ObservableCollection<StudentViewModel>(students.Select(s => new StudentViewModel(s)));
            TeachersList = new ObservableCollection<TeacherViewModel>(teachers.Select(t => new TeacherViewModel(t)));
            Container = (UnityContainer)container;
            Context = context;
            window = authorization;
        }
        private DelegateCommand registerTeacherCommand;
        private DelegateCommand registerStudentCommand;
        private DelegateCommand logInCommand;
        public ICommand RegisterTeacherCommand
        {
            get
            {
                if (registerTeacherCommand == null)
                {
                    registerTeacherCommand = new DelegateCommand(RegisterTeacher);
                }
                return registerTeacherCommand;
            }
        }
        public ICommand RegisterStudentCommand
        {
            get
            {
                if (registerStudentCommand == null)
                {
                    registerStudentCommand = new DelegateCommand(RegisterStudent);
                }
                return registerStudentCommand;
            }
        }
        public ICommand LogInCommand
        {
            get
            {
                if (logInCommand == null)
                    logInCommand = new DelegateCommand(LogIn);
                return logInCommand;
            }

        }
        private void RegisterTeacher()
        {
            IUnityContainer container = new UnityContainer();
            Views.RegistrationTeacher registrationTeacherWindow = new Views.RegistrationTeacher();
            container.RegisterInstance<IPasswordSupplier>(registrationTeacherWindow);
            RegistrationTeacherViewModel viewModel = new RegistrationTeacherViewModel(Context.subjects.ToList(), Context.subjectTypes.ToList(), Context.teachers.ToList(), 
                Context.registrationUsers.ToList(), Context, container);
            registrationTeacherWindow.DataContext = viewModel;
            registrationTeacherWindow.Show();
            window.Hide();
            registrationTeacherWindow.Closing += RegistrationTeacherWindow_Closing;
        }

        private void RegistrationTeacherWindow_Closing(object sender, CancelEventArgs e)
        {
            window.Show();
        }

        private void RegisterStudent()
        {
            IUnityContainer container = new UnityContainer();
            RegistrationStudent registrationStudentWindow = new RegistrationStudent();
            container.RegisterInstance<IPasswordSupplier>(registrationStudentWindow);
            RegistrationStudentViewModel viewModel = new RegistrationStudentViewModel(Context.groups.ToList(), Context.students.ToList(), Context.registrationStudents.ToList(), Context, container);
            registrationStudentWindow.DataContext = viewModel;
            registrationStudentWindow.Show();
            window.Hide();
            registrationStudentWindow.Closing += RegistrationStudentWindow_Closing;
        }

        private void RegistrationStudentWindow_Closing(object sender, CancelEventArgs e)
        {
            window.Show();
        }

        private void LogIn()
        {
            if (Login == null || Password == "")
            {
                Message = "Чтобы войти необходимо ввести логин и пароль";
            }
            else
            {
                Teacher teacher = new Teacher();
                Student student = new Student();
                foreach (TeacherViewModel model in TeachersList)
                {
                    if (model.Login == Login && model.Password == Data.GetHash(Password))
                    {
                        teacher = model.Teacher;
                        TeacherGradebook gradebookWindow = new TeacherGradebook();
                        TeacherGradebookViewModel viewModel = new TeacherGradebookViewModel(teacher, gradebookWindow, Context);
                        gradebookWindow.DataContext = viewModel;
                        gradebookWindow.Show();
                        window.Close();
                    }
                }
                foreach (StudentViewModel studentView in StudentsList)
                {
                    if (studentView.Login == Login && studentView.Password == Data.GetHash(Password))
                    {
                        student = studentView.Student;
                        StudentGradebook studentGradebookWindow = new StudentGradebook();
                        StudentGradebookViewModel viewModel = new StudentGradebookViewModel(student, studentGradebookWindow, Context);
                        studentGradebookWindow.DataContext = viewModel;
                        studentGradebookWindow.Show();
                        window.Close();
                    }
                }
                foreach (TeacherViewModel teacherView in TeachersList)
                {
                    if (teacherView.Login == Login && teacherView.Password != Data.GetHash(Password))
                    {
                        Message = "Проверьте корректность введённого пароля";
                    }
                }
                foreach (StudentViewModel studentViewModel in StudentsList)
                {
                    if (studentViewModel.Login == Login && studentViewModel.Password != Data.GetHash(Password))
                    {
                        Message = "Проверьте корректность введённого пароля";
                    }
                }
                if (!Context.teachers.Local.Contains(Context.teachers.Local.Where(t => t.Login == Login).FirstOrDefault()) && 
                    !Context.students.Local.Contains(Context.students.Local.Where(t => t.Login == Login).FirstOrDefault()))
                {
                    Message = "Пользователя с таким логином не существует";
                }
                
            }            
        }
    }
}

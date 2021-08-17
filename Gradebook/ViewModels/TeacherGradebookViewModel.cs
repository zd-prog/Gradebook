using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Unity;

namespace Gradebook.ViewModels
{
    class TeacherGradebookViewModel
    {
        public bool Admin
        {
            get
            {
                return Teacher.Admin;
            }
        }
        public Context Context { get; set; }
        public Teacher Teacher { get; set; }
        public TeacherGradebook window { get; set; }

        public TeacherGradebookViewModel(Teacher teacher, TeacherGradebook teacherGradebook, Context context)
        {
            Context = context;
            Teacher = teacher;
            window = teacherGradebook;
            WelcomePage welcomePage = new WelcomePage();
            window.FramePage.Content = welcomePage;
        }
        private DelegateCommand labsCommand;
        private DelegateCommand testsCommand;
        private DelegateCommand examsCommand;
        private DelegateCommand timetableCommand;
        private DelegateCommand missingsCommand;
        private DelegateCommand usersCommand;
        private DelegateCommand exitCommand;
        public ICommand LabsCommand
        {
            get
            {
                if (labsCommand == null)
                    labsCommand = new DelegateCommand(Labs);
                return labsCommand;
            }
        }
        public ICommand TestsCommand
        {
            get
            {
                if (testsCommand == null)
                    testsCommand = new DelegateCommand(Tests);
                return testsCommand;
            }
        }
        public ICommand ExamsCommand
        {
            get
            {
                if (examsCommand == null)
                    examsCommand = new DelegateCommand(Exams);
                return examsCommand;
            }
        }
        public ICommand TimetableCommand
        {
            get
            {
                if (timetableCommand == null)
                    timetableCommand = new DelegateCommand(Timetable);
                return timetableCommand;
            }
        }
        public ICommand MissingsCommand
        {
            get
            {
                if (missingsCommand == null)
                    missingsCommand = new DelegateCommand(Missings);
                return missingsCommand;
            }
        }
        public ICommand UsersCommand
        {
            get
            {
                if (usersCommand == null)
                    usersCommand = new DelegateCommand(Users);
                return usersCommand;
            }
        }
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                    exitCommand = new DelegateCommand(Exit);
                return exitCommand;
            }
        }
        private void Labs()
        {
            LabsTeacher labsWindow = new LabsTeacher();
            LabsTeacherViewModel viewModel = new LabsTeacherViewModel(Teacher, Context);
            labsWindow.DataContext = viewModel;
            window.FramePage.Content = labsWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Tests()
        {
            ControlsTeacher controlsWindow = new ControlsTeacher();
            ControlsTeacherViewModel viewModel = new ControlsTeacherViewModel(Teacher, Context);
            controlsWindow.DataContext = viewModel;
            window.FramePage.Content = controlsWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Exams()
        {
            ExamsTeacher examsWindow = new ExamsTeacher();
            ExamsTeacherViewModel viewModel = new ExamsTeacherViewModel(Teacher, Context);
            examsWindow.DataContext = viewModel;
            window.FramePage.Content = examsWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Timetable()
        {
            TimetableTeacher timetableWindow = new TimetableTeacher();
            TimetableTeacherViewModel viewModel = new TimetableTeacherViewModel(Teacher, Context);
            timetableWindow.DataContext = viewModel;
            window.FramePage.Content = timetableWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Missings()
        {
            MissingsTeacher missingsWindow = new MissingsTeacher();
            MissingsTeacherViewModel viewModel = new MissingsTeacherViewModel(Teacher, Context);
            missingsWindow.DataContext = viewModel;
            window.FramePage.Content = missingsWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Users()
        {
            UsersTeacher usersWindow = new UsersTeacher();
            UsersTeacherViewModel viewModel = new UsersTeacherViewModel(Context);
            usersWindow.DataContext = viewModel;
            window.FramePage.Content = usersWindow;
            window.FramePage.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
        }
        private void Exit()
        {
            Authorization authorizationWindow = new Authorization();
            IUnityContainer container = new UnityContainer();
            container.RegisterInstance<IPasswordSupplier>(authorizationWindow);
            AuthorizationViewModel viewModel = new AuthorizationViewModel(Context.students.Local.ToList(), Context.teachers.Local.ToList(), container, Context, authorizationWindow);
            authorizationWindow.DataContext = viewModel;
            authorizationWindow.Show();
            window.Close();
        }
    }
}

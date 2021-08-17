using Gradebook.Commands;
using Gradebook.Models;
using Gradebook.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Unity;

namespace Gradebook.ViewModels
{
    public class StudentGradebookViewModel
    {
        Context Context { get; set; }
        public Student Student { get; set; }
        public StudentGradebook window { get; set; }

        public StudentGradebookViewModel(Student student, StudentGradebook studentGradebook, Context context)
        {
            Student = student;
            window = studentGradebook;
            WelcomePageStudent welcomePage = new WelcomePageStudent();
            WelcomePageStudentViewModel viewModel = new WelcomePageStudentViewModel(Student);
            welcomePage.DataContext = viewModel;
            window.FramePage.Content = welcomePage;
            Context = context;
        }
        private DelegateCommand progressCommand;
        private DelegateCommand controlsCommand;
        private DelegateCommand examsCommand;
        private DelegateCommand timetableCommand;
        private DelegateCommand exitCommand;
        public ICommand ProgressCommand
        {
            get
            {
                if (progressCommand == null)
                    progressCommand = new DelegateCommand(Progress);
                return progressCommand;
            }
        }
        public ICommand ControlsCommand
        {
            get
            {
                if (controlsCommand == null)
                    controlsCommand = new DelegateCommand(Control);
                return controlsCommand;
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
        public ICommand ExitCommand
        {
            get
            {
                if (exitCommand == null)
                    exitCommand = new DelegateCommand(Exit);
                return exitCommand;
            }
        }
        private void Progress()
        {
            ProgressStudent progressPage = new ProgressStudent();
            ProgressStudentViewModel viewModel = new ProgressStudentViewModel(Student, Context);
            progressPage.DataContext = viewModel;
            window.FramePage.Content = progressPage;
            window.FramePage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        private void Control()
        {
            ControlsStudent controlsPage = new ControlsStudent();
            ControlsStudentViewModel viewModel = new ControlsStudentViewModel(Student, Context);
            controlsPage.DataContext = viewModel;
            window.FramePage.Content = controlsPage;
            window.FramePage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        private void Exams()
        {
            ExamsStudent examsPage = new ExamsStudent();
            ExamsStudentViewModel viewModel = new ExamsStudentViewModel(Student);
            examsPage.DataContext = viewModel;
            window.FramePage.Content = examsPage;
            window.FramePage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }
        private void Timetable()
        {
            Timetable tablePage = new Timetable();
            TimetableViewModel viewModel = new TimetableViewModel(Student.Group, Context);
            tablePage.DataContext = viewModel;
            window.FramePage.Content = tablePage;
            window.FramePage.NavigationUIVisibility = NavigationUIVisibility.Hidden;
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

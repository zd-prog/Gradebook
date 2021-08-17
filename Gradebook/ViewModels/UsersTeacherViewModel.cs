using Gradebook.Commands;
using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Gradebook.ViewModels
{
    public class UsersTeacherViewModel : ViewModelBase
    {
        Context Context { get; set; }
        public ObservableCollection<RegistrationTeach> TeachersList
        {
            get
            {
                return new ObservableCollection<RegistrationTeach>(Context.registrationUsers.Local);
            }
        }
        private RegistrationTeach selectedTeacher;
        public RegistrationTeach SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                this.selectedTeacher = value;
                OnPropertyChanged(nameof(SelectedTeacher));
            }
        }
        public ObservableCollection<RegistrationStud> StudentsList
        {
            get
            {
                return new ObservableCollection<RegistrationStud>(Context.registrationStudents.Local);
            }
        }
        private RegistrationStud selectedStudent;
        public RegistrationStud SelectedStudent
        {
            get
            {
                return selectedStudent;
            }
            set
            {
                this.selectedStudent = value;
                OnPropertyChanged(nameof(SelectedStudent));
            }
        }
        public UsersTeacherViewModel(Context context)
        {
            Context = context;
            Context.registrationUsers.Load();
        }
        private DelegateCommand addTeacher;
        private DelegateCommand addStudent;
        private DelegateCommand deleteTeacher;
        private DelegateCommand deleteStudent;
        public ICommand AddTeacher
        {
            get
            {
                if (addTeacher == null)
                    addTeacher = new DelegateCommand(AddTeach);
                return addTeacher;
            }
        }
        public ICommand AddStudent
        {
            get
            {
                if (addStudent == null)
                    addStudent = new DelegateCommand(AddStud);
                return addStudent;
            }
        }
        public ICommand DeleteTeacher
        {
            get
            {
                if (deleteTeacher == null)
                    deleteTeacher = new DelegateCommand(DeleteTeach);
                return deleteTeacher;
            }
        }
        public ICommand DeleteStudent
        {
            get
            {
                if (deleteStudent == null)
                    deleteStudent = new DelegateCommand(DeleteStud);
                return deleteStudent;
            }
        }
        private void AddTeach()
        {
            Teacher teacher = new Teacher() { Admin = false, Password = Data.GetHash(SelectedTeacher.Password), Login = SelectedTeacher.Login, Surname = SelectedTeacher.Surname };
            teacher.Subjects.Add(SelectedTeacher.Subject);
            Context.teachers.Local.Add(teacher);
            Context.registrationUsers.Local.Remove(SelectedTeacher);
            Context.SaveChanges();
            OnPropertyChanged(nameof(TeachersList));
        }
        private void AddStud()
        {
            Student student = new Student() { Group = SelectedStudent.Group, Login = SelectedStudent.Login, Password = Data.GetHash(SelectedStudent.Password), Surname = SelectedStudent.Surname };
            Context.students.Local.Add(student);
            Context.registrationStudents.Local.Remove(SelectedStudent);
            Context.SaveChanges();
            OnPropertyChanged(nameof(StudentsList));
        }
        private void DeleteTeach()
        {
            Context.registrationUsers.Local.Remove(SelectedTeacher);
            Context.SaveChanges();
            OnPropertyChanged(nameof(TeachersList));
        }
        private void DeleteStud()
        {
            Context.registrationStudents.Local.Remove(SelectedStudent);
            Context.SaveChanges();
            OnPropertyChanged(nameof(StudentsList));
        }
    }
}

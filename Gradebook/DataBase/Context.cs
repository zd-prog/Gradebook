using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook
{
    public class Context : DbContext
    {
        public Context() : base("Gradebook")
        {

        }
        static Context()
        {
            Database.SetInitializer<Context>(new MyContextInitializer());
        }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<SubjectType> subjectTypes { get; set; }
        public DbSet<RegistrationTeach> registrationUsers { get; set; }
        public DbSet<RegistrationStud> registrationStudents { get; set; }
        public DbSet<LabResult> labResults { get; set; }
        public DbSet<TestResult> testResults { get; set; }
        public DbSet<ExamResult> examResults { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<Exam> exams { get; set; }
        public DbSet<Lab> labs { get; set; }
        public DbSet<Weekday> weekdays { get; set; }
        public DbSet<Class> classes { get; set; }
        public DbSet<TestType> testTypes { get; set; }
        public DbSet<Missing> missings { get; set; }
        public DbSet<Schedule> schedules { get; set; }
    }
}

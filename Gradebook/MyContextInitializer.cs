using Gradebook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Gradebook
{
    class MyContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            Class FirstO = new Class() { ClassNumber = 1, WeekNumber = 1, Time = "08:00 - 09:35" };
            Class SecondO = new Class() { ClassNumber = 2, WeekNumber = 1, Time = "09:50 - 11:25" };
            Class ThirdO = new Class() { ClassNumber = 3, WeekNumber = 1, Time = "11:40 - 13:15" };
            Class FourthO = new Class() { ClassNumber = 4, WeekNumber = 1, Time = "13:50 - 15:25" };
            Class FifthO = new Class() { ClassNumber = 5, WeekNumber = 1, Time = "15:40 - 17:15" };
            Class SixthO = new Class() { ClassNumber = 6, WeekNumber = 1, Time = "17:30 - 19:05" };
            Class SeventO = new Class() { ClassNumber = 7, WeekNumber = 1, Time = "19:20 - 20:55" };
            Class FirstT = new Class() { ClassNumber = 1, WeekNumber = 2, Time = "08:00 - 09:35" };
            Class SecondT = new Class() { ClassNumber = 2, WeekNumber = 2, Time = "09:50 - 11:25" };
            Class ThirdT = new Class() { ClassNumber = 3, WeekNumber = 2, Time = "11:40 - 13:15" };
            Class FourthT = new Class() { ClassNumber = 4, WeekNumber = 2, Time = "13:50 - 15:25" };
            Class FifthT = new Class() { ClassNumber = 5, WeekNumber = 2, Time = "15:40 - 17:15" };
            Class SixthT = new Class() { ClassNumber = 6, WeekNumber = 2, Time = "17:30 - 19:05" };
            Class SeventT = new Class() { ClassNumber = 7, WeekNumber = 2, Time = "19:20 - 20:55" };
            context.classes.Add(FirstO);
            context.classes.Add(SecondO);
            context.classes.Add(ThirdO);
            context.classes.Add(FourthO);
            context.classes.Add(FifthO);
            context.classes.Add(SixthO);
            context.classes.Add(SeventO);
            context.classes.Add(FirstT);
            context.classes.Add(SecondT);
            context.classes.Add(ThirdT);
            context.classes.Add(FourthT);
            context.classes.Add(FifthT);
            context.classes.Add(SixthT);
            context.classes.Add(SeventT);

            Group group = new Group() { Name = "2-8" };
            context.groups.Add(group);

            Student studentZiziko = new Student() { Surname = "Зизико Дарья", Group = group, Login = "zizikod", Password = Data.GetHash("zizikod6") };
            Student studentBlinov = new Student() { Surname = "Блинов Антон", Group = group, Login = "blinovA", Password = Data.GetHash("blinovA") };
            context.students.Add(studentZiziko);
            context.students.Add(studentBlinov);
            group.Students.Add(studentBlinov);
            group.Students.Add(studentZiziko);

            SubjectType type1 = new SubjectType() { Subject_Type = "ЛК" };
            SubjectType type2 = new SubjectType() { Subject_Type = "ЛР" };
            SubjectType type3 = new SubjectType() { Subject_Type = "ПЗ" };
            context.subjectTypes.Add(type1);
            context.subjectTypes.Add(type2);
            context.subjectTypes.Add(type3);

            Teacher teacher = new Teacher() { Surname = "Нистюк О.А.", Admin = false, Login = "nistyuk", Password = Data.GetHash("nistyuk") };
            context.teachers.Add(teacher);
            Teacher admin = new Teacher() { Surname = "Admin", Admin = true, Login = "admin", Password = Data.GetHash("admin") };
            context.teachers.Add(admin);


            Subject subject = new Subject() { Name = "Базы данных ЛР", SubjectType = type2, Amount_Hours = 32 };
            Subject subject1 = new Subject() { Name = "Базы данных ЛК", SubjectType = type1, Amount_Hours = 32 };
            subject.Groups.Add(group);
            subject.Groups.Add(group);
            context.subjects.Add(subject);
            context.subjects.Add(subject1);
            group.Subjects.Add(subject);
            group.Subjects.Add(subject1);
            teacher.Subjects.Add(subject);
            teacher.Subjects.Add(subject1);
            admin.Subjects.Add(subject1);

            Exam exam1 = new Exam() { Group = group, Teacher = teacher, Subject = subject1, ExamDate = DateTime.Parse("07.06.2021") };
            context.exams.Add(exam1);
            teacher.Exams.Add(exam1);

            ExamResult examResult = new ExamResult() { Exam = exam1, ExamDate = DateTime.Parse("07.06.2021"), Student = studentZiziko, ExamMark = 8 };
            context.examResults.Add(examResult);
            exam1.ExamResults.Add(examResult);
            studentZiziko.ExamResults.Add(examResult);

            TestType testType1 = new TestType() { Test_Type = "Контрольная работа" };
            TestType testType2 = new TestType() { Test_Type = "Коллоквиум" };
            context.testTypes.Add(testType1);
            context.testTypes.Add(testType2);

            Test test = new Test() { Group = group, Name = "Коллоквиум", Subject = subject1, Teacher = teacher, TestDate = DateTime.Parse("18.05.2021"), TestType = testType2 };
            context.tests.Add(test);
            group.Tests.Add(test);
            teacher.Tests.Add(test);

            TestResult testResult = new TestResult() { Student = studentZiziko, Test = test, TestMark = 8 };
            context.testResults.Add(testResult);
            test.TestResults.Add(testResult);
            studentZiziko.TestResults.Add(testResult);

            Weekday weekday1 = new Weekday() { Name = "Понедельник" };
            Weekday weekday2 = new Weekday() { Name = "Вторник" };
            Weekday weekday3 = new Weekday() { Name = "Среда" };
            Weekday weekday4 = new Weekday() { Name = "Четверг" };
            Weekday weekday5 = new Weekday() { Name = "Пятница" };
            Weekday weekday6 = new Weekday() { Name = "Суббота" };
            context.weekdays.Add(weekday1);
            context.weekdays.Add(weekday2);
            context.weekdays.Add(weekday3);
            context.weekdays.Add(weekday4);
            context.weekdays.Add(weekday5);
            context.weekdays.Add(weekday6);

            Lab lab = new Lab() { Group = group, Name = "Процедуры", Subject = subject, Teacher = teacher };
            context.labs.Add(lab);
            group.Labs.Add(lab);
            subject.Labs.Add(lab);
            teacher.Labs.Add(lab);

            LabResult labResult = new LabResult() { Lab = lab, Student = studentZiziko, Date = DateTime.Parse("06.05.2021"), Mark = 8 };
            context.labResults.Add(labResult);
            lab.LabResults.Add(labResult);
            studentZiziko.LabResults.Add(labResult);

            Missing missing = new Missing() { Group = group, Student = studentZiziko, Subject = subject, Teacher = teacher, Date = DateTime.Parse("29.04.2021") };
            context.missings.Add(missing);
            studentZiziko.Missings.Add(missing);
            group.Missings.Add(missing);
            studentZiziko.Missings.Add(missing);
            subject.Missings.Add(missing);
            teacher.Missings.Add(missing);

            Schedule schedule = new Schedule() { Class = FourthT, Group = group, Subject = subject, Teacher = teacher, Weekday = weekday2, Auditorium = "309-1" };
            Schedule schedule1 = new Schedule() { Class = FourthO, Group = group, Subject = subject, Teacher = teacher, Weekday = weekday2, Auditorium = "309-1" };
            context.schedules.Add(schedule);
            FourthT.Schedules.Add(schedule);
            group.Schedules.Add(schedule);
            subject.Schedules.Add(schedule);
            teacher.Schedules.Add(schedule);

            context.schedules.Add(schedule1);
            FourthT.Schedules.Add(schedule1);
            group.Schedules.Add(schedule1);
            subject.Schedules.Add(schedule1);
            teacher.Schedules.Add(schedule1);


            subject.Teachers.Add(teacher);
            subject.Tests.Add(test);

            context.SaveChanges();
        }
    }
}

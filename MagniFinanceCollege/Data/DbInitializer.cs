/**
 * 
 * Popular Database with Static Data
 * 
 */

using MagniFinanceCollege.Models;
using System;
using System.Linq;

namespace MagniFinanceCollege.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CollegeContext context)
        {
            context.Database.EnsureCreated();

            // Find for any course in database.
            if (context.Courses.Any())
            {
                return;
            }

            // seed Course Table
            var courses = new Course[]
           {
            new Course{CourseID=1,CourseName="Chemistry"},
            new Course{CourseID=2,CourseName="Microeconomics"},
            new Course{CourseID=3,CourseName="Macroeconomics"},
            new Course{CourseID=4,CourseName="Calculus"},
            new Course{CourseID=5,CourseName="Trigonometry"},
            new Course{CourseID=6,CourseName="Composition"},
            new Course{CourseID=7,CourseName="Literature"}
           };
            foreach (Course course in courses)
            {
                context.Courses.Add(course);
            }
            context.SaveChanges();

            // seed Teacher Table
            var teachers = new Teacher[]
            {
            new Teacher{TeacherID=1,TeacherName="Dr. Carson Alexander",TeacherBirthday=DateTime.Parse("2005-09-01"),Salary=120.23},
            new Teacher{TeacherID=2,TeacherName="Dr. Meredith Alonso",TeacherBirthday=DateTime.Parse("2002-11-18"),Salary=125.23},
            new Teacher{TeacherID=3,TeacherName="Mr. Arturo Anand",TeacherBirthday=DateTime.Parse("2003-02-8"),Salary=119.02},
            new Teacher{TeacherID=4,TeacherName="Dr. Gytis Barzdukas",TeacherBirthday=DateTime.Parse("2002-09-10"),Salary=127.23},
            new Teacher{TeacherID=5,TeacherName="Dr. Yan Li",TeacherBirthday=DateTime.Parse("2002-07-21"),Salary=100.2},
            new Teacher{TeacherID=6,TeacherName="Sir. Peggy Justice",TeacherBirthday=DateTime.Parse("2001-03-27"),Salary=99.6},
            new Teacher{TeacherID=7,TeacherName="Ms. Laura Norman",TeacherBirthday=DateTime.Parse("2003-09-21"),Salary=132.35},
            new Teacher{TeacherID=8,TeacherName="Mr. Nino Olivetto",TeacherBirthday=DateTime.Parse("2005-04-12"),Salary=192.4}
            };
            foreach (Teacher teacher in teachers)
            {
                context.Teachers.Add(teacher);
            }
            context.SaveChanges();

            // seed Subject Table
            var subjects = new Subject[]
            {
                new Subject{SubjectID=1,SubjectName="Geography",TeacherID=1,CourseID=1},
                new Subject{SubjectID=2,SubjectName="Geography",TeacherID=1,CourseID=2},
                new Subject{SubjectID=3,SubjectName="Geography II",TeacherID=1,CourseID=3},
                new Subject{SubjectID=4,SubjectName="Literacy",TeacherID=2,CourseID=4},
                new Subject{SubjectID=5,SubjectName="Literacy",TeacherID=2,CourseID=1},
                new Subject{SubjectID=6,SubjectName="Arithmetic",TeacherID=3,CourseID=2},
                new Subject{SubjectID=7,SubjectName="Arithmetic",TeacherID=4,CourseID=3},
                new Subject{SubjectID=8,SubjectName="Biology",TeacherID=5,CourseID=4},
                new Subject{SubjectID=9,SubjectName="Citizenship",TeacherID=6,CourseID=1},
                new Subject{SubjectID=10,SubjectName="Drama",TeacherID=7,CourseID=1},
                new Subject{SubjectID=11,SubjectName="Information Technology",TeacherID=8,CourseID=3},
                new Subject{SubjectID=12,SubjectName="Information Technology",TeacherID=8,CourseID=7}
            };
            foreach (Subject subject in subjects)
            {
                context.Subjects.Add(subject);
            }
            context.SaveChanges();

            // seed Student Table
            var students = new Student[]
                {
            new Student{StudentID=1,StudentName="Justice Laura",StudentBirthday=DateTime.Parse("2005-03-07"),RegisterNumber=20211024},
            new Student{StudentID=2,StudentName="Norman Alonso",StudentBirthday=DateTime.Parse("2004-02-15"),RegisterNumber=20212355},
            new Student{StudentID=3,StudentName="Arturo Nino",StudentBirthday=DateTime.Parse("2003-11-21"),RegisterNumber=202130492},
            new Student{StudentID=4,StudentName="Barzdukas Barzdukas",StudentBirthday=DateTime.Parse("2002-09-30"),RegisterNumber=20201253},
            new Student{StudentID=5,StudentName="Yan Li",StudentBirthday=DateTime.Parse("2001-12-23"),RegisterNumber=20191242},
            new Student{StudentID=6,StudentName="Olivetto Justice",StudentBirthday=DateTime.Parse("2002-03-19"),RegisterNumber=20121452},
            new Student{StudentID=7,StudentName="Carla Junior",StudentBirthday=DateTime.Parse("2003-06-03"),RegisterNumber=20201245},
            new Student{StudentID=8,StudentName="Flavio Olivetto",StudentBirthday=DateTime.Parse("2005-09-02"),RegisterNumber=20201423}
                };
            foreach (Student student in students)
            {
                context.Students.Add(student);
            }
            context.SaveChanges();

            // sedd Enrollment Table
            var enrollments = new Enrollment[]
            {
            new Enrollment{EnrollmentID=1,StudentID=1,CourseID=1},
            new Enrollment{EnrollmentID=2,StudentID=2,CourseID=2},
            new Enrollment{EnrollmentID=3,StudentID=3,CourseID=3},
            new Enrollment{EnrollmentID=4,StudentID=4,CourseID=4},
            new Enrollment{EnrollmentID=5,StudentID=5,CourseID=5},
            new Enrollment{EnrollmentID=6,StudentID=6,CourseID=6},
            new Enrollment{EnrollmentID=7,StudentID=7,CourseID=7},
            new Enrollment{EnrollmentID=8,StudentID=8,CourseID=4},
            new Enrollment{EnrollmentID=9,StudentID=2,CourseID=1},
            new Enrollment{EnrollmentID=10,StudentID=3,CourseID=2},
            new Enrollment{EnrollmentID=11,StudentID=4,CourseID=3},
            new Enrollment{EnrollmentID=12,StudentID=5,CourseID=4},
            };
            foreach (Enrollment enrollment in enrollments)
            {
                context.Enrollments.Add(enrollment);
            }
            context.SaveChanges();

            // seed Enrollment_Subject Table
            var enrollment_subjects = new Enrollment_Subject[]
            {
            new Enrollment_Subject{EnrollmentID=1,SubjectID=1,Grade=Grade.A},
            new Enrollment_Subject{EnrollmentID=1,SubjectID=5,Grade=Grade.C},
            new Enrollment_Subject{EnrollmentID=1,SubjectID=9,Grade=Grade.B},
            new Enrollment_Subject{EnrollmentID=1,SubjectID=10,Grade=Grade.B},
            new Enrollment_Subject{EnrollmentID=2,SubjectID=2,Grade=Grade.F},
            new Enrollment_Subject{EnrollmentID=2,SubjectID=6,Grade=Grade.F},
            new Enrollment_Subject{EnrollmentID=3,SubjectID=3},
            new Enrollment_Subject{EnrollmentID=3,SubjectID=7},
            new Enrollment_Subject{EnrollmentID=3,SubjectID=11},
            new Enrollment_Subject{EnrollmentID=4,SubjectID=4,Grade=Grade.F},
            new Enrollment_Subject{EnrollmentID=7,SubjectID=12,Grade=Grade.A},
            };
            foreach (Enrollment_Subject enrollment_subject in enrollment_subjects)
            {
                context.Enrollment_Subjects.Add(enrollment_subject);
            }
            context.SaveChanges();
        }
    }
}
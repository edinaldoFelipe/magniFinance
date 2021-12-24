/**
 * 
 * All dinamics connection are commenteds
 * because connection with database is fail
 * And need add CollegeContext at class
 * 
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MagniFinanceCollege.Hubs
{
    public class Subjects:Hub
    {
        // private CollegeContext context;

        // Static Data to test
        private object[] staticData()
        {
            return new[]
            {
                new {SubjectID=1,SubjectName="Geography",TeacherName="Dr. Carson Alexander",CourseName="Microeconomics",amountStudents=25},
                new {SubjectID=2,SubjectName="Literacy",TeacherName="Sir. Peggy Justice",CourseName="Chemistry",amountStudents=56},
                new {SubjectID=3,SubjectName="Arithmetic",TeacherName="Sir. Peggy Justice",CourseName="Trigonometry",amountStudents=23},
                new {SubjectID=4,SubjectName="Biology",TeacherName="Dr. Carson Alexander",CourseName="Microeconomics",amountStudents=44},
                new {SubjectID=5,SubjectName="Citizenship",TeacherName="Dr. Meredith Alonso",CourseName="Composition",amountStudents=26},
                new {SubjectID=6,SubjectName="Information Technology",TeacherName="Ms. Laura Norman",CourseName="Literature",amountStudents=35},
                new {SubjectID=7,SubjectName="Drama",TeacherName="Mr. Nino Olivetto",CourseName="Calculus",amountStudents=23}
            };
        }

        public async Task Index(string data = null)
        {
            //object[] response = context.Subjects.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseSubjects", response);
        }

        public async Task Store(string data = null)
        {
            //context.Database.EnsureCreated();
            //context.Subjects.Add(new Subject { SubjectName = data});                

            await Clients.All.SendAsync("responseSubjects", true /*context.SaveChanges()*/);
        }

        public async Task Destroy(string id = null)
        {
            //Subject curse = new Subject() { SubjectId = id };
            //context.Customers.Attach(curse);
            //context.Customers.Remove(curse);
            //context.SaveChanges();
            //object[] response = context.Subjects.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseSubjects", response);
        }

        public async Task Update(object data = null)
        {
            //var subject = context.Subjects.Find(data.id);
            //Subject.SubjectName = data.name;
            //context.Entry(subject).State = EntityState.Modified;

            await Clients.All.SendAsync("responseSubjects", true /*context.SaveChanges()*/);
        }
    }
}
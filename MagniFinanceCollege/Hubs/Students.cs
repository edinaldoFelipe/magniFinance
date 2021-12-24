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
    public class Students:Hub
    {
        // private CollegeContext context;

        // Static Data to test
        private object[] staticData()
        {
            return new[]
            {
            new {StudentID=1,StudentName="Justice Laura",StudentBirthday="2005-03-07",RegisterNumber=20211024},
            new {StudentID=2,StudentName="Norman Alonso",StudentBirthday="2004-02-15",RegisterNumber=20212355},
            new {StudentID=3,StudentName="Arturo Nino",StudentBirthday="2003-11-21",RegisterNumber=202130492},
            new {StudentID=4,StudentName="Barzdukas Barzdukas",StudentBirthday="2002-09-30",RegisterNumber=20201253},
            new {StudentID=5,StudentName="Yan Li",StudentBirthday="2001-12-23",RegisterNumber=20191242},
            new {StudentID=6,StudentName="Olivetto Justice",StudentBirthday="2002-03-19",RegisterNumber=20121452},
            new {StudentID=7,StudentName="Carla Junior",StudentBirthday="2003-06-03",RegisterNumber=20201245},
            new {StudentID=8,StudentName="Flavio Olivetto",StudentBirthday="2005-09-02",RegisterNumber=20201423}
            };
        }

        public async Task Index(string data = null)
        {
            //object[] response = context.Students.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseStudents", response);
        }

        public async Task Store(string data = null)
        {
            //context.Database.EnsureCreated();
            //context.Students.Add(new Student { StudentName = data});                

            await Clients.All.SendAsync("responseStudents", true /*context.SaveChanges()*/);
        }

        public async Task Destroy(string id = null)
        {
            //Student curse = new Student() { StudentId = id };
            //context.Customers.Attach(curse);
            //context.Customers.Remove(curse);
            //context.SaveChanges();
            //object[] response = context.Students.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseStudents", response);
        }

        public async Task Update(object data = null)
        {
            //var student = context.Students.Find(data.id);
            //Student.StudentName = data.name;
            //context.Entry(student).State = EntityState.Modified;

            await Clients.All.SendAsync("responseStudents", true /*context.SaveChanges()*/);
        }
    }
}
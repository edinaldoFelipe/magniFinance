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
    public class Teachers : Hub
    {
        // private CollegeContext context;

        // Static Data to test
        private object[] staticData()
        {
            return new[]
            {
                new {TeacherID=1,TeacherName="Dr. Carson Alexander",TeacherBirthday="2005-09-01",Salary=120.23,AmountSubjects=1},
                new {TeacherID=2,TeacherName="Mr. Arturo Anand",TeacherBirthday="2002-11-18",Salary=125.23,AmountSubjects=2},
                new {TeacherID=3,TeacherName="Dr. Gytis Barzdukas",TeacherBirthday="2003-02-08",Salary=119.02,AmountSubjects=3},
                new {TeacherID=4,TeacherName="Dr. Yan Li",TeacherBirthday="2002-07-21",Salary=127.23,AmountSubjects=2},
                new {TeacherID=5,TeacherName="Sir. Peggy Justice",TeacherBirthday="2001-03-27",Salary=100.2,AmountSubjects=2},
                new {TeacherID=6,TeacherName="Ms. Laura Norman",TeacherBirthday="2003-09-21",Salary=132.35,AmountSubjects=1},
                new {TeacherID=7,TeacherName="Dr. Meredith Alonso",TeacherBirthday="2005-04-12",Salary=192.4,AmountSubjects=1}
            };
        }

        public async Task Index(string data = null)
        {
            //object[] response = context.Teachers.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseTeachers", response);
        }

        public async Task Store(string data = null)
        {
            //context.Database.EnsureCreated();
            //context.Teachers.Add(new Teacher { TeacherName = data});                

            await Clients.All.SendAsync("responseTeachers", true /*context.SaveChanges()*/);
        }

        public async Task Destroy(string id = null)
        {
            //Teacher curse = new Teacher() { TeacherId = id };
            //context.Customers.Attach(curse);
            //context.Customers.Remove(curse);
            //context.SaveChanges();
            //object[] response = context.Teachers.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseTeachers", response);
        }

        public async Task Update(object data = null)
        {
            //var teacher = context.Teachers.Find(data.id);
            //Teacher.TeacherName = data.name;
            //context.Entry(teacher).State = EntityState.Modified;

            await Clients.All.SendAsync("responseTeachers", true /*context.SaveChanges()*/);
        }
    }
}
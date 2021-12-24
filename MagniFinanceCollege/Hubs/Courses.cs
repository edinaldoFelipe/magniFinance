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
    public class Courses:Hub
    {
        // private CollegeContext context;

        /**
         * Static Data to test
         */
        private object[] staticData()
        {
            return new[]
            {
                new {CourseID=1,CourseName="Chemistry",Subjects=5,Teachers=5,Students=245},
                new {CourseID=2,CourseName="Microeconomics",Subjects=6,Teachers=4,Students=350},
                new {CourseID=3,CourseName="Macroeconomics",Subjects=4,Teachers=4,Students=278},
                new {CourseID=4,CourseName="Calculus",Subjects=5,Teachers=5,Students=412},
                new {CourseID=5,CourseName="Trigonometry",Subjects=2,Teachers=2,Students=384},
                new {CourseID=6,CourseName="Composition",Subjects=1,Teachers=0,Students=284},
                new {CourseID=7,CourseName="Literature",Subjects=8,Teachers=8,Students=934}
            };
        }

        public async Task Index(string data = null)
        {
            //object[] response = context.Courses.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseCourses", response);
        }

        public async Task Store(string data = null)
        {
            //context.Database.EnsureCreated();
            //context.Courses.Add(new Course { CourseName = data});                

            await Clients.All.SendAsync("responseCourses", true /*context.SaveChanges()*/);
        }

        public async Task Destroy(string id = null)
        {
            //Course curse = new Course() { CourseId = id };
            //context.Customers.Attach(curse);
            //context.Customers.Remove(curse);
            //context.SaveChanges();
            //object[] response = context.Courses.ToList();
            object[] response = this.staticData();

            await Clients.All.SendAsync("responseCourses", response);
        }

        public async Task Update(object data = null)
        {
            //var course = context.Courses.Find(data.id);
            //course.CourseName = data.name;
            //context.Entry(course).State = EntityState.Modified;

            await Clients.All.SendAsync("responseCourses", true /*context.SaveChanges()*/);
        }
    }
}
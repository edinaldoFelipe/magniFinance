/**
 * 
 * All dinamics connection don't work
 * because connection with database is fail
 * And need add CollegeContext at class
 * 
 */

using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace MagniFinanceCollege.Hubs
{
    public class Dashboard:Hub
    {
        public async Task Index(string data = null)
        {
            // TODO create consult into model to generate dinamic data
            // Static Data to test
            object response = new
            {
                amount= new{courses=9, subjects=23, teacher=8, students=124},
                activities=new[]
                {
                    new{name="Isabella Christensen",date="11 MAY 12:56",status="active", description="Lorem Ipsum is simply",img="avatar-1"},
                    new{name="Mathilde Andersen",date="11 MAY 10:35",status="inactive", description="Lorem Ipsum is simply text of",img="avatar-2"},
                    new{name="Karla Sorensen",date="9 MAY 17:38",status="active", description="Lorem Ipsum is simply…",img="avatar-3"},
                    new{name="Ida Jorgensen",date="19 MAY 12:56",status="inactive", description="Lorem Ipsum is simply dummy",img="avatar-1"},
                    new{name="Albert Andersen",date="21 July 12:56",status="inactive", description="Lorem Ipsum is simply text of",img="avatar-1"},
                },
                rating=new{r1=4,r2=20,r3=8,r4=32,r5=65,diff=0.4,avg=4.5}
            };

            await Clients.All.SendAsync("responseDashboard", response);
        }
    }
}

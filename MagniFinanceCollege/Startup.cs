using MagniFinanceCollege.Data;
using Microsoft.EntityFrameworkCore;
using MagniFinanceCollege.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MagniFinanceCollege
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // configure DBcontext
            services.AddDbContext<CollegeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddControllersWithViews();

            // start SignalR
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<Dashboard>("/dashboardHub");
                endpoints.MapHub<Courses>("/coursesHub");
                endpoints.MapHub<Subjects>("/subjectsHub");
                endpoints.MapHub<Teachers>("/teachersHub");
                endpoints.MapHub<Students>("/studentsHub");
            });
        }
    }
}

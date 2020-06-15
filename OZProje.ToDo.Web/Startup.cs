using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OZProje.ToDo.Business.Concrete;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;

namespace OZProje.ToDo.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IReportService, ReportManager>();

            services.AddScoped<ITaskDAL, EfTaskRepository>();
            services.AddScoped<IReportDAL, EfReportRepository>();
            services.AddScoped<IPriorityDAL, EfPriorityRepository>();

            services.AddDbContext<ToDoContext>();
            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ToDoContext>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}

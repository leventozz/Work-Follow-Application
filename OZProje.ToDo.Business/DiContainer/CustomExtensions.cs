using Microsoft.Extensions.DependencyInjection;
using OZProje.ToDo.Business.Concrete;
using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;

namespace OZProje.ToDo.Business.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainer(this IServiceCollection services)
        {
            services.AddScoped<ITaskService, TaskManager>();
            services.AddScoped<IPriorityService, PriorityManager>();
            services.AddScoped<IReportService, ReportManager>();
            services.AddScoped<IAppUserService, AppUserManager>();
            services.AddScoped<IFileService, FileManager>();
            services.AddScoped<INotificationService, NotificationManager>();

            services.AddScoped<ITaskDAL, EfTaskRepository>();
            services.AddScoped<IReportDAL, EfReportRepository>();
            services.AddScoped<IPriorityDAL, EfPriorityRepository>();
            services.AddScoped<IAppUserDAL, EfAppUserRepository>();
            services.AddScoped<INotificationDAL, EfNotificationRepository>();
        }
    }
}

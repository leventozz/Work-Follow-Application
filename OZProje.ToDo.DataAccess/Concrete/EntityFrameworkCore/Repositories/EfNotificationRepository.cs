using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDAL
    {
        public List<Notification> GetUnread(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Notifications.Where(x => x.AppUserId == appUserId && !x.IsRead).ToList();
        }
    }
}

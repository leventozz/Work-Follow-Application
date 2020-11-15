using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDAL _notificationDAL;
        public NotificationManager(INotificationDAL notificationDAL)
        {
            _notificationDAL = notificationDAL;
        }
        public void Delete(Notification table)
        {
            _notificationDAL.Delete(table);
        }

        public List<Notification> GetAll()
        {
            return _notificationDAL.GetAll();
        }

        public Notification GetById(int id)
        {
            return _notificationDAL.GetById(id);
        }

        public List<Notification> GetUnread(int appUserId)
        {
            return _notificationDAL.GetUnread(appUserId);
        }

        public void Save(Notification table)
        {
            _notificationDAL.Save(table);
        }

        public void Update(Notification table)
        {
            _notificationDAL.Update(table);
        }
    }
}

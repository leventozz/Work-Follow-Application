using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetUnread(int appUserId);
    }
}

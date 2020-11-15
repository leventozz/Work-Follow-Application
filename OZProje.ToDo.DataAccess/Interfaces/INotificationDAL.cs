using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface INotificationDAL: IGenericDAL<Notification>
    {
        List<Notification> GetUnread(int appUserId);
    }
}

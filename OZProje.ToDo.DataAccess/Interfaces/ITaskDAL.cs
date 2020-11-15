using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface ITaskDAL :IGenericDAL<Task>
    {
        List<Task> GetIsNotCompleted();
        List<Task> GetWithAllies();
        List<Task> GetWithAllies(Expression<Func<Task, bool>> filter);
        Task GetByPriorityId(int id);
        List<Task> GetByAppUserId(int appUserId);
        Task GetReportsById(int id);
        List<Task> GetCompletedWithAllies(out int totalIndex, int userId, int activeIndex);
        int GetCompletedTaskCount(int userId);
        int GetNotCompletedTaskCount(int userId);
    }
}

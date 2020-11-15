using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface ITaskService: IGenericService<Task>
    {
        List<Task> GetIsNotCompleted();
        List<Task> GetWithAllies();
        Task GetByPriorityId(int id);
        List<Task> GetByAppUserId(int appUserId);
        Task GetReportsById(int id);
        List<Task> GetWithAllies(Expression<Func<Task, bool>> filter);
        List<Task> GetCompletedWithAllies(out int totalIndex, int userId, int activeIndex=1);
        int GetCompletedTaskCount(int userId);
        int GetNotCompletedTaskCount(int userId);
    }
}

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
        List<Task> GetWithAlias();
        List<Task> GetWithAlias(Expression<Func<Task, bool>> filter);
        Task GetByPriorityId(int id);
        List<Task> GetByAppUserId(int appUserId);
        Task GetReportsById(int id);
    }
}

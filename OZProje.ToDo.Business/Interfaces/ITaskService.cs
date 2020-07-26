using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Interfaces
{
    public interface ITaskService: IGenericService<Task>
    {
        List<Task> GetIsNotCompleted();
        List<Task> GetWithAlias();
        Task GetByPriorityId(int id);
        List<Task> GetByAppUserId(int appUserId);
    }
}

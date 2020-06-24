using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Interfaces
{
    public interface ITaskDAL :IGenericDAL<Task>
    {
        List<Task> GetIsNotCompleted();
        List<Task> GetWithAlias();
        Task GetByPriorityId(int id);
    }
}

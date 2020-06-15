using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.Business.Concrete
{
    public class TaskManager : ITaskService
    {
        private readonly ITaskDAL _taskDAL;
        public TaskManager(ITaskDAL taskDAL)
        {
            _taskDAL = taskDAL;
        }
        public void Delete(Task table)
        {
            _taskDAL.Delete(table);
        }

        public List<Task> GetAll()
        {
            return _taskDAL.GetAll();
        }

        public Task GetById(int id)
        {
            return _taskDAL.GetById(id);
        }

        public void Save(Task table)
        {
            _taskDAL.Save(table);
        }

        public void Update(Task table)
        {
            _taskDAL.Update(table);
        }
    }
}

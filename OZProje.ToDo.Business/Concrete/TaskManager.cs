using OZProje.ToDo.Business.Interfaces;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

        public int GetAllCompletedTaskCount()
        {
            return _taskDAL.GetAllCompletedTaskCount();
        }

        public List<Task> GetByAppUserId(int appUserId)
        {
            return _taskDAL.GetByAppUserId(appUserId);
        }

        public Task GetById(int id)
        {
            return _taskDAL.GetById(id);
        }

        public Task GetByPriorityId(int id)
        {
            return _taskDAL.GetByPriorityId(id);
        }

        public int GetCompletedTaskCount(int userId)
        {
            return _taskDAL.GetCompletedTaskCount(userId);
        }

        public List<Task> GetCompletedWithAllies(out int totalIndex, int userId, int activeIndex)
        {
            return _taskDAL.GetCompletedWithAllies(out totalIndex, userId, activeIndex);
        }

        public List<Task> GetIsNotCompleted()
        {
            return _taskDAL.GetIsNotCompleted();
        }

        public int GetNotAssignedTaskCount()
        {
            return _taskDAL.GetNotAssignedTaskCount();
        }

        public int GetNotCompletedTaskCount(int userId)
        {
            return _taskDAL.GetNotCompletedTaskCount(userId);
        }

        public Task GetReportsById(int id)
        {
            return _taskDAL.GetReportsById(id);
        }

        public List<Task> GetWithAllies()
        {
            return _taskDAL.GetWithAllies();
        }

        public List<Task> GetWithAllies(Expression<Func<Task, bool>> filter)
        {
            return _taskDAL.GetWithAllies(filter);
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

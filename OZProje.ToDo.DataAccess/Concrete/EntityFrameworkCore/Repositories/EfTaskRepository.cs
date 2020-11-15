using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTaskRepository : EfGenericRepository<Task>, ITaskDAL
    {
        public List<Task> GetByAppUserId(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Tasks.Where(x => x.AppUserId == appUserId).ToList();
        }

        public Task GetByPriorityId(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).FirstOrDefault(x => !x.IsComplete && x.Id == id);
        }

        public List<Task> GetIsNotCompleted()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).Where(x => !x.IsComplete).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public List<Task> GetWithAllies()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).Include(x => x.Reports).Include(x => x.AppUser).Where(x => !x.IsComplete).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Task GetReportsById(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Reports).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Task> GetWithAllies(Expression<Func<Task, bool>> filter)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).Include(x => x.Reports).Include(x => x.AppUser).Where(filter).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public List<Task> GetCompletedWithAllies(out int totalIndex, int userId, int activeIndex=1)
        {
            using var context = new ToDoContext();
            var values= context.Tasks.Include(x => x.Priority).Include(x => x.Reports).Include(x => x.AppUser).Where(x=>x.AppUserId==userId).Where(x=>x.IsComplete).OrderByDescending(x => x.CreatedOn);

            totalIndex = (int)Math.Ceiling((double)values.Count() / 3);
            return values.Skip((activeIndex - 1) * 3).Take(3).ToList();
        }

        public int GetCompletedTaskCount(int userId)
        {
            using var context = new ToDoContext();
            return context.Tasks.Where(x => x.AppUserId == userId && x.IsComplete).Count();
        }

        public int GetNotCompletedTaskCount(int userId)
        {
            using var context = new ToDoContext();
            return context.Tasks.Where(x => x.AppUserId == userId && !x.IsComplete).Count();
        }
    }
}

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

        public List<Task> GetWithAlias()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).Include(x => x.Reports).Include(x => x.AppUser).Where(x => !x.IsComplete).OrderByDescending(x => x.CreatedOn).ToList();
        }

        public Task GetReportsById(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Reports).Include(x=>x.AppUser).Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Task> GetWithAlias(Expression<Func<Task, bool>> filter)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.Priority).Include(x => x.Reports).Include(x => x.AppUser).Where(filter).OrderByDescending(x => x.CreatedOn).ToList();
        }
    }
}

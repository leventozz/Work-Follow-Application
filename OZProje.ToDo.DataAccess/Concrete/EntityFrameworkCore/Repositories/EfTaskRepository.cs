using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

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
    }
}

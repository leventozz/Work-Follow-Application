using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System.Linq;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDAL
    {
        public int GetReportsCount(int userId)
        {
            using var context = new ToDoContext();
            var result= context.Tasks.Include(x => x.Reports).Where(x => x.AppUserId == userId);
            return result.SelectMany(x => x.Reports).Count();
        }

        public Report GetWithAllies(int id)
        {
            using var context = new ToDoContext();
            return context.Reports.Include(x => x.Task).ThenInclude(x=>x.Priority).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDAL
    {
        public Report GetWithAllies(int id)
        {
            using var context = new ToDoContext();
            return context.Reports.Include(x => x.Task).ThenInclude(x=>x.Priority).Where(x => x.Id == id).FirstOrDefault();
        }
    }
}

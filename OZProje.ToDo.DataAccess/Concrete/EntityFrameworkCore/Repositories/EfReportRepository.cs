using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDAL
    {
    }
}

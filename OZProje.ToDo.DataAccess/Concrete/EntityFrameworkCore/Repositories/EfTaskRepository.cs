using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfTaskRepository : EfGenericRepository<Task>, ITaskDAL
    {
        
    }
}

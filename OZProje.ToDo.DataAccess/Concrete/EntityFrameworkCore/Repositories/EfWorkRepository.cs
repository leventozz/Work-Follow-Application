using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfWorkRepository : IWorkDAL
    {
        public void Delete(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Remove(work);
            context.SaveChanges();
        }

        public List<Work> GetAll()
        {
            using var context = new ToDoContext();
            return context.Works.ToList();
        }

        public Work GetById(int id)
        {
            using var context = new ToDoContext();
            return context.Works.Find(id);
        }

        public void Save(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Add(work);
            context.SaveChanges();
        }

        public void Update(Work work)
        {
            using var context = new ToDoContext();
            context.Works.Update(work);
            context.SaveChanges();
        }
    }
}

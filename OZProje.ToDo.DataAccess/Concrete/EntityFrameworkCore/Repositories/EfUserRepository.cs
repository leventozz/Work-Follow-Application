using OZProje.ToDo.DataAccess.Concrete.EntityFrameuserCore.Contexts;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameuserCore.Repositories
{
    public class EfUserRepository : IUserDAL
    {
        public void Delete(User user)
        {
            using var context = new ToDoContext();
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public List<User> GetAll()
        {
            using var context = new ToDoContext();
            return context.Users.ToList();
        }

        public User GetById(int id)
        {
            using var context = new ToDoContext();
            return context.Users.Find(id);
        }

        public void Save(User user)
        {
            using var context = new ToDoContext();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Update(User user)
        {
            using var context = new ToDoContext();
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}

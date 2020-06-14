using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class ToDoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QAAQCOC\\SQLEXPRESS; database=udemyBlogToDo; integrated security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new WorkMap());
        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Work> Works{ get; set; }
    }
}

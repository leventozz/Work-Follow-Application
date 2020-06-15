using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class ToDoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QAAQCOC\\SQLEXPRESS; database=BlogToDo; integrated security=true");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TaskMap());
            modelBuilder.ApplyConfiguration(new PriorityMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new ReportMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Task> Tasks{ get; set; }
        public DbSet<Priority> Priorities{ get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}

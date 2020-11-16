using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDAL
    {
        public List<AppUser> GetMembers()
        {
            using var context = new ToDoContext();

            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, firstJoin => firstJoin.userRole.RoleId, role => role.Id, (resultJoin, resultRole) => new
            {
                user = resultJoin.user,
                userRoles = resultJoin.userRole,
                roles = resultRole
            }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName
            }).ToList();

        }
        public List<AppUser> GetMembers(out int totalPage, string searchKey, int activePage=1)
        {
            using var context = new ToDoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, firstJoin => firstJoin.userRole.RoleId, role => role.Id, (resultJoin, resultRole) => new
            {
                user = resultJoin.user,
                userRoles = resultJoin.userRole,
                roles = resultRole
            }).Where(x => x.roles.Name == "Member").Select(x => new AppUser()
            {
                Id = x.user.Id,
                Name = x.user.Name,
                Surname = x.user.Surname,
                Picture = x.user.Picture,
                Email = x.user.Email,
                UserName = x.user.UserName
            });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                result = result.Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Surname.ToLower().Contains(searchKey.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);
            }

            result = result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }
        public List<DualHelper> GetTopTaskCompletionPersonnels()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.AppUser).Where(x => x.IsComplete == true)
                .GroupBy(x => x.AppUser.UserName)
                .OrderByDescending(x=>x.Count())
                .Select(x=>new DualHelper { 
                Name = x.Key,
                TaskCount = x.Count()
                }).ToList();
        }
        public List<DualHelper> GetTopActivePersonnels()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(x => x.AppUser).Where(x => x.IsComplete == false && x.AppUserId != null)
                .GroupBy(x => x.AppUser.UserName)
                .OrderByDescending(x => x.Count())
                .Select(x => new DualHelper
                {
                    Name = x.Key,
                    TaskCount = x.Count()
                }).ToList();
        }
    }
}

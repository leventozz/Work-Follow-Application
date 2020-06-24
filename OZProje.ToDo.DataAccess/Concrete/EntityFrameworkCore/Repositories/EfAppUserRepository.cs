using Microsoft.EntityFrameworkCore.Internal;
using OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using OZProje.ToDo.DataAccess.Interfaces;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OZProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAppUserRepository : IAppUserDAL
    {
        /* select * from AspNetUsers inner join AspNetUserRoles on AspNetUsers.Id=AspNetUserRoles.UserId
inner join AspNetRoles on AspNetUserRoles.RoleId=AspNetRoles.Id where AspNetRoles.Name='Member'*/
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
        public List<AppUser> GetMembers(string searchKey, int activePage=1)
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

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                result.Where(x => x.Name.ToLower().Contains(searchKey.ToLower()) || x.Surname.ToLower().Contains(searchKey.ToLower()));
            }

            result.Skip((activePage - 1) * 3).Take(3);

            return result.ToList();
        }
    }
}

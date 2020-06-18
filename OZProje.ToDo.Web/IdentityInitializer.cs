using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using OZProje.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OZProje.ToDo.Web
{
    public static class IdentityInitializer
    {
        public static async System.Threading.Tasks.Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Admin" });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "Member" });
            }

            var adminUser = await userManager.FindByNameAsync("Levent");
            if (adminUser == null)
            {
                AppUser appUser = new AppUser
                {
                    Name = "Levent",
                    Surname = "Oz",
                    UserName = "Levent",
                    Email = "leventufukozturk@gmail.com"
                };
                await userManager.CreateAsync(appUser, "1");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
        }
    }
}

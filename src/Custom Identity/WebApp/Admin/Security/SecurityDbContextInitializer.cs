using Demo.BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Admin.Security
{
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole { Name = "Administrators" });
            roleManager.Create(new IdentityRole { Name = "Registered Users" });

            var adminUser = new ApplicationUser
            {
                UserName = "WebAdmin",
                Email = "696@hotmail.ca",
                EmailConfirmed = true
            };

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(adminUser, "Password");
            if (result.Succeeded)
            {
                var found = userManager.FindByName("WebAdmin").Id;
                userManager.AddToRole(found, "AdminiStrators");

            }
            var demoManager = new DemoController();
            var people = demoManager.ListImportantPeople();
            foreach(var person in people)
            {
                var user = new ApplicationUser
                {
                    UserName = $"{person.FirstName}.{person.LastName}",
                    Email = $"{person.FirstName}.{person.LastName}@DemoIsland.com",
                    EmailConfirmed = true,
                    PersonId = person.PersonID
                };
                result = userManager.Create(user, "password1");
                if(result.Succeeded)
                {
                    var userId = userManager.FindByName(user.UserName).Id;
                    userManager.AddToRole(userId, "Registered Users");
                }
            }



            base.Seed(context);
        }
    }
}
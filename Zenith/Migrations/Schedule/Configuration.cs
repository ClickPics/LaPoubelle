namespace ZenithDataLib.Migrations.Schedule
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithDataLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithDataLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Schedule";
        }

        protected override void Seed(ZenithDataLib.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            this.SeedRoles(context);
            this.SeedUsers(context);
        }

        private void SeedRoles(ZenithDataLib.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("Member"))
            {
                roleManager.Create(new IdentityRole("Member"));
            }
        }

        private void SeedUsers(ZenithDataLib.Models.ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (userManager.FindByEmail("a@a.a") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "a@a.a",
                    UserName = "a",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
                }
            }

            if (userManager.FindByEmail("g@g.g") == null)
            {
                var user = new ApplicationUser
                {
                    Email = "m@m.m",
                    UserName = "m",
                };
                var result = userManager.Create(user, "P@$$w0rd");
                if (result.Succeeded)
                {
                    userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Member");
                }
            }
        }
    }
}

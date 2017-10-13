namespace Zenith.Migrations.Schedule
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
            this.SeedEvents(context);
            this.SeedRoles(context);
            this.SeedUsers(context);
        }

        private void SeedEvents(ZenithDataLib.Models.ApplicationDbContext context)
        {
            context.ActivityCategories.AddOrUpdate(a => a.ActivityCategoryId,
                GetActivityCategories(context).ToArray()
            );
            context.SaveChanges();

            context.Events.AddOrUpdate(e => e.EventId,
                  GetEvents(context).ToArray()
            );
            context.SaveChanges();
        }

        private List<ActivityCategory> GetActivityCategories(ZenithDataLib.Models.ApplicationDbContext context)
        {

            List<ActivityCategory> categories = new List<ActivityCategory>()
            {
                new ActivityCategory { ActivityCategoryId = 1,
                    ActivityDescription = "Senior's Golf Tournament",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 2,
                    ActivityDescription = "Leadership General Assembly Meeting",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 3,
                    ActivityDescription = "Youth Bowling Tournament",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 4,
                    ActivityDescription = "Young Ladies Cooking Lessons",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 5,
                    ActivityDescription = "Youth Craft Lessons",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 6,
                    ActivityDescription = "Youth Choir Practice",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 7,
                    ActivityDescription = "Lunch",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 8,
                    ActivityDescription = "Pancake Breakfast",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 9,
                    ActivityDescription = "Swimming Lessons for the Youth",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 10,
                    ActivityDescription = "Swimming Exercise for Parents",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 11,
                    ActivityDescription = "Bingo Tournament",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 12,
                    ActivityDescription = "BBQ Lunch",
                    CreationDate = DateTime.Now},
                new ActivityCategory { ActivityCategoryId = 13,
                    ActivityDescription = "Garage Sale",
                    CreationDate = DateTime.Now},
            };
            return categories;
        }

        private List<Event> GetEvents(ZenithDataLib.Models.ApplicationDbContext context)
        {
            List<Event> events = new List<Event>()
            {
                new Event() { StartDateTime= new DateTime(2017, 10, 10, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 10, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 1).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 11, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 11, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 2).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 13, 17, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 13, 19, 15, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 3).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 13, 19, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 13, 20, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 4).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 14, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 14, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 5).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 14, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 14, 12, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 6).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 14, 12, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 14, 13, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 7).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 7, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 8, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 8).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 9).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 10).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 12, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 11).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 12, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 13, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 12).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 15, 13, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 15, 18, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 13).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 17, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 17, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 1).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 18, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 18, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 2).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 20, 17, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 20, 19, 15, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 3).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 20, 19, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 20, 20, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 4).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 21, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 21, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 5).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 21, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 21, 12, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 6).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 21, 12, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 21, 13, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 7).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 7, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 8, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 8).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 9).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 8, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 10, 30, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 10).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 10, 30, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 12, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 11).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 12, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 13, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 12).ActivityCategoryId},
                new Event() { StartDateTime= new DateTime(2017, 10, 22, 13, 00, 00),
                    EndDateTime = new DateTime(2017, 10, 22, 18, 00, 00),
                    Username = "a",
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ActivityCategoryId = context.ActivityCategories.FirstOrDefault(
                        a => a.ActivityCategoryId == 13).ActivityCategoryId},
            };
            return events;
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

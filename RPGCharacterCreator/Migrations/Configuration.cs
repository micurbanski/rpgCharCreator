namespace RPGCharacterCreator.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RPGCharacterCreator.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RPGCharacterCreator.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //{
            //    System.Diagnostics.Debugger.Launch();
            //}

            SeedRoles(context);
            SeedUsers(context);
            SeedCharacters(context);
            SeedSkills(context);
            SeedCharacter_Skill(context);
        }

        private void SeedRoles(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>());
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);

            if (!context.Users.Any(u => u.UserName == "Admin@rpgcreator.com"))
            {
                var user = new ApplicationUser { UserName = "Admin@rpgcreator.com" };
                var adminResult = manager.Create(user, "Q!w2e3r4");

                if (adminResult.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }

            if (!context.Users.Any(u => u.UserName == "TestUser@rpgcreator.com"))
            {
                var user = new ApplicationUser { UserName = "TestUser@rpgcreator.com" };
                var adminResult = manager.Create(user, "R$e3w2q1");

                if (adminResult.Succeeded)
                {
                    manager.AddToRole(user.Id, "User");
                }
            }


        }

        private void SeedCharacters(ApplicationDbContext context)
        {
            Random r = new Random();

            var idUser = context.Set<ApplicationUser>().Where(u => u.UserName == "Admin").FirstOrDefault().Id;
            
            var classList = new List<String>();
            classList.Add("Mage");
            classList.Add("Knight");
            classList.Add("Rouge");

            for (int i = 0; i <= 10; i++)
            {
                var seededCharacter = new Character()
                {
                    Id = i,
                    UserId = idUser,
                    Name = "Name" + i.ToString(),

                    ClassChoice = classList.ElementAt(r.Next(0,3)),
                    StrengthPoints = r.Next(1, 5),
                    IntelligencePoints = r.Next(1, 5),
                    AgilityPoints = r.Next(1, 5)
                };
                context.Set<Character>().AddOrUpdate(seededCharacter);
            }
            context.SaveChanges();
        }

        private void SeedSkills(ApplicationDbContext context)
        {
            Random r = new Random();

            var classList = new List<String>();
            classList.Add("Mage");
            classList.Add("Knight");
            classList.Add("Rouge");

            var typeList = new List<String>();
            typeList.Add("Offensive");
            typeList.Add("Defensive");
            typeList.Add("Neutral");

            for (int i = 0; i <= 10; i++)
            {
                var skill = new Skill()
                {
                    Id = i,
                    SkillName = "Skill" + i.ToString(),
                    ClassRequired = classList.ElementAt(r.Next(0, 3)),
                    SkillType = typeList.ElementAt(r.Next(0, 3)),
                    SkillLevel = r.Next(1, 3)
                };
                context.Set<Skill>().AddOrUpdate(skill);
            }
            
            context.SaveChanges();
        }
        private void SeedCharacter_Skill(ApplicationDbContext context)
        {
            for (int i = 0; i <= 10; i++)
            {
                var characterSkill = new Character_Skill()
                {
                    Id = i,
                    CharacterId = i / 2 + 1,
                    SkillId = i / 2 + 2
                };
                context.Set<Character_Skill>().AddOrUpdate(characterSkill);
            }
            context.SaveChanges();
        }
    }
}

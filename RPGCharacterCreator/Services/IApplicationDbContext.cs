using RPGCharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace RPGCharacterCreator.Services
{
    public interface IApplicationDbContext
    {
        DbSet<Character> Characters { get; set; }
        DbSet<Skill> Skils { get; set; }
        DbSet<Character_Skill> CharacterSkill { get; set; }
        DbSet<ApplicationUser> User { get; set; }

        int SaveChanges();
        Database Database { get; }
        DbEntityEntry Entry(object entity);

    }
}
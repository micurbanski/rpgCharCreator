using RPGCharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RPGCharacterCreator.Services
{
    public class CharacterService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Character> GetCharacters()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            return db.Characters.AsNoTracking();
        }
    }
}
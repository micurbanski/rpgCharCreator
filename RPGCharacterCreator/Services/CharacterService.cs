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

        public Character GetCharacterById(int id)
        {
            Character character = db.Characters.Find(id);
            return character;
        }

        public bool DeleteCharacter(int id)
        {
            DeleteCharaterConstraints(id);

            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private void DeleteCharaterConstraints(int idCharacter)
        {
            var list = db.CharacterSkill.Where(o => o.CharacterId == idCharacter);

            foreach (var element in list)
            {
                db.CharacterSkill.Remove(element);
            }
        }
    }
}
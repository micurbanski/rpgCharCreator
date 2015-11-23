using RPGCharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;

namespace RPGCharacterCreator.Services
{
    public class CharacterService: ICharacterService
    {
        private readonly IApplicationDbContext _db;
        public CharacterService(IApplicationDbContext db)
        {
            _db = db;
        }


        public IQueryable<Character> GetCharacters()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Characters.AsNoTracking();
        }

        public Character GetCharacterById(int id)
        {
            Character character = _db.Characters.Find(id);
            return character;
        }

        public bool DeleteCharacter(int id)
        {
            DeleteCharaterConstraints(id);

            Character character = _db.Characters.Find(id);
            _db.Characters.Remove(character);
            try
            {
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        private void DeleteCharaterConstraints(int idCharacter)
        {
            var list = _db.CharacterSkill.Where(o => o.CharacterId == idCharacter);

            foreach (var element in list)
            {
                _db.CharacterSkill.Remove(element);
            }
        }

        public void AddCharacter(Character character)
        {
            _db.Characters.Add(character);
        }

        public void UpdateCharacter(Character character)
        {
            _db.Entry(character).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
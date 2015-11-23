using RPGCharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace RPGCharacterCreator.Services
{
    public interface ICharacterService
    {
        IQueryable<Character> GetCharacters();
        Character GetCharacterById(int id);
        bool DeleteCharacter(int id);
        void AddCharacter(Character character);
        void UpdateCharacter(Character character);

        void SaveChanges();
    }
}
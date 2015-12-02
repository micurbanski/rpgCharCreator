using RPGCharacterCreator.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace RPGCharacterCreator.Services
{
    public class SkillService
    {

        private ApplicationDbContext db = new ApplicationDbContext();


        public IQueryable<Skill> GetSkills()
        {
            db.Database.Log = message => Trace.WriteLine(message);
            return db.Skills.AsNoTracking();
        }

        public Skill GetSkillById(int id)
        {
            Skill skill = db.Skills.Find(id);
            return skill;
        }

        public bool DeleteSkill(int id)
        {
            DeleteSkillConstraints(id);

            Skill skill = db.Skills.Find(id);
            db.Skills.Remove(skill);
            try
            {
                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }

        private void DeleteSkillConstraints(int idSkill)
        {
            var list = db.CharacterSkill.Where(o => o.SkillId == idSkill);

            foreach (var element in list)
            {
                db.CharacterSkill.Remove(element);
            }
        }

        public void AddSkill(Skill skill)
        {
            db.Skills.Add(skill);
        }

        public void UpdateSkill(Skill skill)
        {
            db.Entry(skill).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public IQueryable<Skill> GetPage(int? page = 1, int? pageSize = 10)
        {
            var skills = db.Skills.OrderByDescending(o => o.SkillLevel)
                .Skip((page.Value - 1) * pageSize.Value)
                .Take(pageSize.Value);

            return skills;
        }


    }
}
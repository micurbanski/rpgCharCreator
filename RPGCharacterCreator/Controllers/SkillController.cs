using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPGCharacterCreator.Models;
using RPGCharacterCreator.Services;

namespace RPGCharacterCreator.Controllers
{
    public class SkillController : Controller
    {
        SkillService skillService = new SkillService();

        // GET: Skill
        public ActionResult Index()
        {
            var skills = skillService.GetSkills().AsNoTracking();
            return View(skills.ToList());
        }

        // GET: Skill/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = skillService.GetSkillById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skill/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View(new Skill());
        }

        // POST: Skill/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SkillName,ClassRequired,SkillType,SkillLevel")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                //db.Skills.Add(skill);
                //db.SaveChanges();
                try
                {
                    skillService.AddSkill(skill);
                    skillService.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(skill);
                    throw;
                }
            }
            return View(skill);
        }

        [Authorize(Roles = "Admin")]
        // GET: Skill/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = skillService.GetSkillById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skill/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SkillName,ClassRequired,SkillType,SkillLevel")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    skillService.UpdateSkill(skill);
                    skillService.SaveChanges();
                    RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Error = true;
                    return View(skill);
                }
            }
            ViewBag.Error = false;
            return View(skill);
        }

        // GET: Skill/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = skillService.GetSkillById((int)id);
            if (skill == null)
            {
                return HttpNotFound();
            }

            if (error != null)
            {
                ViewBag.Error = true;
            }
            return View(skill);
        }

        // POST: Skill/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            skillService.DeleteSkill(id);
            try
            {
                skillService.SaveChanges();
            }
            catch
            {
                return RedirectToAction("Delete", new { id = id, error = true });
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}

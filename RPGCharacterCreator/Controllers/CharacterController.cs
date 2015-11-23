﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RPGCharacterCreator.Models;
using System.Diagnostics;
using RPGCharacterCreator.Services;

namespace RPGCharacterCreator.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        CharacterService characterService = new CharacterService();
        // GET: Character
        public ActionResult Index()
        {
            var characters = characterService.GetCharacters();
            return View(characters);
        }

        //// GET: Character/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = characterService.GetCharacterById((int)id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // GET: Character/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email"); NO USER LIST
            return View(new Character());
        }

        // POST: Character/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,Name,ClassChoice,StrengthPoints,IntelligencePoints,AgilityPoints,MaxPoints,UserId")] Character character)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Characters.Add(character);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
        //    return View(character);
        //}

            //// GET: Character/Edit/5
            //public ActionResult Edit(int? id)
            //{
            //    if (id == null)
            //    {
            //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //    }
            //    Character character = db.Characters.Find(id);
            //    if (character == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
            //    return View(character);
            //}

            //// POST: Character/Edit/5
            //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            //[HttpPost]
            //[ValidateAntiForgeryToken]
            //public ActionResult Edit([Bind(Include = "Id,Name,ClassChoice,StrengthPoints,IntelligencePoints,AgilityPoints,MaxPoints,UserId")] Character character)
            //{
            //    if (ModelState.IsValid)
            //    {
            //        db.Entry(character).State = EntityState.Modified;
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    ViewBag.UserId = new SelectList(db.Users, "Id", "Email", character.UserId);
            //    return View(character);
            //}

            //// GET: Character/Delete/5
        public ActionResult Delete(int? id, bool? error)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Character character = characterService.GetCharacterById((int)id);
            if (character == null)
            {
                return HttpNotFound();
            }

            if (error != null)
            {
                ViewBag.Error = true;
            }
            return View(character);
        }

        //// POST: Character/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                characterService.DeleteCharacter(id);
            }
            catch
            {

                return RedirectToAction("Delete", new {id = id, error = true });
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

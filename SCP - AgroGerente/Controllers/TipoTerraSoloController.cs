using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Controllers
{
    public class TipoTerraSoloController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /TipoTerraSolo/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.TerraSolo.ToList());
        }

        //
        // GET: /TipoTerraSolo/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            TerraSolo terrasolo = db.TerraSolo.Find(id);
            if (terrasolo == null)
            {
                return HttpNotFound();
            }
            return View(terrasolo);
        }

        //
        // GET: /TipoTerraSolo/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View();
        }

        //
        // POST: /TipoTerraSolo/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(TerraSolo terrasolo)
        {
            if (ModelState.IsValid)
            {
                db.TerraSolo.Add(terrasolo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(terrasolo);
        }

        //
        // GET: /TipoTerraSolo/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            TerraSolo terrasolo = db.TerraSolo.Find(id);
            if (terrasolo == null)
            {
                return HttpNotFound();
            }
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View(terrasolo);
        }

        //
        // POST: /TipoTerraSolo/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(TerraSolo terrasolo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terrasolo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(terrasolo);
        }

       

        //
        // POST: /TipoTerraSolo/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            TerraSolo terrasolo = db.TerraSolo.Find(id);
            db.TerraSolo.Remove(terrasolo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Areas.Projetos.Model;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class CadastroBQTiposController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        // GET: Projetos/CadastroBQTipos
        public ActionResult Index()
        {
            return View(db.CadastroBQTipo.ToList());
        }

        // GET: Projetos/CadastroBQTipos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBQTipo cadastroBQTipo = db.CadastroBQTipo.Find(id);
            if (cadastroBQTipo == null)
            {
                return HttpNotFound();
            }
            return View(cadastroBQTipo);
        }

        // GET: Projetos/CadastroBQTipos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Projetos/CadastroBQTipos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BQTipo,BQTipoAtivo")] CadastroBQTipo cadastroBQTipo)
        {
            if (ModelState.IsValid)
            {
                db.CadastroBQTipo.Add(cadastroBQTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroBQTipo);
        }

        // GET: Projetos/CadastroBQTipos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBQTipo cadastroBQTipo = db.CadastroBQTipo.Find(id);
            if (cadastroBQTipo == null)
            {
                return HttpNotFound();
            }
            return View(cadastroBQTipo);
        }

        // POST: Projetos/CadastroBQTipos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BQTipo,BQTipoAtivo")] CadastroBQTipo cadastroBQTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroBQTipo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroBQTipo);
        }

      

        // POST: Projetos/CadastroBQTipos/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroBQTipo cadastroBQTipo = db.CadastroBQTipo.Find(id);
            db.CadastroBQTipo.Remove(cadastroBQTipo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

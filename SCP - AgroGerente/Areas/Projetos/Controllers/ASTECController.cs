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
    public class ASTECController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        // GET: Projetos/ASTEC
        public ActionResult Index()
        {
            var cadastroASTEC = db.CadastroASTEC.Include(c => c.CadastroSafra);
            return View(cadastroASTEC.ToList());
        }

        // GET: Projetos/ASTEC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroASTEC cadastroASTEC = db.CadastroASTEC.Find(id);
            if (cadastroASTEC == null)
            {
                return HttpNotFound();
            }
            return View(cadastroASTEC);
        }

        // GET: Projetos/ASTEC/Create
        public ActionResult Create()
        {
            ViewBag.AstecSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra");
            return View();
        }

        // POST: Projetos/ASTEC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AstecValor,AstecSafra")] CadastroASTEC cadastroASTEC)
        {
            if (ModelState.IsValid)
            {
                db.CadastroASTEC.Add(cadastroASTEC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AstecSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroASTEC.AstecSafra);
            return View(cadastroASTEC);
        }

        // GET: Projetos/ASTEC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroASTEC cadastroASTEC = db.CadastroASTEC.Find(id);
            if (cadastroASTEC == null)
            {
                return HttpNotFound();
            }
            ViewBag.AstecSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroASTEC.AstecSafra);
            return View(cadastroASTEC);
        }

        // POST: Projetos/ASTEC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AstecValor,AstecSafra")] CadastroASTEC cadastroASTEC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroASTEC).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AstecSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroASTEC.AstecSafra);
            return View(cadastroASTEC);
        }

        // GET: Projetos/ASTEC/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroASTEC cadastroASTEC = db.CadastroASTEC.Find(id);
            if (cadastroASTEC == null)
            {
                return HttpNotFound();
            }
            return View(cadastroASTEC);
        }

        // POST: Projetos/ASTEC/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroASTEC cadastroASTEC = db.CadastroASTEC.Find(id);
            db.CadastroASTEC.Remove(cadastroASTEC);
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

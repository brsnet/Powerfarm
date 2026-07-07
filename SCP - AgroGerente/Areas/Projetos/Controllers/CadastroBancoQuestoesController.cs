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
    public class CadastroBancoQuestoesController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        // GET: Projetos/CadastroBancoQuestoes
        public ActionResult Index()
        {
            var cadastroBancoQuestoes = db.CadastroBancoQuestoes.Include(c => c.CadastroBQTipo);
            return View(cadastroBancoQuestoes.ToList());
        }

        // GET: Projetos/CadastroBancoQuestoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBancoQuestoes cadastroBancoQuestoes = db.CadastroBancoQuestoes.Find(id);
            if (cadastroBancoQuestoes == null)
            {
                return HttpNotFound();
            }
            return View(cadastroBancoQuestoes);
        }

        // GET: Projetos/CadastroBancoQuestoes/Create
        public ActionResult Create()
        {
            ViewBag.BancoQuestoesTipo = new SelectList(db.CadastroBQTipo, "ID", "BQTipo");
            return View();
        }

        // POST: Projetos/CadastroBancoQuestoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BancoQuestoesTipo,BancoQuestoesPergunta,BancoQuestoesAtivo")] CadastroBancoQuestoes cadastroBancoQuestoes)
        {
            if (ModelState.IsValid)
            {
                db.CadastroBancoQuestoes.Add(cadastroBancoQuestoes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BancoQuestoesTipo = new SelectList(db.CadastroBQTipo, "ID", "BQTipo", cadastroBancoQuestoes.BancoQuestoesTipo);
            return View(cadastroBancoQuestoes);
        }

        // GET: Projetos/CadastroBancoQuestoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBancoQuestoes cadastroBancoQuestoes = db.CadastroBancoQuestoes.Find(id);
            if (cadastroBancoQuestoes == null)
            {
                return HttpNotFound();
            }
            ViewBag.BancoQuestoesTipo = new SelectList(db.CadastroBQTipo, "ID", "BQTipo", cadastroBancoQuestoes.BancoQuestoesTipo);
            return View(cadastroBancoQuestoes);
        }

        // POST: Projetos/CadastroBancoQuestoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BancoQuestoesTipo,BancoQuestoesPergunta,BancoQuestoesAtivo")] CadastroBancoQuestoes cadastroBancoQuestoes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroBancoQuestoes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BancoQuestoesTipo = new SelectList(db.CadastroBQTipo, "ID", "BQTipo", cadastroBancoQuestoes.BancoQuestoesTipo);
            return View(cadastroBancoQuestoes);
        }

      

        // POST: Projetos/CadastroBancoQuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroBancoQuestoes cadastroBancoQuestoes = db.CadastroBancoQuestoes.Find(id);
            db.CadastroBancoQuestoes.Remove(cadastroBancoQuestoes);
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

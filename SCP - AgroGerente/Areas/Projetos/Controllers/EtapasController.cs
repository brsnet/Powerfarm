using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Areas.Projetos.Model;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class EtapasController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        //
        // GET: /Projetos/Etapas/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.CadastroEtapa.ToList());
        }

      

        //
        // GET: /Projetos/Etapas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Projetos/Etapas/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroEtapa cadastroetapa)
        {
            if (ModelState.IsValid)
            {
                db.CadastroEtapa.Add(cadastroetapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroetapa);
        }

        //
        // GET: /Projetos/Etapas/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroEtapa cadastroetapa = db.CadastroEtapa.Find(id);
            if (cadastroetapa == null)
            {
                return HttpNotFound();
            }
            return View(cadastroetapa);
        }

        //
        // POST: /Projetos/Etapas/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroEtapa cadastroetapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroetapa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroetapa);
        }

      

        //
        // POST: /Projetos/Etapas/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroEtapa cadastroetapa = db.CadastroEtapa.Find(id);
            db.CadastroEtapa.Remove(cadastroetapa);
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
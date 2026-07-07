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
    public class TipoEtapaController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        //
        // GET: /Projetos/TipoEtapa/
        [Authorize]
        public ActionResult Index()
        {

            return View(db.CadastroTipoEtapa.OrderBy(s => s.TipoEtapaOrdem).ToList());
        }

       

        //
        // GET: /Projetos/TipoEtapa/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["TipoCadastroEtapa"] = EnumProjetos.EnumTipoEtapa;
            return View();
        }

        //
        // POST: /Projetos/TipoEtapa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroTipoEtapa cadastrotipoetapa)
        {
            if (ModelState.IsValid)
            {
                db.CadastroTipoEtapa.Add(cadastrotipoetapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrotipoetapa);
        }

        //
        // GET: /Projetos/TipoEtapa/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroTipoEtapa cadastrotipoetapa = db.CadastroTipoEtapa.Find(id);
            if (cadastrotipoetapa == null)
            {
                return HttpNotFound();
            }
            ViewData["TipoCadastroEtapa"] = EnumProjetos.EnumTipoEtapa;
            return View(cadastrotipoetapa);
        }

        //
        // POST: /Projetos/TipoEtapa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroTipoEtapa cadastrotipoetapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrotipoetapa).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrotipoetapa);
        }

        //
        // GET: /Projetos/TipoEtapa/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            CadastroTipoEtapa cadastrotipoetapa = db.CadastroTipoEtapa.Find(id);
            if (cadastrotipoetapa == null)
            {
                return HttpNotFound();
            }
            return View(cadastrotipoetapa);
        }

        //
        // POST: /Projetos/TipoEtapa/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroTipoEtapa cadastrotipoetapa = db.CadastroTipoEtapa.Find(id);
            db.CadastroTipoEtapa.Remove(cadastrotipoetapa);
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
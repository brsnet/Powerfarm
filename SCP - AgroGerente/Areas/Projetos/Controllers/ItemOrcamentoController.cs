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
    public class ItemOrcamentoController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        //
        // GET: /Projetos/ItemOrcamento/
        [Authorize]
        public ActionResult Index()
        {
            ViewData["EnumTipoUnidadeTempo"] = EnumProjetos.EnumTipoUnidadeTempo;
            var cadastroitemorcamento = db.MarcaProduto.ToList(); 






            return View(cadastroitemorcamento);
        }

        //
        // GET: /Projetos/ItemOrcamento/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroItemOrcamento cadastroitemorcamento = db.CadastroItemOrcamento.Find(id);
            if (cadastroitemorcamento == null)
            {
                return HttpNotFound();
            }
            return View(cadastroitemorcamento);
        }

        //
        // GET: /Projetos/ItemOrcamento/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["EnumTipoUnidadeTempo"] = EnumProjetos.EnumTipoUnidadeTempo;           
            return View();
        }

        //
        // POST: /Projetos/ItemOrcamento/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroItemOrcamento cadastroitemorcamento)
        {
            if (ModelState.IsValid)
            {
                db.CadastroItemOrcamento.Add(cadastroitemorcamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemOrcamentoProduto = new SelectList(db.CadastroProduto, "ID", "MarcaNome", cadastroitemorcamento.ItemOrcamentoProduto);
            return View(cadastroitemorcamento);
        }

        //
        // GET: /Projetos/ItemOrcamento/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroItemOrcamento cadastroitemorcamento = db.CadastroItemOrcamento.Find(id);
            if (cadastroitemorcamento == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemOrcamentoProduto = new SelectList(db.CadastroProduto, "ID", "MarcaNome", cadastroitemorcamento.ItemOrcamentoProduto);
            return View(cadastroitemorcamento);
        }

        //
        // POST: /Projetos/ItemOrcamento/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroItemOrcamento cadastroitemorcamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroitemorcamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemOrcamentoProduto = new SelectList(db.CadastroProduto, "ID", "MarcaNome", cadastroitemorcamento.ItemOrcamentoProduto);
            return View(cadastroitemorcamento);
        }

        //
        // GET: /Projetos/ItemOrcamento/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            CadastroItemOrcamento cadastroitemorcamento = db.CadastroItemOrcamento.Find(id);
            if (cadastroitemorcamento == null)
            {
                return HttpNotFound();
            }
            return View(cadastroitemorcamento);
        }

        //
        // POST: /Projetos/ItemOrcamento/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroItemOrcamento cadastroitemorcamento = db.CadastroItemOrcamento.Find(id);
            db.CadastroItemOrcamento.Remove(cadastroitemorcamento);
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
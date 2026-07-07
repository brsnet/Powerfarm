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
    public class FazendasController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Fazenda/
        [Authorize]
        public ActionResult Index(string FazendaBusca)
        {

            if (FazendaBusca != "" && FazendaBusca != null)
            {
                List<FazendaTotals> produtolist = (from FazendaTotals in db.FazendaTotals select FazendaTotals).Where(s => s.FazendaNome.Contains(FazendaBusca)).ToList();
                return View(produtolist);
            }

            return View(db.FazendaTotals.ToList());
        }

        //
        // GET: /Fazenda/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroFazenda cadastrofazenda = db.CadastroFazenda.Find(id);
            if (cadastrofazenda == null)
            {
                return HttpNotFound();
            }
            return View(cadastrofazenda);
        }

        //
        // GET: /Fazenda/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["Culturas"] = db.Cultura.AsEnumerable().Select(x => new SelectListItem {
                Text= x.NomeCultura,
                Value = Convert.ToString(x.ID)
                });
            //ViewData["UsuariosArrendamento"] = db.CadastroUsuarios.AsEnumerable().Select(x => new SelectListItem
            //{
            //    Text = x.Nome,
            //    Value = Convert.ToString(x.ID)
            //});

            //número mágico

            ViewBag.ValorSoja = (from Cultura in db.Cultura where (Cultura.CulturaCalculo == true) select Cultura.ValorSaca).FirstOrDefault();
            ViewBag.Microrregioes = db.CadastroMicrorregiao.AsEnumerable();
            
            return View();
        }

        //
        // POST: /Fazenda/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroFazenda cadastrofazenda)
        {
            if (ModelState.IsValid)
            {
                db.CadastroFazenda.Add(cadastrofazenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(cadastrofazenda);
        }

        //
        // GET: /Fazenda/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroFazenda cadastrofazenda = db.CadastroFazenda.Find(id);
            if (cadastrofazenda == null)
            {
                return HttpNotFound();
            }
            //ViewData["UsuariosArrendamento"] = db.CadastroUsuarios.AsEnumerable().Select(x => new SelectListItem
            //{
            //    Text = x.Nome,
            //    Value = Convert.ToString(x.ID)
            //});
            ViewBag.Microrregioes = db.CadastroMicrorregiao.AsEnumerable();
            ViewData["Culturas"] = db.Cultura.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.NomeCultura,
                Value = Convert.ToString(x.ID)
            });
            ViewBag.ValorSoja = (from Cultura in db.Cultura where (Cultura.CulturaCalculo == true) select Cultura.ValorSaca).FirstOrDefault();
            return View(cadastrofazenda);
        }

        //
        // POST: /Fazenda/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroFazenda cadastrofazenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrofazenda).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(cadastrofazenda);
        }

     
        //
        // POST: /Fazenda/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {

            var deletaTerra = (from CadastroTerraSolo in db.CadastroTerraSolo where (CadastroTerraSolo.TerraSoloFazenda == id) select CadastroTerraSolo);

            foreach (var item in deletaTerra)
            {
                db.CadastroTerraSolo.Remove(item);
            }

            var deletaRelacao = (from CadastroRelacao in db.CadastroRelacao where (CadastroRelacao.RelacaoFazendaID == id) select CadastroRelacao);

            foreach (var item in deletaRelacao)
            {
                db.CadastroRelacao.Remove(item);
            }

            
            
            
            CadastroFazenda cadastrofazenda = db.CadastroFazenda.Find(id);
            db.CadastroFazenda.Remove(cadastrofazenda);

           
            
            
            
            
            
            
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
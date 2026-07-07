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
    public class ProdutoController : Controller
    {
       /* private SCPProjetosEntities db = new SCPProjetosEntities();

        //
        // GET: /Projetos/Produto/
        [Authorize]
        public ActionResult Index(string MarcaEspecificacao)
        {

            if (MarcaEspecificacao != "" && MarcaEspecificacao != null)
            {
                List<ViewProdutos> produtolist = (from ViewProdutos in db.ViewProdutos select ViewProdutos).Where(s => s.MarcaEspecificacao.Contains(MarcaEspecificacao)).ToList();
                return View(produtolist);
            }


            return View(db.ViewProdutos.ToList());
        }

        //
        // GET: /Projetos/Produto/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroProduto cadastroproduto = db.CadastroProduto.Find(id);
            if (cadastroproduto == null)
            {
                return HttpNotFound();
            }
            return View(cadastroproduto);
        }

        //
        // GET: /Projetos/Produto/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.MarcaEtapa = new SelectList(db.CadastroTipoEtapa.Where(s => s.TipoEtapaTipo == 2), "ID", "TipoEtapaNome");
            return View();
        }

        //
        // POST: /Projetos/Produto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroProduto cadastroproduto)
        {
            if (ModelState.IsValid)
            {
                db.CadastroProduto.Add(cadastroproduto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroproduto);
        }

        //
        // GET: /Projetos/Produto/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            
            
            CadastroProduto cadastroproduto = db.CadastroProduto.Find(id);
            if (cadastroproduto == null)
            {
                return HttpNotFound();
            }

            ViewBag.MarcaEtapa = new SelectList(db.CadastroTipoEtapa.Where(s=>s.TipoEtapaTipo==2), "ID", "TipoEtapaNome", cadastroproduto.MarcaEtapa);

            return View(cadastroproduto);
        }

        //
        // POST: /Projetos/Produto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroProduto cadastroproduto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroproduto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroproduto);
        }

        //
        // GET: /Projetos/Produto/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            CadastroProduto cadastroproduto = db.CadastroProduto.Find(id);
            if (cadastroproduto == null)
            {
                return HttpNotFound();
            }
            return View(cadastroproduto);
        }

        //
        // POST: /Projetos/Produto/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroProduto cadastroproduto = db.CadastroProduto.Find(id);
            db.CadastroProduto.Remove(cadastroproduto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

       */
    }
       
}
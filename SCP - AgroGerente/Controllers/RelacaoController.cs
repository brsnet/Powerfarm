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
    public class RelacaoController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Relacao/
        [Authorize]
        public ActionResult Index(string searchString)
        {

            var cadastrorelacao = (from CadastroRelacao in db.CadastroRelacao
                                   select CadastroRelacao).Include(c => c.CadastroFazenda).Include(c => c.CadastroUsuarios);

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                cadastrorelacao = cadastrorelacao.Where(s => s.RelacaoFazendaID == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazenda();
          
            
            
           
            return View(cadastrorelacao.ToList());
        }

        //
        // GET: /Relacao/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroRelacao cadastrorelacao = db.CadastroRelacao.Find(id);
            if (cadastrorelacao == null)
            {
                return HttpNotFound();
            }
            return View(cadastrorelacao);
        }

        //
        // GET: /Relacao/Create
        [Authorize]
        public ActionResult Create(int id = 0)
        {
            if (id==0)
            {
                ViewBag.RelacaoFazendaID = new SelectList(db.CadastroFazenda, "ID", "FazendaNome");
                ViewBag.RelacaoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome");
                ViewData["vRelacaoFazenda"] = EnumSCP.EnumNivelPosse;
                return View();
            }
            else
            {

                List<CadastroRelacao> NovaRelacaoCliente = (from CadastroRelacao in db.CadastroRelacao where (CadastroRelacao.RelacaoUsuarioID==id) select CadastroRelacao).ToList();
                
                return RedirectToAction("Edit", "Relacao", new { id = NovaRelacaoCliente[0].ID });
                

            }
            
           
        }

        //
        // POST: /Relacao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroRelacao cadastrorelacao)
        {
            if (ModelState.IsValid)
            {
                db.CadastroRelacao.Add(cadastrorelacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RelacaoFazendaID = new SelectList(db.CadastroFazenda, "ID", "FazendaNome", cadastrorelacao.RelacaoFazendaID);
            ViewBag.RelacaoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastrorelacao.RelacaoUsuarioID);
            return View(cadastrorelacao);
        }

        //
        // GET: /Relacao/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroRelacao cadastrorelacao = db.CadastroRelacao.Find(id);
            if (cadastrorelacao == null)
            {
                return HttpNotFound();
            }
            ViewData["vRelacaoFazenda"] = EnumSCP.EnumNivelPosse;
            ViewBag.RelacaoFazendaID = new SelectList(db.CadastroFazenda, "ID", "FazendaNome", cadastrorelacao.RelacaoFazendaID);
            ViewBag.RelacaoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastrorelacao.RelacaoUsuarioID);
            return View(cadastrorelacao);
        }

        //
        // POST: /Relacao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroRelacao cadastrorelacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrorelacao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                try
                {
                     if (Session != null && Session["novoCliente"].ToString() == "true")
                    {
                        Session["novoCliente"] = "false";
                        return RedirectToAction("Index", "Clientes");

                    }
                }
                catch (Exception)
                {
                    
                   
                }
              
            
            }


           
                return RedirectToAction("Index");
            
        }

       
        //
        // POST: /Relacao/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroRelacao cadastrorelacao = db.CadastroRelacao.Find(id);
            db.CadastroRelacao.Remove(cadastrorelacao);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;
using SCP___AgroGerente.Areas.Projetos.Model;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class OrcamentoAnaliticoController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();
        private SCPEntities dbA = new SCPEntities();

       
        

        // GET: Projetos/OrcamentoAnalitico
        public ActionResult Index()
        {

            ViewBag.PossuiSafraPrevista = (from DistribuicaoSafraFazenda in dbA.DistribuicaoSafraFazenda where DistribuicaoSafraFazenda.DistribuicaoSafraUsuarioID == UserRef.IDUsuario && DistribuicaoSafraFazenda.SafraPrevista == true select DistribuicaoSafraFazenda.SafraPrevista).Count();

            ViewBag.SafraDadosPrevista = dbA.SafraNormalPrevista.Where(s => s.CadastroSafra.SafraPrevista == true && s.SafrasCultura == 1 && s.SafrasUsuarioID == UserRef.IDUsuario).ToList();
            ViewBag.ASTEC = db.CadastroASTEC.Where(s => s.CadastroSafra.SafraPrevista == true).ToList();
            return View(db.ViewOrcamentoAnalitico.Where(s=>s.OrcamentoAnaliticoUsuarioID == UserRef.IDUsuario).OrderBy(s=>s.EtapaOrdem).ThenBy(s=>s.OrcamentoAnaliticoItemTipo).ToList());
        }

        // GET: Projetos/OrcamentoAnalitico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroOrcamentoAnalitico cadastroOrcamentoAnalitico = db.CadastroOrcamentoAnalitico.Find(id);
            if (cadastroOrcamentoAnalitico == null)
            {
                return HttpNotFound();
            }
            return View(cadastroOrcamentoAnalitico);
        }

        // GET: Projetos/OrcamentoAnalitico/Create
        public ActionResult Create()
        {
            ViewData["OrcamentoAnaliticoItemTipo"] = EnumProjetos.EnumTipoEtapa;
         
            ViewBag.OrcamentoAnaliticoSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra");
            ViewBag.OrcamentoAnaliticoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome");
            ViewBag.OrcamentoAnaliticoEtapa = new SelectList(db.CadastroEtapa, "ID", "EtapaNome");
            return View();
        }

        // POST: Projetos/OrcamentoAnalitico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrcamentoAnaliticoEtapa,OrcamentoAnaliticoItemOrcamento,OrcamentoAnaliticoItemEspecificacao,OrcamentoAnaliticoQuantidadeItemOrcamento,OrcamentoAnaliticoQuantidadePorHectarItemOrcamento,OrcamentoAnaliticoValorUnitarioItemOrcamento,OrcamentoAnaliticoSafra,OrcamentoAnaliticoUsuarioID,OrcamentoAnaliticoAtiva,OrcamentoAnaliticoItemTipo,OrcamentoAnaliticoMesInicio, OrcamentoAnaliticoMesFim")] CadastroOrcamentoAnalitico cadastroOrcamentoAnalitico)
        {
            if (ModelState.IsValid)
            {
                db.CadastroOrcamentoAnalitico.Add(cadastroOrcamentoAnalitico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["OrcamentoAnaliticoItemTipo"] = EnumProjetos.EnumTipoEtapa;
         
            ViewBag.OrcamentoAnaliticoSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroOrcamentoAnalitico.OrcamentoAnaliticoSafra);
            ViewBag.OrcamentoAnaliticoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoUsuarioID);
            ViewBag.OrcamentoAnaliticoEtapa = new SelectList(db.CadastroEtapa, "ID", "EtapaNome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoEtapa);
            return View(cadastroOrcamentoAnalitico);
        }

        // GET: Projetos/OrcamentoAnalitico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroOrcamentoAnalitico cadastroOrcamentoAnalitico = db.CadastroOrcamentoAnalitico.Find(id);
            if (cadastroOrcamentoAnalitico == null)
            {
                return HttpNotFound();
            }
            ViewData["OrcamentoAnaliticoItemTipoData"] = EnumProjetos.EnumTipoEtapa;
         
            ViewBag.OrcamentoAnaliticoSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroOrcamentoAnalitico.OrcamentoAnaliticoSafra);
            ViewBag.OrcamentoAnaliticoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoUsuarioID);
            ViewBag.OrcamentoAnaliticoEtapa = new SelectList(db.CadastroEtapa, "ID", "EtapaNome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoEtapa);
            return View(cadastroOrcamentoAnalitico);
        }

        // POST: Projetos/OrcamentoAnalitico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrcamentoAnaliticoEtapa,OrcamentoAnaliticoItemOrcamento,OrcamentoAnaliticoItemEspecificacao,OrcamentoAnaliticoQuantidadeItemOrcamento,OrcamentoAnaliticoQuantidadePorHectarItemOrcamento,OrcamentoAnaliticoValorUnitarioItemOrcamento,OrcamentoAnaliticoSafra,OrcamentoAnaliticoUsuarioID,OrcamentoAnaliticoAtiva,OrcamentoAnaliticoItemTipo,OrcamentoAnaliticoMesInicio,OrcamentoAnaliticoMesFim")] CadastroOrcamentoAnalitico cadastroOrcamentoAnalitico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroOrcamentoAnalitico).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["OrcamentoAnaliticoItemTipo"] = EnumProjetos.EnumTipoEtapa;
         
            ViewBag.OrcamentoAnaliticoSafra = new SelectList(db.CadastroSafra, "ID", "NomeSafra", cadastroOrcamentoAnalitico.OrcamentoAnaliticoSafra);
            ViewBag.OrcamentoAnaliticoUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoUsuarioID);
            ViewBag.OrcamentoAnaliticoEtapa = new SelectList(db.CadastroEtapa, "ID", "EtapaNome", cadastroOrcamentoAnalitico.OrcamentoAnaliticoEtapa);
            return View(cadastroOrcamentoAnalitico);
        }

        

        // POST: Projetos/OrcamentoAnalitico/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroOrcamentoAnalitico cadastroOrcamentoAnalitico = db.CadastroOrcamentoAnalitico.Find(id);
            db.CadastroOrcamentoAnalitico.Remove(cadastroOrcamentoAnalitico);
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

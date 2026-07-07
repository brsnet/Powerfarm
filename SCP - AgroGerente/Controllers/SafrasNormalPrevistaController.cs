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
    public class SafrasNormalPrevistaController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /SafrasNormalPrevista/
        [Authorize]
        public ActionResult Index()
        {
            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }


            var safradistribuicao = from UsuarioSafrasNormalPrevista in db.UsuarioSafrasNormalPrevista
                                    where (UsuarioSafrasNormalPrevista.SafrasUsuarioID == UserRef.IDUsuario)
                                    select UsuarioSafrasNormalPrevista;
            return View(safradistribuicao.ToList());
        }

        //
        // GET: /SafrasNormalPrevista/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            SafraNormalPrevista safranormalprevista = db.SafraNormalPrevista.Find(id);
            if (safranormalprevista == null)
            {
                return HttpNotFound();
            }
            return View(safranormalprevista);
        }

        //
        // GET: /SafrasNormalPrevista/Create
        [Authorize]
        public ActionResult Create()
        {

            ViewData["Cultura_edit"] = (IEnumerable<SelectListItem>)EnumSCP.EnumTipoCultura();
            ViewData["SafrasSafra_edit"] = EnumSCP.vSafra();
            ViewData["SafrasSistemaPlantio_edit"] = EnumSCP.EnumTipoSistemaPlantio;
            ViewData["SafrasPrevista_edit"] = EnumSCP.EnumBit;
            return View();
        }

        //
        // POST: /SafrasNormalPrevista/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(SafraNormalPrevista safranormalprevista)
        {
            if (ModelState.IsValid)
            {
                db.SafraNormalPrevista.Add(safranormalprevista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SafrasUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", safranormalprevista.SafrasUsuarioID);
            return View(safranormalprevista);
        }

        //
        // GET: /SafrasNormalPrevista/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            SafraNormalPrevista safranormalprevista = db.SafraNormalPrevista.Find(id);
            if (safranormalprevista == null)
            {
                return HttpNotFound();
            }
            ViewData["Cultura_edit"] = (IEnumerable<SelectListItem>)EnumSCP.EnumTipoCultura();
            ViewData["SafrasSafra_edit"] = EnumSCP.vSafra();
            ViewData["SafrasSistemaPlantio_edit"] = EnumSCP.EnumTipoSistemaPlantio;
            ViewData["SafrasPrevista_edit"] = EnumSCP.EnumBit;
            
            return View(safranormalprevista);
        }

        //
        // POST: /SafrasNormalPrevista/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(SafraNormalPrevista safranormalprevista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safranormalprevista).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SafrasUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", safranormalprevista.SafrasUsuarioID);
            return View(safranormalprevista);
        }

       

        //
        // POST: /SafrasNormalPrevista/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            SafraNormalPrevista safranormalprevista = db.SafraNormalPrevista.Find(id);
            db.SafraNormalPrevista.Remove(safranormalprevista);
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
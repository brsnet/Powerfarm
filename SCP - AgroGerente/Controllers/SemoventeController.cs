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
    public class SemoventeController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Semovente/
        [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }

            var ResultSearch = (from CadastroSemovente in db.CadastroSemovente
                               where (CadastroSemovente.SemoventeUsuarioID == UserRef.IDUsuario)
                               select CadastroSemovente).Include(c => c.CadastroFazenda).Include(c => c.CadastroUsuarios);;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ResultSearch = ResultSearch.Where(s => s.SemoventeFazendaID == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(ResultSearch.ToList());
            
            
        }

        //
        // GET: /Semovente/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroSemovente cadastrosemovente = db.CadastroSemovente.Find(id);
            if (cadastrosemovente == null)
            {
                return HttpNotFound();
            }
            return View(cadastrosemovente);
        }

        //
        // GET: /Semovente/Create

        public ActionResult Create()
        {
            ViewData["SemoventeFazendaID"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View();
        }

        //
        // POST: /Semovente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroSemovente cadastrosemovente)
        {
            if (ModelState.IsValid)
            {
                db.CadastroSemovente.Add(cadastrosemovente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrosemovente);
        }

        //
        // GET: /Semovente/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroSemovente cadastrosemovente = db.CadastroSemovente.Find(id);
            if (cadastrosemovente == null)
            {
                return HttpNotFound();
            }
            ViewData["SemoventeFazendaID_edit"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(cadastrosemovente);
        }

        //
        // POST: /Semovente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroSemovente cadastrosemovente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrosemovente).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrosemovente);
        }

        //
        // GET: /Semovente/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            CadastroSemovente cadastrosemovente = db.CadastroSemovente.Find(id);
            if (cadastrosemovente == null)
            {
                return HttpNotFound();
            }
            return View(cadastrosemovente);
        }

        //
        // POST: /Semovente/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroSemovente cadastrosemovente = db.CadastroSemovente.Find(id);
            db.CadastroSemovente.Remove(cadastrosemovente);
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
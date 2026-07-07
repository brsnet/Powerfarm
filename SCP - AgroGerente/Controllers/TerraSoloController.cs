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
    public class TerraSoloController : Controller
    {
        private SCPEntities db = new SCPEntities();


        
       

        //
        // GET: /TerraSolo/
        [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }

            var ResultSearch = from TerraSoloFazenda in db.TerraSoloFazenda
                           where(TerraSoloFazenda.TerraSoloUsuario == UserRef.IDUsuario)
                           select TerraSoloFazenda;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ResultSearch = ResultSearch.Where(s => s.FazendaID == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(ResultSearch.ToList());

        }

        //
        // GET: /TerraSolo/
        [Authorize]
        public ActionResult Relatorio(string searchString)
        {



            var students = from TerraSoloFazenda in db.TerraSoloFazenda
                           select TerraSoloFazenda;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.FazendaID == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazenda();
            return View(students.ToList());

        }

        //
        // GET: /TerraSolo/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroTerraSolo cadastroterrasolo = db.CadastroTerraSolo.Find(id);
            if (cadastroterrasolo == null)
            {
                return HttpNotFound();
            }
            return View(cadastroterrasolo);
        }

        //
        // GET: /TerraSolo/Create
        [Authorize]
        public ActionResult Create()
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }

            

            ViewData["EnumBit"] = EnumSCP.EnumBit;
            ViewData["TipoTerraSolo"] = EnumSCP.EnumTipoTerraSolo();
            return View();

        }

        //
        // POST: /TerraSolo/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroTerraSolo cadastroterrasolo)
        {
            if (ModelState.IsValid)
            {
                db.CadastroTerraSolo.Add(cadastroterrasolo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroterrasolo);
        }

        //
        // GET: /TerraSolo/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroTerraSolo cadastroterrasolo = db.CadastroTerraSolo.Find(id);
            if (cadastroterrasolo == null)
            {
                return HttpNotFound();
            }



            //ViewData["TerraSolo"] = EnumSCP.vTipoTerraSolo();
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["TipoTerraSolo"] = EnumSCP.EnumTipoTerraSolo();


            return View(cadastroterrasolo);
        }

        //
        // POST: /TerraSolo/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroTerraSolo cadastroterrasolo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroterrasolo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroterrasolo);
        }

      

        //
        // POST: /TerraSolo/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroTerraSolo cadastroterrasolo = db.CadastroTerraSolo.Find(id);
            db.CadastroTerraSolo.Remove(cadastroterrasolo);
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
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
    public class BenfeitoriaController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Benfeitoria/


        [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }

            var SearchResult = from BenfeitoriaFazenda in db.BenfeitoriaFazenda
                           where (BenfeitoriaFazenda.BenfeitoriaUsuario == UserRef.IDUsuario)
                           select BenfeitoriaFazenda;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                SearchResult = SearchResult.Where(s => s.BenfeitoriaFazenda1 == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(SearchResult.ToList());

        }
        [Authorize]
        public ActionResult Relatorio(string searchString)
        {

           

            var SearchResult = from BenfeitoriaFazenda in db.BenfeitoriaFazenda
                               select BenfeitoriaFazenda;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                SearchResult = SearchResult.Where(s => s.BenfeitoriaFazenda1 == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazenda();
            return View(SearchResult.ToList());

        }

        //
        // GET: /Benfeitoria/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
             BenfeitoriaFazenda cadastrobenfeitoria = db.BenfeitoriaFazenda.Find(id);
            if (cadastrobenfeitoria == null)
            {
                return HttpNotFound();
            }
            return View(cadastrobenfeitoria);
        }

        //
        // GET: /Benfeitoria/Create

        public ActionResult Create()
        {
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View();
        }

        //
        // POST: /Benfeitoria/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroBenfeitoria cadastrobenfeitoria)
        {
            if (ModelState.IsValid)
            {
                db.CadastroBenfeitoria.Add(cadastrobenfeitoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }





            return View(cadastrobenfeitoria);
        }

        //
        // GET: /Benfeitoria/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroBenfeitoria cadastrobenfeitoria = db.CadastroBenfeitoria.Find(id);
            if (cadastrobenfeitoria == null)
            {
                return HttpNotFound();
            }
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(cadastrobenfeitoria);
        }


       
        //
        // POST: /Benfeitoria/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroBenfeitoria cadastrobenfeitoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrobenfeitoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrobenfeitoria);
        }
       
        //
        // POST: /Benfeitoria/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroBenfeitoria cadastrobenfeitoria = db.CadastroBenfeitoria.Find(id);
            db.CadastroBenfeitoria.Remove(cadastrobenfeitoria);
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
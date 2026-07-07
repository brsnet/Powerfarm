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
    public class ImplementoController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Implemento/

       [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }






            return View(db.ImplementoFazendaUsuario.Where(s=>s.ImplementoUsuario == UserRef.IDUsuario).ToList());

        }
        [Authorize]
        public ActionResult Relatorio(string searchString)
        {

          

            var ResultSearch = from ImplementoFazendaUsuario in db.ImplementoFazendaUsuario
                               select ImplementoFazendaUsuario;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ResultSearch = ResultSearch.Where(s => s.IDFazenda == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazenda();
            return View(ResultSearch.ToList());

        }
        
        

        //
        // GET: /Implemento/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroImplemento cadastroimplemento = db.CadastroImplemento.Find(id);
            if (cadastroimplemento == null)
            {
                return HttpNotFound();
            }
            return View(cadastroimplemento);
        }

        //
        // GET: /Implemento/Create
        [Authorize]
        public ActionResult Create()
        {

            
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            
            return View();
        }

        //
        // POST: /Implemento/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroImplemento cadastroimplemento)
        {
            if (ModelState.IsValid)
            {
                db.CadastroImplemento.Add(cadastroimplemento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroimplemento);
        }

        //
        // GET: /Implemento/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroImplemento cadastroimplemento = db.CadastroImplemento.Find(id);
            if (cadastroimplemento == null)
            {
                return HttpNotFound();
            }


            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;

            return View(cadastroimplemento);
        }
       
      
        //
        // POST: /Implemento/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroImplemento cadastroimplemento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroimplemento).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroimplemento);
        }
       

       

        //
        // POST: /Implemento/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroImplemento cadastroimplemento = db.CadastroImplemento.Find(id);
            db.CadastroImplemento.Remove(cadastroimplemento);
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
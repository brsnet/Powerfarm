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
    public class MicrorregiaoController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Microrregiao/
        [Authorize]
        public ActionResult Index(string searchString = "0")
        {
            int idcultura = 1;
            
            if (searchString=="0")
            {
                ViewData["Culturas"] = new SelectList(db.Cultura, "ID", "NomeCultura",1);
            }
            else
            {
                idcultura = Convert.ToInt32(searchString);
                ViewData["Culturas"] = new SelectList(db.Cultura, "ID", "NomeCultura", idcultura);
            }


                ViewBag.valorcultura = db.Cultura.Find(idcultura).ValorSaca;
           
           

            



            return View(db.CadastroMicrorregiao.ToList());
        }
        
       

        //
        // GET: /Microrregiao/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroMicrorregiao cadastromicrorregiao = db.CadastroMicrorregiao.Find(id);
            if (cadastromicrorregiao == null)
            {
                return HttpNotFound();
            }
            return View(cadastromicrorregiao);
        }

        //
        // GET: /Microrregiao/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Microrregiao/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroMicrorregiao cadastromicrorregiao)
        {
            if (ModelState.IsValid)
            {
                db.CadastroMicrorregiao.Add(cadastromicrorregiao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastromicrorregiao);
        }

        //
        // GET: /Microrregiao/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroMicrorregiao cadastromicrorregiao = db.CadastroMicrorregiao.Find(id);
            if (cadastromicrorregiao == null)
            {
                return HttpNotFound();
            }
            return View(cadastromicrorregiao);
        }

        //
        // POST: /Microrregiao/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroMicrorregiao cadastromicrorregiao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastromicrorregiao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastromicrorregiao);
        }

      

        //
        // POST: /Microrregiao/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroMicrorregiao cadastromicrorregiao = db.CadastroMicrorregiao.Find(id);
            db.CadastroMicrorregiao.Remove(cadastromicrorregiao);
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
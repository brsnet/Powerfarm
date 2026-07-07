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
    public class BensDireitosController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /BensDireitos/
        [Authorize]
        public ActionResult Index()
        {


            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }


            var cadastrobensdireitos = from CadastroBensDireitos in db.CadastroBensDireitos
                                       where (CadastroBensDireitos.BensDireitosUsuarioID == UserRef.IDUsuario)
                                       select CadastroBensDireitos;
            
            return View(cadastrobensdireitos.ToList());
        }

        //
        // GET: /BensDireitos/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroBensDireitos cadastrobensdireitos = db.CadastroBensDireitos.Find(id);
            if (cadastrobensdireitos == null)
            {
                return HttpNotFound();
            }
            return View(cadastrobensdireitos);
        }

        //
        // GET: /BensDireitos/Create

        public ActionResult Create()
        {
            ViewBag.BensDireitosUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome");
            return View();
        }

        //
        // POST: /BensDireitos/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create(CadastroBensDireitos cadastrobensdireitos)
        {
            if (ModelState.IsValid)
            {
                db.CadastroBensDireitos.Add(cadastrobensdireitos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BensDireitosUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastrobensdireitos.BensDireitosUsuarioID);
            return View(cadastrobensdireitos);
        }

        //
        // GET: /BensDireitos/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroBensDireitos cadastrobensdireitos = db.CadastroBensDireitos.Find(id);
            if (cadastrobensdireitos == null)
            {
                return HttpNotFound();
            }
            ViewBag.BensDireitosUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastrobensdireitos.BensDireitosUsuarioID);
            return View(cadastrobensdireitos);
        }

        //
        // POST: /BensDireitos/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(CadastroBensDireitos cadastrobensdireitos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrobensdireitos).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BensDireitosUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastrobensdireitos.BensDireitosUsuarioID);
            return View(cadastrobensdireitos);
        }

        //
        // GET: /BensDireitos/Delete/5
        [Authorize]
        public ActionResult Delete(int id = 0)
        {
            CadastroBensDireitos cadastrobensdireitos = db.CadastroBensDireitos.Find(id);
            if (cadastrobensdireitos == null)
            {
                return HttpNotFound();
            }
            return View(cadastrobensdireitos);
        }

        //
        // POST: /BensDireitos/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroBensDireitos cadastrobensdireitos = db.CadastroBensDireitos.Find(id);
            db.CadastroBensDireitos.Remove(cadastrobensdireitos);
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
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
    public class UsuariosController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Usuarios/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.CadastroUsuarios.ToList());
        }

        //
        // GET: /Usuarios/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroUsuarios cadastrousuarios = db.CadastroUsuarios.Find(id);
            if (cadastrousuarios == null)
            {
                return HttpNotFound();
            }
            return View(cadastrousuarios);
        }

        //
        // GET: /Usuarios/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Usuarios/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroUsuarios cadastrousuarios)
        {
            if (ModelState.IsValid)
            {
                db.CadastroUsuarios.Add(cadastrousuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrousuarios);
        }

        //
        // GET: /Usuarios/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroUsuarios cadastrousuarios = db.CadastroUsuarios.Find(id);
            if (cadastrousuarios == null)
            {
                return HttpNotFound();
            }

            return View(cadastrousuarios);
        }

        //
        // POST: /Usuarios/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroUsuarios cadastrousuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrousuarios).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrousuarios);
        }

       

        //
        // POST: /Usuarios/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroUsuarios cadastrousuarios = db.CadastroUsuarios.Find(id);
            db.CadastroUsuarios.Remove(cadastrousuarios);
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
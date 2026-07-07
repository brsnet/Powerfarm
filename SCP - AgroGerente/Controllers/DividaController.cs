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
    public class DividaController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Divida/
        [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }


            return View(db.DividaUsuario.Where(s=>s.DividaUsuario1 == UserRef.IDUsuario).ToList());
            
            
            
           
        }

        


        //
        // GET: /Divida/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroDivida cadastrodivida = db.CadastroDivida.Find(id);
            if (cadastrodivida == null)
            {
                return HttpNotFound();
            }
            return View(cadastrodivida);
        }

        //
        // GET: /Divida/Create
        [Authorize]
        public ActionResult Create()
        {
            var vNomeUsuario = (from CadastroUsuarios in db.CadastroUsuarios select CadastroUsuarios).AsEnumerable()
                                
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.Nome,
                                    Value = x.ID.ToString()
                                });
            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;

            return View();
        }

        //
        // POST: /Divida/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroDivida cadastrodivida)
        {
            if (ModelState.IsValid)
            {
                db.CadastroDivida.Add(cadastrodivida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastrodivida);
        }

        //
        // GET: /Divida/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroDivida cadastrodivida = db.CadastroDivida.Find(id);
            if (cadastrodivida == null)
            {
                return HttpNotFound();
            }


            var vNomeUsuario = (from CadastroUsuarios in db.CadastroUsuarios select CadastroUsuarios).AsEnumerable()

                               .Select(
                               x => new SelectListItem
                               {
                                   Text = x.Nome,
                                   Value = x.ID.ToString()
                               });
            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            return View(cadastrodivida);
        }

        //
        // POST: /Divida/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroDivida cadastrodivida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrodivida).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrodivida);
        }

      

        //
        // POST: /Divida/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroDivida cadastrodivida = db.CadastroDivida.Find(id);
            db.CadastroDivida.Remove(cadastrodivida);
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
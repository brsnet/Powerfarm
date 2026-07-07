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
    public class QuestionarioController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Questionario/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.CadastroQuestionario.ToList());
        }

        //
        // GET: /Questionario/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroQuestionario cadastroquestionario = db.CadastroQuestionario.Find(id);
            if (cadastroquestionario == null)
            {
                return HttpNotFound();
            }
            return View(cadastroquestionario);
        }

        //
        // GET: /Questionario/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Questionario/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroQuestionario cadastroquestionario)
        {
            if (ModelState.IsValid)
            {
                db.CadastroQuestionario.Add(cadastroquestionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroquestionario);
        }

        //
        // GET: /Questionario/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroQuestionario cadastroquestionario = db.CadastroQuestionario.Find(id);
            if (cadastroquestionario == null)
            {
                return HttpNotFound();
            }
            return View(cadastroquestionario);
        }

        //
        // POST: /Questionario/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroQuestionario cadastroquestionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroquestionario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroquestionario);
        }

        //
        // POST: /Questionario/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroQuestionario cadastroquestionario = db.CadastroQuestionario.Find(id);
            db.CadastroQuestionario.Remove(cadastroquestionario);
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
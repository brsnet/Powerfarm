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
    public class CulturaController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Cultura/
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Cultura.ToList());
        }

        //
        // GET: /Cultura/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Cultura cultura = db.Cultura.Find(id);
            if (cultura == null)
            {
                return HttpNotFound();
            }
            return View(cultura);
        }

        //
        // GET: /Cultura/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View();
        }

        //
        // POST: /Cultura/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(Cultura cultura)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    int culturaAgora = (from Cultura in db.Cultura where (Cultura.CulturaCalculo == true) select Cultura.ID).FirstOrDefault();



                    if (cultura.CulturaCalculo == true && culturaAgora != 0)// && cultura.ID != culturaAgora)
                    {



                        Cultura limpaSafraPrevista = db.Cultura.Find(culturaAgora);

                        limpaSafraPrevista.CulturaCalculo = false;

                        db.Cultura.Add(cultura);
                        db.Entry(limpaSafraPrevista).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        db.Cultura.Add(cultura);
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    throw;
                }




                return RedirectToAction("Index");
            }

            return View(cultura);
        }

        //
        // GET: /Cultura/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Cultura cultura = db.Cultura.Find(id);
            if (cultura == null)
            {
                return HttpNotFound();
            }
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View(cultura);
        }

        //
        // POST: /Cultura/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Cultura cultura)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    int culturaAgora = (from Cultura in db.Cultura where (Cultura.CulturaCalculo == true) select Cultura.ID).FirstOrDefault();



                    if (cultura.CulturaCalculo == true && cultura.ID != culturaAgora && culturaAgora != 0)
                    {


                        Cultura limpaSafraPrevista = db.Cultura.Find(culturaAgora);

                        limpaSafraPrevista.CulturaCalculo = false;

                        db.Entry(cultura).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        db.Entry(limpaSafraPrevista).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    else
                    {
                        db.Entry(cultura).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {

                }


                return RedirectToAction("Index");
            }
            return View(cultura);
        }


        //
        // POST: /Cultura/Delete/5

        [HttpPost]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Cultura cultura = db.Cultura.Find(id);
            db.Cultura.Remove(cultura);
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
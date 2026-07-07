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
    public class SafraController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Safra/
        [Authorize]
        public ActionResult Index()
        {
            UserRef.SafraPrevista = db.CadastroSafra.FirstOrDefault(s => s.SafraPrevista == true).NomeSafra;
            return View(db.CadastroSafra.OrderByDescending(s=>s.SafraPrevista).ToList());
        }

        //
        // GET: /Safra/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroSafra cadastrosafra = db.CadastroSafra.Find(id);
            if (cadastrosafra == null)
            {
                return HttpNotFound();
            }
            return View(cadastrosafra);
        }

        //
        // GET: /Safra/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View();
        }

        //
        // POST: /Safra/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroSafra cadastrosafra)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    int limpaCalculoSelecao = (int)(from CadastroSafra in db.CadastroSafra where (CadastroSafra.SafraPrevista == true) select CadastroSafra.ID).FirstOrDefault();


                    if (cadastrosafra.SafraPrevista == true && limpaCalculoSelecao != 0)
                    {
                        

                        CadastroSafra Atualiza = db.CadastroSafra.Find(limpaCalculoSelecao);

                      
                        Atualiza.SafraPrevista = false;

                        db.CadastroSafra.Add(cadastrosafra);
                        db.SaveChanges();
                        db.Entry(Atualiza).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                           
                        

                    }
                }
                catch (Exception)
                {

                }

               
                return RedirectToAction("Index");
            }

            return View(cadastrosafra);
        }

        //
        // GET: /Safra/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroSafra cadastrosafra = db.CadastroSafra.Find(id);
            if (cadastrosafra == null)
            {
                return HttpNotFound();
            }
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View(cadastrosafra);
        }

        //
        // POST: /Safra/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroSafra cadastrosafra)
        {
            if (ModelState.IsValid)
            {

                try
                {

                    int limpaCalculoSelecao = (from CadastroSafra in db.CadastroSafra where (CadastroSafra.SafraPrevista == true) select CadastroSafra.ID).FirstOrDefault();


                    if (cadastrosafra.SafraPrevista == true && cadastrosafra.ID != limpaCalculoSelecao && limpaCalculoSelecao != 0)
                    {


                        CadastroSafra Atualiza = db.CadastroSafra.Find(limpaCalculoSelecao);

                      
                        Atualiza.SafraPrevista = false;

                        db.Entry(cadastrosafra).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        db.Entry(Atualiza).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                       

                    }
                }
                catch (Exception)
                {

                }


                return RedirectToAction("Index");
            }
            return View(cadastrosafra);
        }

       

        //
        // POST: /Safra/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroSafra cadastrosafra = db.CadastroSafra.Find(id);
            db.CadastroSafra.Remove(cadastrosafra);
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
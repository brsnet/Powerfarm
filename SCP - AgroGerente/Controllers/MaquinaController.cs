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
    public class MaquinaController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Maquina/


        [Authorize]
        public ActionResult Index()
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }







            return View(db.MaquinaFazendaUsuario.Where(s=>s.MaquinaUsuario == UserRef.IDUsuario).ToList());

        }

        [Authorize]
        public ActionResult Relatorio(string searchString)
        {

           
            var ResultSearch = from MaquinaFazendaUsuario in db.MaquinaFazendaUsuario
                               select MaquinaFazendaUsuario;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ResultSearch = ResultSearch.Where(s => s.MaquinaFazendaOrigem == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazenda();
            return View(ResultSearch.ToList());

        }

        

        //
        // GET: /Maquina/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroMaquina cadastromaquina = db.CadastroMaquina.Find(id);
            if (cadastromaquina == null)
            {
                return HttpNotFound();
            }
            return View(cadastromaquina);
        }

        //
        // GET: /Maquina/Create
        [Authorize]
        public ActionResult Create()
        {
           
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            
            return View();
        }

        //
        // POST: /Maquina/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroMaquina cadastromaquina)
        {
            if (ModelState.IsValid)
            {
                db.CadastroMaquina.Add(cadastromaquina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastromaquina);
        }

        //
        // GET: /Maquina/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroMaquina cadastromaquina = db.CadastroMaquina.Find(id);
            if (cadastromaquina == null)
            {
                return HttpNotFound();
            }

            
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;


            return View(cadastromaquina);
        }

        //
        // POST: /Maquina/Edit/5

        

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroMaquina cadastromaquina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastromaquina).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastromaquina);
        }

       

        //
        // POST: /Maquina/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroMaquina cadastromaquina = db.CadastroMaquina.Find(id);
            db.CadastroMaquina.Remove(cadastromaquina);
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
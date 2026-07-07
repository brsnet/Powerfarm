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
    public class VeiculoController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /Veiculo/8

       
        [Authorize]
        public ActionResult Index(string searchString)
        {

            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }

            var ResultSearch = from VeiculoFazendaUsuario in db.VeiculoFazendaUsuario
                               where (VeiculoFazendaUsuario.IDUsuario == UserRef.IDUsuario)
                               select VeiculoFazendaUsuario;

            int storeNum;
            int? stnum = int.TryParse(searchString, out storeNum) ? storeNum : (int?)null;
            if (!String.IsNullOrEmpty(searchString))
            {
                ResultSearch = ResultSearch.Where(s => s.IDFazenda == stnum);
            }




            ViewData["Fazendas"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            return View(ResultSearch.ToList());

        }

        [Authorize]
        public ActionResult Relatorio(string searchString)
        {

           
            var ResultSearch = from VeiculoFazendaUsuario in db.VeiculoFazendaUsuario
                               select VeiculoFazendaUsuario;

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
        // GET: /Veiculo/Details/5

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroVeiculo cadastroveiculo = db.CadastroVeiculo.Find(id);
            if (cadastroveiculo == null)
            {
                return HttpNotFound();
            }
            return View(cadastroveiculo);
        }

        //
        // GET: /Veiculo/Create
        [Authorize]
        public ActionResult Create()
        {
           
            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View();
        }

        //
        // POST: /Veiculo/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(CadastroVeiculo cadastroveiculo)
        {
            if (ModelState.IsValid)
            {
                db.CadastroVeiculo.Add(cadastroveiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cadastroveiculo);
        }

        //
        // GET: /Veiculo/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroVeiculo cadastroveiculo = db.CadastroVeiculo.Find(id);
            if (cadastroveiculo == null)
            {
                return HttpNotFound();
            }


            ViewData["Fazendas"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumBit"] = EnumSCP.EnumBit;
            return View(cadastroveiculo);
        }

        //
        // POST: /Veiculo/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroVeiculo cadastroveiculo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroveiculo).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastroveiculo);
        }



        

        //
        // POST: /Veiculo/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroVeiculo cadastroveiculo = db.CadastroVeiculo.Find(id);
            db.CadastroVeiculo.Remove(cadastroveiculo);
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
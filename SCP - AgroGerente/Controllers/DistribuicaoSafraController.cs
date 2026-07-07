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
    public class DistribuicaoSafraController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /DistribuicaoSafra/
        [Authorize]
        public ActionResult Index()
        {


            if (Session != null && Session["UserID"] == null)
            {
                return Redirect("/");
            }


            var safradistribuicao = from DistribuicaoSafraFazenda in db.DistribuicaoSafraFazenda
                                    where (DistribuicaoSafraFazenda.DistribuicaoSafraUsuarioID == UserRef.IDUsuario && DistribuicaoSafraFazenda.IDProprietário == UserRef.IDUsuario && DistribuicaoSafraFazenda.SafraPrevista ==true)
                                    select DistribuicaoSafraFazenda;
            return View(safradistribuicao.OrderBy(s => s.DistribuicaoSafraTipo).ToList());
        }

        //
        // GET: /DistribuicaoSafra/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            SafraDistribuicao safradistribuicao = db.SafraDistribuicao.Find(id);
            if (safradistribuicao == null)
            {
                return HttpNotFound();
            }
            return View(safradistribuicao);
        }

        //
        // GET: /DistribuicaoSafra/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewData["Culturas"] = db.Cultura.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.NomeCultura,
                Value = Convert.ToString(x.ID)
            });
            ViewData["funcaodistribuicaoareasafra"] = (from funcaodistribuicaoAreaSafra in db.funcaodistribuicaoAreaSafra where funcaodistribuicaoAreaSafra.ID == UserRef.IDUsuario select funcaodistribuicaoAreaSafra.RestanteArea).FirstOrDefault();
            ViewData["DistribuicaoSafraSafra"] = (IEnumerable<SelectListItem>)EnumSCP.vSafra();
            ViewData["EnumTipoDistribuicaoSafra"] = EnumSCP.EnumTipoDistribuicaoSafra;
            ViewData["DistribuicaoSafraSistemaPlantio"] = EnumSCP.EnumTipoSistemaPlantio;
            ViewData["DistribuicaoSafraFazenda"] = (IEnumerable<SelectListItem>)EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumObservacaoGravame"] = EnumSCP.EnumObsGravameSafra;
            

            return View();
        }

        //
        // POST: /DistribuicaoSafra/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(SafraDistribuicao safradistribuicao)
        {
            if (ModelState.IsValid)
            {
                db.SafraDistribuicao.Add(safradistribuicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            return View(safradistribuicao);
        }

        //
        // GET: /DistribuicaoSafra/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            SafraDistribuicao safradistribuicao = db.SafraDistribuicao.Find(id);
            if (safradistribuicao == null)
            {
                return HttpNotFound();
            }


            ViewData["Culturas"] = db.Cultura.AsEnumerable().Select(x => new SelectListItem
            {
                Text = x.NomeCultura,
                Value = Convert.ToString(x.ID)
            });
            ViewData["DistribuicaoSafraSafra_edit"] = EnumSCP.vSafra();
            ViewData["DistribuicaoSafraTipo_edit"] = EnumSCP.EnumTipoDistribuicaoSafra;
            ViewData["DistribuicaoSafraSistemaPlantio_edit"] = EnumSCP.EnumTipoSistemaPlantio;
            ViewData["DistribuicaoSafraFazenda_edit"] = EnumSCP.vNomeFazendaDistinct(UserRef.IDUsuario);
            ViewData["EnumObservacaoGravame"] = EnumSCP.EnumObsGravameSafra;
           



            return View(safradistribuicao);
        }

        //
        // POST: /DistribuicaoSafra/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(SafraDistribuicao safradistribuicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(safradistribuicao).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(safradistribuicao);
        }

       

        //
        // POST: /DistribuicaoSafra/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            SafraDistribuicao safradistribuicao = db.SafraDistribuicao.Find(id);
            db.SafraDistribuicao.Remove(safradistribuicao);
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
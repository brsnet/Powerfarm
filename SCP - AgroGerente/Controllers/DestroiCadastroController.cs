using SCP___AgroGerente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCP___AgroGerente.Controllers
{
    public class DestroiCadastroController : Controller
    {
        private SCPEntities db = new SCPEntities();
        //
        // GET: /DestroiCadastro/
        [Authorize]
        public ActionResult Index()
        {


            var vNomeProprietarios = (from Proprietarios in db.Proprietarios



                                      select new { vNome = Proprietarios.Nome, vID = Proprietarios.ID }).AsEnumerable()
                             .Select(
                             x => new SelectListItem
                             {
                                 Text = x.vNome,
                                 Value = x.vID.ToString()
                             });

            ViewData["Proprietarios"] = (IEnumerable<SelectListItem>)vNomeProprietarios;

            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Index(cloneProfile clonados)
        {


            db.DestroiCadastro(clonados.UserClonedId);


            return RedirectToAction("Index", "Home");

        }

    }
}

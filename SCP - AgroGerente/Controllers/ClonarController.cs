using SCP___AgroGerente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCP___AgroGerente.Controllers
{
    public class ClonarController : Controller
    {
        private SCPEntities db = new SCPEntities();
       
        //
        // GET: /Clonar/
        [Authorize]
        public ActionResult Index()
        {


            var vNomeUsuario = (from CadastroUsuarios in db.CadastroUsuarios
                                where !(from CadastroClientes in db.CadastroClientes
                                        select CadastroClientes.ClienteDadosUsuario)
                                .Contains(CadastroUsuarios.ID)
                                select CadastroUsuarios).AsEnumerable()
                               .Select(
                               x => new SelectListItem
                               {
                                   Text = x.Nome,
                                   Value = x.ID.ToString()
                               });

             var vNomeProprietarios = (from Proprietarios in db.Proprietarios



                            select new { vNome = Proprietarios.Nome, vID = Proprietarios.ID }).AsEnumerable()
                            .Select(
                            x => new SelectListItem
                            {
                                Text = x.vNome,
                                Value = x.vID.ToString()
                            });

            ViewData["Proprietarios"] = (IEnumerable<SelectListItem>)vNomeProprietarios;

            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            return View();
        }



        [HttpPost]
        [Authorize]
        public ActionResult Index(cloneProfile clonados)
        {


            db.CloneCadastroPatrimonio(clonados.UserToCloneId, clonados.UserClonedId);


            return RedirectToAction("Usuario", "Home", new { id = clonados.UserToCloneId });

        }

    }
}

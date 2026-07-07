using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Controllers
{
    public class HomeController : Controller
    {
        private SCPEntities db = new SCPEntities();

        [Authorize]
        public ActionResult Index(int id = 0)
        {


            var vNomeUsuario = (from Proprietarios in db.Proprietarios

                             

                                select new { vNome = Proprietarios.Nome, vID = Proprietarios.ID }).AsEnumerable()
                             .Select(
                             x => new SelectListItem
                             {
                                 Text = x.vNome,
                                 Value = x.vID.ToString()
                             });


          
            List<Proprietarios> Clientes = (from Proprietarios in db.Proprietarios select Proprietarios).OrderBy(s => s.Nome).ToList();

            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            ViewBag.Clientes = Clientes;
            ViewBag.Limites = db.LimiteCredito.OrderByDescending(s => s.EntidadeDataCadastro).Take(5).ToList();
            UserRef.SafraPrevista = db.CadastroSafra.FirstOrDefault(s => s.SafraPrevista == true).NomeSafra;
            return View();
        }
        [Authorize]
        public ActionResult Usuario(int id = 0)
        {



            VerificacaoDadosGerais VerificacaoDadosGerais = db.VerificacaoDadosGerais.Find(id);

            UserRef.IDUsuario = id;
            UserRef.NomeUsuario = VerificacaoDadosGerais.Nome;
            




            if (VerificacaoDadosGerais == null)
            {
                return HttpNotFound();
            }



            //ViewData["ResumoFazendas"] = db.ResumoFazendas.Where(s => s.ID == id).ToList();
            //ViewData["ResumoFazendasArrendadas"] = db.ResumoFazendasArrendadas.Where(s => s.ID == id).ToList();
            ViewData["Fazendas"] = db.FazendaTotals.Where(s => s.RelacaoTitulo == 1 && s.RelacaoUsuarioID == id).ToList();
            ViewData["FazendasArrendadas"] = db.FazendaTotals.Where(s => s.RelacaoTitulo == 2 && s.RelacaoUsuarioID == id).ToList();

            return View(VerificacaoDadosGerais);
        }
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        [Authorize]
        public ActionResult PendenciasGeracaoCredito()
        {
           return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
    }
}

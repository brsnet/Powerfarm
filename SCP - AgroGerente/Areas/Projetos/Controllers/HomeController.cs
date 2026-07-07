using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;
using SCP___AgroGerente.Areas.Projetos.Model;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Projetos/Home


        private SCPEntities db = new SCPEntities();
        private SCPProjetosEntities dbP = new SCPProjetosEntities();

        [Authorize]
        public ActionResult Index()
        {


            var vNomeUsuario = (from Proprietarios in db.Proprietarios



                            select new { vNome = Proprietarios.Nome, vID = Proprietarios.ID }).AsEnumerable()
                            .Select(
                            x => new SelectListItem
                            {
                                Text = x.vNome,
                                Value = x.vID.ToString()
                            });

            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            ViewData["AgendaAplicacoes"] = dbP.ViewAgendaAplicacoes.OrderBy(s =>s.MesInicio).ToList();
            return View();
        }
        [Authorize]
        public ActionResult Usuario(int id = 0)
        {


            ViewData["TiposQuestoes"] = dbP.CadastroBQTipo.ToList();
            VerificacaoDadosGerais VerificacaoDadosGerais = db.VerificacaoDadosGerais.Find(id);

            UserRef.IDUsuario = id;
            UserRef.NomeUsuario = VerificacaoDadosGerais.Nome;



            if (VerificacaoDadosGerais == null)
            {
                return HttpNotFound();
            }



            ViewData["AgendaAplicações"] = dbP.ViewOrcamentoAnalitico.Where(s => s.OrcamentoAnaliticoUsuarioID == UserRef.IDUsuario).OrderBy(s => s.EtapaOrdem).ThenBy(s => s.OrcamentoAnaliticoItemTipo).ThenBy(s=>s.OrcamentoAnaliticoMesInicio).ToList();
            //ViewData["ResumoFazendasArrendadas"] = db.ResumoFazendasArrendadas.Where(s => s.ID == id).ToList();
            //ViewData["Fazendas"] = db.FazendaTotals.Where(s => s.RelacaoUsuarioID == id).ToList();
            //ViewData["FazendasArrendadas"] = db.FazendaTotals.Where(s => s.FazendaArrendadaUsuario == id).ToList();


            return View(VerificacaoDadosGerais);
        }

    }
}

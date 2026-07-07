using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Areas.Projetos.Model;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class CadastroBQRespostasController : Controller
    {
        private SCPProjetosEntities db = new SCPProjetosEntities();

        // GET: Projetos/CadastroBQRespostas
        public ActionResult Index(int id)
        {


            var CadastroBQ = db.ViewRespostasPerguntas.Where(s => s.BancoQuestoesTipo == id && s.BQRespostaUsuarioID == null || s.BancoQuestoesTipo == id && s.BQRespostaUsuarioID == UserRef.IDUsuario).ToList();
            return View(CadastroBQ);
            //var cadastroBQResposta = db.CadastroBQResposta.Include(c => c.CadastroSafra).Include(c => c.CadastroUsuarios).Include(c => c.CadastroBancoQuestoes);
            //return View(cadastroBQResposta.Where(s => s.CadastroBancoQuestoes.BancoQuestoesTipo == BDQID && s.BQRespostaUsuarioID == UserRef.IDUsuario).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int id,FormCollection collection)
        {


            int totalRows = Convert.ToInt32(collection["conter"]);


            CadastroBQResposta cadastroquestoes = new CadastroBQResposta();


            for (int i = 1; i <= totalRows; i++)
            {



                if (collection["IDResposta" + i] == "" && collection["TextareaResposta" + i] != "")
                {

                    
                    cadastroquestoes.BQRespostaPergunta = Convert.ToInt32(collection["CadastroBancoQuestoesBancoQuestoesPergunta" + i]);
                    cadastroquestoes.BQRespostaResposta = collection["TextareaResposta" + i];
                    cadastroquestoes.BQRespostaSafra = (from CadastroSafra in db.CadastroSafra where CadastroSafra.SafraPrevista == true select CadastroSafra.ID).FirstOrDefault();
                    cadastroquestoes.BQRespostaUsuarioID = UserRef.IDUsuario;

                    db.CadastroBQResposta.Add(cadastroquestoes);
                    db.SaveChanges();
                }
                else if (collection["TextareaResposta" + i] != "")
                {
                    
               
                    int IDUsado = Convert.ToInt32(collection["IDResposta" + i]);

                    CadastroBQResposta Atualizaquestoes = db.CadastroBQResposta.Find(IDUsado);

                    Atualizaquestoes.BQRespostaResposta = collection["TextareaResposta" + i];

                    db.Entry(Atualizaquestoes).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }


            }



            var CadastroBQ = db.ViewRespostasPerguntas.Where(s => s.BancoQuestoesTipo == id && s.BQRespostaUsuarioID == null || s.BancoQuestoesTipo == id && s.BQRespostaUsuarioID == UserRef.IDUsuario).ToList();
            return View(CadastroBQ);

        }
        // GET: Projetos/CadastroBQRespostas/Details/5

      
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBQResposta cadastroBQResposta = db.CadastroBQResposta.Find(id);
            if (cadastroBQResposta == null)
            {
                return HttpNotFound();
            }
            return View(cadastroBQResposta);
        }

        // GET: Projetos/CadastroBQRespostas/Create
        public ActionResult Create(int BDQID)
        {
            ViewBag.BQRespostaSafra = new SelectList(db.CadastroSafra, "ID", "SafraData");
            ViewBag.BQRespostaUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome");
            ViewBag.BQRespostaPergunta = new SelectList(db.CadastroBancoQuestoes, "ID", "BancoQuestoesPergunta");
            return View();
        }

        // POST: Projetos/CadastroBQRespostas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BQRespostaPergunta,BQRespostaResposta,BQRespostaSafra,BQRespostaUsuarioID")] CadastroBQResposta cadastroBQResposta)
        {
            if (ModelState.IsValid)
            {
                db.CadastroBQResposta.Add(cadastroBQResposta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BQRespostaSafra = new SelectList(db.CadastroSafra, "ID", "SafraData", cadastroBQResposta.BQRespostaSafra);
            ViewBag.BQRespostaUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroBQResposta.BQRespostaUsuarioID);
            ViewBag.BQRespostaPergunta = new SelectList(db.CadastroBancoQuestoes, "ID", "BancoQuestoesPergunta", cadastroBQResposta.BQRespostaPergunta);
            return View(cadastroBQResposta);
        }

        // GET: Projetos/CadastroBQRespostas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBQResposta cadastroBQResposta = db.CadastroBQResposta.Find(id);
            if (cadastroBQResposta == null)
            {
                return HttpNotFound();
            }
            ViewBag.BQRespostaSafra = new SelectList(db.CadastroSafra, "ID", "SafraData", cadastroBQResposta.BQRespostaSafra);
            ViewBag.BQRespostaUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroBQResposta.BQRespostaUsuarioID);
            ViewBag.BQRespostaPergunta = new SelectList(db.CadastroBancoQuestoes, "ID", "BancoQuestoesPergunta", cadastroBQResposta.BQRespostaPergunta);
            return View(cadastroBQResposta);
        }

        // POST: Projetos/CadastroBQRespostas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BQRespostaPergunta,BQRespostaResposta,BQRespostaSafra,BQRespostaUsuarioID")] CadastroBQResposta cadastroBQResposta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroBQResposta).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BQRespostaSafra = new SelectList(db.CadastroSafra, "ID", "SafraData", cadastroBQResposta.BQRespostaSafra);
            ViewBag.BQRespostaUsuarioID = new SelectList(db.CadastroUsuarios, "ID", "Nome", cadastroBQResposta.BQRespostaUsuarioID);
            ViewBag.BQRespostaPergunta = new SelectList(db.CadastroBancoQuestoes, "ID", "BancoQuestoesPergunta", cadastroBQResposta.BQRespostaPergunta);
            return View(cadastroBQResposta);
        }

        // GET: Projetos/CadastroBQRespostas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CadastroBQResposta cadastroBQResposta = db.CadastroBQResposta.Find(id);
            if (cadastroBQResposta == null)
            {
                return HttpNotFound();
            }
            return View(cadastroBQResposta);
        }

        // POST: Projetos/CadastroBQRespostas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CadastroBQResposta cadastroBQResposta = db.CadastroBQResposta.Find(id);
            db.CadastroBQResposta.Remove(cadastroBQResposta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

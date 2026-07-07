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
    public class RespostaQuestionarioController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /RespostaQuestionario/
        [Authorize]
        public ActionResult Index(int ID = 0)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                int stnum = (int)Session["UserID"];
                return View(db.QuestionarioResposta.Where(p => p.QuestionarioRespostaUsuario == stnum).ToList());
            }
        }

        //
        // GET: /RespostaQuestionario/Details/5
        [Authorize]
        public ActionResult Details(int id = 0)
        {
            CadastroRespostaQuestionario cadastrorespostaquestionario = db.CadastroRespostaQuestionario.Find(id);
            if (cadastrorespostaquestionario == null)
            {
                return HttpNotFound();
            }
            return View(cadastrorespostaquestionario);
        }

        //
        // GET: /RespostaQuestionario/Create
        [Authorize]
        public ActionResult Create()
        {
            List<Proc_Questoes_Result> Resutado = db.Proc_Questoes((int)Session["UserID"]).ToList();

            ViewData["DataVer"] = Resutado;


            return View(db.CadastroRespostaQuestionario.ToList());
        }

        //
        // POST: /RespostaQuestionario/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(FormCollection collection)
        {

            int totalRows = Convert.ToInt32(collection["TotalRows"])+1;
            CadastroRespostaQuestionario cadastrorespostaquestionario = new CadastroRespostaQuestionario();


            for (int i = 1; i < totalRows; i++)
             {
                 

                 if (collection["Resposta" + i]!=null)
                 {
                     cadastrorespostaquestionario.QuestionarioRespostaUsuario = Convert.ToInt32(collection["Usuario"]);
                     cadastrorespostaquestionario.QuestionarioRespostaQuestao = Convert.ToInt32(collection["Questao" + i]);
                     cadastrorespostaquestionario.QuestionarioRespostaResposta1 = collection["Resposta" + i];
                     db.CadastroRespostaQuestionario.Add(cadastrorespostaquestionario);
                     db.SaveChanges();
                 }
                
              
             }
               
                return RedirectToAction("Index");
           

           
        }

        //
        // GET: /RespostaQuestionario/Edit/5
        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            CadastroRespostaQuestionario cadastrorespostaquestionario = db.CadastroRespostaQuestionario.Find(id);
            if (cadastrorespostaquestionario == null)
            {
                return HttpNotFound();
            }
            return View(cadastrorespostaquestionario);
        }

        //
        // POST: /RespostaQuestionario/Edit/5

        [HttpPost]
        [Authorize]
        public ActionResult Edit(CadastroRespostaQuestionario cadastrorespostaquestionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastrorespostaquestionario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cadastrorespostaquestionario);
        }

        
        //
        // POST: /RespostaQuestionario/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            CadastroRespostaQuestionario cadastrorespostaquestionario = db.CadastroRespostaQuestionario.Find(id);
            db.CadastroRespostaQuestionario.Remove(cadastrorespostaquestionario);
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
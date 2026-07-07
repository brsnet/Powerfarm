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
    public class ClientesController : Controller
    {
        private SCPEntities db = new SCPEntities();
        
       
        //
        // GET: /Clientes/
        [Authorize] 
        public ActionResult Index()
        {

            return View(db.ClienteFazenda.ToList());
        }

       
        //
        // GET: /Clientes/Create

        [Authorize] 
        public ActionResult Create()
        {

           
            
          
         
             var vNomeUsuario = (from CadastroUsuarios in db.CadastroUsuarios
                                where !(from CadastroClientes in db.CadastroClientes
                                        select CadastroClientes.ClienteDadosUsuario)
                                .Contains(CadastroUsuarios.ID) select CadastroUsuarios).AsEnumerable()
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.Nome,
                                    Value = x.ID.ToString()
                                });

             var vNomeUsuarioFull = (from CadastroUsuarios in db.CadastroUsuarios
                                      select CadastroUsuarios).AsEnumerable()
                                 .Select(
                                 x => new SelectListItem
                                 {
                                     Text = x.Nome,
                                     Value = x.ID.ToString()
                                 });


            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            ViewData["TUsuarios"] = (IEnumerable<SelectListItem>)vNomeUsuarioFull;
            ViewData["EstadoCivil"] = EnumSCP.EnumEstadoCivil;
            return View();
        }

        //
        // POST: /Clientes/Create

        [HttpPost]
        [Authorize] 
        public ActionResult Create(CadastroClientes cadastroclientes)
        {
            if (ModelState.IsValid)
            {
                
                CadastroRelacao RegistroRelacao = new CadastroRelacao();
                RegistroRelacao.RelacaoUsuarioID = cadastroclientes.ClienteDadosUsuario;
                RegistroRelacao.RelacaoTitulo = 1;
                
                db.CadastroClientes.Add(cadastroclientes);
                db.CadastroRelacao.Add(RegistroRelacao);
                db.SaveChanges();


                Session["novoCliente"] = "true";

                return RedirectToAction("Create", "Relacao", new { id = cadastroclientes.ClienteDadosUsuario });
            }
           
            return View(cadastroclientes);
        }

        //
        // GET: /Clientes/Edit/5

        [Authorize] 
        public ActionResult Edit(int id = 0)
        {
            CadastroClientes cadastroclientes = db.CadastroClientes.Find(id);
            if (cadastroclientes == null)
            {
                return HttpNotFound();
            }

               
            var vNomeUsuario = (from CadastroUsuarios in db.CadastroUsuarios
                                where !(from CadastroClientes in db.CadastroClientes
                                        where CadastroClientes.ID != id
                                        select CadastroClientes.ClienteConjujeUsuario)
                                .Contains(CadastroUsuarios.ID)
                                select CadastroUsuarios).AsEnumerable()
                                .Select(x => new SelectListItem
                                {
                                    Text = x.Nome,
                                    Value = x.ID.ToString()
                                });
            
            var vNomeUsuarioFull = (from CadastroUsuarios in db.CadastroUsuarios
                                   
                                    select CadastroUsuarios).AsEnumerable()
                                 .Select(
                                 x => new SelectListItem
                                 {
                                     Text = x.Nome,
                                     Value = x.ID.ToString()
                                 });
         

            ViewData["Usuarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            ViewData["TUsuarios"] = (IEnumerable<SelectListItem>)vNomeUsuarioFull;
            ViewData["EstadoCivil"] = EnumSCP.EnumEstadoCivil;

            return View(cadastroclientes);
        }

        //
        // POST: /Clientes/Edit/5

        [HttpPost]
        [Authorize] 
        public ActionResult Edit(CadastroClientes cadastroclientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cadastroclientes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           
            return View(cadastroclientes);
        }

      

        //
        // POST: /Clientes/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize] 
        public ActionResult Delete(int id)
        {
            
            //número mágico
            int IDProprietario = 1;
            List<FazendaRelacao> cadastroRelacaoID = (from FazendaRelacao in db.FazendaRelacao
                                                      where (FazendaRelacao.IDCliente == id && FazendaRelacao.RelacaoTitulo == IDProprietario)
                                                      select FazendaRelacao).ToList();

            CadastroClientes cadastroclientes = db.CadastroClientes.Find(id);
            CadastroRelacao cadastrorelacao = db.CadastroRelacao.Find(cadastroRelacaoID[0].IDRelacao);
            db.CadastroClientes.Remove(cadastroclientes);
            db.CadastroRelacao.Remove(cadastrorelacao);
            
            
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
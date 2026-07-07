using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using SCP___AgroGerente.Models;


namespace SCP___AgroGerente.Controllers
{
   
    public class FazendaTotalsController : ApiController
    {
        
        private SCPEntities db = new SCPEntities();

        // GET api/FazendaTotals
        //public IEnumerable<FazendaTotals> GetFazendaTotals()
        //{
        //    //return db.FazendaTotals.Where(s => s.RelacaoUsuarioID == 17).AsEnumerable();
        //}

        public IEnumerable<FazendaTotals> GetFazendaTotals(int id)
        {

            return db.FazendaTotals.Where(s => s.RelacaoUsuarioID == id ).AsEnumerable();
        }
    }
}
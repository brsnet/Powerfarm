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
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Controllers
{
    public class MicrorregiaoAPIController : ApiController
    {
        private SCPEntities db = new SCPEntities();

        // GET api/MicrorregiaoAPI
        public IEnumerable<CadastroMicrorregiao> GetCadastroMicrorregiaos()
        {
            return db.CadastroMicrorregiao.AsEnumerable();
        }

       
    }
}
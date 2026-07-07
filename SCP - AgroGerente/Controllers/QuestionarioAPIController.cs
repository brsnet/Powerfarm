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
    public class QuestionarioAPIController : ApiController
    {
        private SCPEntities db = new SCPEntities();

        // GET api/QuestionarioAPI


        public IEnumerable<CadastroQuestionario> GetCadastroQuestionarios()
        {
            return db.CadastroQuestionario.AsEnumerable();
        }

        public Proc_Questoes_Result Proc_Questoes_Result(int id)
        {

            Proc_Questoes_Result Resutado = db.Proc_Questoes(id).FirstOrDefault();
            if (Resutado == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return Resutado;
        }

    }
}
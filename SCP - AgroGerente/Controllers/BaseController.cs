using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Controllers
{
    public class BaseController : Controller
    {

        public string SafraPrevista = BaseSistema.SafraPrevista;

        public BaseController()
        {
            ViewData["_Base_SafraPrevista"] = SafraPrevista;
            ViewBag.mensagemErro = string.Empty;
        }
        

    }
}

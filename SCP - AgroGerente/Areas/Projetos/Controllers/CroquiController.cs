using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Areas.Projetos.Model;

namespace SCP___AgroGerente.Areas.Projetos.Controllers
{
    public class CroquiController : Controller
    {
        //
        // GET: /Croqui/
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Mapa = "http://localhost:400/Kml/westcampus.kml";
            ViewBag.qual = HttpContext.Request.ApplicationPath.ToString();
            return View();
        }
        [Authorize]
        public ActionResult Teste()
        {
            ViewBag.Mapa = "http://localhost:400/Kml/westcampus.kml";
            ViewBag.qual = HttpContext.Request.ApplicationPath.ToString();
            return View();
        }
    }
}

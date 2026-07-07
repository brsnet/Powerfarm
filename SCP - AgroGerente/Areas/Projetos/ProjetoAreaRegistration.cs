using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace SCP___AgroGerente
{
    public class ProjetoAreaRegistration : AreaRegistration
    {

       
        public override string AreaName
        {
            get
            {
                return "Projetos";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {


            
            context.MapRoute(
                "Projetos_Default",
                "Projetos/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "SCP___AgroGerente.Areas.Projetos.Controllers" }
            );
        }
      



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SCP___AgroGerente
{
    public class MyViewEngine : RazorViewEngine
    {
        private static string[] AdditionalViewLocations = new[]{
        "~/Projetos/Views/{1}/{0}.cshtml",
        "~/Projetos/Views/{1}/{0}.vbhtml",
        "~/Projetos/Views/Shared/{0}.cshtml",
        "~/Projetos/Views/Shared/{0}.vbhtml"
    };

        public MyViewEngine()
        {
            base.PartialViewLocationFormats = base.PartialViewLocationFormats.Union(AdditionalViewLocations).ToArray();
            base.ViewLocationFormats = base.ViewLocationFormats.Union(AdditionalViewLocations).ToArray();
            base.MasterLocationFormats = base.MasterLocationFormats.Union(AdditionalViewLocations).ToArray();
        }
    }
}

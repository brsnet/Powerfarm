using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace SCP___AgroGerente.Controllers
{
    public class SessionData
    {
        const string ClientId_KEY = "ClientId";
        public static int ClientId
        {
            get { return HttpContext.Current.Session[ClientId_KEY] != null ? (int)HttpContext.Current.Session[ClientId_KEY] : 0; }
            set { HttpContext.Current.Session[ClientId_KEY] = value; }
        }
    }
}

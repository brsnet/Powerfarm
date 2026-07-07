using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente
{
    public class BaseSistema
    {

        #region Propriedades Principais

        public static string SafraPrevista { get; set; }

        public static void Iniciar()
        {
            SCPEntities db = new SCPEntities();
            SafraPrevista = db.CadastroSafra.First(w => w.SafraPrevista == true).NomeSafra;
        }

        #endregion
    }
}
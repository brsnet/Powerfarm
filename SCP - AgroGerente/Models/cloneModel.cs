using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace SCP___AgroGerente.Models
{
    public class cloneContext : DbContext
    {
        public cloneContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<cloneProfile> cloneProfiles { get; set; }
    }


    public class cloneProfile
    {
       

        public int UserToCloneId { get; set; }
        public int UserClonedId { get; set; }
    }


}

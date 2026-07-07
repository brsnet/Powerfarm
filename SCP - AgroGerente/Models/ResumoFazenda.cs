namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ResumoFazenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? QTDMaquinas { get; set; }

        public int? QTDImplementos { get; set; }

        public int? QTDVeiculos { get; set; }

        public int? QTDTerrasSolos { get; set; }

        public int? QTDBenfeitorias { get; set; }

        public int? QTDSemoventes { get; set; }

        public double? ClienteParticipacaoGeral { get; set; }

        public double? TotalTerraSolo { get; set; }

        public double? TotalBenfeitorias { get; set; }

        public double? TotalSemoventes { get; set; }

        public double? ResumoMaquina { get; set; }

        public double? ResumoVeiculo { get; set; }

        public double? ResumoImplemento { get; set; }

        public double? ResumoBensDireitos { get; set; }
    }
}

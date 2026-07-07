namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LimiteCredito")]
    public partial class LimiteCredito1
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string EntidadeTipo { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EntidadeID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string EntidadeSafra { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string EntidadeHash { get; set; }

        [StringLength(255)]
        public string EntidadeReferencia { get; set; }

        public int? EntidadeReferenciaValor { get; set; }

        public DateTime? EntidadeDataCadastro { get; set; }

        [StringLength(255)]
        public string Campo1 { get; set; }

        [StringLength(255)]
        public string NomeSafra { get; set; }
    }
}

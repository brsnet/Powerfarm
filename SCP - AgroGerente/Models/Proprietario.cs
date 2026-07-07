namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Proprietario
    {
        public int? ID { get; set; }

        [StringLength(255)]
        public string Nome { get; set; }

        public int? RelacaoTitulo { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCliente { get; set; }

        [StringLength(255)]
        public string Celular1 { get; set; }

        [StringLength(255)]
        public string Celular2 { get; set; }

        [StringLength(255)]
        public string Telefone1 { get; set; }

        [StringLength(255)]
        public string Telefone2 { get; set; }
    }
}

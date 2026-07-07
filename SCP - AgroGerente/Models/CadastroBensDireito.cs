namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CadastroBensDireitos")]
    public partial class CadastroBensDireitos
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string BensDireitosCategoria { get; set; }

        [Required]
        [StringLength(255)]
        public string BensDireitosCaracteristicas { get; set; }

        public double BensDireitosValor { get; set; }

        public int BensDireitosUsuarioID { get; set; }

        public virtual CadastroUsuario CadastroUsuario { get; set; }
    }
}

namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CadastroClientes
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string ClienteGrau { get; set; }

        [StringLength(255)]
        public string ClienteFormacao { get; set; }

        [StringLength(255)]
        public string ClienteExperiencia { get; set; }

        [StringLength(255)]
        public string ClienteClassificacaoPorte { get; set; }

        [StringLength(255)]
        public string ClienteAtividadeDesenvolvida { get; set; }

        [StringLength(255)]
        public string ClienteTempoAtividade { get; set; }

        [StringLength(255)]
        public string ClienteEstruturaArmazenamento { get; set; }

        [StringLength(255)]
        public string ClienteEstruturaTransporte { get; set; }

        [StringLength(255)]
        public string ClienteResidenciaProdutor { get; set; }

        [StringLength(255)]
        public string ClienteEstadoCivil { get; set; }

        public int? ClienteAuthority { get; set; }

        public int ClienteDadosUsuario { get; set; }

        public int? ClienteRelacaoFazenda { get; set; }

        public int? ClienteFazenda { get; set; }

        public int? ClienteConjujeUsuario { get; set; }

        public double? ClienteParticipacaoGeral { get; set; }

        [StringLength(255)]
        public string ClienteListaSociosID { get; set; }

        [StringLength(255)]
        public string ClienteListaSociosNome { get; set; }

        public virtual CadastroUsuario CadastroUsuario { get; set; }
    }
}

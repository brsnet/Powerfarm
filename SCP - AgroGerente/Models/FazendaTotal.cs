namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FazendaTotal
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string FazendaNome { get; set; }

        [Key]
        [Column(Order = 2)]
        public double FazendaBeneficioSoloSaca { get; set; }

        [Key]
        [Column(Order = 3)]
        public double FazendaBeneficioSoloValorUnitario { get; set; }

        public double? ValorTotal { get; set; }

        public double? AreaTotal { get; set; }

        public double? ValorParticipacao { get; set; }

        public double? BeneficioSolo { get; set; }

        public int? RelacaoUsuarioID { get; set; }

        public double? AreaCultivada { get; set; }

        public double? ValorTerraNua { get; set; }

        public int? IDMicrorregiao { get; set; }

        [StringLength(255)]
        public string MicrorregiaoNome { get; set; }

        public int? IDCultura { get; set; }

        [StringLength(255)]
        public string NomeCultura { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(255)]
        public string FazendaMunicipio { get; set; }

        public int? MicrorregiaoBrutaNuaInferiorSaca { get; set; }

        public int? MicrorregiaoBrutaNuaSuperiorSaca { get; set; }

        public int? MicrorregiaoCurrigidaCultivadaInferiorSaca { get; set; }

        public int? MicrorregiaoCurrigidaCultivadaSuperiorSaca { get; set; }

        public double? FazendaParticipacao { get; set; }

        public int? TotalBenfeitoriaChecked { get; set; }

        public double? TotalValorBenfeitoriaChecked { get; set; }

        public double? ValorParticipacaoBenfeitoria { get; set; }

        public int? RelacaoTitulo { get; set; }

        [StringLength(255)]
        public string NomeProprietario { get; set; }

        public bool? FazendaArrendada { get; set; }

        public double? TotaisSemovente { get; set; }

        public double? TotalArrendado { get; set; }

        [Key]
        [Column(Order = 5)]
        public double ValorSaca { get; set; }
    }
}

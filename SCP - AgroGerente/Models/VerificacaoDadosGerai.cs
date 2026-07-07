namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VerificacaoDadosGerais
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(4)]
        public string ClienteGrau { get; set; }

        [StringLength(8)]
        public string ClienteFormacao { get; set; }

        [StringLength(11)]
        public string ClienteExperiencia { get; set; }

        [StringLength(19)]
        public string ClienteClassificacaoPorte { get; set; }

        [StringLength(22)]
        public string ClienteAtividadeDesenvolvida { get; set; }

        [StringLength(18)]
        public string ClienteTempoAtividade { get; set; }

        [StringLength(26)]
        public string ClienteEstruturaArmazenamento { get; set; }

        [StringLength(23)]
        public string ClienteEstruturaTransporte { get; set; }

        [StringLength(22)]
        public string ClienteResidenciaProdutor { get; set; }

        [StringLength(22)]
        public string ClienteEstadoCivil { get; set; }

        [StringLength(40)]
        public string ClienteDadosUsuario { get; set; }

        [StringLength(44)]
        public string ClienteFazenda { get; set; }

        [StringLength(15)]
        public string ClienteRelacaoFazenda { get; set; }

        public int? IDCliente { get; set; }

        [StringLength(2)]
        public string UsuarioRG { get; set; }

        [StringLength(17)]
        public string UsuarioDataExpedicao { get; set; }

        [StringLength(3)]
        public string UsuarioCPF { get; set; }

        [StringLength(18)]
        public string UsuarioDataNascimento { get; set; }

        [StringLength(12)]
        public string UsuarioNaturalidade { get; set; }

        [StringLength(8)]
        public string UsuarioTelefone1 { get; set; }

        [StringLength(7)]
        public string UsuarioCelular1 { get; set; }

        [StringLength(8)]
        public string UsuarioEndereco { get; set; }

        [StringLength(3)]
        public string UsuarioCEP { get; set; }

        [StringLength(11)]
        public string UsuarioRendaMensal { get; set; }

        [StringLength(6)]
        public string UsuarioCidade { get; set; }

        [StringLength(6)]
        public string UsuarioEstado { get; set; }

        [StringLength(255)]
        public string Telefone1 { get; set; }

        [StringLength(255)]
        public string Telefone2 { get; set; }

        [StringLength(255)]
        public string Celular1 { get; set; }

        [StringLength(255)]
        public string Celular2 { get; set; }

        public int? RelacaoTitulo { get; set; }

        public int? QuantidadeFazendas { get; set; }
    }
}

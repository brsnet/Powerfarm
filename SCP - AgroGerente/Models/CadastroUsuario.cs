namespace SCP___AgroGerente.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CadastroUsuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CadastroUsuario()
        {
            CadastroBenfeitorias = new HashSet<CadastroBenfeitoria>();
            CadastroBensDireitos = new HashSet<CadastroBensDireitos>();
            CadastroClientes = new HashSet<CadastroClientes>();
            CadastroDividas = new HashSet<CadastroDivida>();
            CadastroImplementoes = new HashSet<CadastroImplemento>();
            CadastroMaquinas = new HashSet<CadastroMaquina>();
            CadastroRelacaos = new HashSet<CadastroRelacao>();
            CadastroSemoventes = new HashSet<CadastroSemovente>();
            CadastroTerraSoloes = new HashSet<CadastroTerraSolo>();
            CadastroVeiculoes = new HashSet<CadastroVeiculo>();
            SafraNormalPrevistas = new HashSet<SafraNormalPrevista>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [StringLength(255)]
        public string RG { get; set; }

        [StringLength(255)]
        public string DataExpedicao { get; set; }

        [StringLength(255)]
        public string CPF { get; set; }

        [StringLength(255)]
        public string DataNascimento { get; set; }

        [StringLength(255)]
        public string Naturalidade { get; set; }

        [StringLength(255)]
        public string Telefone1 { get; set; }

        [StringLength(255)]
        public string Telefone2 { get; set; }

        [StringLength(255)]
        public string Celular1 { get; set; }

        [StringLength(255)]
        public string Celular2 { get; set; }

        [StringLength(255)]
        public string Endereco { get; set; }

        [StringLength(255)]
        public string CEP { get; set; }

        [StringLength(255)]
        public string RendaMensal { get; set; }

        [StringLength(255)]
        public string Cidade { get; set; }

        [StringLength(255)]
        public string Estado { get; set; }

        [StringLength(255)]
        public string Ocupacao { get; set; }

        [StringLength(255)]
        public string Grau { get; set; }

        [StringLength(255)]
        public string Formacao { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroBenfeitoria> CadastroBenfeitorias { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroBensDireitos> CadastroBensDireitos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroClientes> CadastroClientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroDivida> CadastroDividas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroImplemento> CadastroImplementoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroMaquina> CadastroMaquinas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroRelacao> CadastroRelacaos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroSemovente> CadastroSemoventes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroTerraSolo> CadastroTerraSoloes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CadastroVeiculo> CadastroVeiculoes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SafraNormalPrevista> SafraNormalPrevistas { get; set; }
    }
}

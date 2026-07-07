namespace SCP___AgroGerente.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SCPEntities : DbContext
    {
        public SCPEntities()
            : base("name=SCPEntities")
        {
        }

        public virtual DbSet<AUTHORITY> AUTHORITY { get; set; }
        public virtual DbSet<CadastroBenfeitoria> CadastroBenfeitorias { get; set; }
        public virtual DbSet<CadastroBensDireitos> CadastroBensDireitos { get; set; }
        public virtual DbSet<CadastroClientes> CadastroClientes { get; set; }
        public virtual DbSet<CadastroDivida> CadastroDividas { get; set; }
        public virtual DbSet<CadastroFazenda> CadastroFazenda { get; set; }
        public virtual DbSet<CadastroImplemento> CadastroImplementoes { get; set; }
        public virtual DbSet<CadastroMaquina> CadastroMaquinas { get; set; }
        public virtual DbSet<CadastroMicrorregiao> CadastroMicrorregiaos { get; set; }
        public virtual DbSet<CadastroQuestionario> CadastroQuestionarios { get; set; }
        public virtual DbSet<CadastroRelacao> CadastroRelacao { get; set; }
        public virtual DbSet<CadastroRespostaQuestionario> CadastroRespostaQuestionarios { get; set; }
        public virtual DbSet<CadastroSafra> CadastroSafras { get; set; }
        public virtual DbSet<CadastroSemovente> CadastroSemoventes { get; set; }
        public virtual DbSet<CadastroTerraSolo> CadastroTerraSoloes { get; set; }
        public virtual DbSet<CadastroUsuario> CadastroUsuarios { get; set; }
        public virtual DbSet<CadastroVeiculo> CadastroVeiculoes { get; set; }
        public virtual DbSet<Cultura> Culturas { get; set; }
        public virtual DbSet<LimiteCredito> LimiteCreditos { get; set; }
        public virtual DbSet<TerraSolo> TerraSoloes { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<SafraDistribuicao> SafraDistribuicaos { get; set; }
        public virtual DbSet<SafraNormalPrevista> SafraNormalPrevistas { get; set; }
        public virtual DbSet<BenfeitoriaFazenda> BenfeitoriaFazendas { get; set; }
        public virtual DbSet<ClienteConjuge> ClienteConjuges { get; set; }
        public virtual DbSet<ClienteFazenda> ClienteFazenda { get; set; }
        public virtual DbSet<DistribuicaoSafraFazenda> DistribuicaoSafraFazendas { get; set; }
        public virtual DbSet<DividaUsuario> DividaUsuarios { get; set; }
        public virtual DbSet<FazendaRelacao> FazendaRelacao { get; set; }
        public virtual DbSet<FazendaTotal> FazendaTotals { get; set; }
        public virtual DbSet<funcaodistribuicaoAreaSafra> funcaodistribuicaoAreaSafras { get; set; }
        public virtual DbSet<ImplementoFazendaUsuario> ImplementoFazendaUsuarios { get; set; }
        public virtual DbSet<LimiteCredito1> LimiteCreditoes { get; set; }
        public virtual DbSet<MaquinaFazendaUsuario> MaquinaFazendaUsuarios { get; set; }
        public virtual DbSet<Proprietario> Proprietarios { get; set; }
        public virtual DbSet<QuestionarioResposta> QuestionarioRespostas { get; set; }
        public virtual DbSet<ResumoFazenda> ResumoFazendas { get; set; }
        public virtual DbSet<TerraSoloFazenda> TerraSoloFazendas { get; set; }
        public virtual DbSet<UsuarioSafrasNormalPrevista> UsuarioSafrasNormalPrevistas { get; set; }
        public virtual DbSet<UsuariosFazenda> UsuariosFazendas { get; set; }
        public virtual DbSet<VeiculoFazendaUsuario> VeiculoFazendaUsuarios { get; set; }
        public virtual DbSet<VerificacaoDadosGerais> VerificacaoDadosGerais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AUTHORITY>()
                .Property(e => e.USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<AUTHORITY>()
                .Property(e => e.USERPASS)
                .IsUnicode(false);

            modelBuilder.Entity<AUTHORITY>()
                .Property(e => e.USERAUTH)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBenfeitoria>()
                .Property(e => e.BenfeitoriaEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBenfeitoria>()
                .Property(e => e.BenfeitoriaCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBenfeitoria>()
                .Property(e => e.BenfeitoriaAno)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBenfeitoria>()
                .Property(e => e.BenfeitoriaEstadoConservacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBensDireitos>()
                .Property(e => e.BensDireitosCategoria)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroBensDireitos>()
                .Property(e => e.BensDireitosCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteGrau)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteFormacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteExperiencia)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteClassificacaoPorte)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteAtividadeDesenvolvida)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteTempoAtividade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteEstruturaArmazenamento)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteEstruturaTransporte)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteResidenciaProdutor)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteEstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteListaSociosID)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroClientes>()
                .Property(e => e.ClienteListaSociosNome)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaCredor)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaFinalidade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaDataContratada)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaDataVencimento)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaCarencia)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaEncargos)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroDivida>()
                .Property(e => e.DividaPeriodicidade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaMatriculaCRI)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaCodigoINCRA)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaRoteiroAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaConfrontacoesNorte)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaConfrontacoesSul)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaConfrontacoesLeste)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaConfrontacoesOeste)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaTitulosDominio)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaTipoPropriedade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaOnusGravames)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaMatricula)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .Property(e => e.FazendaCodReceitaFederal)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroFazenda>()
                .HasMany(e => e.CadastroBenfeitorias)
                .WithRequired(e => e.CadastroFazenda)
                .HasForeignKey(e => e.BenfeitoriaFazenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroFazenda>()
                .HasMany(e => e.CadastroRelacaos)
                .WithOptional(e => e.CadastroFazenda)
                .HasForeignKey(e => e.RelacaoFazendaID);

            modelBuilder.Entity<CadastroFazenda>()
                .HasMany(e => e.CadastroSemoventes)
                .WithRequired(e => e.CadastroFazenda)
                .HasForeignKey(e => e.SemoventeFazendaID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroFazenda>()
                .HasMany(e => e.CadastroTerraSoloes)
                .WithRequired(e => e.CadastroFazenda)
                .HasForeignKey(e => e.TerraSoloFazenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroFazenda>()
                .HasMany(e => e.SafraDistribuicaos)
                .WithRequired(e => e.CadastroFazenda)
                .HasForeignKey(e => e.DistribuicaoSafraFazenda)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoMarca)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoModelo)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoAno)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoEstado)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoP)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroImplemento>()
                .Property(e => e.ImplementoSafra)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaMarca)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaModelo)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaPotencia)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaAno)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaEstado)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaP)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMaquina>()
                .Property(e => e.MaquinaCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMicrorregiao>()
                .Property(e => e.MicrorregiaoNome)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroMicrorregiao>()
                .HasMany(e => e.CadastroFazendas)
                .WithRequired(e => e.CadastroMicrorregiao)
                .HasForeignKey(e => e.FazendaMicrorregiao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioQuestao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioResposta1)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioResposta2)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioResposta3)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioResposta4)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroQuestionario>()
                .Property(e => e.QuestionarioResposta5)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroRespostaQuestionario>()
                .Property(e => e.QuestionarioRespostaResposta1)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroRespostaQuestionario>()
                .Property(e => e.QuestionarioRespostaResposta2)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroRespostaQuestionario>()
                .Property(e => e.QuestionarioRespostaResposta3)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroRespostaQuestionario>()
                .Property(e => e.QuestionarioRespostaResposta4)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroRespostaQuestionario>()
                .Property(e => e.QuestionarioRespostaResposta5)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSafra>()
                .Property(e => e.SafraData)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSafra>()
                .Property(e => e.NomeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSafra>()
                .HasMany(e => e.SafraDistribuicaos)
                .WithRequired(e => e.CadastroSafra)
                .HasForeignKey(e => e.DistribuicaoSafraSafra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroSafra>()
                .HasMany(e => e.SafraNormalPrevistas)
                .WithRequired(e => e.CadastroSafra)
                .HasForeignKey(e => e.SafrasSafra)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroSemovente>()
                .Property(e => e.SemoventeEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSemovente>()
                .Property(e => e.SemoventeCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroSemovente>()
                .Property(e => e.SemoventeCredor)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroTerraSolo>()
                .Property(e => e.TerraSoloCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroTerraSolo>()
                .Property(e => e.TerraSoloClasse)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.DataExpedicao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.DataNascimento)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Naturalidade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Celular1)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Celular2)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.RendaMensal)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Ocupacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Grau)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .Property(e => e.Formacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroBenfeitorias)
                .WithOptional(e => e.CadastroUsuario)
                .HasForeignKey(e => e.BenfeitoriaUsuario);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroBensDireitos)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.BensDireitosUsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroClientes)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.ClienteDadosUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroDividas)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.DividaUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroImplementoes)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.ImplementoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroMaquinas)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.MaquinaUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroRelacaos)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.RelacaoUsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroSemoventes)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.SemoventeUsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroTerraSoloes)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.TerraSoloUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.CadastroVeiculoes)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.VeiculoUsuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroUsuario>()
                .HasMany(e => e.SafraNormalPrevistas)
                .WithRequired(e => e.CadastroUsuario)
                .HasForeignKey(e => e.SafrasUsuarioID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoMarca)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoModelo)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoPotencia)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoAno)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoEstado)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoP)
                .IsUnicode(false);

            modelBuilder.Entity<CadastroVeiculo>()
                .Property(e => e.VeiculoCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<Cultura>()
                .Property(e => e.NomeCultura)
                .IsUnicode(false);

            modelBuilder.Entity<Cultura>()
                .HasMany(e => e.CadastroFazendas)
                .WithRequired(e => e.Cultura)
                .HasForeignKey(e => e.FazendaCultura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cultura>()
                .HasMany(e => e.SafraDistribuicaos)
                .WithOptional(e => e.Cultura)
                .HasForeignKey(e => e.DistribuicaoSafraCultura);

            modelBuilder.Entity<Cultura>()
                .HasMany(e => e.SafraNormalPrevistas)
                .WithRequired(e => e.Cultura)
                .HasForeignKey(e => e.SafrasCultura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.EntidadeTipo)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.EntidadeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.EntidadeHash)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.EntidadeReferencia)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo1)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo2)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo3)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo4)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo5)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo6)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo7)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo8)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo9)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo10)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo11)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo12)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo13)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo14)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo15)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo16)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo17)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo18)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo19)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo20)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Text1)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Text2)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Text3)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Text4)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Text5)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo21)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo22)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo23)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo24)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito>()
                .Property(e => e.Campo25)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSolo>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSolo>()
                .HasMany(e => e.CadastroTerraSoloes)
                .WithRequired(e => e.TerraSolo)
                .HasForeignKey(e => e.TerraSoloEspecificacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SafraDistribuicao>()
                .Property(e => e.DistribuicaoSafraTipo)
                .IsUnicode(false);

            modelBuilder.Entity<SafraDistribuicao>()
                .Property(e => e.DistribuicaoSafraObservacaoGravame)
                .IsUnicode(false);

            modelBuilder.Entity<SafraNormalPrevista>()
                .Property(e => e.SafrasObservacao)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.BenfeitoriaEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.BenfeitoriaCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.BenfeitoriaAno)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.BenfeitoriaEstadoConservacao)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<BenfeitoriaFazenda>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteConjuge>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.ClienteTempoAtividade)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.ClienteEstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.UsuarioNome)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.ConjugeUsuarioNome)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.ClienteListaSociosID)
                .IsUnicode(false);

            modelBuilder.Entity<ClienteFazenda>()
                .Property(e => e.ClienteListaSociosNome)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.DistribuicaoSafraTipo)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.FazendaMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.FazendaOnusGravames)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.NomeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<DistribuicaoSafraFazenda>()
                .Property(e => e.NomeCultura)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaCredor)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaFinalidade)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaDataContratada)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaDataVencimento)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaCarencia)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaEncargos)
                .IsUnicode(false);

            modelBuilder.Entity<DividaUsuario>()
                .Property(e => e.DividaPeriodicidade)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaMatriculaCRI)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaCodigoINCRA)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaRoteiroAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaConfrontacoesNorte)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaConfrontacoesSul)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaConfrontacoesLeste)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaConfrontacoesOeste)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaTitulosDominio)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaTipoPropriedade)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaOnusGravames)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaMatricula)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaRelacao>()
                .Property(e => e.FazendaCodReceitaFederal)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaTotal>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaTotal>()
                .Property(e => e.MicrorregiaoNome)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaTotal>()
                .Property(e => e.NomeCultura)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaTotal>()
                .Property(e => e.FazendaMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<FazendaTotal>()
                .Property(e => e.NomeProprietario)
                .IsUnicode(false);

            modelBuilder.Entity<funcaodistribuicaoAreaSafra>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoMarca)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoP)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoEstado)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoAno)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoModelo)
                .IsUnicode(false);

            modelBuilder.Entity<ImplementoFazendaUsuario>()
                .Property(e => e.ImplementoCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.EntidadeTipo)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.EntidadeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.EntidadeHash)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.EntidadeReferencia)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.Campo1)
                .IsUnicode(false);

            modelBuilder.Entity<LimiteCredito1>()
                .Property(e => e.NomeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaMarca)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaModelo)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaPotencia)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaAno)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaEstado)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaP)
                .IsUnicode(false);

            modelBuilder.Entity<MaquinaFazendaUsuario>()
                .Property(e => e.MaquinaCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietario>()
                .Property(e => e.Celular1)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietario>()
                .Property(e => e.Celular2)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietario>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Proprietario>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionarioResposta>()
                .Property(e => e.QuestionarioQuestao)
                .IsUnicode(false);

            modelBuilder.Entity<QuestionarioResposta>()
                .Property(e => e.QuestionarioRespostaResposta1)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaMatriculaCRI)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaCodigoINCRA)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.TerraSoloClasse)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.TerraSoloCaracteristicas)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaMunicipio)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaRoteiroAcesso)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaConfrontacoesNorte)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaOnusGravames)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaTipoPropriedade)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaConfrontacoesLeste)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaConfrontacoesOeste)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaTitulosDominio)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.FazendaConfrontacoesSul)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.MicrorregiaoNome)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.NomeCultura)
                .IsUnicode(false);

            modelBuilder.Entity<TerraSoloFazenda>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioSafrasNormalPrevista>()
                .Property(e => e.SafrasObservacao)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioSafrasNormalPrevista>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioSafrasNormalPrevista>()
                .Property(e => e.NomeSafra)
                .IsUnicode(false);

            modelBuilder.Entity<UsuarioSafrasNormalPrevista>()
                .Property(e => e.NomeCultura)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.DataExpedicao)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.DataNascimento)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Naturalidade)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Celular1)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Celular2)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.RendaMensal)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosFazenda>()
                .Property(e => e.Ocupacao)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoEspecificacao)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoMarca)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoModelo)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoPotencia)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoAno)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoEstado)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoChassiSerie)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoP)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.VeiculoCidadeLocal)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<VeiculoFazendaUsuario>()
                .Property(e => e.FazendaNome)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteGrau)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteFormacao)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteExperiencia)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteClassificacaoPorte)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteAtividadeDesenvolvida)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteTempoAtividade)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteEstruturaArmazenamento)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteEstruturaTransporte)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteResidenciaProdutor)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteEstadoCivil)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteDadosUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteFazenda)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.ClienteRelacaoFazenda)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioRG)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioDataExpedicao)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioCPF)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioDataNascimento)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioNaturalidade)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioTelefone1)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioCelular1)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioEndereco)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioCEP)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioRendaMensal)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioCidade)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.UsuarioEstado)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.Telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.Telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.Celular1)
                .IsUnicode(false);

            modelBuilder.Entity<VerificacaoDadosGerais>()
                .Property(e => e.Celular2)
                .IsUnicode(false);
        }
    }
}

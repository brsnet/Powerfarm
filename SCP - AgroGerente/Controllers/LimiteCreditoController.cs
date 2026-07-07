using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCP___AgroGerente.Models;

namespace SCP___AgroGerente.Controllers
{
    public class LimiteCreditoController : Controller
    {
        private SCPEntities db = new SCPEntities();

        //
        // GET: /LimiteCredito/
        [Authorize]
        public ActionResult Index()
        {
            var vNomeUsuario = (from Proprietarios in db.Proprietarios
                                select Proprietarios).AsEnumerable()
                               .Select(
                               x => new SelectListItem
                               {
                                   Text = x.Nome,
                                   Value = x.ID.ToString()
                               });
            ViewData["Proprietarios"] = (IEnumerable<SelectListItem>)vNomeUsuario;
            ViewData["Safra"] = EnumSCP.vSafra();
            return View(db.LimiteCredito.OrderByDescending(s => s.EntidadeDataCadastro).ToList());
        }

        #region Gerador de dados


        
        private void CadastraItemLimiteCredito(
            //
            // Summary:
            //     Lista de Campos a serem inseridos na estrurura de Limite de crédito
            //
            // Parameters:
            //   UsuarioID:
            //    ID do elemento
            //
            //   EntidadeSafra:
            //    Indicação da Safra
            
            int UsuarioID,
            string EntidadeTipo,
            string EntidadeSafra,
            string hash,
            string Referencia,
            int CampoReferencia,
            string Campo1,
            string Campo2,
            string Campo3,
            string Campo4,
            string Campo5,
            string Campo6,
            string Campo7,
            string Campo8,
            string Campo9,
            string Campo10,
            string Campo11,
            string Campo12,
            string Campo13,
            string Campo14,
            string Campo15,
            string Campo16,
            string Campo17,
            string Campo18,
            string Campo19,
            string Campo20,
            string Campo21,
            string Campo22,
            string Campo23,
            string Campo24,
            string Campo25
            )
        {
            LimiteCreditos DadosLimiteCredito = new Models.LimiteCreditos();


            DadosLimiteCredito.EntidadeID = UsuarioID;
            DadosLimiteCredito.EntidadeTipo = EntidadeTipo;
            DadosLimiteCredito.EntidadeSafra = EntidadeSafra;
            DadosLimiteCredito.EntidadeHash = hash;
            DadosLimiteCredito.EntidadeReferencia = Referencia;
            DadosLimiteCredito.EntidadeReferenciaValor = CampoReferencia;
            DadosLimiteCredito.Campo1 = Campo1;
            DadosLimiteCredito.Campo2 = Campo2;
            DadosLimiteCredito.Campo3 = Campo3;
            DadosLimiteCredito.Campo4 = Campo4;
            DadosLimiteCredito.Campo5 = Campo5;
            DadosLimiteCredito.Campo6 = Campo6;
            DadosLimiteCredito.Campo7 = Campo7;
            DadosLimiteCredito.Campo8 = Campo8;
            DadosLimiteCredito.Campo9 = Campo9;
            DadosLimiteCredito.Campo10 = Campo10;
            DadosLimiteCredito.Campo11 = Campo11;
            DadosLimiteCredito.Campo12 = Campo12;
            DadosLimiteCredito.Campo13 = Campo13;
            DadosLimiteCredito.Campo14 = Campo14;
            DadosLimiteCredito.Campo15 = Campo15;
            DadosLimiteCredito.Campo16 = Campo16;
            DadosLimiteCredito.Campo17 = Campo17;
            DadosLimiteCredito.Campo18 = Campo18;
            DadosLimiteCredito.Campo19 = Campo19;
            DadosLimiteCredito.Campo20 = Campo20;
            DadosLimiteCredito.Campo21 = Campo21;
            DadosLimiteCredito.Campo22 = Campo22;
            DadosLimiteCredito.Campo23 = Campo23;
            DadosLimiteCredito.Campo24 = Campo24;
            DadosLimiteCredito.Campo25 = Campo25;
            DadosLimiteCredito.EntidadeDataCadastro = DateTime.Now;


            db.LimiteCreditos.Add(DadosLimiteCredito);



        }

        #endregion

        [HttpPost]
        [Authorize]
        public ActionResult Index(LimiteCreditoRef Selecionados)
        {


            if (Selecionados.IDUsuario != null)
            {
                int UsuarioID = (int)Selecionados.IDUsuario;
                int ConjugeID = 0;
                int SafraUsada = Convert.ToInt32(Selecionados.IDSafra);
                string hash = EnumSCP.hashString();
                int erro = 0;
                Session["mensagemErro"] = "";

                List<FazendaRelacao> RelacaoPropriedades = (from FazendaRelacao in db.FazendaRelacao select FazendaRelacao).Where(s => s.RelacaoUsuarioID == UsuarioID && s.RelacaoTitulo == 1).ToList();
                List<FazendaRelacao> Relacao = (from FazendaRelacao in db.FazendaRelacao select FazendaRelacao).Where(s => s.RelacaoUsuarioID == UsuarioID && s.RelacaoTitulo == 1 || s.RelacaoTitulo == 2).ToList();
                List<FazendaRelacao> FazendasArrendadas = (from FazendaRelacao in db.FazendaRelacao



                                                           select FazendaRelacao).Where(s => s.RelacaoUsuarioID == UsuarioID && s.RelacaoTitulo == 2).ToList();

                List<CadastroClientes> Cliente = (from CadastroClientes in db.CadastroClientes select CadastroClientes).Where(s => s.ClienteDadosUsuario == UsuarioID).ToList();
                List<CadastroUsuarios> ClienteUsuario = (from CadastroUsuarios in db.CadastroUsuarios select CadastroUsuarios).Where(s => s.ID == UsuarioID).ToList();

                
                List<QuestionarioResposta> RespostasQuestionario = (from QuestionarioResposta in db.QuestionarioResposta select QuestionarioResposta).Where(s => s.QuestionarioRespostaUsuario == UsuarioID).ToList();


                List<CadastroMaquina> Maquinas = (from CadastroMaquina in db.CadastroMaquina select CadastroMaquina).Where(s => s.MaquinaUsuario == UsuarioID && s.MaquinaAtiva == true).ToList();
                List<CadastroVeiculo> Veiculos = (from CadastroVeiculo in db.CadastroVeiculo select CadastroVeiculo).Where(s => s.VeiculoUsuario == UsuarioID && s.VeiculoAtiva == true).ToList();
                List<CadastroImplemento> Implementos = (from CadastroImplemento in db.CadastroImplemento select CadastroImplemento).Where(s => s.ImplementoUsuario == UsuarioID && s.ImplementoAtiva == true).ToList();
                List<CadastroBensDireitos> BensDireitos = (from CadastroBensDireitos in db.CadastroBensDireitos select CadastroBensDireitos).Where(s => s.BensDireitosUsuarioID == UsuarioID).ToList();
                List<CadastroDivida> DividasUsuario = (from CadastroDivida in db.CadastroDivida select CadastroDivida).Where(s => s.DividaUsuario == UsuarioID).ToList();
                List<UsuarioSafrasNormalPrevista> Safras = (from UsuarioSafrasNormalPrevista in db.UsuarioSafrasNormalPrevista select UsuarioSafrasNormalPrevista).Where(s => s.SafrasUsuarioID == UsuarioID).OrderByDescending(s =>s.SafraPrevista).ToList();
                List<DistribuicaoSafraFazenda> SafrasDistribuidas = (from DistribuicaoSafraFazenda in db.DistribuicaoSafraFazenda select DistribuicaoSafraFazenda).Where(s => s.DistribuicaoSafraUsuarioID == UsuarioID && s.IDProprietário == UsuarioID && s.DistribuicaoSafraSafra == SafraUsada).OrderBy(s => s.DistribuicaoSafraTipo).ToList();

                if (RespostasQuestionario.Count() == 0)
                {
                    Session["mensagemErro"] = Session["mensagemErro"] + "<h5>Não existe(m) resposta(s) no Questionário</h5>";
                    erro = 1;
                }


                #region dados Cliente

                CadastraItemLimiteCredito(

                              Cliente[0].ID,
                              "Cliente",
                              Selecionados.IDSafra,
                              hash,
                              "Proprietario",
                              Relacao[0].RelacaoUsuarioID,
                              Cliente[0].ClienteEstadoCivil,
                              Cliente[0].ClienteConjujeUsuario.ToString(),
                              Cliente[0].ClienteExperiencia,
                              Cliente[0].ClienteClassificacaoPorte,
                              Cliente[0].ClienteAtividadeDesenvolvida,
                              Cliente[0].ClienteTempoAtividade,
                              Cliente[0].ClienteEstruturaArmazenamento,
                              Cliente[0].ClienteEstruturaTransporte,
                              Cliente[0].ClienteResidenciaProdutor,
                              Cliente[0].ClienteListaSociosNome,
                              Cliente[0].ClienteListaSociosID,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );


                #endregion

                #region dados Usuário

                CadastraItemLimiteCredito(

                             ClienteUsuario[0].ID,
                             "Usuario",
                             Selecionados.IDSafra,
                             hash,
                             "Proprietario",
                             Relacao[0].RelacaoUsuarioID,
                             ClienteUsuario[0].Nome,
                             ClienteUsuario[0].DataNascimento,
                             ClienteUsuario[0].Naturalidade,
                             ClienteUsuario[0].RendaMensal,
                             ClienteUsuario[0].RG,
                             ClienteUsuario[0].DataExpedicao,
                             ClienteUsuario[0].CPF,
                             ClienteUsuario[0].Telefone1,
                             ClienteUsuario[0].Telefone2,
                             ClienteUsuario[0].Celular1,
                             ClienteUsuario[0].Celular2,
                             ClienteUsuario[0].Endereco,
                             ClienteUsuario[0].Cidade,
                             ClienteUsuario[0].Estado,
                             ClienteUsuario[0].CEP,
                             ClienteUsuario[0].Grau,
                             ClienteUsuario[0].Formacao,
                             string.Empty,
                             string.Empty,
                             string.Empty,
                             string.Empty,
                             string.Empty,
                             string.Empty,
                             string.Empty,
                             string.Empty

                      );

                #endregion

                #region Dados do Conjuge
                try
                {
                    ConjugeID = (int)Cliente[0].ClienteConjujeUsuario;

                    List<CadastroUsuarios> ClienteConjuge = (from CadastroUsuarios in db.CadastroUsuarios select CadastroUsuarios).Where(s => s.ID == ConjugeID).ToList();

                    CadastraItemLimiteCredito(

                                 ClienteConjuge[0].ID,
                                 "Conjuge",
                                 Selecionados.IDSafra,
                                 hash,
                                 "Proprietario",
                                 Relacao[0].RelacaoUsuarioID,
                                 ClienteConjuge[0].Nome,
                                 ClienteConjuge[0].DataNascimento,
                                 ClienteConjuge[0].Naturalidade,
                                 ClienteConjuge[0].RendaMensal,
                                 ClienteConjuge[0].RG,
                                 ClienteConjuge[0].DataExpedicao,
                                 ClienteConjuge[0].CPF,
                                 ClienteConjuge[0].Telefone1,
                                 ClienteConjuge[0].Telefone2,
                                 ClienteConjuge[0].Celular1,
                                 ClienteConjuge[0].Celular2,
                                 ClienteConjuge[0].Endereco,
                                 ClienteConjuge[0].Cidade,
                                 ClienteConjuge[0].Estado,
                                 ClienteConjuge[0].CEP,
                                 ClienteUsuario[0].Grau,
                                 ClienteUsuario[0].Formacao,
                                 ClienteUsuario[0].Ocupacao,
                                 string.Empty,
                                 string.Empty,
                                 string.Empty,
                                 string.Empty,
                                 string.Empty,
                                 string.Empty,
                                 string.Empty

                          );



                }
                catch (Exception)
                {


                }

                #endregion

                #region Respostas do Questionário

                if (RespostasQuestionario.Count != 0)
                {
                    for (int i = 0; i < RespostasQuestionario.Count; i++)
                    {

                        CadastraItemLimiteCredito(

                              RespostasQuestionario[i].ID,
                              "Questionario",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              Relacao[0].RelacaoUsuarioID,
                              RespostasQuestionario[i].ID.ToString(),
                              RespostasQuestionario[i].QuestionarioRespostaQuestao.ToString(),
                              RespostasQuestionario[i].QuestionarioQuestao,
                              RespostasQuestionario[i].QuestionarioRespostaResposta1,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Safras Normais e Previstas

                if (Safras.Count != 0)
                {
                    for (int i = 0; i < Safras.Count; i++)
                    {

                       
                        CadastraItemLimiteCredito(

                              Safras[i].ID,
                              "Safras",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              Relacao[0].RelacaoUsuarioID,
                              Safras[i].ID.ToString(),
                              Safras[i].NomeSafra,
                              Safras[i].NomeCultura,
                              Safras[i].SafrasSistemaPlantio.ToString(),
                              Safras[i].SafrasArea.ToString(),
                              Safras[i].SafrasProdutividade.ToString(),
                              Safras[i].SafrasValorUnitario.ToString(),
                              Safras[i].ValorReceita.ToString(),
                              Safras[i].CustoTotal.ToString(),
                              Safras[i].SafraPrevista.ToString(),
                              Safras[i].SafrasObservacao,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Dsitribuição Safras

                if (SafrasDistribuidas.Count != 0)
                {
                    for (int i = 0; i < SafrasDistribuidas.Count; i++)
                    {

                        if (SafrasDistribuidas[i].Nome == null)
                        {
                            Session["mensagemErro"] = Session["mensagemErro"] + "<h5>Para alguma Fazenda Arrendada você esqueceu de adicionar o Proprietário</h5>";
                            erro = 1;
                            return RedirectToAction("Index");
                            
                        }

                        CadastraItemLimiteCredito(

                              SafrasDistribuidas[i].ID,
                              "SafrasDistribuidas",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              Relacao[0].RelacaoUsuarioID,
                              SafrasDistribuidas[i].ID.ToString(),
                              SafrasDistribuidas[i].DistribuicaoSafraTipo,
                              SafrasDistribuidas[i].NomeCultura,
                              SafrasDistribuidas[i].DistribuicaoSafraSistemaPlantio.ToString(),
                              SafrasDistribuidas[i].DistribuicaoSafraArea.ToString(),
                              SafrasDistribuidas[i].FazendaNome,
                              SafrasDistribuidas[i].FazendaMunicipio,
                              SafrasDistribuidas[i].Nome.ToString(),
                              SafrasDistribuidas[i].FazendaArrendada.ToString(),
                              SafrasDistribuidas[i].FazendaOnusGravames.ToString(),
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Dívidas do Usuário

                if (DividasUsuario.Count != 0)
                {


                    for (int i = 0; i < DividasUsuario.Count; i++)
                    {

                        CadastraItemLimiteCredito(

                              DividasUsuario[i].ID,
                              "Divida",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              Relacao[0].RelacaoUsuarioID,
                              DividasUsuario[i].DividaCredor,
                              DividasUsuario[i].DividaFinalidade,
                              DividasUsuario[i].DividaDataContratada,
                              DividasUsuario[i].DividaDataVencimento,
                              DividasUsuario[i].DividaCarencia,
                              DividasUsuario[i].DividaEncargos,
                              DividasUsuario[i].DividaPeriodicidade,
                              DividasUsuario[i].DividaSaldo.ToString(),
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Dados das Máquinas
                if (Maquinas.Count != 0)
                {
                    for (int a = 0; a < Maquinas.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              Maquinas[a].ID,
                              "Maquina",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              UsuarioID,
                              Maquinas[a].MaquinaEspecificacao,
                              Cliente[0].ClienteParticipacaoGeral.ToString(),
                              Maquinas[a].MaquinaMarca,
                              Maquinas[a].MaquinaModelo,
                              Maquinas[a].MaquinaPotencia,
                              Maquinas[a].MaquinaAno.ToString(),
                              Maquinas[a].MaquinaEstado,
                              Maquinas[a].MaquinaChassiSerie,
                              Maquinas[a].MaquinaValor.ToString(),
                              Maquinas[a].MaquinaP,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Dados das Veículos
                if (Veiculos.Count != 0)
                {
                    for (int a = 0; a < Veiculos.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              Veiculos[a].ID,
                              "Veiculo",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              UsuarioID,
                              Veiculos[a].VeiculoEspecificacao,
                              Cliente[0].ClienteParticipacaoGeral.ToString(),
                              Veiculos[a].VeiculoMarca,
                              Veiculos[a].VeiculoModelo,
                              Veiculos[a].VeiculoPotencia,
                              Veiculos[a].VeiculoAno.ToString(),
                              Veiculos[a].VeiculoEstado,
                              Veiculos[a].VeiculoChassiSerie,
                              Veiculos[a].VeiculoValor.ToString(),
                              Veiculos[a].VeiculoP,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion
                
                #region Dados das Implementos
                if (Implementos.Count != 0)
                {
                    for (int a = 0; a < Implementos.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              Implementos[a].ID,
                              "Implemento",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              UsuarioID,
                              Implementos[a].ImplementoEspecificacao,
                              Cliente[0].ClienteParticipacaoGeral.ToString(),
                              Implementos[a].ImplementoMarca,
                              Implementos[a].ImplementoModelo,
                              string.Empty,
                              Implementos[a].ImplementoAno.ToString(),
                              Implementos[a].ImplementoEstado,
                              Implementos[a].ImplementoChassiSerie,
                              Implementos[a].ImplementoValor.ToString(),
                              Implementos[a].ImplementoP,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion

                #region Dados dos Bens e Direitos
                if (BensDireitos.Count != 0)
                {
                    for (int a = 0; a < BensDireitos.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              BensDireitos[a].ID,
                              "BemDireito",
                              Selecionados.IDSafra,
                              hash,
                              "Usuario",
                              UsuarioID,
                              BensDireitos[a].BensDireitosCategoria,
                              BensDireitos[a].BensDireitosCaracteristicas,
                              BensDireitos[a].BensDireitosValor.ToString(),
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }
                }
                #endregion




                if (FazendasArrendadas.Count != 0)
                {

                    for (int i = 0; i < FazendasArrendadas.Count; i++)
                    {

                        int tempFazendaArrendada = (int)FazendasArrendadas[i].ID;

                        List<CadastroFazenda> FazendaArrendada = (from CadastroFazenda in db.CadastroFazenda select CadastroFazenda).Where(s => s.ID == tempFazendaArrendada).ToList();
                        List<FazendaTotals> TotaisFazendas = (from FazendaTotals in db.FazendaTotals select FazendaTotals).Where(s => s.ID == tempFazendaArrendada && s.RelacaoUsuarioID == UsuarioID).ToList();
                        List<CadastroBenfeitoria> Benfeitorias = (from CadastroBenfeitoria in db.CadastroBenfeitoria select CadastroBenfeitoria).Where(s => s.BenfeitoriaFazenda == tempFazendaArrendada && s.BenfeitoriaAtiva == true && s.BenfeitoriaUsuario == UsuarioID).ToList();
                        List<TerraSoloFazenda> TerrasSolos = (from TerraSoloFazenda in db.TerraSoloFazenda select TerraSoloFazenda).Where(s => s.FazendaID == tempFazendaArrendada && s.TerraSoloAtiva == true && s.TerraSoloUsuario == UsuarioID).ToList();
                        List<CadastroSemovente> Semoventes = (from CadastroSemovente in db.CadastroSemovente select CadastroSemovente).Where(s => s.SemoventeFazendaID == tempFazendaArrendada && s.SemoventeUsuarioID == UsuarioID).ToList();


                        if (TerrasSolos.Count() == 0)
                        {
                            Session["mensagemErro"] = Session["mensagemErro"] + "<h5>Não existem Terras/solo para as Fazendas Arrendadas</h5>";
                            erro = 1;
                        }


                        #region Dados das Fazendas Arrendadas

                        for (int a = 0; a < FazendaArrendada.Count; a++)
                        {
                            string PrazoArrendamento = null;
                            if (FazendaArrendada[a].FazendaArrendadaDataInicio!=null)
                            {
                                DateTime tempo1 = FazendaArrendada[a].FazendaArrendadaDataInicio.Value;
                                DateTime tempo2 = FazendaArrendada[a].FazendaArrendadaDataFim.Value;

                                PrazoArrendamento = tempo2.Subtract(tempo1).TotalDays.ToString();
                                
                            }
                           
                            CadastraItemLimiteCredito(

                                  FazendaArrendada[a].ID,
                                  "Fazenda",
                                  Selecionados.IDSafra,
                                  hash,
                                  "FazendaArrendada",
                                  tempFazendaArrendada,
                                  FazendaArrendada[a].FazendaNome,
                                  FazendaArrendada[a].FazendaMatricula,
                                  FazendaArrendada[a].FazendaMatriculaCRI,
                                  FazendaArrendada[a].FazendaCodReceitaFederal,
                                  FazendaArrendada[a].FazendaCodigoINCRA,
                                  FazendaArrendada[a].FazendaTitulosDominio,
                                  FazendaArrendada[a].FazendaTipoPropriedade,
                                  FazendaArrendada[a].FazendaOnusGravames,
                                  FazendaArrendada[a].FazendaMunicipio,
                                  FazendaArrendada[a].FazendaRoteiroAcesso,
                                  FazendaArrendada[a].FazendaConfrontacoesNorte,
                                  FazendaArrendada[a].FazendaConfrontacoesSul,
                                  FazendaArrendada[a].FazendaConfrontacoesLeste,
                                  FazendaArrendada[a].FazendaConfrontacoesOeste,
                                  FazendaArrendada[a].FazendaArrendadaDataInicio.ToString(),
                                  FazendaArrendada[a].FazendaArrendadaDataFim.ToString(),
                                  FazendaArrendada[a].FazendaArrendadaAreaArrendada.ToString(),
                                  FazendaArrendada[a].FazendaArrendadaValorArrendado.ToString(),
                                  PrazoArrendamento,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty

                           );

                        }

                        #endregion

                        #region Totais das Fazendas Arrendadas

                        for (int a = 0; a < TotaisFazendas.Count; a++)
                        {

                            CadastraItemLimiteCredito(

                                  TotaisFazendas[a].ID,
                                  "Totais",
                                  Selecionados.IDSafra,
                                  hash,
                                  "FazendaArrendada",
                                  tempFazendaArrendada,

                                  TotaisFazendas[a].FazendaNome,
                                  TotaisFazendas[a].FazendaBeneficioSoloSaca.ToString(),
                                  TotaisFazendas[a].FazendaBeneficioSoloValorUnitario.ToString(),
                                  TotaisFazendas[a].ValorTotal.ToString(),
                                  TotaisFazendas[a].AreaTotal.ToString(),
                                  TotaisFazendas[a].ValorParticipacao.ToString(),
                                  TotaisFazendas[a].BeneficioSolo.ToString(),
                                  TotaisFazendas[a].AreaCultivada.ToString(),
                                  TotaisFazendas[a].ValorTerraNua.ToString(),
                                  TotaisFazendas[a].FazendaParticipacao.ToString(),
                                  TotaisFazendas[a].MicrorregiaoBrutaNuaInferiorSaca.ToString(),
                                  TotaisFazendas[a].MicrorregiaoBrutaNuaSuperiorSaca.ToString(),
                                  TotaisFazendas[a].MicrorregiaoCurrigidaCultivadaInferiorSaca.ToString(),
                                  TotaisFazendas[a].MicrorregiaoCurrigidaCultivadaSuperiorSaca.ToString(),
                                  TotaisFazendas[a].MicrorregiaoNome,
                                  TotaisFazendas[a].NomeCultura,
                                  TotaisFazendas[a].ValorParticipacao.ToString(),
                                  TotaisFazendas[a].ValorSaca.ToString(),
                                  TotaisFazendas[a].ValorTerraNua.ToString(),
                                  TotaisFazendas[a].TotalBenfeitoriaChecked.ToString(),
                                  TotaisFazendas[a].TotalValorBenfeitoriaChecked.ToString(),
                                  TotaisFazendas[a].ValorParticipacaoBenfeitoria.ToString(),
                                  TotaisFazendas[a].TotaisSemovente.ToString(),
                                  TotaisFazendas[a].TotalArrendado.ToString(),
                                  string.Empty

                           );

                        }

                        #endregion

                        #region Dados das Benfeitorias Arrendadas
                        if (Benfeitorias.Count != 0)
                        {


                            for (int a = 0; a < Benfeitorias.Count; a++)
                            {

                                CadastraItemLimiteCredito(

                                      Benfeitorias[a].ID,
                                      "Benfeitoria",
                                      Selecionados.IDSafra,
                                      hash,
                                      "FazendaArrendada",
                                      tempFazendaArrendada,
                                      Benfeitorias[a].BenfeitoriaArrendado.ToString(),
                                      Benfeitorias[a].BenfeitoriaQuantidade.ToString(),
                                      Benfeitorias[a].BenfeitoriaEspecificacao,
                                      Benfeitorias[a].BenfeitoriaCaracteristicas,
                                      Benfeitorias[a].BenfeitoriaAno,
                                      Benfeitorias[a].BenfeitoriaEstadoConservacao,
                                      Benfeitorias[a].BenfeitoriaValor.ToString(),
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty

                               );

                            }
                        }
                        #endregion
                        
                        #region Dados das Terra/Solos Arrendadas
                        if (TerrasSolos.Count != 0)
                        {
                            for (int a = 0; a < TerrasSolos.Count; a++)
                            {

                                CadastraItemLimiteCredito(

                                      TerrasSolos[a].IDSOLO,
                                      "TerraSolo",
                                      Selecionados.IDSafra,
                                      hash,
                                      "FazendaArrendada",
                                      tempFazendaArrendada,
                                      TerrasSolos[a].tipo,
                                      TerrasSolos[a].TerraSoloArea.ToString(),
                                      TerrasSolos[a].TerraSoloCaracteristicas,
                                      TerrasSolos[a].TerraSoloClasse.ToString(),
                                      TerrasSolos[a].TerraSoloSacas.ToString(),
                                      TerrasSolos[a].ValorUnitario.ToString(),
                                      TerrasSolos[a].ValorTotal.ToString(),
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty

                               );

                            }
                        }

                        #endregion

                        #region Dados dos Semoventes Arrendados
                        if (TerrasSolos.Count != 0)
                        {
                            for (int a = 0; a < Semoventes.Count; a++)
                            {

                                CadastraItemLimiteCredito(

                                      Semoventes[a].ID,
                                      "Semovente",
                                      Selecionados.IDSafra,
                                      hash,
                                      "Fazenda",
                                      tempFazendaArrendada,
                                      Semoventes[a].SemoventeEspecificacao,
                                      Semoventes[a].SemoventeUA.ToString(),
                                      Semoventes[a].SemoventeNumeroUA.ToString(),
                                      Semoventes[a].SemoventeNumeroCabecas.ToString(),
                                      Semoventes[a].SemoventeCaracteristicas,
                                      Semoventes[a].SemoventeValorUnitario.ToString(),
                                      (Semoventes[a].SemoventeValorUnitario * Semoventes[a].SemoventeNumeroCabecas).ToString(),
                                      Semoventes[a].SemoventeCredor,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty,
                                      string.Empty

                               );

                            }
                        }

                        #endregion
                       

                    }
                }

                for (int i = 0; i < RelacaoPropriedades.Count; i++)
                {

                    int tempFazenda = (int)RelacaoPropriedades[i].ID;

                    List<CadastroFazenda> Fazendas = (from CadastroFazenda in db.CadastroFazenda select CadastroFazenda).Where(s => s.ID == tempFazenda).ToList();
                    List<FazendaTotals> TotaisFazendas = (from FazendaTotals in db.FazendaTotals select FazendaTotals).Where(s => s.ID == tempFazenda && s.RelacaoUsuarioID == UsuarioID).ToList();
                    List<CadastroBenfeitoria> Benfeitorias = (from CadastroBenfeitoria in db.CadastroBenfeitoria select CadastroBenfeitoria).Where(s => s.BenfeitoriaFazenda == tempFazenda && s.BenfeitoriaAtiva == true && s.BenfeitoriaUsuario == UsuarioID).ToList();
                    List<TerraSoloFazenda> TerrasSolos = (from TerraSoloFazenda in db.TerraSoloFazenda select TerraSoloFazenda).Where(s => s.FazendaID == tempFazenda && s.TerraSoloAtiva == true && s.TerraSoloUsuario == UsuarioID).ToList();
                    List<CadastroSemovente> Semoventes = (from CadastroSemovente in db.CadastroSemovente select CadastroSemovente).Where(s => s.SemoventeFazendaID == tempFazenda && s.SemoventeUsuarioID == UsuarioID).ToList();
                    
                    
                    
                    List<UsuariosFazenda> UsuariosFazendas = (from UsuariosFazenda in db.UsuariosFazenda select UsuariosFazenda).Where(s => s.RelacaoFazendaID == tempFazenda).ToList();



                    if (TerrasSolos.Count() == 0)
                    {
                        Session["mensagemErro"] = Session["mensagemErro"] + "<h5>Não existem Terras/solo para as Fazendas</h5>";
                        erro = 1;
                    }








                    //lISTAS DE DADDOS DO LIMITE

                    #region Dados das Fazendas

                    for (int a = 0; a < Fazendas.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              Fazendas[a].ID,
                              "Fazenda",
                              Selecionados.IDSafra,
                              hash,
                              "Fazenda",
                              tempFazenda,
                              Fazendas[a].FazendaNome,                                  //Campo1
                              Fazendas[a].FazendaMatricula,                             //Campo2
                              Fazendas[a].FazendaMatriculaCRI,                          //Campo3
                              Fazendas[a].FazendaCodReceitaFederal,                     //Campo4
                              Fazendas[a].FazendaCodigoINCRA,                           //Campo5
                              Fazendas[a].FazendaTitulosDominio,                        //Campo6
                              Fazendas[a].FazendaTipoPropriedade,                       //Campo7
                              Fazendas[a].FazendaOnusGravames,                          //Campo8
                              Fazendas[a].FazendaMunicipio,                             //Campo9
                              Fazendas[a].FazendaRoteiroAcesso,                         //Campo10
                              Fazendas[a].FazendaConfrontacoesNorte,                    //Campo11
                              Fazendas[a].FazendaConfrontacoesSul,                      //Campo12
                              Fazendas[a].FazendaConfrontacoesLeste,                    //Campo13
                              Fazendas[a].FazendaConfrontacoesOeste,                    //Campo14
                              string.Empty,                                             //Campo15
                              string.Empty,                                             //Campo16
                              string.Empty,                                             //Campo17
                              string.Empty,                                             //Campo18
                              string.Empty,                                             //Campo19
                              string.Empty,                                             //Campo20
                              string.Empty,                                             //Campo21
                              string.Empty,                                             //Campo22
                              string.Empty,                                             //Campo23
                              string.Empty,                                             //Campo24
                              string.Empty                                              //Campo25

                       );

                    }

                    #endregion

                    #region Totais das Fazendas

                    for (int a = 0; a < TotaisFazendas.Count; a++)
                    {

                        CadastraItemLimiteCredito(

                              TotaisFazendas[a].ID,
                              "Totais",
                              Selecionados.IDSafra,
                              hash,
                              "Fazenda",
                              tempFazenda,



                              TotaisFazendas[a].FazendaNome,
                              TotaisFazendas[a].FazendaBeneficioSoloSaca.ToString(),
                              TotaisFazendas[a].FazendaBeneficioSoloValorUnitario.ToString(),
                              TotaisFazendas[a].ValorTotal.ToString(),
                              TotaisFazendas[a].AreaTotal.ToString(),
                              TotaisFazendas[a].ValorParticipacao.ToString(),
                              TotaisFazendas[a].BeneficioSolo.ToString(),
                              TotaisFazendas[a].AreaCultivada.ToString(),
                              TotaisFazendas[a].ValorTerraNua.ToString(),
                              TotaisFazendas[a].FazendaParticipacao.ToString(),
                              TotaisFazendas[a].MicrorregiaoBrutaNuaInferiorSaca.ToString(),
                              TotaisFazendas[a].MicrorregiaoBrutaNuaSuperiorSaca.ToString(),
                              TotaisFazendas[a].MicrorregiaoCurrigidaCultivadaInferiorSaca.ToString(),
                              TotaisFazendas[a].MicrorregiaoCurrigidaCultivadaSuperiorSaca.ToString(),
                              TotaisFazendas[a].MicrorregiaoNome,
                              TotaisFazendas[a].NomeCultura,
                              TotaisFazendas[a].ValorParticipacao.ToString(),
                              TotaisFazendas[a].ValorSaca.ToString(),
                              TotaisFazendas[a].ValorTerraNua.ToString(),
                              TotaisFazendas[a].TotalBenfeitoriaChecked.ToString(),
                              TotaisFazendas[a].TotalValorBenfeitoriaChecked.ToString(),
                              TotaisFazendas[a].ValorParticipacaoBenfeitoria.ToString(),
                              string.Empty,
                              string.Empty,
                              string.Empty

                       );

                    }

                    #endregion

                    #region Demais Usuários das Fazendas

                    for (int a = 0; a < UsuariosFazendas.Count; a++)
                    {
                        try
                        {

                            CadastraItemLimiteCredito(

                                         UsuariosFazendas[a].ID,
                                         "Usuarios",
                                         Selecionados.IDSafra,
                                         hash,
                                         "Fazenda",
                                         tempFazenda,
                                         UsuariosFazendas[a].Nome,
                                         UsuariosFazendas[a].DataNascimento,
                                         UsuariosFazendas[a].Naturalidade,
                                         UsuariosFazendas[a].RendaMensal,
                                         UsuariosFazendas[a].RG,
                                         UsuariosFazendas[a].DataExpedicao,
                                         UsuariosFazendas[a].CPF,
                                         UsuariosFazendas[a].Telefone1,
                                         UsuariosFazendas[a].Telefone2,
                                         UsuariosFazendas[a].Celular1,
                                         UsuariosFazendas[a].Celular2,
                                         UsuariosFazendas[a].Endereco,
                                         UsuariosFazendas[a].Cidade,
                                         UsuariosFazendas[a].Estado,
                                         UsuariosFazendas[a].CEP,
                                         UsuariosFazendas[a].RelacaoTitulo.ToString(),
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty,
                                         string.Empty

                                  );



                        }
                        catch (Exception)
                        {


                        }
                    }

                    #endregion

                    #region Dados das Benfeitorias
                    if (Benfeitorias.Count != 0)
                    {


                        for (int a = 0; a < Benfeitorias.Count; a++)
                        {

                            CadastraItemLimiteCredito(

                                  Benfeitorias[a].ID,
                                  "Benfeitoria",
                                  Selecionados.IDSafra,
                                  hash,
                                  "Fazenda",
                                  tempFazenda,
                                  Benfeitorias[a].BenfeitoriaArrendado.ToString(),
                                  Benfeitorias[a].BenfeitoriaQuantidade.ToString(),
                                  Benfeitorias[a].BenfeitoriaEspecificacao,
                                  Benfeitorias[a].BenfeitoriaCaracteristicas,
                                  Benfeitorias[a].BenfeitoriaAno,
                                  Benfeitorias[a].BenfeitoriaEstadoConservacao,
                                  Benfeitorias[a].BenfeitoriaValor.ToString(),
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                              string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty

                           );

                        }
                    }
                    #endregion

                    #region Dados das Terra/Solos
                    if (TerrasSolos.Count != 0)
                    {
                        for (int a = 0; a < TerrasSolos.Count; a++)
                        {

                            CadastraItemLimiteCredito(

                                  TerrasSolos[a].IDSOLO,
                                  "TerraSolo",
                                  Selecionados.IDSafra,
                                  hash,
                                  "Fazenda",
                                  tempFazenda,
                                  TerrasSolos[a].tipo,
                                  TerrasSolos[a].TerraSoloArea.ToString(),
                                  TerrasSolos[a].TerraSoloCaracteristicas,
                                  TerrasSolos[a].TerraSoloClasse.ToString(),
                                  TerrasSolos[a].TerraSoloSacas.ToString(),
                                  TerrasSolos[a].ValorUnitario.ToString(),
                                  TerrasSolos[a].ValorTotal.ToString(),
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty

                           );

                        }
                    }

                    #endregion

                    #region Dados dos Semoventes
                    if (TerrasSolos.Count != 0)
                    {
                        for (int a = 0; a < Semoventes.Count; a++)
                        {

                            CadastraItemLimiteCredito(

                                  Semoventes[a].ID,
                                  "Semovente",
                                  Selecionados.IDSafra,
                                  hash,
                                  "Fazenda",
                                  tempFazenda,
                                  Semoventes[a].SemoventeEspecificacao,
                                  Semoventes[a].SemoventeUA.ToString(),
                                  Semoventes[a].SemoventeNumeroUA.ToString(),
                                  Semoventes[a].SemoventeNumeroCabecas.ToString(),
                                  Semoventes[a].SemoventeCaracteristicas,
                                  Semoventes[a].SemoventeValorUnitario.ToString(),
                                  (Semoventes[a].SemoventeValorUnitario * Semoventes[a].SemoventeNumeroCabecas).ToString(),
                                  Semoventes[a].SemoventeCredor,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty,
                                  string.Empty

                           );

                        }
                    }

                    #endregion


                  






                }








                if (erro == 1)
                {
                    return RedirectToAction("Index");
                }
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Index");
            }



        }

        [Authorize]
        public ActionResult Print(string ID = "")
        {

            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("pt-BR");
            System.Threading.Thread.CurrentThread.CurrentCulture = ci;

            List<LimiteCreditos> HashPrinted = (from LimiteCreditos in db.LimiteCreditos select LimiteCreditos).Where(s => s.EntidadeHash == ID).ToList();

            if (HashPrinted == null)
            {
                return HttpNotFound();
            }


            ViewBag.Usuario = HashPrinted.Where(s => s.EntidadeTipo == "Usuario" && s.EntidadeReferencia == "Proprietario").ToList();
            ViewBag.Cliente = HashPrinted.Where(s => s.EntidadeTipo == "Cliente").ToList();
            ViewBag.Conjuge = HashPrinted.Where(s => s.EntidadeTipo == "Conjuge").ToList();
            ViewBag.Safras = HashPrinted.Where(s => s.EntidadeTipo == "Safras").ToList();
            ViewBag.SafrasDistribuidas = HashPrinted.Where(s => s.EntidadeTipo == "SafrasDistribuidas").ToList();
            ViewBag.Questionario = HashPrinted.Where(s => s.EntidadeTipo == "Questionario").ToList();




            //Porra pesada

            ViewBag.FazendasArrendadas = HashPrinted.Where(s => s.EntidadeTipo == "Fazenda" && s.EntidadeReferencia == "FazendaArrendada").ToList();
            ViewBag.TotaisFazendasArrendadas = HashPrinted.Where(s => s.EntidadeTipo == "Totais" && s.EntidadeReferencia == "FazendaArrendada").ToList();


            ViewBag.Fazendas = HashPrinted.Where(s => s.EntidadeTipo == "Fazenda" && s.EntidadeReferencia == "Fazenda").ToList();




            ViewBag.TotaisFazendas = HashPrinted.Where(s => s.EntidadeTipo == "Totais" && s.EntidadeReferencia == "Fazenda").ToList();
            ViewBag.TerrasSolos = HashPrinted.Where(s => s.EntidadeTipo == "TerraSolo").OrderBy(s => s.Campo2).ToList();
            ViewBag.Benfeitorias = HashPrinted.Where(s => s.EntidadeTipo == "Benfeitoria").ToList();
            ViewBag.Semoventes = HashPrinted.Where(s => s.EntidadeTipo == "Semovente").ToList();

            ViewBag.UsuariosSocios = HashPrinted.Where(s => s.EntidadeTipo == "Usuarios" && s.Campo16 == "2").ToList();
            ViewBag.UsuariosAdministradores = HashPrinted.Where(s => s.EntidadeTipo == "Usuarios" && s.Campo16 == "3").ToList();

            ViewBag.Maquinas = HashPrinted.Where(s => s.EntidadeTipo == "Maquina").ToList();
            ViewBag.Veiculos = HashPrinted.Where(s => s.EntidadeTipo == "Veiculo").ToList();
            ViewBag.Implementos = HashPrinted.Where(s => s.EntidadeTipo == "Implemento").ToList();
            ViewBag.BensDireitos = HashPrinted.Where(s => s.EntidadeTipo == "BemDireito").ToList();
            ViewBag.Dividas = HashPrinted.Where(s => s.EntidadeTipo == "Divida").ToList();

            return View();

        }

        //
        // POST: /Cultura/Delete/5

        [HttpPost, ActionName("Delete")]
        [Authorize]
        public ActionResult Delete(string hash)
        {

            List<LimiteCreditos> LCDelete = (from LimiteCreditos in db.LimiteCreditos select LimiteCreditos).Where(s => s.EntidadeHash == hash).ToList();

            for (int i = 0; i < LCDelete.Count(); i++)
            {
                LimiteCreditos LC = db.LimiteCreditos.Find(LCDelete[i].ID);
                db.LimiteCreditos.Remove(LC);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
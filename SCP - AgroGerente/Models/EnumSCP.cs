using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Security;
using System.Web;

namespace SCP___AgroGerente.Models
{



    public class JsonResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public partial class LimiteCreditoRef
    {

        public Nullable<int> IDUsuario { get; set; }
        public int[] IDFazenda { get; set; }
        public string IDSafra { get; set; }
      
    }

    public class UserRef
    {

        public static int IDUsuario
        {
            get { return HttpContext.Current.Session["UserID"] != null ? (int)HttpContext.Current.Session["UserID"] : 0; }
            set { HttpContext.Current.Session["UserID"] = value; }
        }

        public static string NomeUsuario
        {
            get { return HttpContext.Current.Session["UserName"] != null ? (string)HttpContext.Current.Session["UserName"] : ""; }
            set { HttpContext.Current.Session["UserName"] = value; }
        }

        public static string SafraPrevista
        {
            get { return HttpContext.Current.Session["SafraPrevista"] != null ? (string)HttpContext.Current.Session["SafraPrevista"] : ""; }
            set { HttpContext.Current.Session["SafraPrevista"] = value; }
        }


    }


    

    public class EnumSCP
    {


        public static string hashString()
        {
        
            Guid createdHash = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(createdHash.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");
            GuidString = GuidString.Replace("/", "");
            GuidString = GuidString.Replace(".", "");

            return GuidString;
        }
        
        public static IEnumerable<SelectListItem> EnumBit = new[]{

            new SelectListItem{
                Text = "Sim",
                Value="True"
            },
            new SelectListItem{
                Text = "Não",
                Value="False"
            }
          
        };

        public static IEnumerable<SelectListItem> EnumObsGravameSafra = new[]{

            new SelectListItem{
                Text = "-",
                Value="1"
            },
            new SelectListItem{
                Text = "RECURSOS CONTROLADOS",
                Value="2"
            },
            new SelectListItem{
                Text = "RECURSOS PRÓPRIOS",
                Value="3"
            }
          
        };


        public static IEnumerable<SelectListItem> EnumTipoDistribuicaoSafra = new[]{

            new SelectListItem{
                Text = "Proposto BB",
                Value="1"
            },
            new SelectListItem{
                Text = "Demais Áreas",
                Value="2"
            }
          
        };

        public static IEnumerable<SelectListItem> EnumTipoSistemaPlantio = new[]{

            new SelectListItem{
                Text = "CONVENCIONAL/SEQUEIRO",
                Value="1"
            },
            new SelectListItem{
                Text = "DIRETO/SEQUEIRO",
                Value="2"
            },
            new SelectListItem{
                Text = "CONVENCIONAL/IRRIGADO",
                Value="3"
            },
            new SelectListItem{
                Text = "DIRETO/IRRIGADO",
                Value="4"
            }
          
        };
        public static IEnumerable<SelectListItem> EnumTipoCultura()
        {
            using (SCPEntities db = new SCPEntities())
            {
                var query = (from Cultura in db.Cultura
                             where Cultura.UsarCultura ==true
                             select Cultura);
                return query.AsEnumerable()
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.NomeCultura,
                                    Value = x.ID.ToString()
                                }).ToList();

            }


        }

        public static IEnumerable<SelectListItem> EnumTipoTerraSolo()
        {
            using (SCPEntities db = new SCPEntities())
            {
                var query = (from TerraSolo in db.TerraSolo
                             where TerraSolo.ativo == true
                             select TerraSolo);
                return query.AsEnumerable()
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.tipo,
                                    Value = x.ID.ToString()
                                }).ToList();

            }


        }

        
            



        public static IEnumerable<SelectListItem> EnumEstadoCivil = new List<SelectListItem>{
            
            new SelectListItem{
                Value  = "Solteiro(a)",
                Text = "Solteiro(a)"
            },
            new SelectListItem {
                Value  = "Casado(a)",
                Text = "Casado(a)"
            },
            new SelectListItem{
                Value  = "Divorciado(a)",
                Text = "Divorciado(a)"
            },
            new SelectListItem {
                Value = "Viuvo(a)",
                Text = "Viuvo(a)"
            }
        
        };

        public static IEnumerable<SelectListItem> EnumNivelPosse = new []{
            
            new SelectListItem {Text = "Proprietário", Value="1"},
           new SelectListItem {Text = "Arredandor", Value="2"},
            new SelectListItem {Text = "Administrador da Fazenda", Value="3"}
        
        };


        public static IEnumerable<SelectListItem> EnumAssociacaoUsuario = new[]{
            
            new SelectListItem {Text = "Socio", Value="1"}
          
        
        };

        public static IEnumerable<SelectListItem> vSafra()
        {
            using (SCPEntities db = new SCPEntities())
            {

                var query = (from CadastroSafra in db.CadastroSafra select CadastroSafra);

                return query.AsEnumerable().Select(
                    x => new SelectListItem
                    {
                        Text = x.NomeSafra,
                        Value = x.ID.ToString()
                    }).ToList();


            }

        
        }

        
        public static IEnumerable<SelectListItem> vNomeFazenda()
        {
            using (SCPEntities db = new SCPEntities())
            {
                var query = (from CadastroFazenda in db.CadastroFazenda
                             select CadastroFazenda);
                return query.AsEnumerable()
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.FazendaNome,
                                    Value = x.ID.ToString()
                                }).ToList();

            }
           
        
        }

        public static IEnumerable<SelectListItem> vNomeFazendaDistinct(int IDUsuario)
        {
            using (SCPEntities db = new SCPEntities())
            {

                var query = (from FazendaTotals in db.FazendaTotals
                             where (FazendaTotals.RelacaoUsuarioID == IDUsuario)
                             select FazendaTotals);
                
                
                
                
                
                return query.AsEnumerable()
                                .Select(
                                x => new SelectListItem
                                {
                                    Text = x.FazendaNome,
                                    Value = x.ID.ToString()
                                }).ToList();

            }


        }


       


      



    }


}

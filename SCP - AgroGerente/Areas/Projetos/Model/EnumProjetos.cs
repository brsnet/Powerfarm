using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCP___AgroGerente.Areas.Projetos.Model
{

 

    public class EnumProjetos
    {



        //public static IList<string> MyList { get { return myList; } }
        //private static readonly ReadOnlyCollection<string> myList =
        //    new ReadOnlyCollection<string>(new[]
        //{
        //    "Item 1", "Item 2", "Item 3"
        //});


        public static IEnumerable<SelectListItem> EnumMeses = new[]{

            new SelectListItem{
                Text = "JAN",
                Value="1"
            },
            new SelectListItem{
                Text = "FEV",
                Value="2"
            },
            new SelectListItem{
                Text = "MAR",
                Value="3"
            },
            new SelectListItem{
                Text = "ABR",
                Value="4"
            },
            new SelectListItem{
                Text = "MAI",
                Value="5"
            },
            new SelectListItem{
                Text = "JUN",
                Value="6"
            },
            new SelectListItem{
                Text = "JUL",
                Value="7"
            },
            new SelectListItem{
                Text = "AGO",
                Value="8"
            },
            new SelectListItem{
                Text = "SET",
                Value="9"
            },
            new SelectListItem{
                Text = "OUT",
                Value="10"
            },
            new SelectListItem{
                Text = "NOV",
                Value="11"
            },
            new SelectListItem{
                Text = "DEZ",
                Value="12"
            }
           

          
        };



        public static IEnumerable<SelectListItem> EnumTipoEtapa = new[]{

            new SelectListItem{
                Text = "Serviços",
                Value="1"
            },
            new SelectListItem{
                Text = "Insumos",
                Value="2"
            }
          
        };

        public static IEnumerable<SelectListItem> EnumTipoUnidadeTempo = new[]{

            new SelectListItem{
                Text = "H/M",
                Value="1"
            },
             new SelectListItem{
                Text = "Tn",
                Value="2"
            },
             new SelectListItem{
                Text = "L",
                Value="3"
            },
             new SelectListItem{
                Text = "Kg",
                Value="4"
            },
             new SelectListItem{
                Text = "R$",
                Value="5"
            }
            
          
        };

    }
}
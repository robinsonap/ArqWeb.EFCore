using System;
using System.Collections.Generic;
using System.Text;
using BEntidad.BModels_Northwind;

namespace BEntidad.BModels
{
    public class Seguridad
    {
        public string sClave { get; set; }
        public string sValor { get; set; }
        public List<Pagina> lista { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BEntidad.BModels_Northwind;

namespace BEntidad.BModels
{
    public class _TmgrupUsua
    {
        public string Co_grup { get; set; }
        public string No_grup { get; set; }

        //Para agregar 
        public string valores { get; set; }

        //Para el editar
        public List<Pagina> ListaPagina { get; set; }
    }
}
